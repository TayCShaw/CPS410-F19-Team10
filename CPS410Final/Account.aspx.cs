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
            if (Session["UserID"] != null)
            {
                username.Visible = false;
                password.Visible = false;
                info.Visible = false;
                overview.Visible = true;
                tutorInfo.Visible = false;

                txtboxNewUsername.Attributes.Add("onkeypress", "return clickButton(event,'" + btnUsername.ClientID + "')");
                txtboxConfirmNewUsername.Attributes.Add("onkeypress", "return clickButton(event,'" + btnUsername.ClientID + "')");
                txtboxTypePassword.Attributes.Add("onkeypress", "return clickButton(event,'" + btnUsername.ClientID + "')");
                txtboxCurrentPassword.Attributes.Add("onkeypress", "return clickButton(event,'" + btnChangePass.ClientID + "')");
                txtboxNewPassword.Attributes.Add("onkeypress", "return clickButton(event,'" + btnChangePass.ClientID + "')");
                txtboxConfirmNewPass.Attributes.Add("onkeypress", "return clickButton(event,'" + btnChangePass.ClientID + "')");
                major.Attributes.Add("onkeypress", "return clickButton(event,'" + btnSubmit.ClientID + "')");
                gradDate.Attributes.Add("onkeypress", "return clickButton(event,'" + btnTutorInfo.ClientID + "')");
                degree.Attributes.Add("onkeypress", "return clickButton(event,'" + btnTutorInfo.ClientID + "')");
                experience.Attributes.Add("onkeypress", "return clickButton(event,'" + btnTutorInfo.ClientID + "')");
                contact.Attributes.Add("onkeypress", "return clickButton(event,'" + btnTutorInfo.ClientID + "')");

                //hide tutorInfo edit button if user is a student, show if tutor
                if (Session["UserRole"].ToString().Equals("Tutor"))
                {
                    btnTutor.Visible = true;
                }
                else //student account, hide tutor button
                {
                    btnTutor.Visible = false;
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }         
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

        protected void btnChangePass_Click(object sender, EventArgs e)
        {
            /*
             * 1) Check if all fields are filled in 
             * 2) Check if the newPassword and confirmNewPass textfields are the same thing
             * 3) Check if currentPassword entered is actually their password
             * 4) If an error, print out the specific one
             */
            if (Security.checkPassword(txtboxCurrentPassword.Text, Session["UserID"].ToString()))
            {
                if (txtboxNewPassword.Text.Equals(txtboxConfirmNewPass.Text))
                {
                    String changed = Database.changePassword(txtboxCurrentPassword.Text, txtboxNewPassword.Text, Session["UserID"].ToString());

                    lblPasswordStatus.Text = changed;
                }
            }
            else
            {
                lblPasswordStatus.ForeColor = System.Drawing.Color.Red;
                lblPasswordStatus.Text = "Incorrect password.";
            }

            // Keep password page open
            overview.Visible = false;
            password.Visible = true;
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