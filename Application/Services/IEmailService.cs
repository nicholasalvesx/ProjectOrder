namespace ProjectOrder.Application.Services;

public interface IEmailService
{
    Task SendOrderEmailVerficationAsync(int costumer, int orderId);
}