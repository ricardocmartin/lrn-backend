using System;
using System.Collections.Generic;
using System.Text;

namespace Lrn.Domain.Entities
{
    public class Course : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Thumbnail { get; set; }
        public string Idiom { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modificated { get; set; }
    }
}
