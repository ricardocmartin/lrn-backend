using GraphQL.Types;
using Lrn.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lrn.Aplication.GraphQLType
{
    public class CourseType : ObjectGraphType<Course>
    {
        public CourseType()
        {
            Name = "Course";

            Field(x => x.Name).Description("Nome do curso");
            Field(x => x.Created).Description("Data da criação do curso");
            Field(x => x.Description).Description("Descrição do curso");
            Field(x => x.Id).Description("Id do curso");
            Field(x => x.Idiom).Description("Idioma do curso");
            Field(x => x.Modificated).Description("Data de ultima modicicação do curso");
            Field(x => x.Thumbnail).Description("Thumbnail do curso");
            
        }
    }
}
