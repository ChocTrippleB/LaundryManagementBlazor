using LaundryManagmentSystem.Obeservers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundryManagementBlazor.Services.Observers
{
    internal class ObservableOrder : IOrderSubject
    {
        public string OrderId { get; private set; }
        public string CustomerName { get; private set; }
        public string ServiceType { get; private set; }
        public OrderStatus Status { get; private set; }
        public string StatusMessage { get; private set; }

        private readonly List<IOrderObserver> _observers = new List<IOrderObserver>();

        public ObservableOrder(string orderId, string customerName, string serviceType)
        {
            OrderId = orderId;
            CustomerName = customerName;
            ServiceType = serviceType;
            Status = OrderStatus.Placed;
            StatusMessage = $"Order {orderId} placed for {customerName}, service: {serviceType}.";
        }

        public void RegisterObserver(IOrderObserver observer)
        {
            if (observer == null)
            {
                throw new ArgumentNullException(nameof(observer));
            }
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);
            }
        }

        public void RemoveObserver(IOrderObserver observer)
        { 
            if (_observers.Contains(observer))
                _observers.Remove(observer);
            else
                throw new InvalidOperationException("Observer not found.");
        }

        public void NotifyObservers()
        {
            foreach (var observer in new List<IOrderObserver>(_observers))
            {
                observer.Update(OrderId, Status, StatusMessage);
            }
        }

        public void UpdateStatus(OrderStatus newStatus, string message)
        {
            Status = newStatus;
            StatusMessage = message;

            Console.WriteLine($"\n[Laundry Order] Order {OrderId} -> {newStatus}");
            Console.WriteLine(new string('-', 55));

            NotifyObservers();
        }
    }
}
