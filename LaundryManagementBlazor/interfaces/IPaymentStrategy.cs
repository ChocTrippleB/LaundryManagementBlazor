using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundryManagmentSystem.Interfaces
{
    public interface IPaymentStrategy
    {
        void Pay(decimal amount);
    }//end of class IPaymentStrategy

}//end of namespace LaundryManagmentSystem.Interfaces
