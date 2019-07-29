using ECommerce.Data;
using ECommerce.Domain;
using System.Collections.Generic;

namespace ECommerce.Business
{
    public class ProductBusiness : IProductBusiness
    {
        private readonly IProductRepository _iProductRepository;
        public ProductBusiness(IProductRepository iProductRepository)
        {
            _iProductRepository = iProductRepository;
        }

        public Product Add(Product product)
        {
           return _iProductRepository.Add(product);
        }

        public List<Product> GetAll()
        {
            return _iProductRepository.GetAll();
        }

        public Product GetByName(string name)
        {
            return _iProductRepository.GetByName(name);
        }
    }
}
