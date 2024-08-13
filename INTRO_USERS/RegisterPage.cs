using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace INTRO_USERS
{
    //Name:
    //Student ID:

    public partial class RegisterPage : Form
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Registers the new user as long as all textboxes hold text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRegister_Click(object sender, EventArgs e)
        {
            //variables to be used
            string username = "", password = "", firstname = "", middlename = "", lastname = "";

            //Check that the text boxes has something typed in it using a method
            bool hasText = checkTextBoxes();
            if (!hasText)
            {
                MessageBox.Show("Please make sure all textboxes have text.  Middle Name is not compulsory");
                textBoxUserName.Focus();
                return;
            }

            //(1) GET the data from the textboxes and store into variables created above, good to put in a try catch with error message
            try
            {
                /*YOUR CODE HERE*/
                username = textBoxUserName.Text.Trim();
                password = textBoxPassword.Text.Trim();
                firstname = textBoxFirst.Text.Trim();
                middlename = textBoxMiddle.Text.Trim();
                lastname = textBoxLast.Text.Trim();

                  
            }
            catch
            {
                //Error message, more useful when you are storing numbers etc. into the database.
                MessageBox.Show("Username or Password given is in an incorrect format.");
                return;
            }

            //(2) Execute the INSERT statement, making sure all quotes and commas are in the correct places.
            //      Practice first on SQL Server Management Studio to make sure it is entering the correct data and in the correct format,
            //      then copy across the statement and where there are string replace the actual text for the variables stored above.
            //Example query: " INSERT INTO Users VALUES ('jkc1', 'John', 'Middle', 'Carter', 'pass1') "
            try
            {
                SQL.executeQuery("INSERT INTO Users Values ('" + username + "', '" + firstname + "', '" + middlename + "', '" + lastname + "', '" + password + "')");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Register attempt unsuccessful.  Check insert statement.  Could be a Username conflict too.");
                return;
            }



            //success message for the user to know it worked
            MessageBox.Show("Successfully Registered: " + firstname + " " + lastname + ". Your username is: " + username);

            //Go back to the login page since we registered successfully to let the user log in
            Hide();                                 //hides the register form
            LoginPage login = new LoginPage();      //creates the login page as an object
            login.ShowDialog();                     //shows the new login page form
            this.Close();                           //closes the register form that was hidden
        }

        /// <summary>
        /// Clears all text boxes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonClear_Click(object sender, EventArgs e)
        {
            initialiseTextBoxes();
        }

        /// <summary>
        /// Takes us back to the login screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            //hides this form currently on
            Hide();
            //is the login page as a new object               
            LoginPage login = new LoginPage();
            //Shows the login page window
            login.ShowDialog();
            //closes the current open windows so its only the new one showing
            this.Close();
        }


        /* Methods go below here */

        /// <summary>
        /// Checks if they textboxes have data in them
        /// </summary>
        /// <returns>TRUE if all hold text, but FALSE if at least one does not hold data</returns>
        private bool checkTextBoxes()
        {
            bool holdsData = true;
            //go through all of the controls
            foreach (Control c in this.Controls)
            {
                //if its a textbox, but doesnt matter if its middle textbox
                if (c is TextBox && (c != textBoxMiddle))
                {
                    //If it is not the case that it is empty
                    if ("".Equals((c as TextBox).Text.Trim()))
                    {
                        //set boolean to false because on textbox is empty
                        holdsData = false;
                    }
                }
            }
            //returns true or false based on if data is in all text boxs or not
            return holdsData;
        }
        /// <summary>
        /// Initialises all textboxes to blank text
        /// Does nothing in terms of re-focusing
        /// </summary>
        private void initialiseTextBoxes()
        {
            //goes through and clears all of the textboxes
            foreach (Control c in this.Controls)
            {
                //if the it is a textbox
                if (c is TextBox)
                {
                    //clear the text box
                    (c as TextBox).Clear();
                }
            }
            //focus on first text box
            textBoxUserName.Focus();
        }
    }
}
