using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaundryManagmentSystem.Models;

namespace LaundryManagmentSystem.Obeservers
{
    internal interface IOrderSubject
    {
        void RegisterObserver(IOrderObserver observer);
        void RemoveObserver(IOrderObserver observer);
        void NotifyObservers(); // can be empty if no specific message is needed
    }
}
