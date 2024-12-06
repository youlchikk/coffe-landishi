using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuDLL { 
    /// <summary>
    /// Абстрактный класс, представляющий абстрактную фабрику по созданию кофе.
    /// </summary>
    public abstract class Coffee
    {
        /// <summary>
        /// Создает американо.
        /// </summary>
        /// <param name="HotOrCold">Горячий или холодный напиток.</param>
        /// <param name="price">Цена.</param>
        /// <param name="volume">Объем.</param>
        /// <returns>Объект типа <see cref="Menu"/>.</returns>
        public abstract Menu createAmericano(bool HotOrCold, double price, double volume);

        /// <summary>
        /// Создает капучино.
        /// </summary>
        /// <param name="HotOrCold">Горячий или холодный напиток.</param>
        /// <param name="price">Цена.</param>
        /// <param name="volume">Объем.</param>
        /// <returns>Объект типа <see cref="Menu"/>.</returns>
        public abstract Menu createCappuccino(bool HotOrCold, double price, double volume);

        /// <summary>
        /// Создает флэт уайт.
        /// </summary>
        /// <param name="HotOrCold">Горячий или холодный напиток.</param>
        /// <param name="price">Цена.</param>
        /// <param name="volume">Объем.</param>
        /// <returns>Объект типа <see cref="Menu"/>.</returns>
        public abstract Menu createFlatWhite(bool HotOrCold, double price, double volume);

        /// <summary>
        /// Создает латте.
        /// </summary>
        /// <param name="HotOrCold">Горячий или холодный напиток.</param>
        /// <param name="price">Цена.</param>
        /// <param name="volume">Объем.</param>
        /// <returns>Объект типа <see cref="Menu"/>.</returns>
        public abstract Menu createLatte(bool HotOrCold, double price, double volume);

        /// <summary>
        /// Создает раф.
        /// </summary>
        /// <param name="HotOrCold">Горячий или холодный напиток.</param>
        /// <param name="price">Цена.</param>
        /// <param name="volume">Объем.</param>
        /// <returns>Объект типа <see cref="Menu"/>.</returns>
        public abstract Menu createRaf(bool HotOrCold, double price, double volume);
    }

    /// <summary>
    /// Абстрактный класс, представляющий американо.
    /// </summary>
    public abstract class Americano : Menu { }

    /// <summary>
    /// Абстрактный класс, представляющий капучино.
    /// </summary>
    public abstract class Cappuccino : Menu { }

    /// <summary>
    /// Абстрактный класс, представляющий флэт уайт.
    /// </summary>
    public abstract class FlatWhite : Menu { }

    /// <summary>
    /// Абстрактный класс, представляющий латте.
    /// </summary>
    public abstract class Latte : Menu { }

    /// <summary>
    /// Абстрактный класс, представляющий раф.
    /// </summary>
    public abstract class Raf : Menu { }

    /// <summary>
    /// Класс, представляющий фабрику по созданию кофе с шоколадным сиропом.
    /// </summary>
    public class ChocolateSyrupFactory : Coffee
    {
        /// <summary>
        /// Создает американо с шоколадным сиропом.
        /// </summary>
        /// <param name="HotOrCold">Горячий или холодный напиток.</param>
        /// <param name="price">Цена.</param>
        /// <param name="volume">Объем.</param>
        /// <returns>Объект типа <see cref="Menu"/>.</returns>
        public override Menu createAmericano(bool HotOrCold, double price, double volume)
        {
            return new AmericanoWithChocolateSyrup(HotOrCold, price, volume);
        }

        /// <summary>
        /// Создает капучино с шоколадным сиропом.
        /// </summary>
        /// <param name="HotOrCold">Горячий или холодный напиток.</param>
        /// <param name="price">Цена.</param>
        /// <param name="volume">Объем.</param>
        /// <returns>Объект типа <see cref="Menu"/>.</returns>
        public override Menu createCappuccino(bool HotOrCold, double price, double volume)
        {
            return new CappuccinoWithChocolateSyrup(HotOrCold, price, volume);
        }

        /// <summary>
        /// Создает флэт уайт с шоколадным сиропом.
        /// </summary>
        /// <param name="HotOrCold">Горячий или холодный напиток.</param>
        /// <param name="price">Цена.</param>
        /// <param name="volume">Объем.</param>
        /// <returns>Объект типа <see cref="Menu"/>.</returns>
        public override Menu createFlatWhite(bool HotOrCold, double price, double volume)
        {
            return new FlatWhiteWithChocolateSyrup(HotOrCold, price, volume);
        }

        /// <summary>
        /// Создает латте с шоколадным сиропом.
        /// </summary>
        /// <param name="HotOrCold">Горячий или холодный напиток.</param>
        /// <param name="price">Цена.</param>
        /// <param name="volume">Объем.</param>
        /// <returns>Объект типа <see cref="Menu"/>.</returns>
        public override Menu createLatte(bool HotOrCold, double price, double volume)
        {
            return new LatteWithChocolateSyrup(HotOrCold, price, volume);
        }

        /// <summary>
        /// Создает раф с шоколадным сиропом.
        /// </summary>
        /// <param name="HotOrCold">Горячий или холодный напиток.</param>
        /// <param name="price">Цена.</param>
        /// <param name="volume">Объем.</param>
        /// <returns>Объект типа <see cref="Menu"/>.</returns>
        public override Menu createRaf(bool HotOrCold, double price, double volume)
        {
            return new RafWithChocolateSyrup(HotOrCold, price, volume);
        }
    }

    /// <summary>
    /// Класс, представляющий фабрику по созданию кофе с банановым сиропом.
    /// </summary>
    public class BananaSyrupFactory : Coffee
    {
        /// <summary>
        /// Создает американо с банановым сиропом.
        /// </summary>
        /// <param name="HotOrCold">Горячий или холодный напиток.</param>
        /// <param name="price">Цена.</param>
        /// <param name="volume">Объем.</param>
        /// <returns>Объект типа <see cref="Menu"/>.</returns>
        public override Menu createAmericano(bool HotOrCold, double price, double volume)
        {
            return new AmericanoWithBananaSyrup(HotOrCold, price, volume);
        }

        /// <summary>
        /// Создает капучино с банановым сиропом.
        /// </summary>
        /// <param name="HotOrCold">Горячий или холодный напиток.</param>
        /// <param name="price">Цена.</param>
        /// <param name="volume">Объем.</param>
        /// <returns>Объект типа <see cref="Menu"/>.</returns>
        public override Menu createCappuccino(bool HotOrCold, double price, double volume)
        {
            return new CappuccinoWithBananaSyrup(HotOrCold, price, volume);
        }

        /// <summary>
        /// Создает флэт уайт с банановым сиропом.
        /// </summary>
        /// <param name="HotOrCold">Горячий или холодный напиток.</param>
        /// <param name="price">Цена.</param>
        /// <param name="volume">Объем.</param>
        /// <returns>Объект типа <see cref="Menu"/>.</returns>
        public override Menu createFlatWhite(bool HotOrCold, double price, double volume)
        {
            return new FlatWhiteWithBananaSyrup(HotOrCold, price, volume);
        }

        /// <summary>
        /// Создает латте с банановым сиропом.
        /// </summary>
        /// <param name="HotOrCold">Горячий или холодный напиток.</param>
        /// <param name="price">Цена.</param>
        /// <param name="volume">Объем.</param>
        /// <returns>Объект типа <see cref="Menu"/>.</returns>
        public override Menu createLatte(bool HotOrCold, double price, double volume)
        {
            return new LatteWithBananaSyrup(HotOrCold, price, volume);
        }

        /// <summary>
        /// Создает раф с банановым сиропом.
        /// </summary>
        /// <param name="HotOrCold">Горячий или холодный напиток.</param>
        /// <param name="price">Цена.</param>
        /// <param name="volume">Объем.</param>
        /// <returns>Объект типа <see cref="Menu"/>.</returns>
        public override Menu createRaf(bool HotOrCold, double price, double volume)
        {
            return new RafWithBananaSyrup(HotOrCold, price, volume);
        }
    }

    /// <summary>
    /// Класс, представляющий фабрику по созданию кофе с лавандовым сиропом.
    /// </summary>
    public class LavenderSyrupFactory : Coffee
    {
        /// <summary>
        /// Создает американо с лавандовым сиропом.
        /// </summary>
        /// <param name="HotOrCold">Горячий или холодный напиток.</param>
        /// <param name="price">Цена.</param>
        /// <param name="volume">Объем.</param>
        /// <returns>Объект типа <see cref="Menu"/>.</returns>
        public override Menu createAmericano(bool HotOrCold, double price, double volume)
        {
            return new AmericanoWithLavenderSyrup(HotOrCold, price, volume);
        }

        /// <summary>
        /// Создает капучино с лавандовым сиропом.
        /// </summary>
        /// <param name="HotOrCold">Горячий или холодный напиток.</param>
        /// <param name="price">Цена.</param>
        /// <param name="volume">Объем.</param>
        /// <returns>Объект типа <see cref="Menu"/>.</returns>
        public override Menu createCappuccino(bool HotOrCold, double price, double volume)
        {
            return new CappuccinoWithLavenderSyrup(HotOrCold, price, volume);
        }

        /// <summary>
        /// Создает флэт уайт с лавандовым сиропом.
        /// </summary>
        /// <param name="HotOrCold">Горячий или холодный напиток.</param>
        /// <param name="price">Цена.</param>
        /// <param name="volume">Объем.</param>
        /// <returns>Объект типа <see cref="Menu"/>.</returns>
        public override Menu createFlatWhite(bool HotOrCold, double price, double volume)
        {
            return new FlatWhiteWithLavenderSyrup(HotOrCold, price, volume);
        }

        /// <summary>
        /// Создает латте с лавандовым сиропом.
        /// </summary>
        /// <param name="HotOrCold">Горячий или холодный напиток.</param>
        /// <param name="price">Цена.</param>
        /// <param name="volume">Объем.</param>
        /// <returns>Объект типа <see cref="Menu"/>.</returns>
        public override Menu createLatte(bool HotOrCold, double price, double volume)
        {
            return new LatteWithLavenderSyrup(HotOrCold, price, volume);
        }

        /// <summary>
        /// Создает раф с лавандовым сиропом.
        /// </summary>
        /// <param name="HotOrCold">Горячий или холодный напиток.</param>
        /// <param name="price">Цена.</param>
        /// <param name="volume">Объем.</param>
        /// <returns>Объект типа <see cref="Menu"/>.</returns>
        public override Menu createRaf(bool HotOrCold, double price, double volume)
        {
            return new RafWithLavenderSyrup(HotOrCold, price, volume);
        }
    }

    /// <summary>
    /// Класс, представляющий фабрику по созданию кофе с малиновым сиропом.
    /// </summary>
    public class RaspberrySyrupFactory : Coffee
    {
        /// <summary>
        /// Создает американо с малиновым сиропом.
        /// </summary>
        /// <param name="HotOrCold">Горячий или холодный напиток.</param>
        /// <param name="price">Цена.</param>
        /// <param name="volume">Объем.</param>
        /// <returns>Объект типа <see cref="Menu"/>.</returns>
        public override Menu createAmericano(bool HotOrCold, double price, double volume)
        {
            return new AmericanoWithRaspberrySyrup(HotOrCold, price, volume);
        }

        /// <summary>
        /// Создает капучино с малиновым сиропом.
        /// </summary>
        /// <param name="HotOrCold">Горячий или холодный напиток.</param>
        /// <param name="price">Цена.</param>
        /// <param name="volume">Объем.</param>
        /// <returns>Объект типа <see cref="Menu"/>.</returns>
        public override Menu createCappuccino(bool HotOrCold, double price, double volume)
        {
            return new CappuccinoWithRaspberrySyrup(HotOrCold, price, volume);
        }

        /// <summary>
        /// Создает флэт уайт с малиновым сиропом.
        /// </summary>
        /// <param name="HotOrCold">Горячий или холодный напиток.</param>
        /// <param name="price">Цена.</param>
        /// <param name="volume">Объем.</param>
        /// <returns>Объект типа <see cref="Menu"/>.</returns>
        public override Menu createFlatWhite(bool HotOrCold, double price, double volume)
        {
            return new FlatWhiteWithRaspberrySyrup(HotOrCold, price, volume);
        }

        /// <summary>
        /// Создает латте с малиновым сиропом.
        /// </summary>
        /// <param name="HotOrCold">Горячий или холодный напиток.</param>
        /// <param name="price">Цена.</param>
        /// <param name="volume">Объем.</param>
        /// <returns>Объект типа <see cref="Menu"/>.</returns>
        public override Menu createLatte(bool HotOrCold, double price, double volume)
        {
            return new LatteWithRaspberrySyrup(HotOrCold, price, volume);
        }

        /// <summary>
        /// Создает раф с малиновым сиропом.
        /// </summary>
        /// <param name="HotOrCold">Горячий или холодный напиток.</param>
        /// <param name="price">Цена.</param>
        /// <param name="volume">Объем.</param>
        /// <returns>Объект типа <see cref="Menu"/>.</returns>
        public override Menu createRaf(bool HotOrCold, double price, double volume)
        {
            return new RafWithRaspberrySyrup(HotOrCold, price, volume);
        }
    }

    public class CaramelSyrupFactory : Coffee
        {
            /// <summary>
            /// Создает американо с карамельным сиропом.
            /// </summary>
            /// <param name="HotOrCold">Горячий или холодный напиток.</param>
            /// <param name="price">Цена.</param>
            /// <param name="volume">Объем.</param>
            /// <returns>Объект типа <see cref="Menu"/>.</returns>
            public override Menu createAmericano(bool HotOrCold, double price, double volume)
            {
                return new AmericanoWithCaramelSyrup(HotOrCold, price, volume);
            }

            /// <summary>
            /// Создает капучино с карамельным сиропом.
            /// </summary>
            /// <param name="HotOrCold">Горячий или холодный напиток.</param>
            /// <param name="price">Цена.</param>
            /// <param name="volume">Объем.</param>
            /// <returns>Объект типа <see cref="Menu"/>.</returns>
            public override Menu createCappuccino(bool HotOrCold, double price, double volume)
            {
                return new CappuccinoWithCaramelSyrup(HotOrCold, price, volume);
            }

            /// <summary>
            /// Создает флэт уайт с карамельным сиропом.
            /// </summary>
            /// <param name="HotOrCold">Горячий или холодный напиток.</param>
            /// <param name="price">Цена.</param>
            /// <param name="volume">Объем.</param>
            /// <returns>Объект типа <see cref="Menu"/>.</returns>
            public override Menu createFlatWhite(bool HotOrCold, double price, double volume)
            {
                return new FlatWhiteWithCaramelSyrup(HotOrCold, price, volume);
            }

            /// <summary>
            /// Создает латте с карамельным сиропом.
            /// </summary>
            /// <param name="HotOrCold">Горячий или холодный напиток.</param>
            /// <param name="price">Цена.</param>
            /// <param name="volume">Объем.</param>
            /// <returns>Объект типа <see cref="Menu"/>.</returns>
            public override Menu createLatte(bool HotOrCold, double price, double volume)
            {
                return new LatteWithCaramelSyrup(HotOrCold, price, volume);
            }

            /// <summary>
            /// Создает раф с карамельным сиропом.
            /// </summary>
            /// <param name="HotOrCold">Горячий или холодный напиток.</param>
            /// <param name="price">Цена.</param>
            /// <param name="volume">Объем.</param>
            /// <returns>Объект типа <see cref="Menu"/>.</returns>
            public override Menu createRaf(bool HotOrCold, double price, double volume)
            {
                return new RafWithCaramelSyrup(HotOrCold, price, volume);
            }
        }

    /// <summary>
    /// Класс, представляющий американо с шоколадным сиропом.
    /// </summary>
    class AmericanoWithChocolateSyrup : Americano
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="AmericanoWithChocolateSyrup"/>.
        /// </summary>
        /// <param name="HotOrCold">Горячий или холодный напиток.</param>
        /// <param name="price">Цена.</param>
        /// <param name="volume">Объем.</param>
        public AmericanoWithChocolateSyrup(bool HotOrCold, double price, double volume)
        {
            this.HotOrCold = HotOrCold;
            this.price = price;
            this.volume = volume;
            this.description = "Американо с шоколадным сиропом";
        }
    }

    /// <summary>
    /// Класс, представляющий американо с банановым сиропом.
    /// </summary>
    class AmericanoWithBananaSyrup : Americano
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="AmericanoWithBananaSyrup"/>.
        /// </summary>
        /// <param name="HotOrCold">Горячий или холодный напиток.</param>
        /// <param name="price">Цена.</param>
        /// <param name="volume">Объем.</param>
        public AmericanoWithBananaSyrup(bool HotOrCold, double price, double volume)
        {
            this.HotOrCold = HotOrCold;
            this.price = price;
            this.volume = volume;
            this.description = "Американо с банановым сиропом";
        }
    }

    /// <summary>
    /// Класс, представляющий американо с лавандовым сиропом.
    /// </summary>
    class AmericanoWithLavenderSyrup : Americano
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="AmericanoWithLavenderSyrup"/>.
        /// </summary>
        /// <param name="HotOrCold">Горячий или холодный напиток.</param>
        /// <param name="price">Цена.</param>
        /// <param name="volume">Объем.</param>
        public AmericanoWithLavenderSyrup(bool HotOrCold, double price, double volume)
        {
            this.HotOrCold = HotOrCold;
            this.price = price;
            this.volume = volume;
            this.description = "Американо с лавандовым сиропом";
        }
    }

    /// <summary>
    /// Класс, представляющий американо с малиновым сиропом.
    /// </summary>
    class AmericanoWithRaspberrySyrup : Americano
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="AmericanoWithRaspberrySyrup"/>.
        /// </summary>
        /// <param name="HotOrCold">Горячий или холодный напиток.</param>
        /// <param name="price">Цена.</param>
        /// <param name="volume">Объем.</param>
        public AmericanoWithRaspberrySyrup(bool HotOrCold, double price, double volume)
        {
            this.HotOrCold = HotOrCold;
            this.price = price;
            this.volume = volume;
            this.description = "Американо с малиновым сиропом";
        }
    }

    /// <summary>
    /// Класс, представляющий американо с карамельным сиропом.
    /// </summary>
    class AmericanoWithCaramelSyrup : Americano
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="AmericanoWithCaramelSyrup"/>.
        /// </summary>
        /// <param name="HotOrCold">Горячий или холодный напиток.</param>
        /// <param name="price">Цена.</param>
        /// <param name="volume">Объем.</param>
        public AmericanoWithCaramelSyrup(bool HotOrCold, double price, double volume)
        {
            this.HotOrCold = HotOrCold;
            this.price = price;
            this.volume = volume;
            this.description = "Американо с карамельным сиропом";
        }
    }

    /// <summary>
    /// Класс, представляющий капучино с шоколадным сиропом.
    /// </summary>
    class CappuccinoWithChocolateSyrup : Cappuccino
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="CappuccinoWithChocolateSyrup"/>.
        /// </summary>
        /// <param name="HotOrCold">Горячий или холодный напиток.</param>
        /// <param name="price">Цена.</param>
        /// <param name="volume">Объем.</param>
        public CappuccinoWithChocolateSyrup(bool HotOrCold, double price, double volume)
        {
            this.HotOrCold = HotOrCold;
            this.price = price;
            this.volume = volume;
            this.description = "Капучино с шоколадным сиропом";
        }
    }

    /// <summary>
    /// Класс, представляющий капучино с банановым сиропом.
    /// </summary>
    class CappuccinoWithBananaSyrup : Cappuccino
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="CappuccinoWithBananaSyrup"/>.
        /// </summary>
        /// <param name="HotOrCold">Горячий или холодный напиток.</param>
        /// <param name="price">Цена.</param>
        /// <param name="volume">Объем.</param>
        public CappuccinoWithBananaSyrup(bool HotOrCold, double price, double volume)
        {
            this.HotOrCold = HotOrCold;
            this.price = price;
            this.volume = volume;
            this.description = "Капучино с банановым сиропом";
        }
    }

    /// <summary>
    /// Класс, представляющий капучино с лавандовым сиропом.
    /// </summary>
    class CappuccinoWithLavenderSyrup : Cappuccino
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="CappuccinoWithLavenderSyrup"/>.
        /// </summary>
        /// <param name="HotOrCold">Горячий или холодный напиток.</param>
        /// <param name="price">Цена.</param>
        /// <param name="volume">Объем.</param>
        public CappuccinoWithLavenderSyrup(bool HotOrCold, double price, double volume)
        {
            this.HotOrCold = HotOrCold;
            this.price = price;
            this.volume = volume;
            this.description = "Капучино с лавандовым сиропом";
        }
    }

    /// <summary>
    /// Класс, представляющий капучино с малиновым сиропом.
    /// </summary>
    class CappuccinoWithRaspberrySyrup : Cappuccino
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="CappuccinoWithRaspberrySyrup"/>.
        /// </summary>
        /// <param name="HotOrCold">Горячий или холодный напиток.</param>
        /// <param name="price">Цена.</param>
        /// <param name="volume">Объем.</param>
        public CappuccinoWithRaspberrySyrup(bool HotOrCold, double price, double volume)
        {
            this.HotOrCold = HotOrCold;
            this.price = price;
            this.volume = volume;
            this.description = "Капучино с малиновым сиропом";
        }
    }

    /// <summary>
    /// Класс, представляющий капучино с карамельным сиропом.
    /// </summary>
    class CappuccinoWithCaramelSyrup : Cappuccino
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="CappuccinoWithCaramelSyrup"/>.
        /// </summary>
        /// <param name="HotOrCold">Горячий или холодный напиток.</param>
        /// <param name="price">Цена.</param>
        /// <param name="volume">Объем.</param>
        public CappuccinoWithCaramelSyrup(bool HotOrCold, double price, double volume)
        {
            this.HotOrCold = HotOrCold;
            this.price = price;
            this.volume = volume;
            this.description = "Капучино с карамельным сиропом";
        }
    }


    /// <summary>
    /// Класс, представляющий флэт уайт с шоколадным сиропом.
    /// </summary>
    class FlatWhiteWithChocolateSyrup : FlatWhite
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="FlatWhiteWithChocolateSyrup"/>.
        /// </summary>
        /// <param name="HotOrCold">Горячий или холодный напиток.</param>
        /// <param name="price">Цена.</param>
        /// <param name="volume">Объем.</param>
        public FlatWhiteWithChocolateSyrup(bool HotOrCold, double price, double volume)
        {
            this.HotOrCold = HotOrCold;
            this.price = price;
            this.volume = volume;
            this.description = "Флэт Уайт с шоколадным сиропом";
        }
    }

    /// <summary>
    /// Класс, представляющий флэт уайт с банановым сиропом.
    /// </summary>
    class FlatWhiteWithBananaSyrup : FlatWhite
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="FlatWhiteWithBananaSyrup"/>.
        /// </summary>
        /// <param name="HotOrCold">Горячий или холодный напиток.</param>
        /// <param name="price">Цена.</param>
        /// <param name="volume">Объем.</param>
        public FlatWhiteWithBananaSyrup(bool HotOrCold, double price, double volume)
        {
            this.HotOrCold = HotOrCold;
            this.price = price;
            this.volume = volume;
            this.description = "Флэт Уайт с банановым сиропом";
        }
    }

    /// <summary>
    /// Класс, представляющий флэт уайт с лавандовым сиропом.
    /// </summary>
    class FlatWhiteWithLavenderSyrup : FlatWhite
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="FlatWhiteWithLavenderSyrup"/>.
        /// </summary>
        /// <param name="HotOrCold">Горячий или холодный напиток.</param>
        /// <param name="price">Цена.</param>
        /// <param name="volume">Объем.</param>
        public FlatWhiteWithLavenderSyrup(bool HotOrCold, double price, double volume)
        {
            this.HotOrCold = HotOrCold;
            this.price = price;
            this.volume = volume;
            this.description = "Флэт Уайт с лавандовым сиропом";
        }
    }

    /// <summary>
    /// Класс, представляющий флэт уайт с малиновым сиропом.
    /// </summary>
    class FlatWhiteWithRaspberrySyrup : FlatWhite
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="FlatWhiteWithRaspberrySyrup"/>.
        /// </summary>
        /// <param name="HotOrCold">Горячий или холодный напиток.</param>
        /// <param name="price">Цена.</param>
        /// <param name="volume">Объем.</param>
        public FlatWhiteWithRaspberrySyrup(bool HotOrCold, double price, double volume)
        {
            this.HotOrCold = HotOrCold;
            this.price = price;
            this.volume = volume;
            this.description = "Флэт Уайт с малиновым сиропом";
        }
    }

    /// <summary>
    /// Класс, представляющий флэт уайт с карамельным сиропом.
    /// </summary>
    class FlatWhiteWithCaramelSyrup : FlatWhite
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="FlatWhiteWithCaramelSyrup"/>.
        /// </summary>
        /// <param name="HotOrCold">Горячий или холодный напиток.</param>
        /// <param name="price">Цена.</param>
        /// <param name="volume">Объем.</param>
        public FlatWhiteWithCaramelSyrup(bool HotOrCold, double price, double volume)
        {
            this.HotOrCold = HotOrCold;
            this.price = price;
            this.volume = volume;
            this.description = "Флэт Уайт с карамельным сиропом";
        }
    }


    /// <summary>
    /// Класс, представляющий латте с шоколадным сиропом.
    /// </summary>
    class LatteWithChocolateSyrup : Latte
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="LatteWithChocolateSyrup"/>.
        /// </summary>
        /// <param name="HotOrCold">Горячий или холодный напиток.</param>
        /// <param name="price">Цена.</param>
        /// <param name="volume">Объем.</param>
        public LatteWithChocolateSyrup(bool HotOrCold, double price, double volume)
        {
            this.HotOrCold = HotOrCold;
            this.price = price;
            this.volume = volume;
            this.description = "Латте с шоколадным сиропом";
        }
    }

    /// <summary>
    /// Класс, представляющий латте с банановым сиропом.
    /// </summary>
    class LatteWithBananaSyrup : Latte
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="LatteWithBananaSyrup"/>.
        /// </summary>
        /// <param name="HotOrCold">Горячий или холодный напиток.</param>
        /// <param name="price">Цена.</param>
        /// <param name="volume">Объем.</param>
        public LatteWithBananaSyrup(bool HotOrCold, double price, double volume)
        {
            this.HotOrCold = HotOrCold;
            this.price = price;
            this.volume = volume;
            this.description = "Латте с банановым сиропом";
        }
    }

    /// <summary>
    /// Класс, представляющий латте с лавандовым сиропом.
    /// </summary>
    class LatteWithLavenderSyrup : Latte
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="LatteWithLavenderSyrup"/>.
        /// </summary>
        /// <param name="HotOrCold">Горячий или холодный напиток.</param>
        /// <param name="price">Цена.</param>
        /// <param name="volume">Объем.</param>
        public LatteWithLavenderSyrup(bool HotOrCold, double price, double volume)
        {
            this.HotOrCold = HotOrCold;
            this.price = price;
            this.volume = volume;
            this.description = "Латте с лавандовым сиропом";
        }
    }

    /// <summary>
    /// Класс, представляющий латте с малиновым сиропом.
    /// </summary>
    class LatteWithRaspberrySyrup : Latte
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="LatteWithRaspberrySyrup"/>.
        /// </summary>
        /// <param name="HotOrCold">Горячий или холодный напиток.</param>
        /// <param name="price">Цена.</param>
        /// <param name="volume">Объем.</param>
        public LatteWithRaspberrySyrup(bool HotOrCold, double price, double volume)
        {
            this.HotOrCold = HotOrCold;
            this.price = price;
            this.volume = volume;
            this.description = "Латте с малиновым сиропом";
        }
    }

    /// <summary>
    /// Класс, представляющий латте с карамельным сиропом.
    /// </summary>
    class LatteWithCaramelSyrup : Latte
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="LatteWithCaramelSyrup"/>.
        /// </summary>
        /// <param name="HotOrCold">Горячий или холодный напиток.</param>
        /// <param name="price">Цена.</param>
        /// <param name="volume">Объем.</param>
        public LatteWithCaramelSyrup(bool HotOrCold, double price, double volume)
        {
            this.HotOrCold = HotOrCold;
            this.price = price;
            this.volume = volume;
            this.description = "Латте с карамельным сиропом";
        }
    }

    /// <summary>
    /// Класс, представляющий раф с шоколадным сиропом.
    /// </summary>
    class RafWithChocolateSyrup : Raf
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="RafWithChocolateSyrup"/>.
        /// </summary>
        /// <param name="HotOrCold">Горячий или холодный напиток.</param>
        /// <param name="price">Цена.</param>
        /// <param name="volume">Объем.</param>
        public RafWithChocolateSyrup(bool HotOrCold, double price, double volume)
        {
            this.HotOrCold = HotOrCold;
            this.price = price;
            this.volume = volume;
            this.description = "Раф с шоколадным сиропом";
        }
    }

    /// <summary>
    /// Класс, представляющий раф с банановым сиропом.
    /// </summary>
    class RafWithBananaSyrup : Raf
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="RafWithBananaSyrup"/>.
        /// </summary>
        /// <param name="HotOrCold">Горячий или холодный напиток.</param>
        /// <param name="price">Цена.</param>
        /// <param name="volume">Объем.</param>
        public RafWithBananaSyrup(bool HotOrCold, double price, double volume)
        {
            this.HotOrCold = HotOrCold;
            this.price = price;
            this.volume = volume;
            this.description = "Раф с банановым сиропом";
        }
    }

    /// <summary>
    /// Класс, представляющий раф с лавандовым сиропом.
    /// </summary>
    class RafWithLavenderSyrup : Raf
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="RafWithLavenderSyrup"/>.
        /// </summary>
        /// <param name="HotOrCold">Горячий или холодный напиток.</param>
        /// <param name="price">Цена.</param>
        /// <param name="volume">Объем.</param>
        public RafWithLavenderSyrup(bool HotOrCold, double price, double volume)
        {
            this.HotOrCold = HotOrCold;
            this.price = price;
            this.volume = volume;
            this.description = "Раф с лавандовым сиропом";
        }
    }

    /// <summary>
    /// Класс, представляющий раф с малиновым сиропом.
    /// </summary>
    class RafWithRaspberrySyrup : Raf
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="RafWithRaspberrySyrup"/>.
        /// </summary>
        /// <param name="HotOrCold">Горячий или холодный напиток.</param>
        /// <param name="price">Цена.</param>
        /// <param name="volume">Объем.</param>
        public RafWithRaspberrySyrup(bool HotOrCold, double price, double volume)
        {
            this.HotOrCold = HotOrCold;
            this.price = price;
            this.volume = volume;
            this.description = "Раф с малиновым сиропом";
        }
    }

    /// <summary>
    /// Класс, представляющий раф с карамельным сиропом.
    /// </summary>
    class RafWithCaramelSyrup : Raf
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="RafWithCaramelSyrup"/>.
        /// </summary>
        /// <param name="HotOrCold">Горячий или холодный напиток.</param>
        /// <param name="price">Цена.</param>
        /// <param name="volume">Объем.</param>
        public RafWithCaramelSyrup(bool HotOrCold, double price, double volume)
        {
            this.HotOrCold = HotOrCold;
            this.price = price;
            this.volume = volume;
            this.description = "Раф с карамельным сиропом";
        }
    }

}