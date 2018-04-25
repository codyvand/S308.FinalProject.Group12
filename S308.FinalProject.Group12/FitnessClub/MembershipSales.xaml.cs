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
        // Nav links
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
