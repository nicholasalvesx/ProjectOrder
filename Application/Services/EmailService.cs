namespace ProjectOrder.Application.Services;

public class EmailService : IEmailService
{
    public async Task SendOrderEmailVerficationAsync(int costumer, int orderId)
    {
        await Task.Delay(500);
        Console.WriteLine($"Email de confirmaçao enviado ao cliente {costumer} referente ao pedido {orderId}");
    }
}