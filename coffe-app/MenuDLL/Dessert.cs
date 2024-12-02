using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuDLL
{
    public class Dessert: Menu
    {
        private double price { get; set; }
        private double volume { get; set; }
        private string description { get; set; }
        public Dessert(double price, double volume, string descriprion) 
        {
            this.price = price;
            this.volume = volume;   
            this.description = descriprion;
        }
    }
}
