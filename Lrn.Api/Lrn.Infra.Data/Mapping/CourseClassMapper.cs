﻿using DapperExtensions.Mapper;
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
            Map(x => x.Id).Column("ID").Key(KeyType.Guid);
            Map(x => x.Name).Column("Name");
            Map(x => x.Description).Column("Description");

        }
    }
}
