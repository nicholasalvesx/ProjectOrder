using ProjectOrder.Infra.UnitOfWork;

namespace ProjectOrder.Application.Commands;
public class CreateCustomerCommand
{ 
    private readonly IUnitOfWork _unitOfWork;

    public CreateCustomerCommand(string name, string email, IUnitOfWork unitOfWork)
    {
        Name = name;
        Email = email;
        _unitOfWork = unitOfWork;
    }
    public string Name { get; set; }
    public string Email { get; set; }
}