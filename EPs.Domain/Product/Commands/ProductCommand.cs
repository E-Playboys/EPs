using EPs.Domain.Core.Commands;
using System;

namespace EPs.Domain.Commands
{
    public abstract class ProductCommand : Command
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
