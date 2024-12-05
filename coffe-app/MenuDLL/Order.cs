using System.Collections.Generic;
using System.Windows;

namespace MenuDLL
{
    public class Order
    {
        public string username { get; set; }
        public double price { get; set; }
        public int status { get; set; } // принят - 1, готовится - 2, готов - 3, выдан - 4 
        public bool pay { get; set; } // true - оплачен, false - не оплачен
        public List<Menu> components { get; set; } = new List<Menu>();

        // Параметрless конструктор
        public Order() { }
         public Order(string username, double price, List<Menu> components)
        {
            this.username = username;
            this.price = price;
            this.components = components;
            this.status = 1;
            this.pay = false;
        }

        public void payment()
        {
            this.pay = true;
        }

        public void nextStatus(int t)
        {
            this.status = t;
        }

        public void addPromotion(Promotion promotion)
        {
            this.price += promotion.price;
            MessageBox.Show("addPromotion");
            foreach (var item in promotion.components)
            {
                this.components.Add(item);
            }
        }
    }
}
