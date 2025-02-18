namespace ProjectOrder.Domain.Entity
{
    public class Product : SharedCore.DomainObjects.Entity
    {
        public int ProductId { get; set; }
        public string Name { get; set; } 
        public int Stock { get; set; }
    }
}