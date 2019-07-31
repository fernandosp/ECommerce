
using System.ComponentModel.DataAnnotations.Schema;
/// <summary>
/// Collecting a list of product by using required parameters listed in
/// 
/// </ Name - Naming of product >
/// </ ProductType - Describing what is product type >
/// </ Value -  How it is product costs >
/// </Quantity - How many products will be onto Order >
/// 
/// </summary>
namespace ECommerce.Domain
{
    [Table("Product")]
    public class Product : Entity
    {
        public string Name { get; set; }
        public ProductType ProductType { get; set; }
        public decimal Value { get; set; }
        public int Quantity { get; set; }
    }
}

