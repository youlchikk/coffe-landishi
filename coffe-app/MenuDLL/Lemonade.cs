using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuDLL
{
    public abstract class Lemonade: Menu
    {
        protected bool HotOrCold { get; set; }
        protected double price { get; set; }
        protected double volume { get; set; }
        protected string description { get; set; }
    }

    public class LemonadeWithoutSyrup : Lemonade
    {
        public LemonadeWithoutSyrup(bool HotOrCold, double price, double volume)
        {
            this.HotOrCold = HotOrCold;
            this.price = price;
            this.volume = volume;
            this.description = "Лимонад";
        }
    }

    public class LemonadeWithChocolateSyrup : Lemonade
    {
        public LemonadeWithChocolateSyrup(bool HotOrCold, double price, double volume)
        {
            this.HotOrCold = HotOrCold;
            this.price = price;
            this.volume = volume;
            this.description = "Лимонад с шоколадом";
        }
    }

    public class LemonadeWithBananaSyrup : Lemonade
    {
        public LemonadeWithBananaSyrup(bool HotOrCold, double price, double volume)
        {
            this.HotOrCold = HotOrCold;
            this.price = price;
            this.volume = volume;
            this.description = "Банановый лимонад";
        }
    }

    public class LemonadeWithLavenderSyrup : Lemonade
    {
        public LemonadeWithLavenderSyrup(bool HotOrCold, double price, double volume)
        {
            this.HotOrCold = HotOrCold;
            this.price = price;
            this.volume = volume;
            this.description = "Лавандовый лимонад";
        }
    }

    public class LemonadeWithRaspberrySyrup : Lemonade
    {
        public LemonadeWithRaspberrySyrup(bool HotOrCold, double price, double volume)
        {
            this.HotOrCold = HotOrCold;
            this.price = price;
            this.volume = volume;
            this.description = "Лимонад с малиной";
        }
    }

    public class LemonadeWithCaramelSyrup : Lemonade
    {
        public LemonadeWithCaramelSyrup(bool HotOrCold, double price, double volume)
        {
            this.HotOrCold = HotOrCold;
            this.price = price;
            this.volume = volume;
            this.description = "Лимонад с карамелью";
        }
    }
}
