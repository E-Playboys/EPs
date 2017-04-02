using EPs.Domain.Core.Events;
using System;

namespace EPs.Domain.Events
{
    public class ProductUpdatedEvent : ProductEvent
    {
        public ProductUpdatedEvent(Guid id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
            AggregateId = id;
        }
    }
}
