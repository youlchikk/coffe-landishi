using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MenuDLL
{
    public abstract class Coffee
    {
        public abstract Menu createAmericano(bool HotOrCold, double price, double volume);
        public abstract Menu createCappuccino(bool HotOrCold, double price, double volume);
        public abstract Menu createFlatWhite(bool HotOrCold, double price, double volume);
        public abstract Menu createLatte(bool HotOrCold, double price, double volume);
        public abstract Menu createRaf(bool HotOrCold, double price, double volume);
    }
    public abstract class Americano: Menu
    {
        protected bool HotOrCold { get; set; }
        public double price { get; set; }
        protected double volume { get; set; }
        protected string description { get; set; }
    }
    public abstract class Cappuccino: Menu
    {
        protected bool HotOrCold { get; set; }
        protected double price { get; set; }
        protected double volume { get; set; }
        protected string description { get; set; }
    }
    public abstract class FlatWhite: Menu
    {
        protected bool HotOrCold { get; set; }
        protected double price { get; set; }
        protected double volume { get; set; }
        protected string description { get; set; }
    }
    public abstract class Latte: Menu
    {
        protected bool HotOrCold { get; set; }
        protected double price { get; set; }
        protected double volume { get; set; }
        protected string description { get; set; }
    }
    public abstract class Raf: Menu
    {
        protected bool HotOrCold { get; set; }
        protected double price { get; set; }
        protected double volume { get; set; }
        protected string description { get; set; }
    }
    public class ChocolateSyrupFactory : Coffee
    {
        public override Menu createAmericano(bool HotOrCold, double price, double volume)
        { 
            return new AmericanoWithChocolateSyrup(HotOrCold, price, volume);
        }
        public override Menu createCappuccino(bool HotOrCold, double price, double volume) 
        {
            return new CappuccinoWithChocolateSyrup(HotOrCold, price, volume);
        }
        public override Menu createFlatWhite(bool HotOrCold, double price, double volume) 
        {
            return new FlatWhiteWithChocolateSyrup(HotOrCold, price, volume);
        }
        public override Menu createLatte(bool HotOrCold, double price, double volume) 
        {
            return new LatteWithChocolateSyrup(HotOrCold, price, volume);
        }
        public override Menu createRaf(bool HotOrCold, double price, double volume) 
        {
            return new RafWithChocolateSyrup(HotOrCold, price, volume);
        }
    }
    public class BananaSyrupFactory : Coffee
    {
        public override Menu createAmericano(bool HotOrCold, double price, double volume)
        {
            return new AmericanoWithBananaSyrup(HotOrCold, price, volume);
        }
        public override Menu createCappuccino(bool HotOrCold, double price, double volume)
        {
            return new CappuccinoWithBananaSyrup(HotOrCold, price, volume);
        }
        public override Menu createFlatWhite(bool HotOrCold, double price, double volume)
        {
            return new FlatWhiteWithBananaSyrup(HotOrCold, price, volume);
        }
        public override Menu createLatte(bool HotOrCold, double price, double volume)
        {
            return new LatteWithBananaSyrup(HotOrCold, price, volume);
        }
        public override Menu createRaf(bool HotOrCold, double price, double volume)
        {
            return new RafWithBananaSyrup(HotOrCold, price, volume);
        }
    }
    public class LavenderSyrupFactory : Coffee
    {
        public override Menu createAmericano(bool HotOrCold, double price, double volume)
        {
            return new AmericanoWithLavenderSyrup(HotOrCold, price, volume);
        }
        public override Menu createCappuccino(bool HotOrCold, double price, double volume)
        {
            return new CappuccinoWithLavenderSyrup(HotOrCold, price, volume);
        }
        public override Menu createFlatWhite(bool HotOrCold, double price, double volume)
        {
            return new FlatWhiteWithLavenderSyrup(HotOrCold, price, volume);
        }
        public override Menu createLatte(bool HotOrCold, double price, double volume)
        {
            return new LatteWithLavenderSyrup(HotOrCold, price, volume);
        }
        public override Menu createRaf(bool HotOrCold, double price, double volume)
        {
            return new RafWithLavenderSyrup(HotOrCold, price, volume);
        }
    }
    public class RaspberrySyrupFactory : Coffee
    {
        public override Menu createAmericano(bool HotOrCold, double price, double volume)
        {
            return new AmericanoWithRaspberrySyrup(HotOrCold, price, volume);
        }
        public override Menu createCappuccino(bool HotOrCold, double price, double volume)
        {
            return new CappuccinoWithRaspberrySyrup(HotOrCold, price, volume);
        }
        public override Menu createFlatWhite(bool HotOrCold, double price, double volume)
        {
            return new FlatWhiteWithRaspberrySyrup(HotOrCold, price, volume);
        }
        public override Menu createLatte(bool HotOrCold, double price, double volume)
        {
            return new LatteWithRaspberrySyrup(HotOrCold, price, volume);
        }
        public override Menu createRaf(bool HotOrCold, double price, double volume)
        {
            return new RafWithRaspberrySyrup(HotOrCold, price, volume);
        }
    }
    public class CaramelSyrupFactory : Coffee
    {
        public override Menu createAmericano(bool HotOrCold, double price, double volume)
        {
            return new AmericanoWithCaramelSyrup(HotOrCold, price, volume);
        }
        public override Menu createCappuccino(bool HotOrCold, double price, double volume)
        {
            return new CappuccinoWithCaramelSyrup(HotOrCold, price, volume);
        }
        public override Menu createFlatWhite(bool HotOrCold, double price, double volume)
        {
            return new FlatWhiteWithCaramelSyrup(HotOrCold, price, volume);
        }
        public override Menu createLatte(bool HotOrCold, double price, double volume)
        {
            return new LatteWithCaramelSyrup(HotOrCold, price, volume);
        }
        public override Menu createRaf(bool HotOrCold, double price, double volume)
        {
            return new RafWithCaramelSyrup(HotOrCold, price, volume);
        }
    }
    class AmericanoWithChocolateSyrup : Menu
    {
        public AmericanoWithChocolateSyrup (bool HotOrCold, double price, double volume)
        {
            this.HotOrCold = HotOrCold;
            this.price = price;
            this.volume = volume;
            this.description = "Американо с шоколадным сиропом";
        }
    }
    class AmericanoWithBananaSyrup : Menu
    {
        public AmericanoWithBananaSyrup (bool HotOrCold, double price, double volume)
        {
            this.HotOrCold = HotOrCold;
            this.price = price;
            this.volume = volume;
            this.description = "Американо с банановым сиропом";
        }
    }
    class AmericanoWithLavenderSyrup : Menu
    {
        public AmericanoWithLavenderSyrup (bool HotOrCold, double price, double volume)
        {
            this.HotOrCold = HotOrCold;
            this.price = price;
            this.volume = volume;
            this.description = "Американо с лавандовым сиропом";
        }
    }
    class AmericanoWithRaspberrySyrup : Menu
    {
        public AmericanoWithRaspberrySyrup (bool HotOrCold, double price, double volume)
        {
            this.HotOrCold = HotOrCold;
            this.price = price;
            this.volume = volume;
            this.description = "Американо с малиновым сиропом";
        }
    }
    class AmericanoWithCaramelSyrup : Menu
    {
        public AmericanoWithCaramelSyrup (bool HotOrCold, double price, double volume)
        {
            this.HotOrCold = HotOrCold;
            this.price = price;
            this.volume = volume;
            this.description = "Американо с карамельным сиропом";
        }
    }

    class CappuccinoWithChocolateSyrup : Menu
    {
        public CappuccinoWithChocolateSyrup (bool HotOrCold, double price, double volume)
        {
            this.HotOrCold = HotOrCold;
            this.price = price;
            this.volume = volume;
            this.description = "Капучино с шоколадным сиропом";
        }
    }
    class CappuccinoWithBananaSyrup : Menu
    {
        public CappuccinoWithBananaSyrup (bool HotOrCold, double price, double volume)
        {
            this.HotOrCold = HotOrCold;
            this.price = price;
            this.volume = volume;
            this.description = "Капучино с банановым сиропом";
        }
    }
    class CappuccinoWithLavenderSyrup : Menu
    {
        public CappuccinoWithLavenderSyrup (bool HotOrCold, double price, double volume)
        {
            this.HotOrCold = HotOrCold;
            this.price = price;
            this.volume = volume;
            this.description = "Капучино с лавандовым сиропом";
        }
    }
    class CappuccinoWithRaspberrySyrup : Menu
    {
        public CappuccinoWithRaspberrySyrup (bool HotOrCold, double price, double volume)
        {
            this.HotOrCold = HotOrCold;
            this.price = price;
            this.volume = volume;
            this.description = "Капучино с малиновым сиропом";
        }
    }
    class CappuccinoWithCaramelSyrup : Menu
    {
        public CappuccinoWithCaramelSyrup (bool HotOrCold, double price, double volume)
        {
            this.HotOrCold = HotOrCold;
            this.price = price;
            this.volume = volume;
            this.description = "Капучино с карамельным сиропом";
        }
    }

    class FlatWhiteWithChocolateSyrup : Menu
    {
        public FlatWhiteWithChocolateSyrup (bool HotOrCold, double price, double volume)
        {
            this.HotOrCold = HotOrCold;
            this.price = price;
            this.volume = volume;
            this.description = "Флэт Уайт с шоколадным сиропом";
        }
    }
    class FlatWhiteWithBananaSyrup : Menu
    {
        public FlatWhiteWithBananaSyrup (bool HotOrCold, double price, double volume)
        {
            this.HotOrCold = HotOrCold;
            this.price = price;
            this.volume = volume;
            this.description = "Флэт Уайт с банановым сиропом";
        }
    }
    class FlatWhiteWithLavenderSyrup : Menu
    {
        public FlatWhiteWithLavenderSyrup (bool HotOrCold, double price, double volume)
        {
            this.HotOrCold = HotOrCold;
            this.price = price;
            this.volume = volume;
            this.description = "Флэт Уайт с лавандовым сиропом";
        }
    }
    class FlatWhiteWithRaspberrySyrup : Menu
    {
        public FlatWhiteWithRaspberrySyrup (bool HotOrCold, double price, double volume)
        {
            this.HotOrCold = HotOrCold;
            this.price = price;
            this.volume = volume;
            this.description = "Флэт Уайт с малиновым сиропом";
        }
    }
    class FlatWhiteWithCaramelSyrup : Menu
    {
        public FlatWhiteWithCaramelSyrup (bool HotOrCold, double price, double volume)
        {
            this.HotOrCold = HotOrCold;
            this.price = price;
            this.volume = volume;
            this.description = "Флэт Уайт с карамельным сиропом";
        }
    }

    class LatteWithChocolateSyrup : Menu
    {
        public LatteWithChocolateSyrup (bool HotOrCold, double price, double volume)
        {
            this.HotOrCold = HotOrCold;
            this.price = price;
            this.volume = volume;
            this.description = "Латте с шоколадным сиропом";
        }
    }
    class LatteWithBananaSyrup : Menu
    {
        public LatteWithBananaSyrup (bool HotOrCold, double price, double volume)
        {
            this.HotOrCold = HotOrCold;
            this.price = price;
            this.volume = volume;
            this.description = "Латте с банановым сиропом";
        }
    }
    class LatteWithLavenderSyrup : Menu
    {
        public LatteWithLavenderSyrup (bool HotOrCold, double price, double volume)
        {
            this.HotOrCold = HotOrCold;
            this.price = price;
            this.volume = volume;
            this.description = "Латте с лавандовым сиропом";
        }
    }
    class LatteWithRaspberrySyrup : Menu
    {
        public LatteWithRaspberrySyrup (bool HotOrCold, double price, double volume)
        {
            this.HotOrCold = HotOrCold;
            this.price = price;
            this.volume = volume;
            this.description = "Латте с малиновым сиропом";
        }
    }
    class LatteWithCaramelSyrup : Menu
    {
        public LatteWithCaramelSyrup (bool HotOrCold, double price, double volume)
        {
            this.HotOrCold = HotOrCold;
            this.price = price;
            this.volume = volume;
            this.description = "Латте с карамельным сиропом";
        }
    }

    class RafWithChocolateSyrup : Menu
    {
        public RafWithChocolateSyrup (bool HotOrCold, double price, double volume)
        {
            this.HotOrCold = HotOrCold;
            this.price = price;
            this.volume = volume;
            this.description = "Раф с шоколадным сиропом";
        }
    }
    class RafWithBananaSyrup : Menu
    {
        public RafWithBananaSyrup (bool HotOrCold, double price, double volume)
        {
            this.HotOrCold = HotOrCold;
            this.price = price;
            this.volume = volume;
            this.description = "Раф с банановым сиропом";
        }
    }
    class RafWithLavenderSyrup : Menu
    {
        public RafWithLavenderSyrup (bool HotOrCold, double price, double volume)
        {
            this.HotOrCold = HotOrCold;
            this.price = price;
            this.volume = volume;
            this.description = "Раф с лавандовым сиропом";
        }
    }
    class RafWithRaspberrySyrup : Menu
    {
        public RafWithRaspberrySyrup (bool HotOrCold, double price, double volume)
        {
            this.HotOrCold = HotOrCold;
            this.price = price;
            this.volume = volume;
            this.description = "Раф с малиновым сиропом";
        }
    }
    class RafWithCaramelSyrup : Menu
    {
        public RafWithCaramelSyrup (bool HotOrCold, double price, double volume)
        {
            this.HotOrCold = HotOrCold;
            this.price = price;
            this.volume = volume;
            this.description = "Раф с карамельным сиропом";
        }
    }
}