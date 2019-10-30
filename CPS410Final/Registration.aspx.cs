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

        protected void buttonClicked(object sender, EventArgs e)
        {
            Database.addNewUser(txtboxEmail.Text, txtboxUsername.Text, txtboxPassword.Text);
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            // TRUE if user was added, FALSE otherwise
            bool userAdded = Database.addNewUser(txtboxEmail.Text, txtboxUsername.Text, txtboxPassword.Text);

            if (userAdded)
            {
                Response.Redirect("Home.aspx");
            }

        }
    }
}