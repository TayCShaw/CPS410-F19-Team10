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
            if (Session["UserID"] != null)
            {
                Response.Redirect("Account.aspx");
            }
            else
            {
                this.TextBoxConfirmPass.Attributes.Add("onkeypress", "return clickButton(event,'" + this.btnRegister.ClientID + "')");
                this.txtboxUsername.Attributes.Add("onkeypress", "return clickButton(event,'" + this.btnRegister.ClientID + "')");
                this.txtboxPassword.Attributes.Add("onkeypress", "return clickButton(event,'" + this.btnRegister.ClientID + "')");
                this.txtboxEmail.Attributes.Add("onkeypress", "return clickButton(event,'" + this.btnRegister.ClientID + "')");
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtboxPassword.Text.Equals(TextBoxConfirmPass.Text) && !txtboxEmail.Text.Equals("") && !txtboxUsername.Text.Equals(""))
            {
                String role = "Student";
                // TRUE if user was added, FALSE otherwise
                String userAdded = Database.addNewUser(txtboxEmail.Text, txtboxUsername.Text, txtboxPassword.Text, role);

                if (userAdded.Contains("TRUE"))
                {
                    String[] args = userAdded.Split(',');
                    Session["UserID"] = args[1];
                    Session["Role"] = role;

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