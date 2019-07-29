using System;
using System.Collections.Generic;
using System.Text;
using ECommerce.Business;
using ECommerce.Domain;

namespace ECommerce.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductBusiness _productBusiness;
        public ProductService(IProductBusiness productBusiness)
        {
            _productBusiness = productBusiness;
        }
        public void Add(Product obj)
        {
            _productBusiness.Add(obj);
        }

        public List<Product> GetAll()
        {
            return _productBusiness.GetAll();
        }

        public Product GetByName(string obj)
        {
            return _productBusiness.GetByName(obj);
        }
    }
}
