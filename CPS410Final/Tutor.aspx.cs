using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CPS410Final
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //show tutor search box when page loads, after search button is pressed
            //hide the tutorsearch div, and populate page with list of potential tutors
            tutorsearch.Visible = true;
            tutorlist.Visible = false;

            //if user presses enter in a textbox, treat it as if they clicked the find tutor button
            txtboxSubject.Attributes.Add("onkeypress", "return clickButton(event,'" + btnTutor.ClientID + "')");
            txtboxSchool.Attributes.Add("onkeypress", "return clickButton(event,'" + btnTutor.ClientID + "')");
            txtboxCommunication.Attributes.Add("onkeypress", "return clickButton(event,'" + btnTutor.ClientID + "')");
            txtboxDegree.Attributes.Add("onkeypress", "return clickButton(event,'" + btnTutor.ClientID + "')");
        }
        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {

        }

        protected void btnTutor_Click(object sender, EventArgs e)
        {
            tutorsearch.Visible = false;
            tutorlist.Visible = true;
        }

        protected void back_Click(object sender, EventArgs e)
        {
            tutorsearch.Visible = true;
            tutorlist.Visible = false;
        }
    }
}