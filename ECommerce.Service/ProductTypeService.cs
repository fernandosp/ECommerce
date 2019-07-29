using ECommerce.Business;
using ECommerce.Domain;
using ECommerce.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Service
{
    public class ProductTypeService : IProductTypeService
    {
        private readonly IProductTypeBusiness _productTypeBusiness;
        public ProductTypeService(IProductTypeBusiness productTypeBusiness)
        {
            _productTypeBusiness = productTypeBusiness;
        }
        public void Add(ProductType obj)
        {
            _productTypeBusiness.Add(obj);
        }

        public List<ProductType> GetAll()
        {
           return _productTypeBusiness.GetAll();
        }
    }
}
