using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectOrder.Domain.Repository;
using ProjectOrder.Infra.UnitOfWork;

namespace ProjectOrder.Pages.Order;

public class OrdersModel : PageModel
{
    private readonly IOrderRepository _orderRepository;
    public OrdersModel(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }
    public List<Domain.Entity.Order>? Orders { get; set; }
    public async Task OnGetAsync()
    {
       Orders = (List<Domain.Entity.Order>?)await _orderRepository.GetAllAsync();
    }
}