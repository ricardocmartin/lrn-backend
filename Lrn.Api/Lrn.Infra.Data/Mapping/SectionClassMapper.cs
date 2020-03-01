using DapperExtensions.Mapper;
using Lrn.Domain.Entities;

namespace Lrn.Infra.Data.Mapping
{
    class SectionClassMapper : ClassMapper<Section>
    {
        public SectionClassMapper()
        {
            Table("tb_section");
            Map(x => x.Id).Column("ID").Key(KeyType.Identity);
            Map(x => x.Name).Column("Name");
            Map(x => x.Created).Column("CreationDate");
            Map(x => x.Modificated).Column("ModificationDate");
        }
    }
}
