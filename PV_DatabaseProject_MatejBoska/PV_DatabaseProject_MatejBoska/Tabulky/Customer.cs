using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV_DatabaseProject_MatejBoska.Tabulky
{
    internal class Customer
    {
        private int customer_id;
        private string first_name;
        private string last_name;
        private string email;
        private string phone_number;

        public int CustomerID { get => customer_id; set => customer_id = value; }
        public string FirstName { get => first_name; set => first_name = value; }
        public string LastName { get => last_name; set => last_name = value; }
        public string Email { get => email; set => email = value; }
        public string PhoneNumber { get => phone_number; set => phone_number = value; }

        public Customer(int customer_id, string first_name, string last_name, string email, string phone_number)
        {
            this.customer_id = customer_id;
            this.first_name = first_name;
            this.last_name = last_name;
            this.email = email;
            this.phone_number = phone_number;
        }

        public Customer(string first_name, string last_name, string email, string phone_number)
        {
            this.customer_id = 0;
            this.first_name = first_name;
            this.last_name = last_name;
            this.email = email;
            this.phone_number = phone_number;
        }

        public Customer()
        {
        }

        public override string ToString()
        {
            return $"CustomerID: {customer_id}, Name: {first_name} {last_name}, Email: {email}, Phone Number: {phone_number}";
        }
    }
}
