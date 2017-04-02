using EPs.Domain.Core.Events;

namespace EPs.Domain.Events
{
    public class ProductEventHandler : IHandler<ProductCreatedEvent>, IHandler<ProductUpdatedEvent>, IHandler<ProductDeletedEvent>
    {
        public void Handle(ProductCreatedEvent message)
        {
        }

        public void Handle(ProductUpdatedEvent message)
        {
        }

        public void Handle(ProductDeletedEvent message)
        {
        }
    }
}
