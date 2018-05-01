using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Newtonsoft.Json;
using System.IO;
using System.Windows.Navigation;

namespace FitnessClub
{
    /// <summary>
    /// Interaction logic for MembershipSales.xaml
    /// </summary>
    public partial class MembershipSales : Window
    {
        List<Customers> customerList;
        List<MembershipType> membershiptypeList;
        string strMonthlyTrainingPlanResult, strMonthlyLockerRentalResult;
        public MembershipSales()
        {
            InitializeComponent();

            //instantiate a list to hold the Campuses
            customerList = new List<Customers>();
            membershiptypeList = new List<MembershipType>();

            //call the method to local the campus information and display
            ImportCustomerData();
            ImportMembershipTypeData();

        }

        private void ImportMembershipTypeData()
        {
            string strFilePathMem = @"..\..\..\Data\MembershipType.json";

            try
            {
                //use System.IO.File to read the entire data file
                string jsonData = File.ReadAllText(strFilePathMem);

                //serialize the json data to a list of campuses
                membershiptypeList = JsonConvert.DeserializeObject<List<MembershipType>>(jsonData);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in import process: " + ex.Message);
            }

        }
        private void ImportCustomerData()
        {
            string strFilePath = @"..\..\..\Data\Customers.json";

            try
            {
                //use System.IO.File to read the entire data file
                string jsonData = File.ReadAllText(strFilePath);

                //serialize the json data to a list of campuses
                customerList = JsonConvert.DeserializeObject<List<Customers>>(jsonData);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in import process: " + ex.Message);
            }

        }
        private Customers ConvertToCustomer(string strLine)
        {
            //declare a string array to hold the data 
            string[] rawData;
            //split on the delimiter into the array
            rawData = strLine.Split(',');

            //create a customer from the data
            Customers customerNew = new Customers(txtPersonalFitnessGoalData.Text.Trim(), txtFirstNameData.Text.Trim(), txtLastNameData.Text.Trim(), txtWeightData.Text.Trim(), txtGenderData.Text.Trim(), txtPhoneData.Text.Trim(), txtEmailData.Text.Trim(), txtAgeData.Text.Trim(), cbxMembershipTypeData.Text, dtpStartDate.SelectedDate.ToString(), txtEndDateData.Text.Trim(), strMonthlyTrainingPlanResult, strMonthlyLockerRentalResult, cbxCreditCardTypeData.Text, txtCreditCardNumberData.Text.Trim());
            return customerNew;
        }
        private bool AddCustomer(string personalfitnessgoal, string firstname, string lastname, string weight, string gender, string phone, string email, string age, string membershiptype, string startdate, string enddate, string monthlytrainingplan, string monthlylockerrental, string creditcardtype, string creditcardnumber)
        {
            //Define variables
            Customers customerNew;

            //Validation on reqired fields (FirstName, LastName, and Phone) 
            //In case of failure, return false (as status) to the calling code
            if (firstname == "")
            {
                MessageBox.Show("First Name is a required field.");
                return false;
            }

            if (lastname == "")
            {
                MessageBox.Show("Last Name is a required field.");
                return false;
            }

            if (phone == "")
            {
                MessageBox.Show("Phone Numer is a required field.");
                return false;
            }


            customerNew = new Customers(personalfitnessgoal, firstname, lastname, weight, gender, phone, email, age, membershiptype, startdate, enddate, monthlytrainingplan, monthlylockerrental, creditcardtype, creditcardnumber);

            //Add the new customer objec to the list
            customerList.Add(customerNew);

            //Return ture (as status) to the calling code
            return true;
        }

        public void btnSubmitMembership_Click(object sender, RoutedEventArgs e)
        {




            string strFilePath = @"..\..\..\Data\Customers.json";
            long phone;
            //1. Declare a variables
            //   - credit card number from the text box and assign (remove spaces)
            //   - counter for loop
            //   - check digit (to hold each digit while working with them)
            //   - check sum (to hold the sum of the digits once modified)
            //   - valid (boolean)
            //   - card type
            //2. Make sure the text entered is numeric
            //       a. message to user that says to enter only numbers
            //       b. show negative result
            //3. Make sure there are 13, 15, 16 digits entered
            //       a. message to the user about the number of digits
            //       b. show negative result
            //4. Determine the card type from the prefix and set the card type variable
            //5. Validate card number
            //       a. reverse all of the characters in the credit card number
            //       b. loop through the characters
            //           - if it is the first, third, fifth, etc digit add it to the check sum
            //           - if it is the second, fourth, sixth, etc digit double before adding to the check sum
            //                   - if after double the digit it is > 9 then add the two numbers before adding to the check sum
            //                   - 12 = 1 + 2 or x - 9
            //       c. if the result is divisible by 10 the card number is a valid number. Set the valid variable
            //6. Show the appropriate result
            //       'a. if valid
            //           - display the logo for the card
            //           - set the text of the result label to Credit Card Is Valid
            //           - set the text color to green
            //       b. else
            //           - set the text of the result label to Credit Card Is Not Valid
            //           - set the text color to red

            string strCardNum = txtCreditCardNumberData.Text.Trim().Replace(" ", "");
            long lngOut;
            bool bolValid = false;
            int i;
            int intCheckDigit;
            int intCheckSum = 0;
            string strCardType;

            //2.

            if (!Int64.TryParse(strCardNum, out lngOut))
            {
                MessageBox.Show("Credit card numbers contain only numbers.");
                return;
            }
            //3.
            if (strCardNum.Length != 13 && strCardNum.Length != 15 && strCardNum.Length != 16)
            {
                MessageBox.Show("Credit card numbers must contain 13, 15, or 16 digits.");
                return;
            }
            //4.
            if (strCardNum.StartsWith("34") || strCardNum.StartsWith("37"))
                strCardType = "AMEX";
            else if (strCardNum.StartsWith("6011"))
                strCardType = "Discover";
            else if (strCardNum.StartsWith("51") || strCardNum.StartsWith("52") || strCardNum.StartsWith("53") || strCardNum.StartsWith("54") || strCardNum.StartsWith("55"))
                strCardType = "MasterCard";
            else if (strCardNum.StartsWith("4"))
                strCardType = "VISA";
            else
                strCardType = "Unknown Card Type";

            //5.
            strCardNum = ReverseString(strCardNum);

            for (i = 0; i < strCardNum.Length; i++)
            {
                intCheckDigit = Convert.ToInt32(strCardNum.Substring(i, 1));

                if ((i + 1) % 2 == 0)
                {
                    intCheckDigit *= 2;

                    if (intCheckDigit > 9)
                    {
                        intCheckDigit -= 9;
                    }
                }

                intCheckSum += intCheckDigit;
            }

            if (intCheckSum % 10 == 0)
            {
                bolValid = true;
            }
            //6.
            if (bolValid)
            {
                switch (strCardType)
                {
                    case "AMEX":
                        break;
                    case "Discover":
                        break;
                    case "MasterCard":
                        break;
                    case "VISA":
                        break;
                }
                if (strCardType == cbxCreditCardTypeData.Text)
                {
                }
                else
                {
                    MessageBox.Show("The Credit Card Is No the Correct Type" + strCardType);
                    return;
                }

            }
            else
            {
                MessageBox.Show("The Credit Card Is Not Valid");
                return;
            }

            //validate the input FirstName(input)
            if (txtFirstNameData.Text.Trim() == "")
            {
                MessageBox.Show("First Name must be provided.");
                return;
            }

            //validate the input LastName(input)
            if (txtLastNameData.Text.Trim() == "")
            {
                MessageBox.Show("Last Name must be provided.");
                return;
            }

            //validate the input Phone (input provided, 10 digits within properties, number)
            if (txtPhoneData.Text.Trim() == "")
            {
                MessageBox.Show("Phone number must be provided.");
                return;
            }

            if (!Int64.TryParse(txtPhoneData.Text.Trim(), out phone))
            {
                MessageBox.Show("Phone number must be only numbers.  Example:1234567890");
                return;
            }


            //Establish Phone as a number so that I an made sure that the value fall within 10 digits this is for validation establish as a string, then convert to a long then establish connection with string and txtphone then convert string into long and then ensure that it is within the right range else user gets a message
            string strPhone;
            long lngPhone;
            strPhone = txtPhoneData.Text.Trim();
            lngPhone = Convert.ToInt64(strPhone);
            if (lngPhone < 1000000000 || lngPhone > 9999999999)
            {
                MessageBox.Show("Phone number must be 10 digits. Example:1234567890");
                return;
            }
            //2
            if (cbxMembershipTypeData.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a theater.");
                return;
            }
            //Email Vailidation
            string strEmailData;
            strEmailData = txtEmailData.Text.Trim();
            bool hasAt = strEmailData.Contains("@") == true;
            bool hasDot = strEmailData.Contains(".") == true;

            if (!(hasDot) || !(hasAt))
            {
                txtEmailData.Text = "";
                MessageBox.Show("Enter a valid email adress.");
                return;
            }

            int intAt = strEmailData.IndexOf("@");
            int intDot = strEmailData.IndexOf(".");
            string strUserName = strEmailData.Substring(0, intAt);
            string strDot = strEmailData.Substring(intAt + 1, intDot - intAt - 1);
            string strDomain = strEmailData.Substring(intDot + 1);

            if (strUserName.Length < 1 || strDot.Length < 1 || strDomain.Length < 2)
            {
                txtEmailData.Text = "";
                MessageBox.Show("Enter a valid email adress.");
                return;

            }

            //Declare Customers class
            Customers customerNew = new Customers(txtPersonalFitnessGoalData.Text.Trim(), txtFirstNameData.Text.Trim(), txtLastNameData.Text.Trim(), txtWeightData.Text.Trim(), txtGenderData.Text.Trim(), txtPhoneData.Text.Trim(), txtEmailData.Text.Trim(), txtAgeData.Text.Trim(), strSelectedMembershipType, dtpStartDate.SelectedDate.ToString(), txtEndDateData.Text.Trim(), strMonthlyTrainingPlanResult, strMonthlyLockerRentalResult, cbxCreditCardTypeData.Text, txtCreditCardNumberData.Text.Trim());


            customerNew = new Customers(txtPersonalFitnessGoalData.Text.Trim(), txtFirstNameData.Text.Trim(), txtLastNameData.Text.Trim(), txtWeightData.Text.Trim(), txtGenderData.Text.Trim(), txtPhoneData.Text.Trim(), txtEmailData.Text.Trim(), txtAgeData.Text.Trim(), strSelectedMembershipType, dtpStartDate.SelectedDate.ToString(), txtEndDateData.Text.Trim(), strMonthlyTrainingPlanResult, strMonthlyLockerRentalResult, cbxCreditCardTypeData.Text, txtCreditCardNumberData.Text.Trim());


            //instantiate a new Campus from the input and add it to the list
            customerList.Add(customerNew);


            try
            {
                //serialize the new list of campuses to json format
                string jsonData = JsonConvert.SerializeObject(customerList);

                //use System.IO.File to write over the file with the json data
                System.IO.File.WriteAllText(strFilePath, jsonData);

                MessageBox.Show(customerList.Count + " Cusomters have been exported.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in export process: " + ex.Message);
            }

            MessageBox.Show("Campus Added!" + Environment.NewLine + customerNew.ToString());
        }


        //Navigation Links
        private void btnMainMenu_Click(object sender, RoutedEventArgs e)
        {
            Window winHomePage = new HomePage();
            winHomePage.Show();
            this.Close();
        }

        private void btnMemberInformation_Click(object sender, RoutedEventArgs e)
        {
            Window winMemberInformation = new MemberInformation();
            winMemberInformation.Show();
            this.Close();
        }

        private void btnMembershipSales_Click(object sender, RoutedEventArgs e)
        {
            Window winMembershipSales = new MembershipSales();
            winMembershipSales.Show();
            this.Close();
        }

        private void btnPricingManagement_Click(object sender, RoutedEventArgs e)
        {
            Window winPricingManager = new PricingManager();
            winPricingManager.Show();
            this.Close();
        }
        double dblMonthlyTrainingCost;
        double dblMonthlyLockerRentalCost;
        private void rbtMonthlyTrainingPlanYes_Checked(object sender, RoutedEventArgs e)
        {
            strMonthlyTrainingPlanResult = "Yes";
            dblMonthlyTrainingCost = 19;
            string strMonthlyTrainingCost = dblMonthlyTrainingCost.ToString();
            txtMonthlyTrainingPlanPrice.Text = strMonthlyTrainingCost;

            string strCostMembershipType;
            strCostMembershipType = txtCostPerMonthData.Text;
            double dblCostMembershipType = Convert.ToDouble(strCostMembershipType);

            string strMonthlyLockerRentalCost = txtMonthlyLockerRentalPrice.Text;
            double dblMonthlyLockerRentalCost = Convert.ToDouble(strMonthlyLockerRentalCost);

            double dblTotalCost = dblMonthlyTrainingCost + dblMonthlyLockerRentalCost + dblCostMembershipType;
            string strTotalCost = Convert.ToString(dblTotalCost);
            txtTotalData.Text = strTotalCost;

        }


        private void rbtMonthlyLockerRentalYes_Checked(object sender, RoutedEventArgs e)
        {
            strMonthlyLockerRentalResult = "Yes";
            dblMonthlyLockerRentalCost = 19;
            string strMonthlyLockerRentalCost = dblMonthlyLockerRentalCost.ToString();
            txtMonthlyLockerRentalPrice.Text = strMonthlyLockerRentalCost;
            string strCostMembershipType;
            strCostMembershipType = txtCostPerMonthData.Text;
            double dblCostMembershipType = Convert.ToDouble(strCostMembershipType);

            string strMonthlyTrainingCost = txtMonthlyTrainingPlanPrice.Text;
            double dblMonthlyTrainingCost = Convert.ToDouble(strMonthlyTrainingCost);

            double dblTotalCost = dblMonthlyTrainingCost + dblMonthlyLockerRentalCost + dblCostMembershipType;
            string strTotalCost = Convert.ToString(dblTotalCost);
            txtTotalData.Text = strTotalCost;

        }


        private void rbtMonthlyLockerRentalNo_Checked(object sender, RoutedEventArgs e)
        {
            strMonthlyLockerRentalResult = "No";
            dblMonthlyLockerRentalCost = 0;
            string strMonthlyLockerRentalCost = dblMonthlyLockerRentalCost.ToString();
            txtMonthlyLockerRentalPrice.Text = strMonthlyLockerRentalCost;

            string strCostMembershipType;
            strCostMembershipType = txtCostPerMonthData.Text;
            double dblCostMembershipType = Convert.ToDouble(strCostMembershipType);

            string strMonthlyTrainingCost = txtMonthlyTrainingPlanPrice.Text;
            double dblMonthlyTrainingCost = Convert.ToDouble(strMonthlyTrainingCost);

            double dblTotalCost = dblMonthlyTrainingCost + dblMonthlyLockerRentalCost + dblCostMembershipType;
            string strTotalCost = Convert.ToString(dblTotalCost);
            txtTotalData.Text = strTotalCost;

        }

        private void rbtMonthlyTrainingPlanNo_Checked_1(object sender, RoutedEventArgs e)
        {
            strMonthlyTrainingPlanResult = "No";
            dblMonthlyTrainingCost = 0;
            string strMonthlyTrainingCost = dblMonthlyTrainingCost.ToString();
            txtMonthlyTrainingPlanPrice.Text = strMonthlyTrainingCost;

            string strCostMembershipType;
            strCostMembershipType = txtCostPerMonthData.Text;
            double dblCostMembershipType = Convert.ToDouble(strCostMembershipType);

            string strMonthlyLockerRentalCost = txtMonthlyLockerRentalPrice.Text;
            double dblMonthlyLockerRentalCost = Convert.ToDouble(strMonthlyLockerRentalCost);

            double dblTotalCost = dblMonthlyTrainingCost + dblMonthlyLockerRentalCost + dblCostMembershipType;
            string strTotalCost = Convert.ToString(dblTotalCost);
            txtTotalData.Text = strTotalCost;

        }

        string strSelectedMembershipType;

        public void cbxMembershipTypeData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {



            //3
            ComboBoxItem cbxSelectedItem = (ComboBoxItem)cbxMembershipTypeData.SelectedItem;
            strSelectedMembershipType = cbxSelectedItem.Content.ToString();
            string strCostMembershipType;
            strCostMembershipType = "0";

            if (strSelectedMembershipType == "Individual1Month" || strSelectedMembershipType == "TwoPerson1Month" || strSelectedMembershipType == "Family1Month")
            {
                DateTime? datStartDate = dtpStartDate.SelectedDate;
                txtEndDateData.Text = "";
                
                TimeSpan tspAddOneMonth = TimeSpan.FromDays(30);
                txtEndDateData.Text = datStartDate + tspAddOneMonth + Environment.NewLine;
            }
            else
            {
                DateTime? datStartDate = dtpStartDate.SelectedDate;
                txtEndDateData.Text = "";

                TimeSpan tspAddOneYear = TimeSpan.FromDays(360);
                txtEndDateData.Text = datStartDate + tspAddOneYear + Environment.NewLine;

            }

            //5
            switch (strSelectedMembershipType)
            {
                case "Individual1Month":
                    strCostMembershipType = "9.99";
                    break;
                case "Individual12Month":
                    strCostMembershipType = "100.00";
                    break;
                case "TwoPerson1Month":
                    strCostMembershipType = "14.99";
                    break;
                case "TwoPerson12Month":
                    strCostMembershipType = "150.00";
                    break;
                case "Family1Month":
                    strCostMembershipType = "19.99";
                    break;
                case "Family12Month":
                    strCostMembershipType = "200.00";
                    break;
            }
            txtCostPerMonthData.Text = strCostMembershipType;
            double dblCostMembershipType = Convert.ToDouble(strCostMembershipType);

            string strMonthlyTrainingCost = txtMonthlyTrainingPlanPrice.Text;
            double dblMonthlyTrainingCost = Convert.ToDouble(strMonthlyTrainingCost);

            string strMonthlyLockerRentalCost = txtMonthlyLockerRentalPrice.Text;
            double dblMonthlyLockerRentalCost = Convert.ToDouble(strMonthlyLockerRentalCost);

            double dblTotalCost = dblMonthlyTrainingCost + dblMonthlyLockerRentalCost + dblCostMembershipType;
            string strTotalCost = Convert.ToString(dblTotalCost);
            txtTotalData.Text = strTotalCost;

    }

        private void dtpStartDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem cbxSelectedItem = (ComboBoxItem)cbxMembershipTypeData.SelectedItem;
            strSelectedMembershipType = cbxSelectedItem.Content.ToString();
            string strCostMembershipType;
            strCostMembershipType = "0";

            if (strSelectedMembershipType == "Individual1Month" || strSelectedMembershipType == "TwoPerson1Month" || strSelectedMembershipType == "Family1Month")
            {
                DateTime? datStartDate = dtpStartDate.SelectedDate;
                txtEndDateData.Text = "";

                TimeSpan tspAddOneMonth = TimeSpan.FromDays(30);
                txtEndDateData.Text = datStartDate + tspAddOneMonth + Environment.NewLine;
            }
            else
            {
                DateTime? datStartDate = dtpStartDate.SelectedDate;
                txtEndDateData.Text = "";

                TimeSpan tspAddOneYear = TimeSpan.FromDays(360);
                txtEndDateData.Text = datStartDate + tspAddOneYear + Environment.NewLine;

            }
        }

        public static string ReverseString(string s)
        {
            char[] array = s.ToCharArray();
            Array.Reverse(array);
            return new string(array);
        }

    }

}
