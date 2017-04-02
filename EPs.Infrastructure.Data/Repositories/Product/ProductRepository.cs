using EPs.Domain.Models;
using EPs.Domain.Repositories;
using EPs.Infrastructure.Data.Contexts;

namespace EPs.Infrastructure.Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(EPsContext context)
            :base(context)
        {
        }
    }
}
