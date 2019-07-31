
using System.ComponentModel.DataAnnotations.Schema;
/// <summary>
/// Collecting a list of product by using required parameters listed in
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

        public Product(int id) : base()
        {
            Id = id;
        }
    }
}

