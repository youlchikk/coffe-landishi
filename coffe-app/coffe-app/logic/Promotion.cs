using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MenuDLL;

namespace coffe_app.logic
{
    internal class Promotion
    {
        public string conditions { get; set; }
        public Menu[] structure { get; set; }
        public string price { get; set; }
        public string startDate { get; set; }
        public string endtDate { get; set; }

        public Promotion() { }

        public void AddToTheOrder() { }

        public void RemovePromotion() { }

    }
}
