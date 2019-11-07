using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CPS410Final
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                username.Visible = false;
                password.Visible = false;
                info.Visible = false;
                overview.Visible = true;

                txtboxNewUsername.Attributes.Add("onkeypress", "return clickButton(event,'" + btnChangeUsername.ClientID + "')");
                txtboxConfirmNewUsername.Attributes.Add("onkeypress", "return clickButton(event,'" + btnChangeUsername.ClientID + "')");
                txtboxTypePassword.Attributes.Add("onkeypress", "return clickButton(event,'" + btnChangeUsername.ClientID + "')");
                txtboxCurrentPassword.Attributes.Add("onkeypress", "return clickButton(event,'" + btnChangePass.ClientID + "')");
                txtboxNewPassword.Attributes.Add("onkeypress", "return clickButton(event,'" + btnChangePass.ClientID + "')");
                txtboxConfirmNewPass.Attributes.Add("onkeypress", "return clickButton(event,'" + btnChangePass.ClientID + "')");
                major.Attributes.Add("onkeypress", "return clickButton(event,'" + btnSubmit.ClientID + "')");
            }
            
        }

        protected void btnUsername_Click(object sender, EventArgs e)
        {
            btnUsername.CssClass = "buttonActive";
            btnPassword.CssClass = "Buttons";
            btnOverview.CssClass = "Buttons";
            btnInfo.CssClass = "Buttons";
            overview.Visible = false;
            username.Visible = true;
            password.Visible = false;
            info.Visible = false;
        }

        protected void btnOverview_Click(object sender, EventArgs e)
        {
            btnUsername.CssClass = "Buttons";
            btnPassword.CssClass = "Buttons";
            btnOverview.CssClass = "buttonActive";
            btnInfo.CssClass = "Buttons";
            overview.Visible = true;
            username.Visible = false;
            password.Visible = false;
            info.Visible = false;

        }

        protected void btnPassword_Click(object sender, EventArgs e)
        {
            btnUsername.CssClass = "Buttons";
            btnPassword.CssClass = "buttonActive";
            btnOverview.CssClass = "Buttons";
            btnInfo.CssClass = "Buttons";
            overview.Visible = false;
            username.Visible = false;
            password.Visible = true;
            info.Visible = false;

        }

        protected void btnInfo_Click(object sender, EventArgs e)
        {
            btnUsername.CssClass = "Buttons";
            btnPassword.CssClass = "Buttons";
            btnOverview.CssClass = "Buttons";
            btnInfo.CssClass = "buttonActive";
            overview.Visible = false;
            username.Visible = false;
            password.Visible = false;
            info.Visible = true;
        }

        protected void btnUser_Click(object sender, EventArgs e)
        {
/*           if ()
           {
                String changed = Database.changeUsername(txtboxNewUsername.Text, Session["UserID"].ToString());
                lblUserStatus.Text = changed;
            }
            */

        }

        protected void btnPass_Click(object sender, EventArgs e)
        {
            /*
             * 1) Check if all fields are filled in 
             * 2) Check if the newPassword and confirmNewPass textfields are the same thing
             * 3) Check if currentPassword entered is actually their password
             * 4) If an error, print out the specific one
             */
            if (!passwordFieldsEmpty())
            {
                if (txtboxNewPassword.Text.Equals(txtboxConfirmNewPass.Text))
                {
                    String changed = Database.changePassword(txtboxCurrentPassword.Text, txtboxNewPassword.Text, Session["UserID"].ToString());

                    lblPasswordStatus.Text = changed;

                    overview.Visible = false;
                    username.Visible = false;
                    info.Visible = false;
                    password.Visible = true;
                }
            }
            else
            {
                lblPasswordStatus.Text = "ERROR: All fields are required!";
            }
        }

        /********* HELPER METHODS ********/

        protected Boolean passwordFieldsEmpty()
        {
            if ((txtboxCurrentPassword.Text.Length != 0) && (txtboxNewPassword.Text.Length != 0) && (txtboxConfirmNewPass.Text.Length != 0))
            {
                return false;
            }
            return true;
        }

    }
}