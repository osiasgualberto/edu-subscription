﻿using EduSubscription.Primitives;

namespace EduSubscription.Repositories.Contracts;

public interface IReadableAllRepository<TEntity> where TEntity : Entity
{
    /// <summary>
    /// Reads all entities from the repository.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<List<TEntity>> ReadAll();
}