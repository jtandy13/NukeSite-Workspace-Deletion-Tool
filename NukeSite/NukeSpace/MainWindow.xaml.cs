using System;
using System.Collections.Generic;
using System.Windows;
using IManage;
using System.IO;

namespace NukeSpace
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            NukeSetting myNuke = new NukeSetting();
            this.DataContext = myNuke;
        }

        private void NukeButton_Click(object sender, RoutedEventArgs e)
        {
            //Connect to the data context
            NukeSetting dc = this.DataContext as NukeSetting;
            
            //Connect to the iManage database
            IManDMS myDMS = new ManDMS();
            IManSession mySess = myDMS.Sessions.Add(dc.serverName);
           
            
            try
            {//Should be removed in the final product
                mySess.TrustedLogin();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            IManDatabase myDB = mySess.Databases.ItemByName(dc.DBname);

            //Create a list to hold all the folder ids
            List<int> folderList = new List<int>();

            //Track status of csv file opening
            Boolean fileStatus = false;

            //Open the csv file and read the contents
            try
            {
                var csvReader = new StreamReader(File.OpenRead(@dc.csvPath));
                fileStatus = true;
                //Populate folderList with data from the csv
                while (!csvReader.EndOfStream)
                {
                    var line = csvReader.ReadLine();
                    int id;
                    Boolean success = Int32.TryParse(line, out id);
                    folderList.Add(id);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //Only run the delete loop if the csv can be opened
            if(fileStatus == true)
            {
                try
                {
                    foreach (int folder in folderList)
                    {
                        myDB.DeleteWorkspace(folder);
                    }
                    MessageBox.Show("All workspaces deleted successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
