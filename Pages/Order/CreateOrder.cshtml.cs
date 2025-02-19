using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectOrder.Infra.Data;

namespace ProjectOrder.Pages.Order;

public class CreateOrderModel : PageModel
{
    private readonly AppDbContext _context;

    [BindProperty]
    public Domain.Entity.Order Order { get; set; }
    public List<Domain.Entity.Product> Products { get; set; } = new();
    public List<SelectListItem> Customers { get; set; } = new();

    public CreateOrderModel(AppDbContext context, Domain.Entity.Order order)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        Order = order;
    }

    public void OnGet()
    {
        LoadCustomersAndProducts();
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            LoadCustomersAndProducts();
            return Page();
        }

        if (Order.ProductId == 0 || !_context.Products.Any(p => p.Id == Order.ProductId))
        {
            ModelState.AddModelError("Order.ProductId", "O produto selecionado é inválido.");
            LoadCustomersAndProducts();
            return Page();
        }

        _context.Orders.Add(Order);
        _context.SaveChanges();
        return RedirectToPage("Index");
    }

    private void LoadCustomersAndProducts()
    {
        Console.WriteLine("Carregando Clientes");
        Console.WriteLine($"Total de Customers: {_context.Customers.Count()}");

        Customers = _context.Customers
            .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
            .ToList() ?? [];

        Console.WriteLine($"Customers carregados: {Customers.Count}");

        Console.WriteLine("Carregando Produtos");
        Console.WriteLine($"Total de Products: {_context.Products.Count()}");

        Products = _context.Products
            .ToList() ?? [];

        Console.WriteLine($"Products carregados: {Products.Count}");
    }

}