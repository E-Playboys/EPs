using EPs.Domain.Core.Events;
using System;

namespace EPs.Domain.Events
{
    public class ProductDeletedEvent : ProductEvent
    {
        public ProductDeletedEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
        }
    }
}
