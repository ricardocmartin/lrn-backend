using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lrn.Aplication.Facades;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore;
using DocumentFormat.OpenXml.EMMA;
using Lrn.Aplication.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using Lrn.Infra.CrossCutting;
using Hangfire;
using Hangfire.MySql;

namespace Lrn.Api
{
    public class Startup
    {
        private string MySqlConnection = "Server=50.116.86.24;Port=3306;Database=telef840_lrn;Uid=telef840_lrn;Pwd=zStEPTrVR_bh;Allow User Variables=True";


        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ICourseFacade, CourseFacade>();
            services.AddTransient<ICourseTopicFacade, CourseTopicFacade>();
            services.AddTransient<IContentFacade, ContentFacade>();
            services.AddTransient<IContentVoteFacade, ContentVoteFacade>();
            services.AddTransient<ISectionFacade, SectionFacade>();
            services.AddControllers();
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Values API", Version= "v1"});
            });

            /*
             * HANGFIRE
             */
            services.AddHangfire(configuration => { 
                configuration.UseStorage(new MySqlStorage(MySqlConnection, new MySqlStorageOptions
                {
                    //QueuePollInterval = TimeSpan.FromSeconds(15),
                    //JobExpirationCheckInterval = TimeSpan.FromHours(1),
                    //CountersAggregateInterval = TimeSpan.FromMinutes(5),
                    //PrepareSchemaIfNecessary = true,
                    //DashboardJobListLimit = 50000,
                    //TransactionTimeout = TimeSpan.FromMinutes(1),
                    TablesPrefix = "hf_"
                }));
            });

            /*
             * REDIS
             */
            services.AddDistributedMemoryCache();
            /*
            services.AddDistributedRedisCache(option =>
            {
                option.Configuration = "127.0.0.1";
                option.InstanceName = "master";
            });*/
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IDistributedCache cache)
        {
            app.UseHangfireServer();

            if (env.IsDevelopment()){
                app.UseHangfireDashboard();
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


            /*
             * Swagger
             */
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Values Api V1");
            });

            CacheManager.Configure(cache);


        }
    }
}
