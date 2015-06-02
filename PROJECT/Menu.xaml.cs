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
using System.Windows.Shapes;
using System.Data.SQLite;
using System.Data;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>.
    public partial class Menu : Window
    {
        ////////////////////////
		//Simmigon Flagg end//
        ///////////////////////
        addPatient UCadd = new addPatient();
        
        searchControl UCsearch = new searchControl();
        viewPatientInfo UCViewPat = new viewPatientInfo();
        NameSearch UCHeaderTextboxes = new NameSearch();
        SQLiteConnection con;
        SQLiteCommand cmd;
        SQLiteDataReader sqlite_datareader;
        
       
        //string IsCovered;
        string firstName;
        string lastName;
        string address;
        string dob;
        string ssn;
        string phone;
        string gender;
        string veteran;
        string healthConcern;
        string descr;
        string IsInsured;
        string dbConnectionString = @"Data Source=JSAT.sqlite;Version=3;";
       
        public Menu()
        {
            InitializeComponent();

            //btnShowAll.Visibility = Visibility.Hidden;
                        
             MenuGrid.Children.Add(UCHeaderTextboxes);
             MenuGrid.Children.Add(UCViewPat);
           
        }
        

        private void exitbtn_Click(object sender, RoutedEventArgs e)
        {           
            this.Close();
        }
      
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            
            if ((UCHeaderTextboxes.txtFirstName.Text == "") && (UCHeaderTextboxes.txtLastName.Text == ""))
            {
                MessageBox.Show("Search box can not be empty");
            }
            else 
            {
                con = new SQLiteConnection(dbConnectionString);
                try
                {
                    con.Open();

                    //SEARCH QUERY
                    //Jasmine Howards
                    string FindQuery = "SELECT fname,lname,address,dob,ssn,phone,gender,veteran,healthConcern,descr,insurance FROM PatientInfo where "
                    + "fname='" + UCHeaderTextboxes.txtFirstName.Text + "' and lname='" + UCHeaderTextboxes.txtLastName.Text + "'";
                    cmd = new SQLiteCommand(FindQuery, con);
                    
                    sqlite_datareader = cmd.ExecuteReader();
                    //Reads data from database
		////////////////////////
		//Simmigon Flagg and Jovy Cortez//
        ///////////////////////
                    while (sqlite_datareader.Read())
                    {
                        firstName = sqlite_datareader.GetString(0);
                        lastName = sqlite_datareader.GetString(1);
                        address = sqlite_datareader.GetString(2);
                        dob = sqlite_datareader.GetString(3);
                        ssn = sqlite_datareader.GetString(4);
                        phone = sqlite_datareader.GetString(5);
                        gender = sqlite_datareader.GetString(6);
                        veteran = sqlite_datareader.GetString(7);
                        healthConcern = sqlite_datareader.GetString(8);
                        descr = sqlite_datareader.GetString(9);
                        

                        //Clear Tab Control before new Search
                         UCViewPat.Patient.Document.Blocks.Clear();

                        //Appends the information to the tab control on the Main Menu if person is found
                        UCViewPat.Patient.AppendText("Name:\t" + firstName + " " + lastName + "\n"
                                                    + "Address:\t " + address + "\r"
                                                    + "Birthday:\t" + dob + "\r"
                                                    + "SSN:\t" + ssn + "\r"
                                                    + "Phone:\t" + phone + "\r"
                                                    + "Sex:\t" + gender + "\r"
                                                    + "Veteran:\t" + veteran + "\r");

                       UCViewPat.Account.Document.Blocks.Clear();
                      UCViewPat.Account.AppendText("Health Concern:\r\t" + healthConcern + "\n"
                                                    + "Description:\r\t" + descr);
		////////////////////////
		//Simmigon Flagg and Jovy Cortez end here//
        ///////////////////////
                     
                    }//end of while loop
                    sqlite_datareader.Close();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    if (firstName != UCHeaderTextboxes.txtFirstName.Text &&
                        lastName != UCHeaderTextboxes.txtLastName.Text)
                    {
                        MessageBox.Show("Person not Found");
                    }
                }//end of try
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }//end of catch               
            }     
            //Clears the HeaderTextBoxes after search
            UCHeaderTextboxes.txtFirstName.Text = "";
            UCHeaderTextboxes.txtLastName.Text = "";
        }
		////////////////////////
		//Simmigon Flagg end//
        ///////////////////////
            /*
                MessageBox.Show("Person Found.");
            
                UCViewPat.tabMenuTab.Content = UCHeaderTextboxes.txtFirstName.Text + "\r" + UCHeaderTextboxes.txtLastName.Text;
                UCHeaderTextboxes.txtFirstName.Text = "";
                UCHeaderTextboxes.txtLastName.Text = "";
            } //end of if else statement
            else 
            {
                MessageBox.Show("No Record of That Person");           
            }*/
        

       
		////////////////////////
		//Simmigon Flagg begin//
        ///////////////////////
        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            //Navigation Code
            UCadd.txtFname.Text = "";
            UCadd.txtLname.Text = "";
            UCadd.txtAddress.Text = "";
            UCadd.txtDOB.Text = "";
            UCadd.txtSSN.Text = "";
            UCadd.txtPhone.Text = "";
            UCadd.txtDescr.Text = "";
            UCadd.cbGender.Text = "--Select--";
            UCadd.cbHealthConcern.Text = "--Select--";
            UCadd.cbVeteran.Text = "--Select--";
           
            

            MenuGrid.Children.Remove(UCsearch);
            MenuGrid.Children.Remove(UCadd);
            MenuGrid.Children.Remove(UCViewPat);
            MenuGrid.Children.Remove(UCHeaderTextboxes);
            MenuGrid.Children.Add(UCadd);
            btnSearch.Visibility = Visibility.Hidden;
            btnFind.Visibility = Visibility.Visible;
            //btnShowAll.Visibility = Visibility.Hidden;                       
            btnSave.IsEnabled = true;
            btnSearch.IsEnabled = true;
            btnUpdate.IsEnabled = false;

        
        }

        private void btnUpdate_Click_1(object sender, RoutedEventArgs e)
        {
            //Navigation Code
                  
            MenuGrid.Children.Remove(UCsearch);
            MenuGrid.Children.Remove(UCadd);
            MenuGrid.Children.Add(UCViewPat);
            btnNew.IsEnabled = true;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            
            if (UCadd.txtFname.Text != "" &&
                UCadd.txtLname.Text != "" &&
                UCadd.txtAddress.Text != "" &&
                UCadd.txtDOB.Text != "" &&
                UCadd.txtSSN.Text != "" &&
                UCadd.txtPhone.Text != "" &&
                UCadd.cbGender.Text != "--Select--" &&
                UCadd.cbHealthConcern.Text != "--Select--" &&
                UCadd.cbVeteran.Text != "--Select--" &&
                UCadd.txtDescr.Text != ""
                )
            {
                con = new SQLiteConnection(dbConnectionString);
                try
                {
                    con.Open();
		////////////////////////
		//Simmigon Flagg end//
        ///////////////////////
		
		////////////////////////
		//Simmigon Flagg end Jovy Cortez//
        ///////////////////////
                    string Query = "insert into PatientInfo(fname,lname,address,dob,ssn,phone,gender,veteran,healthConcern,descr,insurance) values('"
                        + UCadd.txtFname.Text + "','"
                        + UCadd.txtLname.Text + "','"
                        + UCadd.txtAddress.Text + "','"
                        + UCadd.txtDOB.Text + "','"
                        + UCadd.txtSSN.Text + "','"
                        + UCadd.txtPhone.Text + "','"
                        + UCadd.cbGender.Text + "','"
                        + UCadd.cbVeteran.Text + "','"
                        + UCadd.cbHealthConcern.Text + "','"
                        + UCadd.txtDescr.Text + "','"
                        + UCadd.checkBox1.ContentStringFormat + "')";
               
                    SQLiteCommand cmd = new SQLiteCommand(Query, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
////////////////////////
		//Simmigon Flagg and Jovy Cortez end here//
        ///////////////////////
		
		////////////////////////
		//Simmigon Flagg begin//
        ///////////////////////
                    MenuGrid.Children.Remove(UCadd);
                    //Gray New button
                    //btnNew.IsEnabled = false;
                    MenuGrid.Children.Add(UCHeaderTextboxes);
                    btnFind.Visibility = Visibility.Hidden;
                    btnSearch.Visibility = Visibility.Visible;
                    MenuGrid.Children.Add(UCViewPat);
                    UCViewPat.Patient.Document.Blocks.Clear();
                    UCViewPat.Account.Document.Blocks.Clear();
                  
		////////////////////////
		//Simmigon Flagg end//
        ///////////////////////
                    MessageBox.Show("New Patient Saved\nHealth Assessment Complete.");
                    UCViewPat.Patient.AppendText("Name:\t" + UCadd.txtFname.Text + " " + UCadd.txtLname.Text + "\n"
                                                    +"Insurance Status:\t" +UCadd.checkBox1.ContentStringFormat + "\r" 
                                                    + "Address:\t " + UCadd.txtAddress.Text + "\r"
                                                    + "Birthday:\t" + UCadd.txtDOB.Text + "\r"
                                                    + "SSN:\t" + UCadd.txtSSN.Text + "\r"
                                                    + "Phone:\t" + UCadd.txtPhone.Text + "\r"
                                                    + "Sex:\t" + UCadd.cbGender.Text + "\r"
                                                    + "Veteran:\t" + UCadd.cbVeteran.Text + "\r");


                    UCViewPat.Account.AppendText("Health Concern:\r\t" + UCadd.cbHealthConcern.Text + "\n"
                                                + "Description:\r\t" + UCadd.txtDescr.Text);
                  
                    

                }//end of try
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }//end of catch                               
                //Navigation Code
                //We are displaying the new patient info in the recent tab control.



                MenuGrid.Children.Remove(UCadd);

                
                          
            }
            else { 
                MessageBox.Show("Please Fill in all Boxes");            
            }
  
        }
     
		////////////////////////
		//Simmigon Flagg begin//
        ///////////////////////
    public void resetAllTextboxDataField(){
                UCadd.txtFname.Text = "";
                UCadd.txtLname.Text = "";
                UCadd.txtAddress.Text = "";
                UCadd.txtDOB.Text = "";
                UCadd.txtSSN.Text = "";
                UCadd.txtPhone.Text = "" ;
                UCadd.cbGender.Text = "--Select--" ;
                UCadd.cbVeteran.Text = "--Select--";
                UCadd.cbHealthConcern.Text = "--Select--";
                UCHeaderTextboxes.txtFirstName.Text = "";
                UCHeaderTextboxes.txtLastName.Text = "";
                UCViewPat.tabMenuTab.Content = "";
                UCadd.txtDescr.Text = "";
                UCadd.checkBox1.IsChecked = false;
    }

    private void btnFind_Click(object sender, RoutedEventArgs e)
    {
        //Goes Back to Search

        MenuGrid.Children.Add(UCHeaderTextboxes);
        MenuGrid.Children.Add(UCViewPat);
        MenuGrid.Children.Remove(UCadd);
        UCViewPat.tabMenuTab.Content = "";

        //btnShowAll.Visibility = Visibility.Hidden;
        btnFind.Visibility = Visibility.Hidden;
        btnSave.IsEnabled = false;
        btnSearch.Visibility = Visibility.Visible;
        btnFind.Visibility = Visibility.Hidden;
       
    }

    private void button1_Click(object sender, RoutedEventArgs e)
    {
        MenuGrid.Children.Add(UCHeaderTextboxes);
        MenuGrid.Children.Add(UCViewPat);
        MenuGrid.Children.Remove(UCadd);
        UCViewPat.tabMenuTab.Content = "";

        //btnShowAll.Visibility = Visibility.Hidden;
        btnFind.Visibility = Visibility.Hidden;
        btnSave.IsEnabled = false;
        btnSearch.Visibility = Visibility.Visible;
        btnFind.Visibility = Visibility.Hidden;
        MenuGrid.Children.Add(UCHeaderTextboxes);
        MenuGrid.Children.Add(UCViewPat);
        MenuGrid.Children.Remove(UCadd);
        UCViewPat.tabMenuTab.Content = "";

        btnFind.Visibility = Visibility.Hidden;
        btnSave.IsEnabled = false;
        btnSearch.Visibility = Visibility.Visible;
        btnFind.Visibility = Visibility.Hidden;
		
    }
	////////////////////////
		//Simmigon Flagg end//
        ///////////////////////

/** SHOW ALL RECORDS IN DATABASE
 * 
 * private void btnShowAll_Click(object sender, RoutedEventArgs e)
    {
        Window w = new Window();
      
        con = new SQLiteConnection(dbConnectionString);
        try
        {
            con.Open();

            //SEARCH QUERY
            string FindQuery = "SELECT fname,lname,address,dob,ssn,phone,gender FROM PatientInfo ";
            cmd = new SQLiteCommand(FindQuery, con);
            cmd.ExecuteNonQuery();

            SQLiteDataAdapter DataAdp = new SQLiteDataAdapter(cmd);
            DataTable dt = new DataTable("PatientInfo");
            DataAdp.Fill(dt);
            w.dataGrid1.ItemsSource = dt.DefaultView;
            DataAdp.Update(dt);
           
            con.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }

    }*/
  }

}

