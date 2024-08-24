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
    public class SaleService : Service<Sale>, ISaleService
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWorks _unitOfWorks;
        public SaleService(IGenericRepository<Sale> repository, IUnitOfWorks unitOfWorks, ISaleRepository saleRepository, IProductRepository productRepository) : base(repository, unitOfWorks)
        {
            _saleRepository = saleRepository;
            _productRepository = productRepository;
            _unitOfWorks = unitOfWorks;
        }

        public async Task SaleProduct(Sale sale)
        {
            var product = await _productRepository.GetByIDAsync(sale.ProductID);
            product.Stock -= sale.Quantity;
            _productRepository.Update(product);
            sale.TotalPrice =sale.UnitPrice - sale.Quantity;

            await AddAsync(sale);

        }
    }
}
