using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV_DatabaseProject_MatejBoska.Tabulky
{
    internal class OrderItem
    {
        private int order_item_id;
        private int order_id;
        private int product_id;
        private int quantity;
        private float total_price;

        public int OrderItemID { get => order_item_id; set => order_item_id = value; }
        public int OrderID { get => order_id; set => order_id = value; }
        public int ProductID { get => product_id; set => product_id = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public float TotalPrice { get => total_price; set => total_price = value; }

        public OrderItem(int order_item_id, int order_id, int product_id, int quantity, float total_price)
        {
            this.order_item_id = order_item_id;
            this.order_id = order_id;
            this.product_id = product_id;
            this.quantity = quantity;
            this.total_price = total_price;
        }

        public OrderItem(int order_id, int product_id, int quantity, float total_price)
        {
            this.order_item_id = 0;
            this.order_id = order_id;
            this.product_id = product_id;
            this.quantity = quantity;
            this.total_price = total_price;
        }

        public OrderItem()
        {
        }

        public override string ToString()
        {
            return $"OrderItemID: {order_item_id}, OrderID: {order_id}, ProductID: {product_id}, Quantity: {quantity}, TotalPrice: {total_price}";
        }
    }
}
