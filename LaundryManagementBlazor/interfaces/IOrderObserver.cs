using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaundryManagmentSystem.Models;

namespace LaundryManagmentSystem.Obeservers
{
    internal interface IOrderObserver
    {
        void Update(string orderId, OrderStatus newStatus, string message);
    }
}
