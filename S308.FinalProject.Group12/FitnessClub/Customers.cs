using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessClub
{
    class Customers
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Weight { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Age { get; set; }
        public Customers()
        {

        }
        public Customers(string firstname, string lastname, string weight, string gender, string phone, string email, string age)
        {
            FirstName = firstname;
            LastName = lastname;
            Weight = weight;
            Gender = gender;
            Phone = phone;
            Email = email;
            Age = age;
        }
        public override string ToString()
        {
            return "Customers" + Environment.NewLine + "First Name:" + FirstName + Environment.NewLine + "Last Name:" + LastName + Environment.NewLine + "Weight:" + Weight + Environment.NewLine + "Gender:" + Gender + Environment.NewLine + "Phone:" + Phone + Environment.NewLine + "Email:" + Email + Environment.NewLine + "Age:" + Age;
        }
    }
}
