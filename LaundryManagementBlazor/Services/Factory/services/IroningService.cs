using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundryManagmentSystem.Factories.Services
{
    class IroningService : LaundryService // ConcreteProduct
    {
        public IroningService()
        {
            this.ServiceName = "Ironing Service";
            this.Description = "Professional ironing";
            this.Price = 60;
        }

        public override void PackOrder()
        {
            Console.WriteLine("Packing ironed clothes on hangers.");
        }
    }
}
