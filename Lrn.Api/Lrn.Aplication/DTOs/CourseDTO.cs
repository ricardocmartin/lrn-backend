using Lrn.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lrn.Aplication.DTOs
{
    public class CourseDTO : Course
    {
        public List<CourseTopic> CourseTopics { get; set; }
    }
}
