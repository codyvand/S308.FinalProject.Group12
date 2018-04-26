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
    /// Interaction logic for MemberInformation.xaml
    /// </summary>
    public partial class MemberInformation : Window
    {
        List<Customers> customerList;
        public MemberInformation()
        {
            InitializeComponent();

            //instantiate a list to hold the Campuses
            customerList = new List<Customers>();
            lbxFindResults.ItemsSource = customerList;
           
        }

        public List<Customers> GetDataSetFromFile()
        {
            List<Customers> lstCustomer = new List<Customers>();

            string strFilePath = @"../../../Data/Customers.json";

            try
            {
                string jsonData = File.ReadAllText(strFilePath);
                lstCustomer = JsonConvert.DeserializeObject<List<Customers>>(jsonData);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading Customer from file: " + ex.Message);
            }

            return lstCustomer;
        }

        // Search Button functionality
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {

            List<Customers> lstCustomer;

            string strNametxtFindLastNameData = txtFindLastNameData.Text.Trim();

            string strFindPhoneData = txtFindPhoneData.Text.Trim();

            string strFindEmailData = txtFindEmailData.Text.Trim();


            txtDetails.Text = "";
            lbxPokemon.Items.Clear();

            pokemonSearch = pokemonIndex.Where(p =>
                p.name.StartsWith(strName) &&
                p.base_experience >= intExpMin &&
                p.base_experience <= intExpMax &&
                p.height >= intHeightMin &&
                p.height <= intHeightMax &&
                p.weight >= intWeightMin &&
                p.weight <= intWeightMax &&
                (strType == "All" || p.types.Exists(t => t.type.name == strType))
            ).ToList();

            foreach (Pokemon p in pokemonSearch)
            {
                lbxPokemon.Items.Add(p.name);
            }

            lblNumFound.Content = "(" + pokemonSearch.Count.ToString() + ")";

        }








        // Navigation Links
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
   
