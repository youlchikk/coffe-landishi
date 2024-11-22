using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuDLL
{
    abstract class Tea
    {
        protected bool HotOrCold { get; set; }
        protected double[] price { get; set; }
        protected double[] volume { get; set; }
        protected string description { get; set; }
    }

    class TeaWithoutSyrup : Tea
    {
        public TeaWithoutSyrup(bool HotOrCold, double[] price, double[] volume) 
        {
            this.HotOrCold = HotOrCold;
            this.price = price;
            this.volume = volume;
            this.description = "Чай";
        }
    }

    class TeaWithChocolateSyrup : Tea
    {
        public TeaWithChocolateSyrup(bool HotOrCold, double[] price, double[] volume)
        {
            this.HotOrCold = HotOrCold;
            this.price = price;
            this.volume = volume;
            this.description = "Чай с шоколадом";
        }
    }

    class TeaWithBananaSyrup : Tea
    {
        public TeaWithBananaSyrup(bool HotOrCold, double[] price, double[] volume)
        {
            this.HotOrCold = HotOrCold;
            this.price = price;
            this.volume = volume;
            this.description = "Чай с бананом";
        }
    }

    class TeaWithLavenderSyrup : Tea
    {
        public TeaWithLavenderSyrup(bool HotOrCold, double[] price, double[] volume)
        {
            this.HotOrCold = HotOrCold;
            this.price = price;
            this.volume = volume;
            this.description = "Чай с лавандой";
        }
    }

    class TeaWithRaspberrySyrup : Tea
    {
        public TeaWithRaspberrySyrup(bool HotOrCold, double[] price, double[] volume)
        {
            this.HotOrCold = HotOrCold;
            this.price = price;
            this.volume = volume;
            this.description = "Чай с малиной";
        }
    }

    class TeaWithCaramelSyrup : Tea
    {
        public TeaWithCaramelSyrup(bool HotOrCold, double[] price, double[] volume)
        {
            this.HotOrCold = HotOrCold;
            this.price = price;
            this.volume = volume;
            this.description = "Чай с карамелью";
        }
    }
}
