using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuDLL
{
    abstract public class Menu
    {

        public double price { get; set; }
        public double volume { get; set; }
        public bool HotOrCold { get; set; }
        public string description { get; set; }

        //public Menu(double price, double volume, bool HotOrOld)
        //{
        //    this.price = price;
        //    this.volume = volume;
        //    this.HotOrCold = HotOrOld;
        //}

    }
}
