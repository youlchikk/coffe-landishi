using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuDLL
{
    /// <summary>
    /// Класс, представляющий меню.
    /// </summary>
    public class Menu
    {
        /// <summary>
        /// Цена.
        /// </summary>
        public double price { get; set; }

        /// <summary>
        /// Объем.
        /// </summary>
        public double volume { get; set; }

        /// <summary>
        /// Горячий или холодный напиток.
        /// </summary>
        public bool HotOrCold { get; set; }

        /// <summary>
        /// Описание.
        /// </summary>
        public string description { get; set; }
    }

}
