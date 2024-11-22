using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coffe_app.logic
{
    internal class User
    {
        private string Name { get; set; }

        public void ViewToMenu() { }

    }

    class Administrator: User
    {
        private int passwordPositionInTheDatabase;

        public void ViewToOrder() { }
        public void AlterOrder() { }
        public void AlterStatusOrder() { }
        public void ViewToStatistic() { }
    }

    class Registered : User 
    {
        private int passwordPositionInTheDatabase;
        private string phoneNumber;

        public void CreateOrder() { }
        public void AddToOrder() { }
        public void RemoveFromOrder() { }
        public void PlaceOrder() { }
        public void viewOrderStatus() { }
    }

    class Guest : User 
    {
        public void registered() { }
    }
}
