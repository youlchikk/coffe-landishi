using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuDLL
{
    public class Dessert: Menu
    {
       
        public Dessert(double price, double volume, string description) 
        {
            this.price = price;
            this.volume = volume;   
            this.description = description;
        }
    }
}
