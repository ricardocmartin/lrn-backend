using Lrn.Aplication.Interfaces;
using Lrn.Domain.Entities;
using Lrn.Service.Services;
using Lrn.Service.Validators;
using System.Collections.Generic;

namespace Lrn.Aplication.Facades
{
    public class CourseTopicFacade : ICourseTopicFacade
    {
        private BaseService<CourseTopic> service = new BaseService<CourseTopic>();

        public CourseTopic Get(int Id)
        {
            return service.Get(Id);
        }

        public IList<CourseTopic> List()
        {
            return service.Get();
        }

        public void Update(CourseTopic obj)
        {
            service.Put<CourseTopicValidator>(obj);
        }

        public void Insert(CourseTopic obj)
        {
            service.Post<CourseTopicValidator>(obj);
        }
        public void Delete(int _Id)
        {
            service.Delete(new CourseTopic { Id = _Id });
        }


    }
}
