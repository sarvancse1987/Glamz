﻿using Glamz.Domain;
using MediatR;

namespace Glamz.Infrastructure.Events
{
    /// <summary>
    /// A container for entities that have been inserted.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EntityInserted<T> : INotification where T : ParentEntity
    {
        public EntityInserted(T entity)
        {
            Entity = entity;
        }

        public T Entity { get; private set; }
    }

}
