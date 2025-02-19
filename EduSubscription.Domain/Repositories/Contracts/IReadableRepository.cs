﻿using EduSubscription.Primitives;

namespace EduSubscription.Repositories.Contracts;

public interface IReadableRepository<TEntity> where TEntity : Entity
{
    /// <summary>
    /// Reads an entity by ID from the data repository.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<TEntity?> ReadById(Guid id);
}