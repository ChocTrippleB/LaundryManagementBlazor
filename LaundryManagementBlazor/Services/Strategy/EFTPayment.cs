using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaundryManagmentSystem.Interfaces;

namespace LaundryManagmentSystem.Strategies
{
    internal class EFTPayment : IPaymentStrategy
    {
        public void Pay(decimal amount)
        {
            // Generate a realistic random South African banking reference
            Random random = new Random();
            string reference = "LND" + random.Next(10000, 99999);

            Console.WriteLine($"[EFT Gateway] Generating electronic funds transfer invoice for R{amount:F2}...");
            Console.WriteLine("=================================================");
            Console.WriteLine("  BANKING DETAILS FOR DEPOSIT:                   ");
            Console.WriteLine("  Bank: Standard Bank                            ");
            Console.WriteLine($"  Account Reference: {reference}                ");
            Console.WriteLine("=================================================");
            Console.WriteLine("[EFT Gateway] Awaiting bank clearance verification... Done! Payment Confirmed.\n");
        }
    }
}
