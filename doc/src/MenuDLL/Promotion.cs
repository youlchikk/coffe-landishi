using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MenuDLL;

namespace MenuDLL
{
    /// <summary>
    /// Класс, представляющий промоакцию.
    /// </summary>
    public class Promotion
    {
        /// <summary>
        /// Условия промоакции.
        /// </summary>
        public string conditions { get; set; }

        /// <summary>
        /// Список компонентов промоакции.
        /// </summary>
        public List<MenuDLL.Menu> components = new List<MenuDLL.Menu>();

        /// <summary>
        /// Цена промоакции.
        /// </summary>
        public double price { get; set; }

        /// <summary>
        /// Дата начала промоакции.
        /// </summary>
        public string startDate { get; set; }

        /// <summary>
        /// Дата окончания промоакции.
        /// </summary>
        public string endtDate { get; set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Promotion"/> с заданными параметрами.
        /// </summary>
        /// <param name="conditions">Условия промоакции.</param>
        /// <param name="structure">Список компонентов промоакции.</param>
        /// <param name="price">Цена промоакции.</param>
        /// <param name="startDate">Дата начала промоакции.</param>
        /// <param name="endDate">Дата окончания промоакции.</param>
        public Promotion(string conditions, List<MenuDLL.Menu> structure, double price, string startDate, string endDate)
        {
            this.conditions = conditions;
            for (int i = 0; i < structure.Count; i++)
            {
                components.Add(structure[i]);
            }
            this.price = price;
            this.startDate = startDate;
            this.endtDate = endDate;
        }
    }

}
