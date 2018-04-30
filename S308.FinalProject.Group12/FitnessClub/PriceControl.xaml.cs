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
            string strLine = "";
            string strFilePath = @"..\..\..\Data\MembershipType.json";

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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in ready file: " + ex.Message);
                return;
            }

            dtgContact.Items.Refresh();
        }
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            MembershipType membershiptypeNew = new MembershipType(txtMembershipNameCreateData.Text.Trim(), txtMembershipCostCreateData.Text.Trim()
                                        , txtMembershipAvailibilityCreateData.Text.Trim(), txtMembershipLengthCreateData.Text.Trim());

            MessageBoxResult messageBoxResult = MessageBox.Show("Do you want to save the following contact?"
                + Environment.NewLine + Environment.NewLine + membershiptypeNew.ToString()
                , "Create New Contact"
                , MessageBoxButton.YesNo);

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
            string strFilePath = @"..\..\..\Data\Contacts"
    + ".json";
            string strLine;

            try
            {
                StreamWriter writer = new StreamWriter(strFilePath, false);
                foreach (MembershipType c in membershiptypeList)
                {
                    strLine = String.Format("{0}|{1}|{2}|{3}", c.MembershipName
                    , c.MembershipPrice, c.MembershipAvailibility, c.MembershipLength);
                    writer.WriteLine(strLine);
                }

                writer.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in write file: " + ex.Message);
                return;
            }

            MessageBox.Show("Export completed!" + Environment.NewLine + "File Created: " + strFilePath);
        }
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            ClearScreen();
            membershiptypeList.Clear();
            dtgContact.Items.Refresh();
        }
        #endregion

        #region Helper Functions
        private MembershipType ConvertToMembershipType(string strLine)
        {
            string[] rawData;
            rawData = strLine.Split('|');

            MembershipType membershiptypeNew = new MembershipType(rawData[0], rawData[1], rawData[2], rawData[3]);
            return membershiptypeNew;
        }

        private void AppendToFile(MembershipType membershiptypeNew)
        {
            string strFilePath = @"..\..\..\Data\MembershipType.txt";
            string strLine;

            try
            {
                StreamWriter writer = new StreamWriter(strFilePath, true);
                strLine = String.Format("{0}|{1}|{2}|{3}", membershiptypeNew.MembershipName, membershiptypeNew.MembershipPrice, membershiptypeNew.MembershipAvailibility, membershiptypeNew.MembershipLength);
                writer.WriteLine(strLine);
                writer.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in append file: " + ex.Message);
                return;
            }
        }

        private void ClearScreen()
        {
            txtMembershipNameCreateData.Text = "";
            txtMembershipCostCreateData.Text = "";
            txtMembershipAvailibilityCreateData.Text = "";
            txtMembershipLengthCreateData.Text = "";
        }

        #endregion

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
