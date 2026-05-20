using LaundryManagmentBlazor.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundryManagmentBlazor.Decorators
{
    public class StainRemovalDecorator : OrderDecorator
    {
        public StainRemovalDecorator(ILaundryOrder order) : base(order) { }

        public override string GetDescription() =>
            _order.GetDescription() + " + Stain Removal";

        public override decimal GetPrice() =>
            _order.GetPrice() + 25.00m;
    }
    //end of class StainRemoverDecorator
}//end of namespace LaundryManagmentSystem.Decorators
