﻿using MediatR;

namespace EduSubscription.Primitives.Contracts;

/// <summary>
/// Represents a domain event handler.
/// </summary>
/// <typeparam name="TDomainEvent"></typeparam>
public interface IDomainEventHandler<in TDomainEvent> : INotificationHandler<TDomainEvent> where TDomainEvent : IDomainEvent;