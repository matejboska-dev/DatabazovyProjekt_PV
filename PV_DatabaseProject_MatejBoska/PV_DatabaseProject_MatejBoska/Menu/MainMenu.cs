using PV_DatabaseProject_MatejBoska.Menu.DS_APP_PODNIK.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV_DatabaseProject_MatejBoska.Menu
{
    internal class MainMenu
    {







        Dictionary<int, MainMenuItem>


         dict = new()
         {
            {1, new CustomerMenu() },
            {2, new ProductMenu() },
            {3, new ProductCategoryMenu() },
            {4, new OrderMenu() },
            {5, new OrderItemMenu() },


         };



        bool exit = false;



        public void Start()
        {




            while (!exit)
            {
                Console.WriteLine(DisplayOptions());


                if (int.TryParse(Console.ReadLine(), out int choice) && choice <= dict.Count)
                {
                    dict[choice].StartSelection();
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }


            }

        }




        string DisplayOptions()
        {
            string res = "\nChoose an option\n";
            for (int i = 1; i <= dict.Count; i++)
            {

                res += i + ") " + (dict[i] == null ? "Exit" : dict[i].Header) + "\n";

            }

            return res;


        }






    }
}
