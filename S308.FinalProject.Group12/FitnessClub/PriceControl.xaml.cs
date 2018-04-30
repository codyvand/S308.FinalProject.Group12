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
    /// Interaction logic for PriceControl.xaml
    /// </summary>
    public partial class PriceControl : Window
    {
        List<MembershipType> membershiptypeList;
        public PriceControl()
        {
            //instantiate a list to hold the membership types
            membershiptypeList = new List<MembershipType>();


            //call the method to local the campus information and display
            ImportMembershipData();
            InitializeComponent();
        }
        private void ImportMembershipData()
        {
            string strFilePath = @"..\..\..\Data\MembershipType.json";

            try
            {
                //use System.IO.File to read the entire data file
                string jsonData = File.ReadAllText(strFilePath);

                //serialize the json data to a list of membership types
                membershiptypeList = JsonConvert.DeserializeObject<List<MembershipType>>(jsonData);

                if (membershiptypeList.Count >= 0)
                    MessageBox.Show(membershiptypeList.Count + " Membership Types have been imported.");
                else
                    MessageBox.Show("No Membership Types has been imported. Please check your file.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in import process: " + ex.Message);
            }


        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            List<MembershipType> membershiptypeSearch;

            string strMembershipTypeSearch = txtMembershipTypeSearch.Text.Trim();
            lbxFindResults.Items.Clear();

            membershiptypeSearch = membershiptypeList.Where(p => p.MembershipName.StartsWith(strMembershipTypeSearch)).ToList();

            foreach (MembershipType p in membershiptypeSearch)
            {
                string strMembershipName = "Membership Name:" + p.MembershipName;
                lbxFindResults.Items.Add(strMembershipName);
            }
        }


        private void lbxFindResults_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbxFindResults.SelectedIndex > -1)
            {
                string strSelectedName = lbxFindResults.SelectedItem.ToString();
                MembershipType membershipSelected = membershiptypeList.Where(p => "Membership Name:" + p.MembershipName == strSelectedName).FirstOrDefault();
                txtMembershipTypeNameData.Text = membershipSelected.MembershipName;
                txtMembershipCostData.Text = membershipSelected.MembershipPrice;
                txtMembershipAvailibilityData.Text = membershipSelected.MembershipAvailibility;
            }
        }
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
    }
}
