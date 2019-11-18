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
                Login.Text = "Logout";
            }
            else
            {
              Login.Text = "Login / Register";
            }
        }


        protected void Home_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void account_Click(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                Response.Redirect("Account.aspx");
            }
        }

        protected void DiscussionBoard_Click(object sender, EventArgs e)
        {
            Response.Redirect("Subject.aspx");
        }

        protected void FindTutor_Click(object sender, EventArgs e)
        {
            Response.Redirect("Tutor.aspx");
        }

        protected void Login_Click(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                Session["UserID"] = null;
                Session["UserRole"] = null;
                Response.Redirect(Request.RawUrl);
            }
           
        }
    }
}