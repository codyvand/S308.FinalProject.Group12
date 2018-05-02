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
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Window
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void btnMemberInformation_Click(object sender, RoutedEventArgs e)
        {
            //Open selected page button and close previous homepage
            Window winMemberInformation = new MemberInformation();
            winMemberInformation.Show();
            this.Close(); 
        }

        private void btnMembershipSales_Click(object sender, RoutedEventArgs e)
        {
            //Open selected page button and close previous homepage
            Window winMembershipSales = new MembershipSales();
            winMembershipSales.Show();
            this.Close();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            //close out of the window homepage
            this.Close();
        }

        private void btnPriceControl_Click(object sender, RoutedEventArgs e)
        {
            //Open up selected page button and close previous homepage
            Window winPriceControl = new PriceControl();
            winPriceControl.Show();
            this.Close();
        }
    }
}
