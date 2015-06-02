////////////////////////
//Simmigon Flagg Begin//
///////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SQLite;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
		////////////////////////
		//Simmigon Flagg Begin//
        ///////////////////////
        string dbConnectionString = @"Data Source=JSAT.sqlite;Version=3;";
        SQLiteDataReader sqlite_datareader;
        string user = "";
        string pass = "";
            
        private void loginbtn_Click(object sender, RoutedEventArgs e)
        {
         
            SQLiteConnection con = new SQLiteConnection(dbConnectionString);
            try
            {
                con.Open();
                string query = "SELECT * from admin where username = '" + txtuserName.Text + "' and password ='" + passwordBox1.Password + "'";
                SQLiteCommand cmd = new SQLiteCommand(query, con);
                SQLiteDataReader sqlite_datareader = cmd.ExecuteReader();
                while (sqlite_datareader.Read())
                {
                    user = sqlite_datareader.GetString(0);
                    pass = sqlite_datareader.GetString(1);

                }

                // SQLiteDataReader DataRead = cmd.ExecuteReader();
                // MessageBox.Show(DataRead.Read() + " ");

                con.Close();
              
                    if (user == txtuserName.Text && passwordBox1.Password == pass &&
                        txtuserName.Text!="" && passwordBox1.Password!="")
                    {
                        MessageBox.Show("Login as " + txtuserName.Text + "!");
                        this.Hide();
                        Menu my = new Menu();
                        my.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Invalid username and password!");
                    }
                }
            
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }         
    
            //Password has been disabled temporarily
           


        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
           // Close the progrm
            this.Close();
        }
		////////////////////////
		//Simmigon Flagg end//
        ///////////////////////
   }
}

