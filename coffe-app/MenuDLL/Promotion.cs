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
        public Menu[] structure { get; set; }
        public double price { get; set; }
        public string startDate { get; set; }
        public string endtDate { get; set; }

        public Promotion(string conditions, Menu[] structure, double price, string startDate, string endDate) 
        {
            this.conditions = conditions;
            this.structure = structure;
            this.price = price;
            this.startDate = startDate;
            this.endtDate = endDate;
        }

    }
}
