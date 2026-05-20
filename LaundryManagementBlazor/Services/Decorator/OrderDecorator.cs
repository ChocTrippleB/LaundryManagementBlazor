using LaundryManagmentBlazor.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundryManagmentBlazor.Decorators
{
    public abstract class OrderDecorator : ILaundryOrder
    {
        protected readonly ILaundryOrder _order;

        public OrderDecorator(ILaundryOrder order)
        {
            _order = order;
        }

        public virtual string GetDescription()
        {
            return _order.GetDescription();
        }

        public virtual decimal GetPrice()
        {
            return _order.GetPrice();
        }
    }
}
