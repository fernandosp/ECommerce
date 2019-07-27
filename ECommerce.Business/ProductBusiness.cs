using System;
using System.Collections.Generic;
using System.Text;
using ECommerce.Data;
using ECommerce.Domain;

namespace ECommerce.Business
{
    public class ProductBusiness : IProductBusiness
    {
        IProductRepository _iProductRepository;
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
