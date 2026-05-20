using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundryManagmentSystem.Factories.Services
{
    class ExpressSameDay : LaundryService // ConcreteProduct
    {
        public ExpressSameDay()
        {
            this.ServiceName = "Express Same-Day";
            this.Description = "Same day express service";
            this.Price = 250;
        }

        public override void SchedulePickup()
        {
            Console.WriteLine("Scheduling priority same day pickup.");
        }
    }
}
