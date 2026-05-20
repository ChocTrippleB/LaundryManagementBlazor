using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundryManagmentSystem.Factories.Services
{
    class LaundryService // ProductBase
    {
        public string ServiceName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public virtual void WashClothes()
        {
            Console.WriteLine("Washing clothes");
        }

        public virtual void PackOrder()
        {
            Console.WriteLine("Packing order");
        }

        public virtual void SchedulePickup()
        {
            Console.WriteLine("Scheduling pickup");
        }
    }
}
