using Lrn.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lrn.Aplication.DTOs
{
    public class CourseDTO : Course
    {
        public CourseDTO(Course c){
            this.Created = c.Created;
            this.Description = c.Description;
            this.Id = c.Id;
            this.Idiom = c.Idiom;
            this.Modificated = c.Modificated;
            this.Name = c.Name;
            this.Thumbnail = c.Thumbnail;
            this.ViewCount = c.ViewCount;
        }

        public List<CourseTopic> CourseTopics { get; set; }
    }
}
