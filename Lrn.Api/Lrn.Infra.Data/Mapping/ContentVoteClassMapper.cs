using DapperExtensions.Mapper;
using Lrn.Domain.Entities;

namespace Lrn.Infra.Data.Mapping
{
    class ContentVoteClassMapper : ClassMapper<ContentVote>
    {
        public ContentVoteClassMapper()
        {
            Table("tb_content_vote");
            Map(x => x.Id).Column("ID").Key(KeyType.Identity);
            Map(x => x.ContentID).Column("ContentID");
            Map(x => x.CourseTopicID).Column("CourseTopicID");
            Map(x => x.Created).Column("CreationDate");
        }
    }
}
