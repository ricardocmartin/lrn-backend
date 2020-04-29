using DapperExtensions.Mapper;
using Lrn.Domain.Entities;

namespace Lrn.Infra.Data.Mapping
{
    class CourseTopicClassMapper : ClassMapper<CourseTopic>
    {
        public CourseTopicClassMapper()
        {
            Table("tb_course_topic");
            Map(x => x.Id).Column("ID").Key(KeyType.Identity);
            Map(x => x.Title).Column("Title");
            Map(x => x.Resume).Column("Resume");
            Map(x => x.KeyWords).Column("KeyWords");
            Map(x => x.Thumbnail).Column("Thumbnail");
            Map(x => x.Idiom).Column("Idiom");
            Map(x => x.Sequence).Column("Sequence");
            Map(x => x.SectionID).Column("SectionID");
            Map(x => x.Created).Column("CreationDate");
            Map(x => x.Modificated).Column("ModificationDate");
            Map(x => x.CourseID).Column("CourseID");
        }
    }
}
