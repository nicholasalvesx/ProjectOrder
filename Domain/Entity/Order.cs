namespace ProjectOrder.Domain.Entity
{
    public class Order
    {
        public int OrderId { get; set; }
        public long CostumerId { get; set; }
        public DateTime OrderDate { get; set; }
    }
}