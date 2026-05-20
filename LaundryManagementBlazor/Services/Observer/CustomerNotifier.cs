using LaundryManagmentSystem.Obeservers;
using LaundryManagementBlazor.Services;

namespace LaundryManagementBlazor.Services.Observers
{
    public class CustomerNotifier : IOrderObserver
    {
        private readonly string _customerName;
        private readonly string _contactNumber;
        private readonly LaundryAppService _appService;

        public CustomerNotifier(string customerName, string contactNumber, LaundryAppService appService)
        {
            _customerName = customerName;
            _contactNumber = contactNumber;
            _appService = appService;
        }

        public void Update(string orderId, OrderStatus newStatus, string message)
        {
            if (newStatus == OrderStatus.Placed ||
                newStatus == OrderStatus.PickupAssigned ||
                newStatus == OrderStatus.OutForDelivery ||
                newStatus == OrderStatus.Delivered ||
                newStatus == OrderStatus.Cancelled)
            {
                _appService.AddNotification("Customer", orderId,
                    $"[SMS → {_customerName}] {message}");
            }
        }
    }
}
