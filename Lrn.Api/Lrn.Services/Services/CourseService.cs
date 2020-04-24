using Lrn.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lrn.Service.Services
{

    public class CourseService : BaseService<Course>
    {
        private struct CourseCount{
            int CourseID;
            int Count;
        }

        private readonly BaseService<CourseView> couseViewService;

        public CourseService(BaseService<CourseView> couseViewService)
        {
            this.couseViewService = couseViewService;
        }

        public List<Course> GetMostView(int count) {
            var viewCounter = 
                couseViewService.Get().GroupBy(view => view.CourseID)
                .Select(group => new {
                    CourseID = group.Key,
                    Count = group.Count()
                })
                .OrderBy(x => x.Count).Take(count);

            var CoursesResult = this.Get().Join(viewCounter,
                Course => Course.Id,
                viewCounter => viewCounter.CourseID,
                (Course, viewCounter) => new { Course = Course, viewCounter = viewCounter })
                .Where(c => c.Course.Id == c.viewCounter.CourseID);

            List<Course> courses = new List<Course>();
            Course course;

            foreach (var c in CoursesResult) {
                course = c.Course;
                course.ViewCount = c.viewCounter.Count;
                courses.Add(course);
            }

            return courses;

            //https://stackoverflow.com/questions/2767709/join-where-with-linq-and-lambda

        }
    } 
}
