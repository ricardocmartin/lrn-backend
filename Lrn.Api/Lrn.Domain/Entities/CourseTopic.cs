using System;

namespace Lrn.Domain.Entities
{
    public class CourseTopic : BaseEntity { 
        public string Title { get; set; }
        public string Resume { get; set; }
        public string KeyWords { get; set; }
        public string Thumbnail { get; set; }
        public string Idiom { get; set; }
        public int Sequence { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modificated { get; set; }
    }
}
