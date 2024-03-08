using PV_DatabaseProject_MatejBoska.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV_DatabaseProject_MatejBoska.Tabulky
{
    internal class Product : IBase
    {
        private int product_id;
        private string product_name;
        private float price;
        private int stock_quantity;
        private int category_id;

        public int ProductID { get => product_id; set => product_id = value; }
        public string ProductName { get => product_name; set => product_name = value; }
        public float Price { get => price; set => price = value; }
        public int StockQuantity { get => stock_quantity; set => stock_quantity = value; }
        public int CategoryID { get => category_id; set => category_id = value; }
        public int ID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Product(int product_id, string product_name, float price, int stock_quantity, int category_id)
        {
            this.product_id = product_id;
            this.product_name = product_name;
            this.price = price;
            this.stock_quantity = stock_quantity;
            this.category_id = category_id;
        }

        public Product(string product_name, float price, int stock_quantity, int category_id)
        {
            this.product_id = 0;
            this.product_name = product_name;
            this.price = price;
            this.stock_quantity = stock_quantity;
            this.category_id = category_id;
        }

        public Product()
        {
        }

        public override string ToString()
        {
            return $"ProductID: {product_id}, Name: {product_name}, Price: {price}, Stock Quantity: {stock_quantity}, CategoryID: {category_id}";
        }
    }
}
