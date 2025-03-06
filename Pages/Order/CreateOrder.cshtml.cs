using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectOrder.Domain.Repository;
using ProjectOrder.Infra.Data;
using ProjectOrder.Infra.UnitOfWork;

namespace ProjectOrder.Pages.Order;

public class CreateOrderModel(AppDbContext context, IUnitOfWork unitOfWork, IOrderRepository orderRepository)
    : PageModel
{
    [BindProperty]
    public int CustomerId { get; set; }
    
    [BindProperty]
    public int ProductId { get; set; }
    
    [BindProperty]
    public int Quantity { get; set; }
    public List<SelectListItem> Customers { get; set; } = [];
    public List<SelectListItem> Products { get; set; } = [];

    public void OnGet()
    {
        Customers = context.Customers
            .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
            .ToList();

        Products = context.Products
            .Select(p => new SelectListItem { Value = p.Id.ToString(), Text = p.Name })
            .ToList();
    }
    
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var customer = await context.Customers.FindAsync(CustomerId);
        Console.WriteLine($"Customer: {customer?.Id}");
        
        if (customer == null)
        {
            Console.WriteLine("Erro: Cliente não encontrados.");
            return Page();
        }
        
        var product = await context.Products.FindAsync(ProductId);
        
        if (product == null)
        {
            Console.WriteLine("Erro: Produto não encontrados.");
            return Page();
        }
        
        var order = new Domain.Entity.Order(CustomerId,ProductId, Quantity);
        orderRepository.AddOrder(order);
        await unitOfWork.CommitAsync();
        
        return RedirectToPage("Index");
    }
}