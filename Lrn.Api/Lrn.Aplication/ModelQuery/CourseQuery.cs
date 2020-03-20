using GraphQL.Types;
using Lrn.Aplication.GraphQLType;
using Lrn.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lrn.Aplication.ModelQuery
{
    public class CourseQuery : ObjectGraphType
    {
        public CourseQuery(IEnumerable<Course> courses)
        {
            Field<ListGraphType<CourseType>>("Course",
                arguments: new QueryArguments(
                    new QueryArgument<StringGraphType> { Name = "name" },
                    new QueryArgument<StringGraphType> { Name = "description" }),
                resolve: context => {
                    var name = context.GetArgument<string>("name");
                    var description = context.GetArgument<string>("description");
                    var id = context.GetArgument<string>("id");

                    if (name != null)
                        courses = courses.Where(x => x.Name.Contains(name));

                    if (description != null)
                        courses = courses.Where(x => x.Description.Contains(description));

                    return courses;
                });
        }
    }
}
