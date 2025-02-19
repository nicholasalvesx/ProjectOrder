using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectOrder.Infra.UnitOfWork;

namespace ProjectOrder.Pages.Order;

public class OrdersModel : PageModel
{
    private readonly IUnitOfWork _unitOfWork;

    public OrdersModel(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public List<Domain.Entity.Order> Orders { get; set; } = new();

    public async Task OnGetAsync()
    {
        Orders = (List<Domain.Entity.Order>)await _unitOfWork.Orders.GetAllAsync();
    }
}