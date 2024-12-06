using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuDLL
{
    /// <summary>
    /// Класс, представляющий десерт.
    /// </summary>
    public class Dessert : Menu
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Dessert"/>.
        /// </summary>
        /// <param name="price">Цена.</param>
        /// <param name="volume">Объем.</param>
        /// <param name="description">Описание.</param>
        public Dessert(double price, double volume, string description)
        {
            this.price = price;
            this.volume = volume;
            this.description = description;
        }
    }

}
