using LaundryManagementBlazor.Models;
using LaundryManagementBlazor.Interfaces;
using LaundryManagementBlazor.Services.AbstractFactory;
using LaundryManagementBlazor.Services.Observers;
using LaundryManagmentBlazor.Decorators;
using LaundryManagmentBlazor.Interfaces;
using LaundryManagmentBlazor.Models;
using LaundryManagmentSystem.Obeservers;
using LaundryManagmentSystem.Singleton;
using LaundryManagmentSystem.Interfaces;
using LaundryManagmentSystem.Strategies;

namespace LaundryManagementBlazor.Services
{
    public class LaundryAppService
    {
        public List<OrderViewModel> Orders { get; } = new();
        public List<NotificationEntry> Notifications { get; } = new();
        public List<LogEntry> LogEntries { get; } = new();

        public event Action? StateChanged;

        private readonly Dictionary<string, ObservableOrder> _observableOrders = new();

        public LaundryAppService()
        {
            OrderLogger.GetInstance().Initialize(this);
        }

        // ── All pattern construction happens here, not in Razor pages ──
        public string PlaceOrder(PlaceOrderRequest req)
        {
            string orderId = $"ORD-{DateTime.Now:HHmmss}";

            // Abstract Factory — select package family
            ILaundryPackageFactory packageFactory = req.PackageName switch
            {
                "Premium"  => new PremiumPackageFactory(),
                "Business" => new BusinessPackageFactory(),
                _          => new StandardPackageFactory()
            };
            var packaging  = packageFactory.CreatePackaging();
            var delivery   = packageFactory.CreateDeliveryMethod();
            var detergent  = packageFactory.CreateDetergent();

            // Factory Method — create base laundry order
            // LaundryOrder implements ILaundryOrder; cast to the Blazor interface used by decorators
            var laundryOrder = new LaundryManagmentBlazor.Models.LaundryOrder(req.ServiceName, req.BasePrice);
            LaundryManagmentBlazor.Interfaces.ILaundryOrder baseOrder = laundryOrder;

            // Decorator — wrap with optional extras
            LaundryManagmentBlazor.Interfaces.ILaundryOrder decorated = baseOrder;
            if (req.AddStainRemoval)     decorated = new StainRemovalDecorator(decorated);
            if (req.AddPerfumeTreatment) decorated = new PerfumeTreatmentDecorator(decorated);

            var extrasDescription = BuildExtrasDescription(req);

            // Strategy — instantiate correct payment handler
            IPaymentStrategy paymentStrategy =
                req.PaymentMethod == "CreditCard"
                    ? new LaundryManagmentSystem.Strategies.CreditCardPayment(
                          req.CardName, req.CardNumber, req.CardExpiry, req.CardCvv)
                    : new LaundryManagmentSystem.Strategies.EFTPayment();

            // Singleton — log before charging
            OrderLogger.GetInstance().Log(
                $"ORDER PLACED: {orderId} — {req.CustomerName} | {req.PackageName} {decorated.GetDescription()} | R{decorated.GetPrice():F2}");

            // Strategy — process payment
            paymentStrategy.Pay(decorated.GetPrice());
            OrderLogger.GetInstance().Log(
                $"PAYMENT: {orderId} via {req.PaymentMethod} — R{decorated.GetPrice():F2} processed.");

            // Build view model
            var order = new OrderViewModel
            {
                OrderId        = orderId,
                CustomerName   = req.CustomerName,
                Address        = req.Address,
                Package        = req.PackageName,
                PackagingType  = packaging.Describe(),
                DeliveryMethod = delivery.Describe(),
                DetergentType  = detergent.Describe(),
                ServiceType    = decorated.GetDescription(),
                Extras         = extrasDescription,
                Total          = decorated.GetPrice(),
                Payment        = req.PaymentMethod == "CreditCard" ? "Credit Card" : "EFT",
                Status         = "Placed",
                CreatedAt      = DateTime.Now
            };

            // Observer — create observable order and wire all stakeholders
            var observable = new ObservableOrder(orderId, req.CustomerName, decorated.GetDescription());
            observable.RegisterObserver(new CustomerNotifier(req.CustomerName, "082 000 0000", this));
            observable.RegisterObserver(new DriverNotifier("Sipho Mokoena", "CA 123-456", this));
            observable.RegisterObserver(new StaffNotifier("Main Wash Station", this));
            observable.RegisterObserver(new AdminDashboard(this));

            _observableOrders[orderId] = observable;
            Orders.Insert(0, order);

            observable.UpdateStatus(OrderStatus.Placed,
                "Your order has been received and will be collected shortly.");

            NotifyStateChanged();
            return orderId;
        }

        // ── Update status of an existing order ───────────────────
        public void UpdateOrderStatus(string orderId, string newStatus, string message)
        {
            var order = Orders.FirstOrDefault(o => o.OrderId == orderId);
            if (order == null) return;

            order.Status = newStatus;

            if (_observableOrders.TryGetValue(orderId, out var observable))
            {
                if (Enum.TryParse<OrderStatus>(newStatus, out var statusEnum))
                    observable.UpdateStatus(statusEnum, message);
            }

            OrderLogger.GetInstance().Log($"STATUS UPDATE: {orderId} → {newStatus}");
            NotifyStateChanged();
        }

        // ── Called by observer classes ────────────────────────────
        public void AddNotification(string role, string orderId, string message)
        {
            Notifications.Insert(0, new NotificationEntry
            {
                Role      = role,
                OrderId   = orderId,
                Message   = message,
                Timestamp = DateTime.Now
            });
            // Don't call NotifyStateChanged here — observers are called inside UpdateOrderStatus
            // which already calls it at the end. Avoids double-render.
        }

        // ── Called by OrderLogger ─────────────────────────────────
        public void AddLog(string message)
        {
            LogEntries.Insert(0, new LogEntry { Message = message, Timestamp = DateTime.Now });
        }

        private static string BuildExtrasDescription(PlaceOrderRequest req)
        {
            var parts = new List<string>();
            if (req.AddStainRemoval)     parts.Add("Stain Removal (+R25)");
            if (req.AddPerfumeTreatment) parts.Add("Perfume Treatment (+R30)");
            return string.Join(", ", parts);
        }

        private void NotifyStateChanged() => StateChanged?.Invoke();
    }
}
