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
        string strIndividual1Month, strIndividual12Month, strTwoPerson1Month, strTwoPerson12Month, strFamily1Month, strFamily12Month;
        public PricingManagement()
        {

            //instantiate a list to hold the Campuses
            featureList = new List<Features>();

            //call the method to local the campus information and display
            InitializeComponent();
            txtIndividual1Month.Text = featureList.ToString();
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

            //set the source of the datagrid and refresh
            txtIndividual1Month.Text = featureList.ToString();
            txtIndividual1Month.Text.Refresh();

        }

        private void rbtIndvidual1MonthYes_Checked(object sender, RoutedEventArgs e)
        {
            strIndividual1Month = "Yes";
        }

        private void rbtIndvidual1MonthNo_Checked(object sender, RoutedEventArgs e)
        {
            strIndividual1Month = "No";
        }

        private void rbtIndvidual12MonthYes_Checked(object sender, RoutedEventArgs e)
        {
            strIndividual12Month = "Yes";
        }

        private void rbtIndvidual12MonthNo_Checked(object sender, RoutedEventArgs e)
        {
            strIndividual12Month = "No";
        }

        private void rbtTwoPerson1MonthYes_Checked(object sender, RoutedEventArgs e)
        {
            strTwoPerson1Month = "Yes";
        }

        private void rbtTwoPerson1MonthNo_Checked(object sender, RoutedEventArgs e)
        {
            strTwoPerson12Month = "No";
        }

        private void rbtTwoPerson12MonthYes_Checked(object sender, RoutedEventArgs e)
        {
            strTwoPerson12Month = "Yes";
        }

        private void rbtTwoPerson12MonthNo_Checked(object sender, RoutedEventArgs e)
        {
            strTwoPerson12Month = "No";
        }

        private void rbtFamily1MonthYes_Checked(object sender, RoutedEventArgs e)
        {
            strFamily1Month = "Yes";
        }

        private void rbtFamily1MonthNo_Checked(object sender, RoutedEventArgs e)
        {
            strFamily1Month = "No";
        }

        private void rbtFamily12MonthYes_Checked(object sender, RoutedEventArgs e)
        {
            strFamily12Month = "Yes";
        }

        private void rbtFamily12MonthNo_Checked(object sender, RoutedEventArgs e)
        {
            strFamily12Month = "No";
        }

        private Features ConvertToFeatures(string strLine)
        {
            //declare a string array to hold the data 
            string[] rawData;
            //split on the delimiter into the array
            rawData = strLine.Split(',');

            //create a customer from the data
            Features featureNew = new Features(txtIndividual1Month.Text.Trim(), strIndividual1Month, txtIndividual12Month.Text.Trim(), strIndividual12Month, txtTwoPerson1Month.Text.Trim(), strTwoPerson1Month, txtTwoPerson12Month.Text.Trim(), strTwoPerson12Month, txtFamily1Month.Text.Trim(), strFamily1Month, txtFamily12Month.Text.Trim(), strFamily12Month);
            return featureNew;
            
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
