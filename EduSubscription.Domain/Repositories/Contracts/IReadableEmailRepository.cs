﻿using EduSubscription.Primitives;

namespace EduSubscription.Repositories.Contracts;

public interface IReadableEmailRepository<TEntity> where TEntity : Entity
{
    /// <summary>
    /// Reads an entity by e-mail.
    /// </summary>
    /// <param name="email"></param>
    /// <returns></returns>
    public Task<TEntity?> ReadByEmail(string email);
}