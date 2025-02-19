using ProjectOrder.Domain.Entity;

namespace ProjectOrder.Domain.Entity;
public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; } 
        public int ProductId { get; set; }
        public Product? Product { get; set; } 
        public decimal Quantity { get; set; }
        public decimal TotalPrice => Quantity * Product!.Price;
        public DateTime OrderDate { get; set; }

        protected Order() {}
        
        public Order(int customerId, int productId, decimal quantity)
        {
            CustomerId = customerId;
            ProductId = productId;
            Quantity = quantity;
            OrderDate = DateTime.UtcNow;
        }
    }
