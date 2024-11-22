using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuDLL
{
    abstract class Coffee
    {
        public abstract void createWithChocolateSyrup();
        public abstract void createWithBananaSyrup();
        public abstract void createWithLavenderSyrup();
        public abstract void createWithRaspberrySyrup();
        public abstract void createWithCaramelSyrup();
    }

    abstract class ChocolateSyrup
    {
        protected bool HotOrCold { get; set;  }
        protected double[] price { get; set;  }
        protected double[] volume { get; set; }
        protected string description { get; set; }

    }

    abstract class BananaSyrup
    {
        protected bool HotOrCold { get; set; }
        protected double[] price { get; set; }
        protected double[] volume { get; set; }
        protected string description { get; set; }

    }

    abstract class LavenderSyrup
    {
        protected bool HotOrCold { get; set; }
        protected double[] price { get; set; }
        protected double[] volume { get; set; }
        protected string description { get; set; }

    }

    abstract class RaspberrySyrup
    {
        protected bool HotOrCold { get; set; }
        protected double[] price { get; set; }
        protected double[] volume { get; set; }
        protected string description { get; set; }

    }

    abstract class CaramelSyrup
    {
        protected bool HotOrCold { get; set; }
        protected double[] price { get; set; }
        protected double[] volume { get; set; }
        protected string description { get; set; }

    }

    class Americano: Coffee
    {
        public override void createWithChocolateSyrup() { }
        public override void createWithBananaSyrup() { }
        public override void createWithLavenderSyrup() { }
        public override void createWithRaspberrySyrup() { }
        public override void createWithCaramelSyrup() { }
    }

    class Cappuccino : Coffee
    {
        public override void createWithChocolateSyrup() { }
        public override void createWithBananaSyrup() { }
        public override void createWithLavenderSyrup() { }
        public override void createWithRaspberrySyrup() { }
        public override void createWithCaramelSyrup() { }
    }

    class FlatWhite : Coffee
    {
        public override void createWithChocolateSyrup() { }
        public override void createWithBananaSyrup() { }
        public override void createWithLavenderSyrup() { }
        public override void createWithRaspberrySyrup() { }
        public override void createWithCaramelSyrup() { }
    }

    class Latte: Coffee
    {
        public override void createWithChocolateSyrup() { }
        public override void createWithBananaSyrup() { }
        public override void createWithLavenderSyrup() { }
        public override void createWithRaspberrySyrup() { }
        public override void createWithCaramelSyrup() { }
    }

    class Raf : Coffee
    {
        public override void createWithChocolateSyrup() { }
        public override void createWithBananaSyrup() { }
        public override void createWithLavenderSyrup() { }
        public override void createWithRaspberrySyrup() { }
        public override void createWithCaramelSyrup() { }
    }


    class AmericanoWithChocolateSyrup: ChocolateSyrup
    {
        AmericanoWithChocolateSyrup (bool HotOrCold, double[] price, double[] volume) 
        { 
            this.HotOrCold = HotOrCold;
            this.price = price;
            this.volume = volume;
            this.description = "Американо с шоколадным сиропом";
        }
    }

    class CappuccinoWithChocolateSyrup : ChocolateSyrup
    {
        CappuccinoWithChocolateSyrup (bool HotOrCold, double[] price, double[] volume)
        {
            this.HotOrCold = HotOrCold;
            this.price = price;
            this.volume = volume;
            this.description = "Капучино с шоколадным сиропом";
        }
    }

    class FlatWhiteWithChocolateSyrup : ChocolateSyrup
    {
        FlatWhiteWithChocolateSyrup (bool HotOrCold, double[] price, double[] volume)
        {
            this.HotOrCold = HotOrCold;
            this.price = price;
            this.volume = volume;
            this.description = "Флэт Уайт с шоколадным сиропом";
        }
    }

    class LatteWithChocolateSyrup : ChocolateSyrup
    {
        LatteWithChocolateSyrup (bool HotOrCold, double[] price, double[] volume)
        {
            this.HotOrCold = HotOrCold;
            this.price = price;
            this.volume = volume;
            this.description = "Латте с шоколадным сиропом";
        }
    }

    class RafWithChocolateSyrup : ChocolateSyrup
    {
        RafWithChocolateSyrup (bool HotOrCold, double[] price, double[] volume)
        {
            this.HotOrCold = HotOrCold;
            this.price = price;
            this.volume = volume;
            this.description = "Раф с шоколадным сиропом";
        }
    }
}
