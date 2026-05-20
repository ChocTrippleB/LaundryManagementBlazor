using LaundryManagmentSystem.Obeservers;
using LaundryManagementBlazor.Services;

namespace LaundryManagementBlazor.Services.Observers
{
    public class DriverNotifier : IOrderObserver
    {
        private readonly string _driverName;
        private readonly string _vehicleRegistration;
        private readonly LaundryAppService _appService;

        public DriverNotifier(string driverName, string vehicleRegistration, LaundryAppService appService)
        {
            _driverName = driverName;
            _vehicleRegistration = vehicleRegistration;
            _appService = appService;
        }

        public void Update(string orderId, OrderStatus newStatus, string message)
        {
            if (newStatus == OrderStatus.PickupAssigned || newStatus == OrderStatus.ReadyForDelivery)
            {
                _appService.AddNotification("Driver", orderId,
                    $"[{_driverName} | {_vehicleRegistration}] {message}");
            }
        }
    }
}
