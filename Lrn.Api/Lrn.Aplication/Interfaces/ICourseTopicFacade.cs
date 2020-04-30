using System.Collections.Generic;
using Lrn.Domain.Entities;

namespace Lrn.Aplication.Interfaces
{
    public interface ICourseTopicFacade
    {
        void Delete(int _Id);
        CourseTopic Get(int Id);
        void Insert(CourseTopic obj);
        IList<CourseTopic> List();
        void Update(CourseTopic obj);
        void GenerateContent();
        void GenerateContent(int DaysOfSet);
    }
}