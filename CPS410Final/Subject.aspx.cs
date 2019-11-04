using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CPS410Final
{
    public partial class DBSubject : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] != null && Session["Role"].Equals("Administrator"))
            {
                btnAddSubject.Visible = true;
                chkboxVisibility.Visible = true;
                txtboxSubjectName.Visible = true;
            }
            else
            {
                btnAddSubject.Visible = false;
                chkboxVisibility.Visible = false;
                txtboxSubjectName.Visible = false;
            }
        }


        protected void btnAddSubject_Click(object sender, EventArgs e)
        {


            Boolean subjectAdded = Database.addNewSubject(Session["UserID"].ToString(), txtboxSubjectName.Text, chkboxVisibility.Checked);
            if (subjectAdded)
            {

            }
            else
            {

            }

            
        }
    }
}