using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundryManagmentSystem.Factories.Services
{
    class WashOnly : LaundryService // ConcreteProduct
    {
        public WashOnly()
        {
            this.ServiceName = "Wash Only";
            this.Description = "Basic wash service";
            this.Price = 80;
        }
    }
}
