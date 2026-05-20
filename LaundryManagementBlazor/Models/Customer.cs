using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaundryManagmentSystem.Interfaces;

namespace LaundryManagmentSystem.Models
{
    internal class Customer
    {
        public string Name { get; private set; }
        public string CellNumber { get; private set; }

        // This holds the reference to the interchangeable strategy interface
        private IPaymentStrategy _paymentStrategy;

        public Customer(string name, string cellNumber)
        {
            Name = name;
            CellNumber = cellNumber;
        }

        // Context method allowing the strategy to be swapped dynamically at runtime
        public void SetPaymentStrategy(IPaymentStrategy paymentStrategy)
        {
            _paymentStrategy = paymentStrategy;
        }

        // Context method that delegates the heavy lifting to the active strategy instance
        public void MakePayment(decimal amount)
        {
            if (_paymentStrategy == null)
            {
                Console.WriteLine("Error: Please select a payment method before attempting checkout.");
                return;
            }

            _paymentStrategy.Pay(amount);
        }
    
    }//end of class Customer
}//end of namespace LaundryManagmentSystem.Models
