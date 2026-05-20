using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundryManagmentSystem.Obeservers
{
    public enum OrderStatus
    {
        Placed,
        PickupAssigned,
        PickedUp,
        InProgress,
        ReadyForDelivery,
        OutForDelivery,
        Delivered,
        Cancelled
    }
}
