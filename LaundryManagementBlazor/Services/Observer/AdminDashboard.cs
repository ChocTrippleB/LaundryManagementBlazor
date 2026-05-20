using LaundryManagmentSystem.Obeservers;
using LaundryManagementBlazor.Services;

namespace LaundryManagementBlazor.Services.Observers
{
    public class AdminDashboard : IOrderObserver
    {
        private readonly LaundryAppService _appService;

        public AdminDashboard(LaundryAppService appService)
        {
            _appService = appService;
        }

        public void Update(string orderId, OrderStatus newStatus, string message)
        {
            _appService.AddNotification("Admin", orderId,
                $"[ADMIN] Order #{orderId} → {newStatus}: {message}");
        }
    }
}
