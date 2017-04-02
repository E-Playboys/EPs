using System;
using EPs.Domain.Core;
using EPs.Domain.Core.Commands;
using EPs.Domain.Core.Events;
using EPs.Domain.Core.Interfaces;
using EPs.Domain.Core.Notification;
using EPs.Domain.Repositories;
using EPs.Domain.Models;
using EPs.Domain.Events;

namespace EPs.Domain.Commands
{
    public class ProductCommandHandler : CommandHandler, IHandler<CreateProductCommand>, IHandler<UpdateProductCommand>, IHandler<DeleteProductCommand>
    {
        private readonly IProductRepository _productRepository;
        private readonly IBus _bus;

        public ProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork, IBus bus, IDomainNotificationHandler<DomainNotification> notification) : base(unitOfWork, bus, notification)
        {
            _productRepository = productRepository;
            _bus = bus;
        }

        public void Handle(CreateProductCommand message)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }

            var product = new Product(Guid.NewGuid(), message.Name, message.Description);

            _productRepository.Add(product);

            if (Commit())
            {
                _bus.RaiseEvent(new ProductCreatedEvent(product.Id, product.Name, product.Description));
            }
        }

        public void Handle(UpdateProductCommand message)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }

            var product = new Product(message.Id, message.Name, message.Description);

            _productRepository.Update(product);

            if (Commit())
            {
                _bus.RaiseEvent(new ProductUpdatedEvent(product.Id, product.Name, product.Description));
            }
        }

        public void Handle(DeleteProductCommand message)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }

            _productRepository.Remove(message.Id);

            if (Commit())
            {
                _bus.RaiseEvent(new ProductDeletedEvent(message.Id));
            }
        }
    }
}
