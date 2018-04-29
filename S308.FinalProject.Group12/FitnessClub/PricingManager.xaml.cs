﻿using System;
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
        public PricingManager()
        {

            //instantiate a list to hold the Customers
            membershiptypeList = new List<MembershipType>();


            //call the method to local the campus information and display
            ImportMembershipTypeData();
            InitializeComponent();
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
    }
}
