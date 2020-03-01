using System;

namespace Lrn.Domain.Entities
{
    public class Section : BaseEntity
    {
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modificated { get; set; }
    }
}
