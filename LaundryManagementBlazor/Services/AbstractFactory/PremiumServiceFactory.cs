using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaundryManagmentSystem.Factories.Services;

namespace LaundryManagementBlazor.Services.AbstractFactory
{
    class PremiumServiceFactory : LaundryServiceFactory // ConcreteFactory
    {
        public override LaundryService MakeService(string serviceName)
        {
            LaundryService service = null;

            if (serviceName == "Dry Cleaning")
                service = new DryCleaning();
            if (serviceName == "Express Same-Day")
                service = new ExpressSameDay();

            return service;
        }
    }
}
