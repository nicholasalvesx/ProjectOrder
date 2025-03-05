using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectOrder.Domain.Repository;
using ProjectOrder.Infra.Data;
using ProjectOrder.Infra.UnitOfWork;

namespace ProjectOrder.Pages.Order;
public class CreateOrderModel : PageModel
{
    private readonly AppDbContext _context;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IOrderRepository _orderRepository;

    [BindProperty]
    public Domain.Entity.Order Order { get; set; } = new();
    public List<SelectListItem> Customers { get; set; }
    public List<SelectListItem> Products { get; set; }

    public CreateOrderModel(AppDbContext context, IUnitOfWork unitOfWork, IOrderRepository orderRepository)
    {
        _context = context;
        _unitOfWork = unitOfWork;
        _orderRepository = orderRepository;
    }

    public void OnGet()
    {
        Customers = _context.Customers
            .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
            .ToList();

        Products = _context.Products
            .Select(p => new SelectListItem { Value = p.Id.ToString(), Text = p.Name })
            .ToList();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var order = new Domain.Entity.Order(Order.CustomerId, Order.ProductId, Order.Quantity);
        
        _orderRepository.AddOrder(order);
        await _unitOfWork.CommitAsync();
        return RedirectToPage("Index");
    }
}