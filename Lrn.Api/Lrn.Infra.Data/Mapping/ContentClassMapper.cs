using DapperExtensions.Mapper;
using Lrn.Domain.Entities;

namespace Lrn.Infra.Data.Mapping
{
    class ContentClassMapper : ClassMapper<Content>
    {
        public ContentClassMapper()
        {
            Table("tb_content");
            Map(x => x.Id).Column("ID").Key(KeyType.Identity);
            Map(x => x.Title).Column("Name");
            Map(x => x.Data).Column("Data");
            Map(x => x.Thumbnail).Column("Thumbnail");
            Map(x => x.Idiom).Column("Idiom");
            Map(x => x.ContentType).Column("ContentType");
            Map(x => x.Transcript).Column("Transcript");
            Map(x => x.Created).Column("CreationDate");
            Map(x => x.Modificated).Column("ModificationDate");
        }
    }
}
