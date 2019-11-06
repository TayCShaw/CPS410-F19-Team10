using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/**
 * Page where you can pick the topic that wants to be explored.
 * E.g.: Science, Math, Languages, etc.
 */
namespace CPS410Final
{
    public partial class DBSubject : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Determine eligibility to add new Subject
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
            //Session["redirect"] = HttpContext.Current.Request.Url.AbsoluteUri;
            //Response.Redirect("Redirect.aspx");
            
            if (subjectAdded)
            {
                // If visibility is T, reload the page and show it on the page
                GridView1.DataBind();
            }
            else
            {

            }      
        }
    }
}