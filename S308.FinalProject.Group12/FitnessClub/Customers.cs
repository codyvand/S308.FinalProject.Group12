using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessClub
{
    class Customers
    {
        public string PersonalFitnessGoal { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Weight { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Age { get; set; }
        public string MembershipType { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string MonthlyTrainingPlan { get; set; }
        public string MonthlyLockerRental { get; set; }
        public string CreditCardType { get; set; }
        public string CreditCardNumber { get; set; }
        public string MembershipCostPerMonth { get; set; }
        public string PersonalTrainingPlanCost { get; set; }
        public string LockerRentalCost { get; set; }
        public string MembershipSubtotalCost { get; set; }
        public string MembershipTotalCost { get; set; }

        public Customers()
        {

        }
        public Customers(string personalfitnessgoal, string firstname, string lastname, string weight, string gender, string phone, string email, string age, string membershiptype, string startdate, string enddate, string monthlytrainingplan, string monthlylockerrental, string creditcardtype, string creditcardnumber, string membershipcostpernomth, string personaltrainingplancost, string lockerrentalcost, string membershipsubtotalcost, string membershiptotalcost)
        {
            PersonalFitnessGoal = personalfitnessgoal;
            FirstName = firstname;
            LastName = lastname;
            Weight = weight;
            Gender = gender;
            Phone = phone;
            Email = email;
            Age = age;
            MembershipType = membershiptype;
            StartDate = startdate;
            EndDate = enddate;
            MonthlyLockerRental = monthlylockerrental;
            MonthlyTrainingPlan = monthlytrainingplan;
            CreditCardType = creditcardtype;
            CreditCardNumber = creditcardnumber;
            MembershipCostPerMonth = membershipcostpernomth;
            PersonalTrainingPlanCost = personaltrainingplancost;
            LockerRentalCost = lockerrentalcost;
            MembershipSubtotalCost = membershipsubtotalcost;
            MembershipTotalCost = membershiptotalcost;
        }
        public override string ToString()
        {
            return "Customers" + Environment.NewLine +"Personal Fitness Goal:" + PersonalFitnessGoal + Environment.NewLine + "First Name:" + FirstName + Environment.NewLine + "Last Name:" + LastName + Environment.NewLine + "Weight:" + Weight + Environment.NewLine + "Gender:" + Gender + Environment.NewLine + "Phone:" + Phone + Environment.NewLine + "Email:" + Email + Environment.NewLine + "Age:" + Age + Environment.NewLine + "Start Date:" + StartDate + Environment.NewLine + "End Date:" +EndDate + Environment.NewLine + "Monthly Training Plan:" + MonthlyTrainingPlan + Environment.NewLine +"Monthly Locker Rental:" + MonthlyLockerRental + Environment.NewLine + "Credit Card Type:" + CreditCardType +Environment.NewLine + "Credit Card Number:" + CreditCardNumber + Environment.NewLine + "Membership Cost Per Month:" + MembershipCostPerMonth + Environment.NewLine + "Personal Training Cost:" + PersonalTrainingPlanCost + Environment.NewLine + "Locker Rental Cost" + LockerRentalCost + Environment.NewLine + "Subtotal Cost:" +MembershipSubtotalCost + Environment.NewLine + "Total Cost:" + MembershipTotalCost;
        }
    }
}
