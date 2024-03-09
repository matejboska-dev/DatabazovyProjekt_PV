using PV_DatabaseProject_MatejBoska.DAO;
using PV_DatabaseProject_MatejBoska.Tabulky;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV_DatabaseProject_MatejBoska.Menu
{
    internal class OrderMenu : MainMenuItem
    {
        private OrderDAO dao;

        public override string Header => "Order";

        public OrderMenu()
        {
            dao = new();
            options = new()
            {
                {1, ("Insert", Insert) },
                {2, ("Update", Update) },
                {3, ("Delete", Delete) },
                {4, ("Print All", PrintAll<Order, OrderDAO>) },
                {5, ("Exit", ()=>{}) }
            };
        }

        void Insert()
        {
            Console.WriteLine("Insert Customer ID");
            if (!int.TryParse(Console.ReadLine(), out int customerID))
            {
                Console.WriteLine("Invalid input");
                return;
            }

            Console.WriteLine("Insert Order Date (YYYY-MM-DD HH:mm:ss)");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime orderDate))
            {
                Console.WriteLine("Invalid input");
                return;
            }

            dao.Save(new Order(customerID, orderDate));
        }

        void Update()
        {
            Console.WriteLine("Insert ID");

            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid input");
                return;
            }

            Order order = dao.GetByID(id);

            Console.WriteLine("Insert Customer ID");
            if (int.TryParse(Console.ReadLine(), out int customerID))
            {
                order.CustomerID = customerID;
            }

            Console.WriteLine("Insert Order Date (YYYY-MM-DD HH:mm:ss)");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime orderDate))
            {
                order.OrderDate = orderDate;
            }

            dao.Save(order);
        }

        void Delete()
        {
            Console.WriteLine("Insert ID");

            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid input");
                return;
            }

            Order order = dao.GetByID(id);
            dao.Delete(order);
        }
    }
}
