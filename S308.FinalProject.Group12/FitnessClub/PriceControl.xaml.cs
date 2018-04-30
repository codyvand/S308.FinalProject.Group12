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
            InitializeComponent();
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

        private MembershipType ConvertToMembershipType(string strLine)
        {
            string[] rawData;
            rawData = strLine.Split(',');

            MembershipType membershiptypeNew = new MembershipType(rawData[0], rawData[1], rawData[2]);
            return membershiptypeNew;
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            //ClearScreen();
            membershiptypeList.Clear();
            dtgContact.Items.Refresh();
        }


        private void btnImport_Click(object sender, RoutedEventArgs e)
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
                    MessageBox.Show(strLine);
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

        private void btnExport_Click_1(object sender, RoutedEventArgs e)
        {
            string strFilePath = @"..\..\..\Data\MembershipType"
    + ".json";
            string strLine;

            try
            {
                StreamWriter writer = new StreamWriter(strFilePath, false);
                foreach (MembershipType c in membershiptypeList)
                {
                    strLine = String.Format("{0},{1},{2}", c.MembershipName
                    , c.MembershipPrice, c.MembershipAvailibility);
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
        private void AppendToFile(MembershipType membershiptypeNew)
        {
            string strFilePath = @"..\..\..\Data\MembershipType.txt";
            string strLine;

            try
            {
                StreamWriter writer = new StreamWriter(strFilePath, true);
                strLine = String.Format("{0}|{1}|{2}", membershiptypeNew.MembershipName
                    , membershiptypeNew.MembershipPrice, membershiptypeNew.MembershipAvailibility);
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

        }
    }
}
