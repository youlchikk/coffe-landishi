using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuDLL
{
    abstract class Lemonade
    {
        protected bool HotOrCold { get; set; }
        protected double[] price { get; set; }
        protected double[] volume { get; set; }
        protected string description { get; set; }
    }

    class LemonadeWithoutSyrup : Lemonade
    {
        public LemonadeWithoutSyrup(bool HotOrCold, double[] price, double[] volume)
        {
            this.HotOrCold = HotOrCold;
            this.price = price;
            this.volume = volume;
            this.description = "Лимонад";
        }
    }

    class LemonadeWithChocolateSyrup : Lemonade
    {
        public LemonadeWithChocolateSyrup(bool HotOrCold, double[] price, double[] volume)
        {
            this.HotOrCold = HotOrCold;
            this.price = price;
            this.volume = volume;
            this.description = "Лимонад с шоколадом";
        }
    }

    class LemonadeWithBananaSyrup : Lemonade
    {
        public LemonadeWithBananaSyrup(bool HotOrCold, double[] price, double[] volume)
        {
            this.HotOrCold = HotOrCold;
            this.price = price;
            this.volume = volume;
            this.description = "Банановый лимонад";
        }
    }

    class LemonadeWithLavenderSyrup : Lemonade
    {
        public LemonadeWithLavenderSyrup(bool HotOrCold, double[] price, double[] volume)
        {
            this.HotOrCold = HotOrCold;
            this.price = price;
            this.volume = volume;
            this.description = "Лавандовый лимонад";
        }
    }

    class LemonadeWithRaspberrySyrup : Lemonade
    {
        public LemonadeWithRaspberrySyrup(bool HotOrCold, double[] price, double[] volume)
        {
            this.HotOrCold = HotOrCold;
            this.price = price;
            this.volume = volume;
            this.description = "Лимонад с малиной";
        }
    }

    class LemonadeWithCaramelSyrup : Lemonade
    {
        public LemonadeWithCaramelSyrup(bool HotOrCold, double[] price, double[] volume)
        {
            this.HotOrCold = HotOrCold;
            this.price = price;
            this.volume = volume;
            this.description = "Лимонад с карамелью";
        }
    }
}
