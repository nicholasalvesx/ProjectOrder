using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectOrder.Domain.Entity;
using ProjectOrder.Infra.UnitOfWork;

namespace ProjectOrder.Pages;

public class CostumerModel : PageModel
{
    private readonly IUnitOfWork _unitOfWork;

    public CostumerModel(IUnitOfWork unitOfWork, IEnumerable<Order> costumers)
    {
        _unitOfWork = unitOfWork;
        Costumers = costumers;
    }
    public IEnumerable<Order> Costumers { get; set; }

    public async Task OnGetAsync()
    {
        Costumers = await _unitOfWork.Orders.GetAllAsync();     
    }
   
}