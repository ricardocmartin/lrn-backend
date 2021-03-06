﻿using Lrn.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lrn.Domain.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Insert(T obj);

        void Update(T obj);

        void Remove<T>(int id);

        T Select(int id);

        IList<T> SelectAll();
    }
}
