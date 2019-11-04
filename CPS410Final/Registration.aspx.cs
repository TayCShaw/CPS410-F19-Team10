using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CPS410Final
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtboxPassword.Text.Equals(TextBoxConfirmPass.Text) && !txtboxEmail.Text.Equals("") && !txtboxUsername.Text.Equals(""))
            {
                // TRUE if user was added, FALSE otherwise
                String userAdded = Database.addNewUser(txtboxEmail.Text, txtboxUsername.Text, txtboxPassword.Text);

                if (userAdded.Contains("TRUE"))
                {
                    Response.Redirect("Account.aspx");
                }
                else if(userAdded.Contains("Username"))
                {
                    lblError.Text = userAdded;
                }else if (userAdded.Contains("FALSE"))
                {
                    lblError.Text = "ERROR: Failed account creation. Please contact an Administrator.";
                }
            }
            else
            {
                if (txtboxEmail.Text.Equals(""))
                {
                    lblError.Text = "Please enter an email";
                }
                else if(txtboxUsername.Text.Equals(""))
                {
                    lblError.Text = "Please enter a username";
                }
                else
                {
                    lblError.Text = "Passwords do not match";
                }
            }

        }
    }
}