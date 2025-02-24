using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectOrder.Domain.Entity;
public class Customer
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } 
    [Required]
    public string Email { get; set; }

    public Customer(string name, string email)
    {
        Name = name;
        Email = email;
    }
}