using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MenuDLL;

namespace MenuDLL
{
    public class Promotion
    {
        public string conditions { get; set; }

        public List<MenuDLL.Menu> components = new List<MenuDLL.Menu>();
        public double price { get; set; }
        public string startDate { get; set; }
        public string endtDate { get; set; }

        public Promotion(string conditions, List <MenuDLL.Menu> structure, double price, string startDate, string endDate) 
        {
            this.conditions = conditions;
            for(int i = 0; i < structure.Count; i++)
            {
                components.Add(structure[i]);
            }
            this.price = price;
            this.startDate = startDate;
            this.endtDate = endDate;
        }

    }
}
