using System;
using System.Collections.Generic;
using System.Windows;
using Microsoft.Win32;

namespace WpfAssignment
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /**
         * Shows a file dialog and reads a csv file the user has selected.
         * Reads the csv file with the user class method ReadCSVFile 
         * that takes the string filename as an argument to access the file.
         * The listbox is filled with the user objects and all the info
         * of the selected object in the list is shown in bound labels
         * in the inner grid to the right of the listbox.
         * Then the statusbar textblocks are updated to 
         * show how many items are in the listbox and at 
         * what time the users were loaded into the listbox.
         */
        private void openFileMenu_Click(object sender, RoutedEventArgs e)
        {
            // Setup file dialog
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.DefaultExt = ".csv";
            fileDialog.Filter = "CSV Files (.csv)|*.csv";

            // Show file dialog.
            Nullable<bool> result = fileDialog.ShowDialog();

            // Process result.
            if(result == true)
            {
                // Load users from file into a list.
                string filename = fileDialog.FileName;
                List<User> users = User.ReadCSVFile(filename);
                
                // Load list of users into the listbox.
                listBox.ItemsSource = users; 
                
                // Show all user information of the selected user to the right of the listbox.
                gridInner.DataContext = users;

                // Set statusbar textblock with number of lines in the listbox.
                int countLines = listBox.Items.Count;
                txtNumLinesStatus.Text = countLines + " Items";
                
                // Set statusbar textblock timestamp for loading users into listbox.
                var timestamp = DateTime.Now.ToLongTimeString();
                txtTimestampStatus.Text = "Last users loaded:\t" + timestamp;
            }
        }
    }
}
