using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundryManagmentSystem.Factories.Services
{
    class WashAndFold : LaundryService // ConcreteProduct
    {
        public WashAndFold()
        {
            this.ServiceName = "Wash and Fold";
            this.Description = "Wash and fold service";
            this.Price = 120;
        }
    }
}
