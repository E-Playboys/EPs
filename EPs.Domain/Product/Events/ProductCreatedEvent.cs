using EPs.Domain.Core.Events;
using System;

namespace EPs.Domain.Events
{
    public class ProductCreatedEvent : ProductEvent
    {
        public ProductCreatedEvent(Guid id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
            AggregateId = id;
        }
    }
}
