using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectOrder.Application.Commands;
using ProjectOrder.Infra.Data;
using ProjectOrder.Infra.UnitOfWork;

namespace ProjectOrder.Pages.Order;
public class CreateOrderModel : PageModel
{
    private readonly AppDbContext _context;
    private readonly IUnitOfWork _unitOfWork;

    [BindProperty] public CreateOrderCommand OrderCommand { get; set; } = new();
    public List<SelectListItem> Customers { get; set; }
    public List<SelectListItem> Products { get; set; }

    public CreateOrderModel(AppDbContext context, IUnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
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

        var result = await OrderCommand.ExecuteAsync(_unitOfWork);
        if (result)
        {
            return RedirectToPage("/Order/Index");
        }
        ModelState.AddModelError(string.Empty, "Erro ao criar pedido.");
        return Page();
    }
}