using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuDLL
{
    abstract public class Menu
    {
        protected double price { get; set; }
        protected double volume { get; set; }
        protected bool HotOrCold { get; set; }
        protected string description { get; set; }

       // public Menu(double price, double volume, bool HotOrOld) 
       // {
       //     this.price = price;
       //     this.volume = volume;
       //     this.HotOrCold = HotOrOld;
       // }

    }
}
