using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaundryManagmentSystem.Factories.Services;

namespace LaundryManagementBlazor.Services.AbstractFactory
{
    class StandardServiceFactory : LaundryServiceFactory // ConcreteFactory
    {
        public override LaundryService MakeService(string serviceName)
        {
            LaundryService service = null;

            if (serviceName == "Wash Only")
                service = new WashOnly();
            if (serviceName == "Wash and Fold")
                service = new WashAndFold();
            if (serviceName == "Ironing Service")
                service = new IroningService();

            return service;
        }
    }
}
