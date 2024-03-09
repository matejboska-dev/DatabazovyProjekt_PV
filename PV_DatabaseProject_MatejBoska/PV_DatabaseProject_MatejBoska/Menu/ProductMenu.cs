using PV_DatabaseProject_MatejBoska.DAO;
using PV_DatabaseProject_MatejBoska.Tabulky;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV_DatabaseProject_MatejBoska.Menu
{
    namespace DS_APP_PODNIK.Menu
    {
        internal class ProductMenu : MainMenuItem
        {
            private ProductDAO dao;

            public override string Header => "Product";

            public ProductMenu()
            {
                dao = new ProductDAO();
                options = new Dictionary<int, (string, Action)>()
            {
                {1, ("Insert", Insert) },
                {2, ("Update", Update) },
                {3, ("Delete", Delete) },
                {4, ("Print All", PrintAll) },
                {5, ("Read from CSV", ReadFromCSV) },
                {6, ("Exit", ()=>{}) }
            };
            }

            void ReadFromCSV()
            {
                Console.WriteLine("Write the file name (must be in the same directory)");
                string path = Console.ReadLine();

                using (var reader = new StreamReader(@"" + path))
                {
                    while (!reader.EndOfStream)
                    {
                        var values = reader.ReadLine().Split(',');

                        if (values.Length != 5)
                        {
                            Console.WriteLine("Invalid CSV file or entry");
                            return;
                        }

                        try
                        {
                            string name = values[1];
                            float price = float.Parse(values[2]);
                            int stock_quantity = int.Parse(values[3]);
                            int category_id = int.Parse(values[4]);

                            if (dao.GetAll().Select(x => x.ProductName).Contains(name))
                            {
                                Console.WriteLine("Product name exists");
                                return;
                            }

                            dao.Save(new Product(name, price, stock_quantity, category_id));
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Invalid CSV entry");
                            return;
                        }
                    }
                }
            }

            void Insert()
            {
                string name;
                float price;
                int stock_quantity;
                int category_id;

                Console.WriteLine("Insert Name");
                name = Console.ReadLine();

                if (!TypeValidation<string>(name)) { Console.WriteLine("Invalid input"); return; }

                if (dao.GetAll().Select(x => x.ProductName).Contains(name))
                {
                    Console.WriteLine("Product name exists"); return;
                }

                Console.WriteLine("Insert Price");
                if (!float.TryParse(Console.ReadLine(), out price))
                {
                    Console.WriteLine("Invalid input");
                    return;
                }

                Console.WriteLine("Insert Stock Quantity");
                if (!int.TryParse(Console.ReadLine(), out stock_quantity))
                {
                    Console.WriteLine("Invalid input");
                    return;
                }

                Console.WriteLine("Insert Category ID");
                if (!int.TryParse(Console.ReadLine(), out category_id))
                {
                    Console.WriteLine("Invalid input");
                    return;
                }

                dao.Save(new Product(name, price, stock_quantity, category_id));
            }

            void Update()
            {
                Console.WriteLine("Insert ID");

                if (!int.TryParse(Console.ReadLine(), out int id))
                {
                    Console.WriteLine("Invalid input");
                    return;
                }

                Product product = dao.GetByID(id);

                Console.WriteLine("[Enter to skip updating a field]");
                Console.WriteLine("Insert Name");
                string name = Console.ReadLine();

                if (!TypeValidation<string>(name)) { Console.WriteLine("Skip"); name = product.ProductName; }
                else if (dao.GetAll().Select(x => x.ProductName).Contains(name))
                {
                    Console.WriteLine("Product name exists");
                    return;
                }

                Console.WriteLine("Insert Price");
                float price;
                if (!float.TryParse(Console.ReadLine(), out price))
                {
                    Console.WriteLine("Skip");
                    price = product.Price;
                }

                Console.WriteLine("Insert Stock Quantity");
                int stock_quantity;
                if (!int.TryParse(Console.ReadLine(), out stock_quantity))
                {
                    Console.WriteLine("Skip");
                    stock_quantity = product.StockQuantity;
                }

                Console.WriteLine("Insert Category ID");
                int category_id;
                if (!int.TryParse(Console.ReadLine(), out category_id))
                {
                    Console.WriteLine("Skip");
                    category_id = product.CategoryID;
                }

                product.ProductName = name;
                product.Price = price;
                product.StockQuantity = stock_quantity;
                product.CategoryID = category_id;

                dao.Save(product);
            }

            void Delete()
            {
                Console.WriteLine("Insert ID");

                if (!int.TryParse(Console.ReadLine(), out int id))
                {
                    Console.WriteLine("Invalid input");
                    return;
                }

                Product product = dao.GetByID(id);
                dao.Delete(product);
            }

            void PrintAll()
            {
                foreach (var product in dao.GetAll())
                {
                    Console.WriteLine(product.ToString());
                }
            }
        }
    }
}
