using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV_DatabaseProject_MatejBoska.Tabulky
{
    internal class ProductCategory
    {
        private int category_id;
        private string category_name;

        public int CategoryID { get => category_id; set => category_id = value; }
        public string CategoryName { get => category_name; set => category_name = value; }

        public ProductCategory(int category_id, string category_name)
        {
            this.category_id = category_id;
            this.category_name = category_name;
        }

        public ProductCategory(string category_name)
        {
            this.category_id = 0;
            this.category_name = category_name;
        }

        public ProductCategory()
        {
        }

        public override string ToString()
        {
            return $"CategoryID: {category_id}, CategoryName: {category_name}";
        }
    }
}
