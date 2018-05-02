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

            //instantiate a list to hold the Customers
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

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            List<Customers> customerSearch;

            string strFindLastName = txtFindLastNameData.Text.Trim();
            string strFindPhone = txtFindPhoneData.Text.Trim();
            string strFindEmail = txtFindEmailData.Text.Trim();
            lbxFindResults.Items.Clear();

            if (txtFindEmailData.Text == "")
            {
                if(txtFindLastNameData.Text == "")
                {
                    if(txtFindPhoneData.Text == "")
                    {
                        MessageBox.Show("Last Name and or Email and or Phone must be provided to look up a member.");
                        return;
                    }
                }

            }

            customerSearch = customerList.Where(p => p.LastName.StartsWith(strFindLastName) && p.Phone.StartsWith(strFindPhone) && p.Email.StartsWith(strFindEmail)).ToList();

            foreach (Customers p in customerSearch)
            {
                string strNamePhoneEmail = "| Last Name: " + p.LastName +" |" + "| Phone: " + p.Phone + " |" + "| Email: " + p.Email + " |" ;
                lbxFindResults.Items.Add(strNamePhoneEmail);

            }
            if (lbxFindResults.Items.IsEmpty)
            {
                MessageBox.Show("Member was not found based on the provided search information");
                return;
            }
        }

        private void lbxFindResults_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbxFindResults.SelectedIndex > -1)
            {
                string strSelectedName = lbxFindResults.SelectedItem.ToString();
                Customers customerSelected = customerList.Where(p => "| Last Name: " + p.LastName + " |" + "| Phone: " + p.Phone + " |" + "| Email: " + p.Email + " |" == strSelectedName).FirstOrDefault();
                txtPhoneData.Text = customerSelected.Phone;
                txtFirstNameData.Text = customerSelected.FirstName;
                txtLastNameData.Text = customerSelected.LastName;
                txtMembershipTypeData.Text = customerSelected.MembershipType;
                txtStartDateData.Text = customerSelected.StartDate;
                txtEndDateData.Text = customerSelected.EndDate;
                txtLockerRentalData.Text = customerSelected.MonthlyLockerRental;
                txtTrainingPlanData.Text = customerSelected.MonthlyLockerRental;
                txtWeightData.Text = customerSelected.Weight;
                txtEmailData.Text = customerSelected.Email;
                txtGenderData.Text = customerSelected.Gender;
                txtAgeData.Text = customerSelected.Age;
                txtPersonalFitnessGoalData.Text = customerSelected.PersonalFitnessGoal;
                txtCostPerMonthCost.Text = customerSelected.MembershipCostPerMonth;
                txtMonthlyTrainingPlanCost.Text = customerSelected.PersonalTrainingPlanCost;
                txtMonthlyLockerRentalCost.Text = customerSelected.LockerRentalCost;
                txtSubtotalCost.Text = customerSelected.MembershipSubtotalCost;
                txtTotalCost.Text = customerSelected.MembershipTotalCost;
            }
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



        private void btnPricingControl_Click(object sender, RoutedEventArgs e)
        {
           
            Window winPriceControl = new PriceControl();
            winPriceControl.Show();
            this.Close();
        }
    }
    }
   
   
