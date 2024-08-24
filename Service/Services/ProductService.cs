using Core.Models;
using Core.Repositories;
using Core.Services;
using Core.UnitofWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class ProductService : Service<Product>, IProductService
    {
        private readonly IProductRepository _repository;
        public ProductService(IGenericRepository<Product> repository, IUnitOfWorks unitOfWorks) : base(repository, unitOfWorks)
        {
        }

        public async Task    BuyProduct(Product product)
        {
            var current = await _repository.GetByIDAsync(product.ID);
            current.Stock += product.Stock;
            Update(current);
        }
    }
}
