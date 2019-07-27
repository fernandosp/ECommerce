namespace ECommerce.Domain
{
    public class Product :Entity
    {
        public string Name { get; set; }
        public ProductType ProductType { get; set; }
        public decimal Value { get; set; }
        public int Quantity { get; set; }
    }
}

