using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuDLL
{
    public abstract class Tea: Menu
    {
        protected bool HotOrCold { get; set; }
        protected double price { get; set; }
        protected double volume { get; set; }
        protected string description { get; set; }
    }

    public class TeaWithoutSyrup : Menu
    {
        public TeaWithoutSyrup(bool HotOrCold, double price, double volume) 
        {
            this.HotOrCold = HotOrCold;
            this.price = price;
            this.volume = volume;
            this.description = "Чай";
        }
    }

    public class TeaWithChocolateSyrup : Menu
    {
        public TeaWithChocolateSyrup(bool HotOrCold, double price, double volume)
        {
            this.HotOrCold = HotOrCold;
            this.price = price;
            this.volume = volume;
            this.description = "Чай с шоколадом";
        }
    }

    public class TeaWithBananaSyrup : Menu
    {
        public TeaWithBananaSyrup(bool HotOrCold, double price, double volume)
        {
            this.HotOrCold = HotOrCold;
            this.price = price;
            this.volume = volume;
            this.description = "Чай с бананом";
        }
    }

    public class TeaWithLavenderSyrup : Menu
    {
        public TeaWithLavenderSyrup(bool HotOrCold, double price, double volume)
        {
            this.HotOrCold = HotOrCold;
            this.price = price;
            this.volume = volume;
            this.description = "Чай с лавандой";
        }
    }

    public class TeaWithRaspberrySyrup : Menu
    {
        public TeaWithRaspberrySyrup(bool HotOrCold, double price, double volume)
        {
            this.HotOrCold = HotOrCold;
            this.price = price;
            this.volume = volume;
            this.description = "Чай с малиной";
        }
    }

    public class TeaWithCaramelSyrup : Menu
    {
        public TeaWithCaramelSyrup(bool HotOrCold, double price, double volume)
        {
            this.HotOrCold = HotOrCold;
            this.price = price;
            this.volume = volume;
            this.description = "Чай с карамелью";
        }
    }
}
