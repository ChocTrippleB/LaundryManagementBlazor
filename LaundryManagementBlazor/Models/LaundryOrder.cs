using LaundryManagmentBlazor.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundryManagmentBlazor.Models
{
    public class LaundryOrder : ILaundryOrder
    {
        private readonly string _description;
        private readonly decimal _price;

        public LaundryOrder(string description, decimal price)
        {
            _description = description;
            _price = price;
        }

        public string GetDescription() => _description;
        public decimal GetPrice() => _price;
    }
    //end of class LaundryOrder
}//end of namespace LaundryManagmentSystem.Models

//Factories/Services/) can return a LaundryOrder, and your decorators wrap it.