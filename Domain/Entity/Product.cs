using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjectOrder.Domain.Entity;
public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        [Precision(18, 4)]
        public decimal Price { get; set; }
        
        public int Stock { get; set; }
        public Product() {}
        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
    }
