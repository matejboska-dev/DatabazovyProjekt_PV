using PV_DatabaseProject_MatejBoska.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV_DatabaseProject_MatejBoska.Menu
{
    internal abstract class MainMenuItem 
    {
        public virtual string Header { get; protected set; }
        public Dictionary<int, (string description, Action action)> options { get; protected set; }

        public void StartSelection()
        {

            Console.WriteLine(DisplayOptions());

            if (int.TryParse(Console.ReadLine(), out int choice) && choice <= options.Count)
            {
                options[choice].action();
            }
            else
            {
                Console.WriteLine("Invalid input");
            }
        }


        public string DisplayOptions()
        {
            string res = "\n" + Header + " - Choose an action\n";
            for (int i = 1; i <= options.Count; i++)
            {

                res += i + ") " + options[i].description + "\n";

            }

            return res;
        }

        public static void PrintAll<Table, Dao>() where Table : IBase where Dao : IDAO<Table>, new()
        {
            Dao dao = new();
            foreach (Table dm in dao.GetAll())
            {
                Console.WriteLine(dm);
            }
        }


        public static bool TypeValidation<T>(T toValidate)
        {
            return toValidate switch
            {
                string s => s.Length > 0,
                int i => i > 0,
                float f => f > 0,

            };
        }


        public static bool IDValidation<Dao, Table>(int id) where Table : IBase where Dao : IDAO<Table>, new()
        {
            Dao dao = new();
            if (dao.GetByID(id) == null)
            {
                return false;
            }

            return true;
        }



    }
}
