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
        /* 
         * Load in the account overview tab initially, hide all other divs
         */
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
                
                txtboxMajor.Attributes.Add("onkeypress", "return clickButton(event,'" + btnSubmitAccountInfo.ClientID + "')");
                txtboxGraduationDate.Attributes.Add("onkeypress", "return clickButton(event,'" + btnTutorInfo.ClientID + "')");
                txtboxDegree.Attributes.Add("onkeypress", "return clickButton(event,'" + btnTutorInfo.ClientID + "')");
                txtboxExperience.Attributes.Add("onkeypress", "return clickButton(event,'" + btnTutorInfo.ClientID + "')");
                txtboxContactInformation.Attributes.Add("onkeypress", "return clickButton(event,'" + btnTutorInfo.ClientID + "')");

                if (Session["UserRole"].ToString().Equals("Tutor"))
                {
                    btnTutor.Visible = true;
                    btnInfo.Visible = false;
                }
                else //student account, hide tutor button
                {
                    btnTutor.Visible = false;
                    btnInfo.Visible = true;
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }         
        }

        /********** SIDE NAVIGATION BAR **********/
        /*
         * Show Account overview div on button click, 
         * highlight overview button
         */
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
        
        
        //show username div on click, hide all other divs
        //also highlight the button clicked on left side
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
        
        
        /*
         * Show password change div on click, highlight password button
         */
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
        
        
        /*
         * Show Edit info div on click, highlight  info button
         */
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

        /*
         * Show Tutor info on click, highlight tutor button
         */
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


        /*****************************************/

        /********** NAVIGATION BAR FUNCTIONALITY **********/

        protected void btnChangeUsername_Click(object sender, EventArgs e)
        {
            /*
             * 1) Check if all fields are filled in 
             * 2) Check if the password is the correct password
             * 3) Check if the username desired is already in use
             * 4) If an error, print out the specific one
             */
            if (Security.checkPassword(txtboxTypePassword.Text, Session["UserID"].ToString()))
            {
                if (txtboxNewUsername.Text.Equals(txtboxConfirmNewUsername.Text))
                {
                    String changed = Database.changeUsername(txtboxConfirmNewUsername.Text, Session["UserID"].ToString());

                    if (changed.Contains("ERROR"))
                    {
                        lblUsernameStatus.ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        lblUsernameStatus.ForeColor = System.Drawing.Color.Black;
                    }
                    lblUsernameStatus.Text = changed;
                }
                else
                {
                    // Usernames do not match
                    lblUsernameStatus.ForeColor = System.Drawing.Color.Red;
                    lblUsernameStatus.Text = "Usernames do not match";
                }
            }
            else
            {
                lblUsernameStatus.ForeColor = System.Drawing.Color.Red;
                lblUsernameStatus.Text = "Incorrect password";
            }

            overview.Visible = false;
            username.Visible = true;
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

                    if (changed.Contains("ERROR"))
                    {
                        lblPasswordStatus.ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        lblPasswordStatus.ForeColor = System.Drawing.Color.Black;
                    }
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


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            String changed = Database.setStudentInformation(Session["UserID"].ToString(), txtboxMajor.Text, 
                ddlGradYear.SelectedValue.ToString(), txtboxSchool.Text, txtboxAbout.Text);

            if (changed.Contains("ERROR"))
            {
                lblAccountStatus.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                lblAccountStatus.ForeColor = System.Drawing.Color.Black;
            }
            lblAccountStatus.Text = changed;


            overview.Visible = false;
            info.Visible = true;
        }

        protected void btnSubmitTutor_Click(object sender, EventArgs e)
        {
            String changed = Database.setTutorInformation(Session["UserID"].ToString(), txtboxGraduationDate.Text,
                txtboxDegree.Text, txtboxExperience.Text, txtboxContactInformation.Text, txtboxTutorSubjects.Text);

            if (changed.Contains("ERROR"))
            {
                lblTutorStatus.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                lblTutorStatus.ForeColor = System.Drawing.Color.Black;
            }
            lblTutorStatus.Text = changed;

            overview.Visible = false;
            tutorInfo.Visible = true;
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

        protected Boolean userFieldsEmpty()
        {
            if ((txtboxNewUsername.Text.Length != 0) && (txtboxConfirmNewUsername.Text.Length != 0) && (txtboxTypePassword.Text.Length != 0))
            {
                return false;
            }
            return true;
        }

    }
}