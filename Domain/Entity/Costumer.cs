namespace ProjectOrder.Domain.Entity;

public class Costumer : SharedCore.DomainObjects.Entity
{
    public int CostumerId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}