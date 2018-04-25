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
        public string CustomerType { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string MonthlyTrainingPlan { get; set; }
        public string MonthlyLockerRental { get; set; }
        public string CreditCardType { get; set; }
        public string CreditCardNumber { get; set; }
        public Customers()
        {

        }
        public Customers(string firstname, string lastname, string weight, string gender, string phone, string email, string age, string customertype, string startdate, string enddate, string monthlytrainingplan, string monthlylockerrental, string creditcardtype, string creditcardnumber)
        {
            FirstName = firstname;
            LastName = lastname;
            Weight = weight;
            Gender = gender;
            Phone = phone;
            Email = email;
            Age = age;
            CustomerType = customertype;
            StartDate = startdate;
            EndDate = enddate;
            MonthlyTrainingPlan = monthlytrainingplan;
            MonthlyLockerRental = monthlylockerrental;
            CreditCardType = creditcardtype;
            CreditCardNumber = creditcardnumber;
        }
        public override string ToString()
        {
            return "Customers" + Environment.NewLine + "First Name:" + FirstName + Environment.NewLine + "Last Name:" + LastName + Environment.NewLine + "Weight:" + Weight + Environment.NewLine + "Gender:" + Gender + Environment.NewLine + "Phone:" + Phone + Environment.NewLine + "Email:" + Email + Environment.NewLine + "Age:" + Age + Environment.NewLine + "Start Date:" + StartDate + Environment.NewLine + "End Date:" +EndDate + Environment.NewLine + "Monthly Training Plan:" + MonthlyTrainingPlan + Environment.NewLine +"Monthly Locker Rental:" + MonthlyLockerRental + Environment.NewLine + "Credit Card Type:" + CreditCardType +Environment.NewLine + "Credit Card Number:" + CreditCardNumber;
        }
    }
}
