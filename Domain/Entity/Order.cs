namespace ProjectOrder.Domain.Entity
{
    public class Order : SharedCore.DomainObjects.Entity
    {
        public int OrderId { get; set; }
        public long CostumerId { get; set; }
        public DateTime OrderDate { get; set; }
    }
}