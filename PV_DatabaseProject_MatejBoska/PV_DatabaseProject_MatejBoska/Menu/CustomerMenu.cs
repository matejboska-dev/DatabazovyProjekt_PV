using PV_DatabaseProject_MatejBoska.DAO;
using PV_DatabaseProject_MatejBoska.Tabulky;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV_DatabaseProject_MatejBoska.Menu
{
    internal class CustomerMenu : MainMenuItem
    {
        private CustomerDAO dao;

        public override string Header => "Customer";

        public CustomerMenu()
        {
            dao = new();
            options = new()
            {
                {1, ("Insert", Insert) },
                {2, ("Update", Update) },
                {3, ("Delete", Delete) },
                {4, ("Print All", PrintAll<Customer, CustomerDAO>) },
                {5, ("Exit", ()=>{}) }
            };
        }

        void Insert()
        {
            Console.WriteLine("Insert First Name");
            string firstName = Console.ReadLine();

            Console.WriteLine("Insert Last Name");
            string lastName = Console.ReadLine();

            Console.WriteLine("Insert Email");
            string email = Console.ReadLine();

            Console.WriteLine("Insert Phone Number");
            string phoneNumber = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(firstName) && !string.IsNullOrWhiteSpace(lastName) &&
                !string.IsNullOrWhiteSpace(email) && !string.IsNullOrWhiteSpace(phoneNumber))
            {
                dao.Save(new Customer(firstName, lastName, email, phoneNumber));
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

            Customer customer = dao.GetByID(id);

            Console.WriteLine("Insert First Name");
            string firstName = Console.ReadLine();

            Console.WriteLine("Insert Last Name");
            string lastName = Console.ReadLine();

            Console.WriteLine("Insert Email");
            string email = Console.ReadLine();

            Console.WriteLine("Insert Phone Number");
            string phoneNumber = Console.ReadLine();

            customer.FirstName = firstName;
            customer.LastName = lastName;
            customer.Email = email;
            customer.PhoneNumber = phoneNumber;

            dao.Save(customer);
        }

        void Delete()
        {
            Console.WriteLine("Insert ID");

            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid input");
                return;
            }

            Customer customer = dao.GetByID(id);
            dao.Delete(customer);
        }
    }
}
