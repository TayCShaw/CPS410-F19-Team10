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
            username.Visible = false;
            password.Visible = false;
            info.Visible = false;
            overview.Visible = true;

            newUsername.Attributes.Add("onkeypress", "return clickButton(event,'" + btnUser.ClientID + "')");
            confirmNewUsername.Attributes.Add("onkeypress", "return clickButton(event,'" + btnUser.ClientID + "')");
            typePassword.Attributes.Add("onkeypress", "return clickButton(event,'" + btnUser.ClientID + "')");
            oldPassword.Attributes.Add("onkeypress", "return clickButton(event,'" + btnPass.ClientID + "')");
            newPass.Attributes.Add("onkeypress", "return clickButton(event,'" + btnPass.ClientID + "')");
            confirmNewPass.Attributes.Add("onkeypress", "return clickButton(event,'" + btnPass.ClientID + "')");
            major.Attributes.Add("onkeypress", "return clickButton(event,'" + btnSubmit.ClientID + "')");
        }
        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {

        }

        protected void Menu1_MenuItemClick1(object sender, MenuEventArgs e)
        {

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
         /*   Boolean changed = Database.changeUsername(newUsername.Text);

            if (changed)
            {
                lblStatus.Text = "Username successfully changed.";
            }
            else
            {
                lblStatus.Text = "ERROR: Username not changed.";
            }
            */
        }
    }
}