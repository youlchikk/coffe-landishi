using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuDLL
{
    /// <summary>
    /// Абстрактный класс, представляющий чай.
    /// </summary>
    public abstract class Tea : Menu { }

    /// <summary>
    /// Класс, представляющий чай без сиропа.
    /// </summary>
    public class TeaWithoutSyrup : Tea
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="TeaWithoutSyrup"/>.
        /// </summary>
        /// <param name="HotOrCold">Горячий или холодный напиток.</param>
        /// <param name="price">Цена.</param>
        /// <param name="volume">Объем.</param>
        public TeaWithoutSyrup(bool HotOrCold, double price, double volume)
        {
            this.HotOrCold = HotOrCold;
            this.price = price;
            this.volume = volume;
            this.description = "Чай";
        }
    }

    /// <summary>
    /// Класс, представляющий чай с шоколадным сиропом.
    /// </summary>
    public class TeaWithChocolateSyrup : Tea
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="TeaWithChocolateSyrup"/>.
        /// </summary>
        /// <param name="HotOrCold">Горячий или холодный напиток.</param>
        /// <param name="price">Цена.</param>
        /// <param name="volume">Объем.</param>
        public TeaWithChocolateSyrup(bool HotOrCold, double price, double volume)
        {
            this.HotOrCold = HotOrCold;
            this.price = price;
            this.volume = volume;
            this.description = "Чай с шоколадом";
        }
    }

    /// <summary>
    /// Класс, представляющий чай с банановым сиропом.
    /// </summary>
    public class TeaWithBananaSyrup : Tea
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="TeaWithBananaSyrup"/>.
        /// </summary>
        /// <param name="HotOrCold">Горячий или холодный напиток.</param>
        /// <param name="price">Цена.</param>
        /// <param name="volume">Объем.</param>
        public TeaWithBananaSyrup(bool HotOrCold, double price, double volume)
        {
            this.HotOrCold = HotOrCold;
            this.price = price;
            this.volume = volume;
            this.description = "Чай с бананом";
        }
    }

    /// <summary>
    /// Класс, представляющий чай с лавандовым сиропом.
    /// </summary>
    public class TeaWithLavenderSyrup : Tea
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="TeaWithLavenderSyrup"/>.
        /// </summary>
        /// <param name="HotOrCold">Горячий или холодный напиток.</param>
        /// <param name="price">Цена.</param>
        /// <param name="volume">Объем.</param>
        public TeaWithLavenderSyrup(bool HotOrCold, double price, double volume)
        {
            this.HotOrCold = HotOrCold;
            this.price = price;
            this.volume = volume;
            this.description = "Чай с лавандой";
        }
    }

    /// <summary>
    /// Класс, представляющий чай с малиновым сиропом.
    /// </summary>
    public class TeaWithRaspberrySyrup : Tea
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="TeaWithRaspberrySyrup"/>.
        /// </summary>
        /// <param name="HotOrCold">Горячий или холодный напиток.</param>
        /// <param name="price">Цена.</param>
        /// <param name="volume">Объем.</param>
        public TeaWithRaspberrySyrup(bool HotOrCold, double price, double volume)
        {
            this.HotOrCold = HotOrCold;
            this.price = price;
            this.volume = volume;
            this.description = "Чай с малиной";
        }
    }

    /// <summary>
    /// Класс, представляющий чай с карамельным сиропом.
    /// </summary>
    public class TeaWithCaramelSyrup : Tea
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="TeaWithCaramelSyrup"/>.
        /// </summary>
        /// <param name="HotOrCold">Горячий или холодный напиток.</param>
        /// <param name="price">Цена.</param>
        /// <param name="volume">Объем.</param>
        public TeaWithCaramelSyrup(bool HotOrCold, double price, double volume)
        {
            this.HotOrCold = HotOrCold;
            this.price = price;
            this.volume = volume;
            this.description = "Чай с карамелью";
        }
    }

}
