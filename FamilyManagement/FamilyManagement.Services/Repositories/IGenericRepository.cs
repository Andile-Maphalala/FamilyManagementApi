﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FamilyManagement.Services.Repositories
{
    public interface IGenericRepository
    {
        IQueryable<T> Set<T>() where T : class;
        Task InsertAsync<T>(T entity, CancellationToken cancellationToken) where T : class;
        Task UpdateAsync<T>(T entity, CancellationToken cancellationToken) where T : class;
        Task DeleteAsync<T>(Expression<Func<T, bool>> findPredicate, CancellationToken cancellationToken) where T : class;
    }
}
