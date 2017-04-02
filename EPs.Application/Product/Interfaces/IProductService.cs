using EPs.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace EPs.Application.Interfaces
{
    public interface IProductService : IDisposable
    {
        IEnumerable<ProductViewModel> GetAll();
        ProductViewModel GetById(Guid id);
        void Create(ProductViewModel productViewModel);
        void Update(ProductViewModel productViewModel);
        void Delete(Guid id);
    }
}
