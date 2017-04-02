using EPs.Domain.Core.Models;
using System;

namespace EPs.Domain.Models
{
    public class Product : Entity
    {
        public Product(Guid id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public string Name { get; set; }
        public string Description { get; set; }
    }
}
