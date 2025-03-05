using System.ComponentModel.DataAnnotations;

namespace ProjectOrder.Domain.Entity;

public class Customer
{
    [Key]
    public int Id { get; set; }
    [Required] public string Name { get; set; }
    [Required] public string Email { get; set; }

    public Customer() { }

    public Customer(string name, string email)
    {
        Name = name;
        Email = email;
    }
}