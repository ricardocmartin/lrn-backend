using DapperExtensions.Mapper;
using Lrn.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lrn.Infra.Data.Mapping
{
    class CourseClassMapper : ClassMapper<Course>
    {
        public CourseClassMapper()
        {
            Table("tb_course");
            Map(x => x.Id).Column("ID").Key(KeyType.Identity);
            Map(x => x.Name).Column("Name");
            Map(x => x.Description).Column("Description");
            Map(x => x.Thumbnail).Column("Thumbnail");
            Map(x => x.Idiom).Column("Idiom");
            Map(x => x.Created).Column("CreationDate");
            Map(x => x.Modificated).Column("ModificationDate");
        }
    }
}
