using System.Collections.Generic;
using Lrn.Domain.Entities;

namespace Lrn.Aplication.Interfaces
{
    public interface ICourseFacade
    {
        void Delete(int _Id);
        Course Get(int Id);
        void Insert(Course obj);
        IList<Course> List();
        void Update(Course obj);
    }
}