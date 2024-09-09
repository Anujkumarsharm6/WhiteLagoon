﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WhiteLagoon.domain.Entities;

namespace WhiteLagoon.Application.Common.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeproperties = null);
        T Get(Expression<Func<T, bool>>? filter, string? includeproperties = null);
        void Add(T entity);
        bool Any(Expression<Func<T, bool>>filter);
        void Remove(T entity);
       
    }
}
