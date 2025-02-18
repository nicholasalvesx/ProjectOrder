using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectOrder.Domain.Entity;
using ProjectOrder.Infra.UnitOfWork;

namespace ProjectOrder.Pages;

public class OrdersModel : PageModel
{
    private readonly IUnitOfWork _unitOfWork;

    public OrdersModel(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public List<Order> Orders { get; set; } = new();

    public async Task OnGetAsync()
    {
        Orders = (List<Order>)await _unitOfWork.Orders.GetAllAsync();
    }
}