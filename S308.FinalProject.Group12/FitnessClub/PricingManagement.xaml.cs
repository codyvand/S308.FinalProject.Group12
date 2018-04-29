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
        string strIndividual1MonthCheck, strIndividual12MonthCheck, strTwoPerson1MonthCheck, strTwoPerson12MonthCheck, strFamily1MonthCheck, strFamily12MonthCheck;
        string strIndividual1Month;
        public PricingManagement()
        {

            //instantiate a list to hold the Campuses
            featureList = new List<Features>();

            //call the method to local the campus information and display
            InitializeComponent();
            ImportFeatureData();

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

            // Display he saved prices into the correct text boxes



        }

        private void rbtIndvidual1MonthYes_Checked(object sender, RoutedEventArgs e)
        {
            strIndividual1MonthCheck = "Yes";
        }

        private void rbtIndvidual1MonthNo_Checked(object sender, RoutedEventArgs e)
        {
            strIndividual1MonthCheck = "No";
        }

        private void rbtIndvidual12MonthYes_Checked(object sender, RoutedEventArgs e)
        {
            strIndividual12MonthCheck = "Yes";
        }

        private void rbtIndvidual12MonthNo_Checked(object sender, RoutedEventArgs e)
        {
            strIndividual12MonthCheck = "No";
        }

        private void rbtTwoPerson1MonthYes_Checked(object sender, RoutedEventArgs e)
        {
            strTwoPerson1MonthCheck = "Yes";
        }

        private void rbtTwoPerson1MonthNo_Checked(object sender, RoutedEventArgs e)
        {
            strTwoPerson1MonthCheck = "No";
        }

        private void rbtTwoPerson12MonthYes_Checked(object sender, RoutedEventArgs e)
        {
            strTwoPerson12MonthCheck = "Yes";
        }

        private void rbtTwoPerson12MonthNo_Checked(object sender, RoutedEventArgs e)
        {
            strTwoPerson12MonthCheck = "No";
        }

        private void rbtFamily1MonthYes_Checked(object sender, RoutedEventArgs e)
        {
            strFamily1MonthCheck = "Yes";
        }

        private void rbtFamily1MonthNo_Checked(object sender, RoutedEventArgs e)
        {
            strFamily1MonthCheck = "No";
        }

        private void rbtFamily12MonthYes_Checked(object sender, RoutedEventArgs e)
        {
            strFamily12MonthCheck = "Yes";
        }

        private void rbtFamily12MonthNo_Checked(object sender, RoutedEventArgs e)
        {
            strFamily12MonthCheck = "No";
        }


        private void btnUpdatePricing_Click(object sender, RoutedEventArgs e)
        {
            string strFilePath = @"..\..\..\Data\Features.json";

            //Declare Customers class
            Features featureNew = new Features(txtIndividual1Month.Text.Trim(), strIndividual1MonthCheck, txtIndividual12Month.Text.Trim(), strIndividual12MonthCheck, txtTwoPerson1Month.Text.Trim(), strTwoPerson1MonthCheck, txtTwoPerson12Month.Text.Trim(), strTwoPerson12MonthCheck, txtFamily1Month.Text.Trim(), strFamily1MonthCheck, txtFamily12Month.Text.Trim(), strFamily12MonthCheck);


            featureNew = new Features(txtIndividual1Month.Text.Trim(), strIndividual1MonthCheck, txtIndividual12Month.Text.Trim(), strIndividual12MonthCheck, txtTwoPerson1Month.Text.Trim(), strTwoPerson1MonthCheck, txtTwoPerson12Month.Text.Trim(), strTwoPerson12MonthCheck, txtFamily1Month.Text.Trim(), strFamily1MonthCheck, txtFamily12Month.Text.Trim(), strFamily12MonthCheck);


            //instantiate a new Campus from the input and add it to the list
            featureList.Clear();
            featureList.Add(featureNew);


            try
            {
                //serialize the new list of campuses to json format
                string jsonData = JsonConvert.SerializeObject(featureList);

                //use System.IO.File to write over the file with the json data
                System.IO.File.WriteAllText(strFilePath, jsonData);

                MessageBox.Show(featureList.Count + " Cusomters have been exported.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in export process: " + ex.Message);
            }

            MessageBox.Show("Campus Added!" + Environment.NewLine + featureNew.ToString());
        
    }

        private Features ConvertToFeatures(string strLine)
        {
            //declare a string array to hold the data 
            string[] rawData;
            //split on the delimiter into the array
            rawData = strLine.Split(',');

            //create a customer from the data
            Features featureNew = new Features(txtIndividual1Month.Text.Trim(), strIndividual1MonthCheck, txtIndividual12Month.Text.Trim(), strIndividual12MonthCheck, txtTwoPerson1Month.Text.Trim(), strTwoPerson1MonthCheck, txtTwoPerson12Month.Text.Trim(), strTwoPerson12MonthCheck, txtFamily1Month.Text.Trim(), strFamily1MonthCheck, txtFamily12Month.Text.Trim(), strFamily12MonthCheck);
            return featureNew;
            
        }

        private bool AddFeature(string individualsinglemonth, string individualsinglemonthcheck, string individualtwelvemonth, string individualtwelvemonthcheck, string twosinglemonth, string twosinglemonthcheck, string twotwelvemonth, string twotwelvemonthcheck, string familysinglemonth, string familysinglemonthcheck, string familytwelvemonth, string familytwelvemonthcheck)
        {
            //Define variables
            Features featureNew;

            featureNew = new Features(individualsinglemonth, individualsinglemonthcheck, individualtwelvemonth, individualtwelvemonthcheck, twosinglemonth, twosinglemonthcheck, twotwelvemonth, twotwelvemonthcheck, familysinglemonth, familysinglemonthcheck, familytwelvemonth, familytwelvemonthcheck);

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
