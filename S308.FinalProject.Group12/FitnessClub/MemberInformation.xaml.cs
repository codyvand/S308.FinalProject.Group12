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
            dtgFindResults.ItemsSource = customerList;

            //call the method to local the campus information and display
            ImportCustomerData();
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

            //set the source of the datagrid and refresh
            dtgFindResults.ItemsSource = customerList;
            dtgFindResults.Items.Refresh();
        }
    }
    }
}
