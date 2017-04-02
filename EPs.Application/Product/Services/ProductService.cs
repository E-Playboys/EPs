using System;
using System.Collections.Generic;
using EPs.Application.Interfaces;
using EPs.Application.ViewModels;
using EPs.Domain.Core;
using EPs.Domain.Repositories;
using AutoMapper;
using EPs.Domain.Commands;

namespace EPs.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        private readonly IBus _bus;

        public ProductService(IMapper mapper, IProductRepository productRepository, IBus bus)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _bus = bus;
        }

        public IEnumerable<ProductViewModel> GetAll()
        {
            return _mapper.Map<IEnumerable<ProductViewModel>>(_productRepository.GetAll());
        }

        public ProductViewModel GetById(Guid id)
        {
            return _mapper.Map<ProductViewModel>(_productRepository.GetById(id));
        }

        public void Create(ProductViewModel productViewModel)
        {
            var createCommand = _mapper.Map<CreateProductCommand>(productViewModel);
            _bus.SendCommand(createCommand);
        }

        public void Update(ProductViewModel productViewModel)
        {
            var updateCommand = _mapper.Map<UpdateProductCommand>(productViewModel);
            _bus.SendCommand(updateCommand);
        }

        public void Delete(Guid id)
        {
            var deleteCommand = new DeleteProductCommand(id);
            _bus.SendCommand(deleteCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
