﻿using Domain.Entities;
using System.Linq.Expressions;

namespace Application.Repositories;

public interface IReadRepository<T> where T : BaseEntity
{
    IQueryable<T>? GetAll(bool tracking = true);
    IQueryable<T>? GetWhere(Expression<Func<T, bool>> method, bool tracking = true);
    Task<T>? GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true);
    Task<T>? GetByIdAsync(string id, bool tracking = true);
}