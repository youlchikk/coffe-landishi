using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuDLL
{
    public class Menu
    {
        private double price { get; set; }
        private double volume { get; set; }
        private bool HotOrCold { get; set; }

        public Menu(double price, double volume, bool HotOrOld) 
        {
            this.price = price;
            this.volume = volume;
            this.HotOrCold = HotOrOld;
        }

    }
}
