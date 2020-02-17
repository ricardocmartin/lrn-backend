using System;

namespace Lrn.Domain.Entities
{
    public class ContentVote : BaseEntity { 
        public int ContentID { get; set; }
        public int CourseTopicID { get; set; }
        public DateTime Created { get; set; }
        public bool Ok { get; set; }
    }
}
