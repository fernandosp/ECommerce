using ECommerce.Domain;
using System.Collections.Generic;

namespace ECommerce.Business
{
    public class ProductTypeBusiness : IProductTypeBusiness
    {
        private readonly IProductTypeBusiness _iProductTypeBusiness;
        public ProductTypeBusiness(IProductTypeBusiness iProductTypeBusiness)
        {
            _iProductTypeBusiness = iProductTypeBusiness;
        }
        public ProductType Add(ProductType productType)
        {
           return _iProductTypeBusiness.Add(productType);
        }

        public List<ProductType> GetAll()
        {
           return _iProductTypeBusiness.GetAll();
        }
    }
}
