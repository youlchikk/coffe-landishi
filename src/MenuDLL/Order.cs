using System.Collections.Generic;
using System.Windows;

namespace MenuDLL
{
    /// <summary>
    /// Класс, представляющий заказ.
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Имя пользователя, сделавшего заказ.
        /// </summary>
        public string username { get; set; }

        /// <summary>
        /// Цена заказа.
        /// </summary>
        public double price { get; set; }

        /// <summary>
        /// Статус заказа (1 - принят, 2 - готовится, 3 - готов, 4 - выдан).
        /// </summary>
        public int status { get; set; } // принят - 1, готовится - 2, готов - 3, выдан - 4 

        /// <summary>
        /// Оплачен ли заказ (true - оплачен, false - не оплачен).
        /// </summary>
        public bool pay { get; set; } // true - оплачен, false - не оплачен

        /// <summary>
        /// Список компонентов заказа.
        /// </summary>
        public List<Menu> components { get; set; } = new List<Menu>();

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Order"/> без параметров.
        /// </summary>
        public Order() { }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Order"/> с заданными параметрами.
        /// </summary>
        /// <param name="username">Имя пользователя.</param>
        /// <param name="price">Цена заказа.</param>
        /// <param name="components">Список компонентов заказа.</param>
        public Order(string username, double price, List<Menu> components)
        {
            this.username = username;
            this.price = price;
            this.components = components;
            this.status = 1;
            this.pay = false;
        }

        /// <summary>
        /// Помечает заказ как оплаченный.
        /// </summary>
        public void payment()
        {
            this.pay = true;
        }

        /// <summary>
        /// Обновляет статус заказа.
        /// </summary>
        /// <param name="t">Новый статус заказа.</param>
        public void nextStatus(int t)
        {
            this.status = t;
        }

        /// <summary>
        /// Добавляет промоакцию к заказу.
        /// </summary>
        /// <param name="promotion">Промоакция для добавления.</param>
        public void addPromotion(Promotion promotion)
        {
            this.price += promotion.price;
            foreach (var item in promotion.components)
            {
                this.components.Add(item);
            }
        }
    }

}
