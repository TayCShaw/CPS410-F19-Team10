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
            this.TextBoxConfirmPass.Attributes.Add("onkeypress", "return clickButton(event,'" + this.btnRegister.ClientID + "')");
            this.txtboxUsername.Attributes.Add("onkeypress", "return clickButton(event,'" + this.btnRegister.ClientID + "')");
            this.txtboxPassword.Attributes.Add("onkeypress", "return clickButton(event,'" + this.btnRegister.ClientID + "')");
            this.txtboxEmail.Attributes.Add("onkeypress", "return clickButton(event,'" + this.btnRegister.ClientID + "')");
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtboxPassword.Text.Equals(TextBoxConfirmPass.Text) && !txtboxEmail.Text.Equals("") && !txtboxUsername.Text.Equals(""))
            {
                // TRUE if user was added, FALSE otherwise
                bool userAdded = Database.addNewUser(txtboxEmail.Text, txtboxUsername.Text, txtboxPassword.Text);

                if (userAdded)
                {
                    Response.Redirect("Account.aspx");
                }
                else
                {
                    lblError.Text = "User Name is Unabailable";
                }
            }
            else
            {
                if (txtboxEmail.Text.Equals(""))
                {
                    lblError.Text = "please enter a email";
                }
                else if(txtboxUsername.Text.Equals(""))
                {
                    lblError.Text = "Please enter a User Name";
                }
                else
                {
                    lblError.Text = "Passwords do not match";
                }
            }

        }
    }
}