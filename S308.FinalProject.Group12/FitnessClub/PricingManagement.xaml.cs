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
            Features featureNew = new Features();
            return featureNew;
            //txtIndividual1Month.Text.Trim(), chbIndividual1Month.Content.ToString(), txtIndividual12Month.Text.Trim(), chbIndividual12Month.Content.ToString(), txtTwoPerson1Month.Text.Trim(), chbTwoPerson1Month.Content.ToString(), txtTwoPerson12Month.Text.Trim(), chbTwoPerson12Month.Content.ToString(), txtFamily1Month.Text.Trim(), chbFamily1Month.Content.ToString(), txtFamily12Month.Text.Trim(), chbFamily12Month.Content.ToString()
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
