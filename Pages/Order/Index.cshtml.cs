using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectOrder.Domain.Repository;

namespace ProjectOrder.Pages.Order;

public class OrdersModel(IOrderRepository orderRepository) : PageModel
{
    public List<Domain.Entity.Order>? Orders { get; set; }
    public async Task OnGetAsync()
    {
       Orders = (List<Domain.Entity.Order>?)await orderRepository.GetAllAsync();
    }
}