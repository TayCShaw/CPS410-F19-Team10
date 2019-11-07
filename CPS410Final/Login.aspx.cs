using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CPS410Final
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] != null)
            {
                Response.Redirect("Account.aspx");
            }
            else
            {
                txtboxUsername.Attributes.Add("onkeypress", "return clickButton(event,'" + btnLogin.ClientID + "')");
                txtboxPassword.Attributes.Add("onkeypress", "return clickButton(event,'" + btnLogin.ClientID + "')");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            String validUser = Database.validCredentials(txtboxUsername.Text, txtboxPassword.Text);

            if (!validUser.Equals(""))
            { // User was found, information correctly entered, returning UserID
                Session["UserID"] = validUser;
                Session["Role"] = Database.getRole(validUser);

                if (Session["Redirect"] != null)
                {
                    Response.Redirect(Session["Redirect"].ToString());
                    Session["Redirect"] = null;
                }
                else
                {
                    Response.Redirect("Home.aspx");
                }
                
            }
            else
            {
                Session["UserID"] = null;
                lblError.Text = "Invalid user name or password";
            }
        }
    }
}