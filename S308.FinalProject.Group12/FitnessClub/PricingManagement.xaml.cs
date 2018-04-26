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
    /// Interaction logic for PricingManagement.xaml
    /// </summary>
    public partial class PricingManagement : Window
    {
        List<Features> featureList;
        public PricingManagement()
        {

            //instantiate a list to hold the Campuses
            featureList = new List<Features>();

            //call the method to local the campus information and display
            ImportFeatureData();
            InitializeComponent();
        }
        private void ImportFeatureData()
        {
            string strFilePath = @"..\..\..\Data\Features.json";

            try
            {
                //use System.IO.File to read the entire data file
                string jsonData = File.ReadAllText(strFilePath);

                //serialize the json data to a list of campuses
                featureList = JsonConvert.DeserializeObject<List<Features>>(jsonData);

                if (featureList.Count >= 0)
                    MessageBox.Show(featureList.Count + " Features have been imported.");
                else
                    MessageBox.Show("No features has been imported. Please check your file.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in import process: " + ex.Message);
            }

        }
        private Features ConvertToFeatures(string strLine)
        {
            //declare a string array to hold the data 
            string[] rawData;
            //split on the delimiter into the array
            rawData = strLine.Split(',');

            //create a customer from the data
            Features featureNew = new Features(txtIndividual1MonthCheck.Text.Trim(), txtIndividual12MonthCheck.Text.Trim(), txtTwoPerson1MonthCheck.Text.Trim(), txtTwoPerson12MonthCheck.Text.Trim(), txtFamily1MonthCheck.Text.Trim(), txtFamily12MonthCheck.Text.Trim());
            return featureNew;
        }

        private bool AddFeature(individualsinglemonth, individualtwelvemonth, twosinglemonth, twotwelvemonth, familysinglemonth, familytwelvemonth)
        {
            //Define variables
            Features featureNew;

            //Validation on reqired fields (FirstName, LastName, and Phone) 
            //In case of failure, return false (as status) to the calling code
            if (indi == "")
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


            featureNew = new Features(firstname, lastname, weight, gender, phone, email, phone, email, age, membershiptype, startdate, enddate, monthlylockerrental, monthlytrainingplan);

            //Add the new customer objec to the list
            featureList.Add(featureNew);

            //Return ture (as status) to the calling code
            return true;
        }

        //Nav links
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
