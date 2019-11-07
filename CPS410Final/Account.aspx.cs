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
            tutorInfo.Visible = false;

            newUsername.Attributes.Add("onkeypress", "return clickButton(event,'" + btnUser.ClientID + "')");
            confirmNewUsername.Attributes.Add("onkeypress", "return clickButton(event,'" + btnUser.ClientID + "')");
            typePassword.Attributes.Add("onkeypress", "return clickButton(event,'" + btnUser.ClientID + "')");
            oldPassword.Attributes.Add("onkeypress", "return clickButton(event,'" + btnPass.ClientID + "')");
            newPass.Attributes.Add("onkeypress", "return clickButton(event,'" + btnPass.ClientID + "')");
            confirmNewPass.Attributes.Add("onkeypress", "return clickButton(event,'" + btnPass.ClientID + "')");
            major.Attributes.Add("onkeypress", "return clickButton(event,'" + btnSubmit.ClientID + "')");
            gradDate.Attributes.Add("onkeypress", "return clickButton(event,'" + btnTutorInfo.ClientID + "')");
            degree.Attributes.Add("onkeypress", "return clickButton(event,'" + btnTutorInfo.ClientID + "')");
            experience.Attributes.Add("onkeypress", "return clickButton(event,'" + btnTutorInfo.ClientID + "')");
            contact.Attributes.Add("onkeypress", "return clickButton(event,'" + btnTutorInfo.ClientID + "')");

            //hide tutorInfo edit button if user is a student, show if tutor
            if(Session["UserRole"].ToString().Equals("Tutor"))
            {
                btnTutor.Visible = true;
            }
            else //student account, hide tutor button
            {
                btnTutor.Visible = false;
            }
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
            btnTutor.CssClass = "Buttons";
            overview.Visible = false;
            username.Visible = true;
            password.Visible = false;
            info.Visible = false;
            tutorInfo.Visible = false;
        }

        protected void btnOverview_Click(object sender, EventArgs e)
        {
            btnUsername.CssClass = "Buttons";
            btnPassword.CssClass = "Buttons";
            btnOverview.CssClass = "buttonActive";
            btnInfo.CssClass = "Buttons";
            btnTutor.CssClass = "Buttons";
            overview.Visible = true;
            username.Visible = false;
            password.Visible = false;
            info.Visible = false;
            tutorInfo.Visible = false;

        }

        protected void btnPassword_Click(object sender, EventArgs e)
        {
            btnUsername.CssClass = "Buttons";
            btnPassword.CssClass = "buttonActive";
            btnOverview.CssClass = "Buttons";
            btnInfo.CssClass = "Buttons";
            btnTutor.CssClass = "Buttons";
            overview.Visible = false;
            username.Visible = false;
            password.Visible = true;
            info.Visible = false;
            tutorInfo.Visible = false;

        }

        protected void btnInfo_Click(object sender, EventArgs e)
        {
            btnUsername.CssClass = "Buttons";
            btnPassword.CssClass = "Buttons";
            btnOverview.CssClass = "Buttons";
            btnInfo.CssClass = "buttonActive";
            btnTutor.CssClass = "Buttons";
            overview.Visible = false;
            username.Visible = false;
            password.Visible = false;
            info.Visible = true;
            tutorInfo.Visible = false;
        }

        protected void btnUser_Click(object sender, EventArgs e)
        {
            btnUsername.CssClass = "buttonActive";
            btnPassword.CssClass = "Buttons";
            btnOverview.CssClass = "Buttons";
            btnInfo.CssClass = "Buttons";
            btnTutor.CssClass = "Buttons";
            overview.Visible = false;
            username.Visible = true;
            password.Visible = false;
            info.Visible = false;
            tutorInfo.Visible = false;

        }

        protected void btnTutor_Click(object sender, EventArgs e)
        {
            btnUsername.CssClass = "Buttons";
            btnPassword.CssClass = "Buttons";
            btnOverview.CssClass = "Buttons";
            btnInfo.CssClass = "Buttons";
            btnTutor.CssClass = "buttonActive";
            overview.Visible = false;
            username.Visible = false;
            password.Visible = false;
            info.Visible = false;
            tutorInfo.Visible = true;
        }

        protected void btnPass_Click(object sender, EventArgs e)
        {
            btnUsername.CssClass = "Buttons";
            btnPassword.CssClass = "buttonActive";
            btnOverview.CssClass = "Buttons";
            btnInfo.CssClass = "Buttons";
            btnTutor.CssClass = "Buttons";
            overview.Visible = false;
            username.Visible = false;
            password.Visible = true;
            info.Visible = false;
            tutorInfo.Visible = false;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            btnUsername.CssClass = "Buttons";
            btnPassword.CssClass = "Buttons";
            btnOverview.CssClass = "Buttons";
            btnInfo.CssClass = "buttonActive";
            btnTutor.CssClass = "Buttons";
            overview.Visible = false;
            username.Visible = false;
            password.Visible = false;
            info.Visible = true;
            tutorInfo.Visible = false;
        }

        protected void btnTutorInfo_Click(object sender, EventArgs e)
        {
            btnUsername.CssClass = "Buttons";
            btnPassword.CssClass = "Buttons";
            btnOverview.CssClass = "Buttons";
            btnInfo.CssClass = "Buttons";
            btnTutor.CssClass = "buttonActive";
            overview.Visible = false;
            username.Visible = false;
            password.Visible = false;
            info.Visible = false;
            tutorInfo.Visible = true;
        }
    }
}