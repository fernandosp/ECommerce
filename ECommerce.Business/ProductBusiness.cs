using System;
using System.Collections.Generic;
using System.Text;
using ECommerce.Data;
using ECommerce.Domain;

namespace ECommerce.Business
{
    public class ProductBusiness : IProductBusiness
    {
        private readonly IProductRepository _ProductRepository;

        public ProductBusiness(IProductRepository iProductRepository)
        {
            _ProductRepository = iProductRepository;
        }

        public List<Product> GetAll()
        {
            return _ProductRepository.GetAll();
        }

        public Product GetProductById(int id)
        {
            return _ProductRepository.GetById(id);
        }

        public void Add(Product product)
        {
            _ProductRepository.Add(product);
        }
    }
}
