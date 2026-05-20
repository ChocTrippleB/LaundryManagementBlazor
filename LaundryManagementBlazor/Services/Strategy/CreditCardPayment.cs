using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaundryManagmentSystem.Interfaces;

namespace LaundryManagmentSystem.Strategies
{
    internal class CreditCardPayment : IPaymentStrategy
    {
        private string _cardHolderName;
        private string _cardNumber;
        private string _expiryDate;
        private string _cvv;

        public CreditCardPayment(string cardHolderName, string cardNumber, string expiryDate, string cvv)
        {
            _cardHolderName = cardHolderName;
            _cardNumber = cardNumber;
            _expiryDate = expiryDate;
            _cvv = cvv;
        }

        public void Pay(decimal amount)
        {
            Console.WriteLine($"[Card Gateway] Processing Credit Card payment of R{amount:F2}...");
            Console.WriteLine($"[Card Gateway] Verifying card ending in {_cardNumber.Substring(_cardNumber.Length - 4)}...");
            Console.WriteLine("[Card Gateway] Payment APPROVED successfully!\n");
        }
    }
}
