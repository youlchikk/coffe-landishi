using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuDLL
{
    /// <summary>
    /// Абстрактный класс, представляющий лимонад.
    /// </summary>
    public abstract class Lemonade : Menu { }

    /// <summary>
    /// Класс, представляющий лимонад без сиропа.
    /// </summary>
    public class LemonadeWithoutSyrup : Lemonade
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="LemonadeWithoutSyrup"/>.
        /// </summary>
        /// <param name="HotOrCold">Горячий или холодный напиток.</param>
        /// <param name="price">Цена.</param>
        /// <param name="volume">Объем.</param>
        public LemonadeWithoutSyrup(bool HotOrCold, double price, double volume)
        {
            this.HotOrCold = HotOrCold;
            this.price = price;
            this.volume = volume;
            this.description = "Лимонад";
        }
    }

    /// <summary>
    /// Класс, представляющий лимонад с шоколадным сиропом.
    /// </summary>
    public class LemonadeWithChocolateSyrup : Lemonade
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="LemonadeWithChocolateSyrup"/>.
        /// </summary>
        /// <param name="HotOrCold">Горячий или холодный напиток.</param>
        /// <param name="price">Цена.</param>
        /// <param name="volume">Объем.</param>
        public LemonadeWithChocolateSyrup(bool HotOrCold, double price, double volume)
        {
            this.HotOrCold = HotOrCold;
            this.price = price;
            this.volume = volume;
            this.description = "Лимонад с шоколадом";
        }
    }

    /// <summary>
    /// Класс, представляющий банановый лимонад.
    /// </summary>
    public class LemonadeWithBananaSyrup : Lemonade
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="LemonadeWithBananaSyrup"/>.
        /// </summary>
        /// <param name="HotOrCold">Горячий или холодный напиток.</param>
        /// <param name="price">Цена.</param>
        /// <param name="volume">Объем.</param>
        public LemonadeWithBananaSyrup(bool HotOrCold, double price, double volume)
        {
            this.HotOrCold = HotOrCold;
            this.price = price;
            this.volume = volume;
            this.description = "Банановый лимонад";
        }
    }

    /// <summary>
    /// Класс, представляющий лавандовый лимонад.
    /// </summary>
    public class LemonadeWithLavenderSyrup : Lemonade
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="LemonadeWithLavenderSyrup"/>.
        /// </summary>
        /// <param name="HotOrCold">Горячий или холодный напиток.</param>
        /// <param name="price">Цена.</param>
        /// <param name="volume">Объем.</param>
        public LemonadeWithLavenderSyrup(bool HotOrCold, double price, double volume)
        {
            this.HotOrCold = HotOrCold;
            this.price = price;
            this.volume = volume;
            this.description = "Лавандовый лимонад";
        }
    }

    /// <summary>
    /// Класс, представляющий лимонад с малиновым сиропом.
    /// </summary>
    public class LemonadeWithRaspberrySyrup : Lemonade
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="LemonadeWithRaspberrySyrup"/>.
        /// </summary>
        /// <param name="HotOrCold">Горячий или холодный напиток.</param>
        /// <param name="price">Цена.</param>
        /// <param name="volume">Объем.</param>
        public LemonadeWithRaspberrySyrup(bool HotOrCold, double price, double volume)
        {
            this.HotOrCold = HotOrCold;
            this.price = price;
            this.volume = volume;
            this.description = "Лимонад с малиной";
        }
    }

    /// <summary>
    /// Класс, представляющий лимонад с карамельным сиропом.
    /// </summary>
    public class LemonadeWithCaramelSyrup : Lemonade
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="LemonadeWithCaramelSyrup"/>.
        /// </summary>
        /// <param name="HotOrCold">Горячий или холодный напиток.</param>
        /// <param name="price">Цена.</param>
        /// <param name="volume">Объем.</param>
        public LemonadeWithCaramelSyrup(bool HotOrCold, double price, double volume)
        {
            this.HotOrCold = HotOrCold;
            this.price = price;
            this.volume = volume;
            this.description = "Лимонад с карамелью";
        }
    }

}
