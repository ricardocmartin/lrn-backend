using Lrn.Domain.Entities;
using Lrn.Domain.Interfaces;
using Lrn.Infra.Data.Context;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Text;
using Dapper;
using DapperExtensions;
using Lrn.Infra.Data.Mapping;

namespace Lrn.Infra.Data.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        public BaseRepository()
        {
            DapperExtensions.DapperExtensions.SetMappingAssemblies(new[] { typeof(CourseClassMapper).Assembly });
            DapperExtensions.DapperExtensions.SetMappingAssemblies(new[] { typeof(CourseTopicClassMapper).Assembly });
            DapperExtensions.DapperExtensions.SetMappingAssemblies(new[] { typeof(ContentVoteClassMapper).Assembly });
            DapperExtensions.DapperExtensions.SetMappingAssemblies(new[] { typeof(ContentClassMapper).Assembly });
            
            DapperExtensions.DapperExtensions.SqlDialect = new DapperExtensions.Sql.MySqlDialect();
        }

        private string GetConnectionString() {
            return "Server=50.116.86.24;Port=3306;Database=telef840_lrn;Uid=telef840_lrn;Pwd=zStEPTrVR_bh";
            //return "Server=localhost;Port=3306;Database=lrn;Uid=root;Pwd=Techno#1";
            //TODO:
            //return ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
        }


        public void Insert(T obj)
        {
            using (IDbConnection con = new MySqlConnection(GetConnectionString())) {
                con.Insert<T>(obj);
            }
        }

        public void Update(T obj){
            using (IDbConnection con = new MySqlConnection(GetConnectionString()))
            {
                con.Update<T>(obj);
            }
        }

        public void Delete(T obj)
        {
            using (IDbConnection con = new MySqlConnection(GetConnectionString()))
            {
                con.Delete<T>(obj);
            }
        }

        public IList<T> Select()
        {
            using (IDbConnection con = new MySqlConnection(GetConnectionString())){
                return con.GetList<T>().AsList();
            }
        }

        public T Select(int id)
        {
            using (IDbConnection con = new MySqlConnection(GetConnectionString())){
                return con.Get<T>(id);
            }
        }

        public void Remove<T1>(int id)
        {
            throw new NotImplementedException();
        }

        public IList<T> SelectAll()
        {
            throw new NotImplementedException();
        }
    }
}
