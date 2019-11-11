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
            //if user presses enter in a textbox, treat it as if they clicked the find tutor button
            txtboxSubject.Attributes.Add("onkeypress", "return clickButton(event,'" + btnTutor.ClientID + "')");
            txtboxSchool.Attributes.Add("onkeypress", "return clickButton(event,'" + btnTutor.ClientID + "')");
            txtboxCommunication.Attributes.Add("onkeypress", "return clickButton(event,'" + btnTutor.ClientID + "')");
            txtboxDegree.Attributes.Add("onkeypress", "return clickButton(event,'" + btnTutor.ClientID + "')");
        }
        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {

        }
    }
}