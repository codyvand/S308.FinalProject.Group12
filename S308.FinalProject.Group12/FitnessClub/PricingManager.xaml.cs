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
        List<MembershipType> membershiptypeList;
        string  strMembershipName,  strMembershipPrice,  strMembershipLength, strMembershipAvailibility;

       
       
        public PricingManager()
        {

            //instantiate a list to hold the Customers
            membershiptypeList = new List<MembershipType>();


            //call the method to local the campus information and display
            InitializeComponent();
            ImportMembershipTypeData();
          
        }
        private void ImportMembershipTypeData()
        {
            string strFilePath = @"..\..\..\Data\MembershipType.json";

            try
            {
                //use System.IO.File to read the entire data file
                string jsonData = File.ReadAllText(strFilePath);

                //serialize the json data to a list of campuses
                membershiptypeList = JsonConvert.DeserializeObject<List<MembershipType>>(jsonData);

                if (membershiptypeList.Count >= 0)
                    MessageBox.Show(membershiptypeList.Count + " Campuses have been imported.");
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
            List<MembershipType> membershiptypeSearch;

            string strMembershipType = cbxMembershipTypeData.Text;
            lbxFindResults.Items.Clear();

            membershiptypeSearch = membershiptypeList.Where(p => p.MembershipName.StartsWith(strMembershipType)).ToList();

            foreach (MembershipType p in membershiptypeSearch)
            {
                string strNamePhoneEmail = "Name: " + p.MembershipName + Environment.NewLine + "Price:  " + p.MembershipPrice + Environment.NewLine + "Availibility: " + p.MembershipAvailibility;
                lbxFindResults.Items.Add(strNamePhoneEmail);

            }
        }

        //Navigation
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
        // This
        private void lbxFindResults_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbxFindResults.SelectedIndex > -1)
            {
                string strSelectedName = lbxFindResults.SelectedItem.ToString();
                MembershipType membershiptypeSelected = membershiptypeList.Where(p => "Name: " + p.MembershipName + Environment.NewLine + "Price:  " + p.MembershipPrice + Environment.NewLine + "Availibility: " + p.MembershipAvailibility == strSelectedName).FirstOrDefault();
                txtAvailibiltyData.Text = membershiptypeSelected.MembershipAvailibility;
                txtPricingData.Text = membershiptypeSelected.MembershipPrice;
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            string strFilePath = @"..\..\..\Data\MembershipType.json";

            //Declare MembershipType class
            MembershipType membershiptypeNew = new MembershipType(strMembershipName,strMembershipPrice, strMembershipLength,strMembershipAvailibility);


            membershiptypeNew = new MembershipType();


            //instantiate a new Campus from the input and add it to the list
            membershiptypeList.Clear();
            membershiptypeList.Add(membershiptypeNew);


            try
            {
                //serialize the new list of memberships to json format
                string jsonData = JsonConvert.SerializeObject(membershiptypeList);

                //use System.IO.File to write over the file with the json data
                System.IO.File.WriteAllText(strFilePath, jsonData);

                MessageBox.Show(membershiptypeList.Count + " Cusomters have been exported.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in export process: " + ex.Message);
            }

            MessageBox.Show("Campus Added!" + Environment.NewLine + membershiptypeNew.ToString());
        }

        private MembershipType ConvertToMembershipType(string strLine)
        {
            //declare a string array to hold the data 
            string[] rawData;
            //split on the delimiter into the array
            rawData = strLine.Split(',');

            //create a customer from the data
            MembershipType membershiptypeNew = new MembershipType(strMembershipName,strMembershipPrice, strMembershipLength, strMembershipAvailibility);
            return membershiptypeNew;

        }
        private bool AddMembershipType(string membershipname, string membershipprice, string membershiplength, string membershipavailibility)
        {
            //Define variables
            MembershipType membershiptypeNew;

            membershiptypeNew = new MembershipType(membershipname, membershipprice, membershiplength, membershipavailibility);

            //Add the new customer objec to the list
            membershiptypeList.Add(membershiptypeNew);

            //Return ture (as status) to the calling code
            return true;
        }
    }
}
