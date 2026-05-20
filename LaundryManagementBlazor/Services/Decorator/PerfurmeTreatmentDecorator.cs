using LaundryManagmentBlazor.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundryManagmentBlazor.Decorators
{
    public class PerfumeTreatmentDecorator : OrderDecorator
    {
        public PerfumeTreatmentDecorator(ILaundryOrder order) : base(order) { }

        public override string GetDescription() =>
            _order.GetDescription() + " + Perfume Treatment";

        public override decimal GetPrice() =>
            _order.GetPrice() + 30.00m;
    }
    //end of class PerfurmeTreatmentDecorator
}//end of namespace LaundryManagmentSystem.Decorators
