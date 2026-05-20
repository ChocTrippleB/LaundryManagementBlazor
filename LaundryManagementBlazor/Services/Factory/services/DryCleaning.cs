using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundryManagmentSystem.Factories.Services
{
    class DryCleaning : LaundryService // ConcreteProduct
    {
        public DryCleaning()
        {
            this.ServiceName = "Dry Cleaning";
            this.Description = "Professional dry cleaning";
            this.Price = 200;
        }

        public override void WashClothes()
        {
            Console.WriteLine("Dry cleaning clothes with special solution.");
        }
    }
}
