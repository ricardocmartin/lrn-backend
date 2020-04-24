using System;

namespace Lrn.Domain.Entities
{
    public class CourseView : BaseEntity
    {
        public int CourseID { get; set; }
        public DateTime Created { get; set; }
    }
}
