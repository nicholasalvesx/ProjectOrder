using System.ComponentModel.DataAnnotations;

namespace ProjectOrder.Domain.Entity;
public class Order 
    {
        [Required]
        public int OrderId { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        
        public DateTime OrderDate { get; set; }
        
        [Required]
        public Customer Customer { get; set; }
        
        [Required]
        public Product Product { get; set; }
        
        public Order(int customerId, int productId, int quantity)
        {
            CustomerId = customerId;
            ProductId = productId;
            Quantity = quantity;
        }
    }
