using PV_DatabaseProject_MatejBoska.DAO;
using PV_DatabaseProject_MatejBoska.Tabulky;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV_DatabaseProject_MatejBoska.Menu
{
    internal class ProductCategoryMenu : MainMenuItem
    {
        ProductCategoryDAO dao;

        public override string Header => "Product Category";

        public ProductCategoryMenu()
        {
            dao = new ProductCategoryDAO();
            options = new Dictionary<int, (string, Action)>()
            {
                {1, ("Insert", Insert) },
                {2, ("Update", Update) },
                {3, ("Delete", Delete) },
                {4, ("Print All", PrintAll) },
                {5, ("Exit", ()=>{}) }
            };
        }

        void Insert()
        {
            Console.WriteLine("Insert Name");
            string name = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(name))
            {
                dao.Save(new ProductCategory(name));
            }
            else
            {
                Console.WriteLine("Invalid input");
            }
        }

        void Update()
        {
            Console.WriteLine("Insert ID");

            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid input");
                return;
            }

            ProductCategory category = dao.GetByID(id);

            Console.WriteLine("Insert Name");
            string name = Console.ReadLine();

            category.CategoryName = name;

            if (!string.IsNullOrWhiteSpace(name))
            {
                dao.Save(category);
            }
            else
            {
                Console.WriteLine("Invalid input");
            }
        }

        void Delete()
        {
            Console.WriteLine("Insert ID");

            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid input");
                return;
            }

            ProductCategory category = dao.GetByID(id);
            dao.Delete(category);
        }

        void PrintAll()
        {
            foreach (var category in dao.GetAll())
            {
                Console.WriteLine(category.ToString());
            }
        }
    }
}
