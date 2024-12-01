using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MenuDLL
{
    public class Order
    {
        public string username {  get; set; }

        public double price { get; set; }
        public int status { get; set; }          // принят - 1, готовится - 2, готов - 3, выдан - 4 
        public bool pay { get; set; }          // true - оплачен, false - не оплачен

        private Menu[] components { get; set; }

        public Order(string username, double price, Menu[] components) 
        { 
            this.username = username;
            this.price = price;
            this.components = components;

            this.status = 1;
            this.pay = false;
        }

        public void payment()           // метод оплаты товара
        {
            this.pay = true;
        }

        public void nextStatus()        // метод для обновления статуса заказа
        {
            this.status++;
            if(status == 4)
            {
                ////    СОХРАНЕНИЕ В АРХИВ
            }

        }
    }
}
