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
namespace FitnessClub
{
    /// <summary>
    /// Interaction logic for MembershipSales.xaml
    /// </summary>
    public partial class MembershipSales : Window
    {
        List<Customers> customerList;
        public MembershipSales()
        {
            InitializeComponent();

            //instantiate a list to hold the Campuses
            customerList = new List<Customers>();

            //call the method to local the campus information and display
            ImportCustomerData();
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

                if (customerList.Count >= 0)
                    MessageBox.Show(customerList.Count + " Campuses have been imported.");
                else
                    MessageBox.Show("No Campuses has been imported. Please check your file.");
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
            Customers customerNew = new Customers(txtFirstNameData.Text.Trim(), txtLastNameData.Text.Trim(), txtWeightData.Text.Trim(), txtGenderData.Text.Trim(), txtPhoneData.Text.Trim(), txtEmailData.Text.Trim(), txtAgeData.Text.Trim(), cbxMembershipTypeData.Text, txtStartDateData.Text.Trim(), txtEndDateData.Text.Trim(), txtTrainingPlanData.Text.Trim(), txtLockerRentalData.Text.Trim(), cbxCreditCardTypeData.Text, txtCreditCardNumberData.Text.Trim());
            return customerNew;
        }
        private bool AddCustomer(string firstName, string lastName, string weight, string gender, string phone, string email, string age, string membershiptype, string startdate, string enddate, string monthlytrainingplan, string monthlylockerrental, string creditcardtype, string creditcardnumber)
        {
            //Define variables
            Customers customerNew;

            //Validation on reqired fields (FirstName, LastName, and Phone) 
            //In case of failure, return false (as status) to the calling code
            if (firstName == "")
            {
                MessageBox.Show("First Name is a required field.");
                return false;
            }

            if (lastName == "")
            {
                MessageBox.Show("Last Name is a required field.");
                return false;
            }

            if (phone == "")
            {
                MessageBox.Show("Phone Numer is a required field.");
                return false;
            }


           customerNew = new Customers(firstName, lastName, weight, gender, phone, email, phone, email, age, membershiptype, startdate, enddate, monthlylockerrental, monthlytrainingplan);

            //Add the new customer objec to the list
            customerList.Add(customerNew);

            //Return ture (as status) to the calling code
            return true;
        }

        private void btnSubmitMembership_Click(object sender, RoutedEventArgs e)
        {
            string strFilePath = @"..\..\..\Data\Customers.json";
            long phone;

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
                MessageBox.Show("Phone must be provided.");
                return;
            }

            if (!Int64.TryParse(txtPhoneData.Text.Trim(), out phone))
            {
                MessageBox.Show("Phone must be a number.");
                return;
            }


            //Establish Phone as a number so that I an made sure that the value fall within 10 digits this is for validation establish as a string, then convert to a long then establish connection with string and txtphone then convert string into long and then ensure that it is within the right range else user gets a message
            string strPhone;
            long lngPhone;
            strPhone = txtPhoneData.Text.Trim();
            lngPhone = Convert.ToInt64(strPhone);
            if (lngPhone < 1000000000 || lngPhone > 9999999999)
            {
                MessageBox.Show("Phone must be 10 digits.");
                return;
            }

            //Declare Customers class
            Customers customerNew = new Customers(txtFirstNameData.Text.Trim(), txtLastNameData.Text.Trim(), txtWeightData.Text.Trim(), txtGenderData.Text.Trim(), txtPhoneData.Text.Trim(), txtEmailData.Text.Trim(), txtAgeData.Text.Trim(), cbxMembershipTypeData.Text, txtStartDateData.Text.Trim(), txtEndDateData.Text.Trim(), txtTrainingPlanData.Text.Trim(), txtLockerRentalData.Text.Trim(), cbxCreditCardTypeData.Text, txtCreditCardNumberData.Text.Trim());


                customerNew = new Customers(txtFirstNameData.Text.Trim(), txtLastNameData.Text.Trim(), txtWeightData.Text.Trim(), txtGenderData.Text.Trim(), txtPhoneData.Text.Trim(), txtEmailData.Text.Trim(), txtAgeData.Text.Trim(), cbxMembershipTypeData.Text, txtStartDateData.Text.Trim(), txtEndDateData.Text.Trim(), txtTrainingPlanData.Text.Trim(), txtLockerRentalData.Text.Trim(), cbxCreditCardTypeData.Text, txtCreditCardNumberData.Text.Trim());


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
            Window winPricingManagement = new PricingManagement();
            winPricingManagement.Show();
            this.Close();
        }
    }
}
