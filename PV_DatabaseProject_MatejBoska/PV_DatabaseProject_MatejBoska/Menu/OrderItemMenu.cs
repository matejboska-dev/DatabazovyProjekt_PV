using PV_DatabaseProject_MatejBoska.DAO;
using PV_DatabaseProject_MatejBoska.Tabulky;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV_DatabaseProject_MatejBoska.Menu
{
    internal class OrderItemMenu : MainMenuItem
    {
        private OrderItemDAO dao;

        public override string Header => "Order Item";

        public OrderItemMenu()
        {
            dao = new OrderItemDAO(); // Replace with your actual OrderItemDAO instantiation
            options = new()
            {
                {1, ("Insert", Insert) },
                {2, ("Update", Update) },
                {3, ("Delete", Delete) },
                {4, ("Print All", PrintAll<OrderItem, OrderItemDAO>) },
                {5, ("Exit", ()=>{}) }
            };
        }

        void Insert()
        {
            Console.WriteLine("Insert Order ID");
            if (!int.TryParse(Console.ReadLine(), out int orderID))
            {
                Console.WriteLine("Invalid input");
                return;
            }

            Console.WriteLine("Insert Product ID");
            if (!int.TryParse(Console.ReadLine(), out int productID))
            {
                Console.WriteLine("Invalid input");
                return;
            }

            Console.WriteLine("Insert Quantity");
            if (!int.TryParse(Console.ReadLine(), out int quantity))
            {
                Console.WriteLine("Invalid input");
                return;
            }

            Console.WriteLine("Insert Total Price");
            if (!float.TryParse(Console.ReadLine(), out float totalPrice))
            {
                Console.WriteLine("Invalid input");
                return;
            }

            dao.Save(new OrderItem(orderID, productID, quantity, totalPrice));
        }

        void Update()
        {
            Console.WriteLine("Insert ID");

            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid input");
                return;
            }

            OrderItem orderItem = dao.GetByID(id);

            Console.WriteLine("Insert Order ID");
            if (int.TryParse(Console.ReadLine(), out int orderID))
            {
                orderItem.OrderID = orderID;
            }

            Console.WriteLine("Insert Product ID");
            if (int.TryParse(Console.ReadLine(), out int productID))
            {
                orderItem.ProductID = productID;
            }

            Console.WriteLine("Insert Quantity");
            if (int.TryParse(Console.ReadLine(), out int quantity))
            {
                orderItem.Quantity = quantity;
            }

            Console.WriteLine("Insert Total Price");
            if (float.TryParse(Console.ReadLine(), out float totalPrice))
            {
                orderItem.TotalPrice = totalPrice;
            }

            dao.Save(orderItem);
        }

        void Delete()
        {
            Console.WriteLine("Insert ID");

            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid input");
                return;
            }

            OrderItem orderItem = dao.GetByID(id);
            dao.Delete(orderItem);
        }
    }
}
