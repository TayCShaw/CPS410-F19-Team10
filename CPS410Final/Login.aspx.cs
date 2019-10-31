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

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            String validUser = Database.validCredentials(txtboxUsername.Text, txtboxPassword.Text);

            if (!validUser.Equals(""))
            { // User was found, information correctly entered, returning UserID
                Session["UserID"] = validUser;
                Response.Redirect("Home.aspx");
            }
        }
    }
}