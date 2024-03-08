using PV_DatabaseProject_MatejBoska.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV_DatabaseProject_MatejBoska.Tabulky
{
    internal class Order : IBase
    {
        private int order_id;
        private int customer_id;
        private DateTime order_date;

        public int OrderID { get => order_id; set => order_id = value; }
        public int CustomerID { get => customer_id; set => customer_id = value; }
        public DateTime OrderDate { get => order_date; set => order_date = value; }
        public int ID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Order(int order_id, int customer_id, DateTime order_date)
        {
            this.order_id = order_id;
            this.customer_id = customer_id;
            this.order_date = order_date;
        }

        public Order(int customer_id, DateTime order_date)
        {
            this.order_id = 0;
            this.customer_id = customer_id;
            this.order_date = order_date;
        }

        public Order()
        {
        }

        public override string ToString()
        {
            return $"OrderID: {order_id}, CustomerID: {customer_id}, OrderDate: {order_date.ToString("yyyy-MM-dd HH:mm:ss")}";
        }
    }
}
