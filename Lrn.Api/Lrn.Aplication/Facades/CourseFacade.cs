using GraphQL;
using GraphQL.Types;
using Lrn.Aplication.DTOs;
using Lrn.Aplication.Interfaces;
using Lrn.Aplication.ModelQuery;
using Lrn.Domain.Entities;
using Lrn.Service.Services;
using Lrn.Service.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lrn.Aplication.Facades
{
    public class CourseFacade : ICourseFacade
    {
        private BaseService<Course> service = new BaseService<Course>();
        private BaseService<CourseTopic> courseTopicService = new BaseService<CourseTopic>();

        public Course Get(int Id)
        {
            return service.Get(Id);
        }

        public CourseDTO GetFull(int Id)
        {
            var course = service.Get(Id);
            return new CourseDTO(course){
                CourseTopics = courseTopicService.Get().Where(x => x.CourseID == Id).ToList()
            };
        }

        public IList<Course> ListHome()
        {
            return service.Get().OrderByDescending(x => x.Created).Take(9).ToList();
        }

        public IList<Course> List()
        {
            return service.Get();
        }

        public IList<Course> ListMostVisualized()
        {
            return service.Get();
        }

        public void Update(Course obj)
        {
            service.Put<CourseValidator>(obj);
        }

        public async Task<ExecutionResult> FindAsync(GraphQLQuery query)
        {
            var schema = new Schema { Query = new CourseQuery(this.List()) };

            var result = await new DocumentExecuter().ExecuteAsync(_ =>
            {
                _.Schema = schema;
                _.Query = query.Query;
            }).ConfigureAwait(false);

            return result;
        }

        public void Insert(Course obj)
        {
            service.Post<CourseValidator>(obj);
        }
        public void Delete(int _Id)
        {
            service.Delete(new Course { Id = _Id });
        }


    }
}
