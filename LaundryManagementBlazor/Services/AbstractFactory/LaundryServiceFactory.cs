using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaundryManagmentSystem.Factories.Services;

namespace LaundryManagementBlazor.Services.AbstractFactory
{
    abstract class LaundryServiceFactory // FactoryBase
    {
        public LaundryService CreateOrder(string serviceName) // orchestration method
        {
            LaundryService service = MakeService(serviceName);

            service.SchedulePickup();
            service.WashClothes();
            service.PackOrder();

            return service;
        }
        public abstract LaundryService MakeService(string serviceName); // factory method
    }//end of class LaundryServiceFactory
}//end of namespace LaundryManagmentSystem.Factories
