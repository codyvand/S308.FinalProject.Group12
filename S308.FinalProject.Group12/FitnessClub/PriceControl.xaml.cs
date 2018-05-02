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
        #region Properties & Constructor
        List<MembershipType> membershiptypeList;
        public PriceControl()
        {
            InitializeComponent();
            membershiptypeList = new List<MembershipType>();
            dtgContact.ItemsSource = membershiptypeList;
        }
        #endregion

        #region Event Handlers
        private void btnImport_Click_1(object sender, RoutedEventArgs e)
        {
            //Declares the variable for the reader as well as the file path with the membership type date
            string strLine = "";
            string strFilePath = @"..\..\..\Data\MembershipType.json";

            //Clears out membership type list and utilized stream reader to import data
            try
            {
                membershiptypeList.Clear();
                StreamReader reader = new StreamReader(strFilePath);

                while (!reader.EndOfStream)
                {
                    strLine = reader.ReadLine();
                    //MessageBox.Show(strLine);
                    membershiptypeList.Add(ConvertToMembershipType(strLine));
                }
                //Close reader file after importing so that it can still be used
                reader.Close();
 
            }
            catch (Exception ex)
            {
                //If error display an error with the error message
                MessageBox.Show("Error in ready file: " + ex.Message);
                return;
            }
            //Refresh the field so that it has most current data after read
            dtgContact.Items.Refresh();
        }
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            //Define new membership type data fields so that a new membership type field can be provided
            MembershipType membershiptypeNew = new MembershipType(txtMembershipNameCreateData.Text.Trim(), txtMembershipCostCreateData.Text.Trim()
                                        , txtMembershipAvailibilityCreateData.Text.Trim(), txtMembershipLengthCreateData.Text.Trim());

            //Provided a confirmation message when a new member is added so that action can be confirmed
            MessageBoxResult messageBoxResult = MessageBox.Show("Do you want to save the following contact?"
                + Environment.NewLine + Environment.NewLine + membershiptypeNew.ToString()
                , "Create New Contact"
                , MessageBoxButton.YesNo);

            //Act upon selected value of the message box by adding new memeber if yes is selected and stoping if no
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                membershiptypeList.Add(membershiptypeNew);
                dtgContact.Items.Refresh();

                AppendToFile(membershiptypeNew);

                ClearScreen();
                MessageBox.Show("New Contact Saved!");
            }
        }

        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
            //Define the variables for the export click such as strLine for the lookup and the file path with the data that we want to export it as so it copies over the old file
            string strFilePath = @"..\..\..\Data\MembershipType"
    + ".json";
            string strLine;

            try
            {
                //Utilze stream writer to right the file path
                StreamWriter writer = new StreamWriter(strFilePath, false);
                foreach (MembershipType c in membershiptypeList)
                {
                    //Define the format for which the file is to be read and then writen in
                    strLine = String.Format("{0}|{1}|{2}|{3}", c.MembershipName
                    , c.MembershipPrice, c.MembershipAvailibility, c.MembershipLength);
                    writer.WriteLine(strLine);
                }
                //Close the write so an new process can be enabled
                writer.Close();
            }
            catch (Exception ex)
            {
                //If there is an error provide an error message
                MessageBox.Show("Error in write file: " + ex.Message);
                return;
            }
            //Provided confirmation message for the new updated file
            MessageBox.Show("Export completed!" + Environment.NewLine + "File Created: " + strFilePath);
        }
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            //Clear the values on the datagrid incase one would like to not display the data grid values
            ClearScreen();
            membershiptypeList.Clear();
            dtgContact.Items.Refresh();
        }
        #endregion

        #region Helper Functions
        private MembershipType ConvertToMembershipType(string strLine)
        {
            //Declare a helper function to convert the membership type data so that it can be put in an array format
            string[] rawData;
            //The Array is broken up by | so this is how the array will be handled
            rawData = strLine.Split('|');

            MembershipType membershiptypeNew = new MembershipType(rawData[0], rawData[1], rawData[2], rawData[3]);
            return membershiptypeNew;
        }

        private void AppendToFile(MembershipType membershiptypeNew)
        {
            //Declare the variables for the strLine as well as the file path for the Membership data
            string strFilePath = @"..\..\..\Data\MembershipType.txt";
            string strLine;

            try
            {
                //Utilize stream writer and define the array so that the strLine can be read and writen
                StreamWriter writer = new StreamWriter(strFilePath, true);
                strLine = String.Format("{0}|{1}|{2}|{3}", membershiptypeNew.MembershipName, membershiptypeNew.MembershipPrice, membershiptypeNew.MembershipAvailibility, membershiptypeNew.MembershipLength);
                writer.WriteLine(strLine);
                //Close out the writer
                writer.Close();
            }
            catch (Exception ex)
            {
                //If thee is an error display the error message
                MessageBox.Show("Error in append file: " + ex.Message);
                return;
            }
        }

        private void ClearScreen()
        {
            //clear out the values 
            txtMembershipNameCreateData.Text = "";
            txtMembershipCostCreateData.Text = "";
            txtMembershipAvailibilityCreateData.Text = "";
            txtMembershipLengthCreateData.Text = "";
        }

        #endregion

        private void btnMainMenu_Click(object sender, RoutedEventArgs e)
        {
            //Open the selected button and close out of the current page
            Window winHomePage = new HomePage();
            winHomePage.Show();
            this.Close();
        }

        private void btnMemberInformation_Click(object sender, RoutedEventArgs e)
        {
            //Open the selected button and close out of the current page
            Window winMemberInformation = new MemberInformation();
            winMemberInformation.Show();
            this.Close();
        }

        private void btnMembershipSales_Click(object sender, RoutedEventArgs e)
        {
            //Open the selected button and close out of the current page
            Window winMembershipSales = new MembershipSales();
            winMembershipSales.Show();
            this.Close();
        }

        private void btnPricingControl_Click(object sender, RoutedEventArgs e)
        {
            //Open the selected button and close out of the current page
            Window winPriceControl = new PriceControl();
            winPriceControl.Show();
            this.Close();
        }
    }
}
