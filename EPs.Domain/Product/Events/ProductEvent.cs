using EPs.Domain.Core.Events;
using System;

namespace EPs.Domain.Events
{
    public abstract class ProductEvent : Event
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
