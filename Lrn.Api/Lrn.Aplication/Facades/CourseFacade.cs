using Lrn.Aplication.Interfaces;
using Lrn.Domain.Entities;
using Lrn.Service.Services;
using Lrn.Service.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lrn.Aplication.Facades
{
    public class CourseFacade : ICourseFacade
    {
        private BaseService<Course> service = new BaseService<Course>();

        public Course Get(int Id)
        {
            return service.Get(Id);
        }

        public IList<Course> List()
        {
            return service.Get();
        }

        public void Update(Course obj)
        {
            service.Put<CourseValidator>(obj);
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
