using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundryManagmentBlazor.Interfaces
{
    public interface ILaundryOrder
    {
        string GetDescription();
        decimal GetPrice();
    }
    //end of interface ILaundryOrder
}//end of namespace LaundryManagmentSystem.Interfaces