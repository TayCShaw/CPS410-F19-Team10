﻿using System;
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
            //if user is already logged in then redirect them to the account page
            if (Session["UserID"] != null)
            {
                Response.Redirect("Account.aspx");
            }
            else
            {
                //if user presses enter in a text box, treat it as though the register button was pressed
                this.TextBoxConfirmPass.Attributes.Add("onkeypress", "return clickButton(event,'" + this.btnRegister.ClientID + "')");
                this.txtboxUsername.Attributes.Add("onkeypress", "return clickButton(event,'" + this.btnRegister.ClientID + "')");
                this.txtboxPassword.Attributes.Add("onkeypress", "return clickButton(event,'" + this.btnRegister.ClientID + "')");
                this.txtboxEmail.Attributes.Add("onkeypress", "return clickButton(event,'" + this.btnRegister.ClientID + "')");
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtboxPassword.Text.Equals(TextBoxConfirmPass.Text) && !txtboxEmail.Text.Equals("") && !txtboxUsername.Text.Equals(""))
            {
                // TRUE if user was added, FALSE otherwise
                String userAdded = Database.addNewUser(txtboxEmail.Text, txtboxUsername.Text, txtboxPassword.Text, rblRole.SelectedValue);

                if (userAdded.Contains("TRUE"))
                {
                    String[] args = userAdded.Split(',');
                    Session["UserID"] = args[1];
                    Session["UserRole"] = rblRole.SelectedValue;

                    Response.Redirect("Account.aspx");
                }
                else if (userAdded.Contains("Username"))
                {
                    lblError.Text = userAdded;
                }
                else if (userAdded.Contains("FALSE"))
                {
                    lblError.Text = "ERROR: Failed account creation. Please contact an Administrator.";
                }
            }
            else
            {
                if (txtboxEmail.Text.Equals(""))
                {
                    lblError.Text = "Please enter an email";
                }
                else if (txtboxUsername.Text.Equals(""))
                {
                    lblError.Text = "Please enter a username";
                }
                else
                {
                    lblError.Text = "Passwords do not match";
                }
            }
        }

        protected void rblRole_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}