using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CPS410Final
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if(Session["UserID"] != null){
                lblLogin.Text = "Logout";
            }
            else
            {
                lblLogin.Text = "Login / Register";
            }
        }
        protected void btnClick(object sender, MenuEventArgs e)
        {
            if (!lblLogin.Text.Equals("Logout"))
            {
                Session["UserID"] = null;
                Response.Redirect("tutor.aspx");
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}