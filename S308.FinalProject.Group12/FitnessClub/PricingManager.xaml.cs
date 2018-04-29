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
using System.IO;
using Newtonsoft.Json;

namespace FitnessClub
{
    /// <summary>
    /// Interaction logic for PricingManager.xaml
    /// </summary>
    public partial class PricingManager : Window
    {
        List<Features> featureList;
        public PricingManager()
        {

            //instantiate a list to hold the Customers
            featureList = new List<Features>();


            //call the method to local the campus information and display
            ImportFeatureData();
            InitializeComponent();
        }
        private void ImportFeatureData()
        {
            string strFilePath = @"..\..\..\Data\Feature.json";

            try
            {
                //use System.IO.File to read the entire data file
                string jsonData = File.ReadAllText(strFilePath);

                //serialize the json data to a list of campuses
                featureList = JsonConvert.DeserializeObject<List<Features>>(jsonData);

                if (featureList.Count >= 0)
                    MessageBox.Show(featureList.Count + " Campuses have been imported.");
                else
                    MessageBox.Show("No Campuses has been imported. Please check your file.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in import process: " + ex.Message);
            }


        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            List<Features> featureSearch;

            string strMembershipType = txtFindLastNameData.Text.Trim();
            lbxFindResults.Items.Clear();

            featureSearch = featureList.Where(p => p.LastName.StartsWith(strFindLastName) && p.Phone.StartsWith(strFindPhone) && p.Email.StartsWith(strFindEmail)).ToList();

            foreach (Customers p in customerSearch)
            {
                string strNamePhoneEmail = "| Last Name: " + p.LastName + " |" + "| Phone: " + p.Phone + " |" + "| Email: " + p.Email + " |";
                lbxFindResults.Items.Add(strNamePhoneEmail);

            }
        }
    }
}
