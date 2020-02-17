﻿using System.Collections.Generic;
using System.Text;

namespace Lrn.Domain.Entities
{
    public class Content : BaseEntity
    {
        public string Title { get; set; }
        public string Data { get; set; }
        public ContentType ContentType { get; set; }
        public string Thumbnail { get; set; }
        public string Idiom { get; set; }
        public string Transcript { get; set; }
    }
}