using LaundryManagmentSystem.Obeservers;
using LaundryManagementBlazor.Services;

namespace LaundryManagementBlazor.Services.Observers
{
    public class StaffNotifier : IOrderObserver
    {
        private readonly string _staffStation;
        private readonly LaundryAppService _appService;

        public StaffNotifier(string staffStation, LaundryAppService appService)
        {
            _staffStation = staffStation;
            _appService = appService;
        }

        public void Update(string orderId, OrderStatus newStatus, string message)
        {
            if (newStatus == OrderStatus.PickedUp   ||
                newStatus == OrderStatus.InProgress ||
                newStatus == OrderStatus.Placed)
            {
                _appService.AddNotification("Staff", orderId,
                    $"[{_staffStation}] {message}");
            }
        }
    }
}
