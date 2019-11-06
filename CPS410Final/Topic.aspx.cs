using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/**
 * Page where you can select the topic (under the Subject) that wants to be explored
 * E.g.: Subject picked was Math, so now under Topic is Algebra, Trig., Discrete, Calculus, etc.
 * 
 * Once a topic is selected, the forum for that topic is displayed.
 */
namespace CPS410Final
{

    public partial class Topic : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Determine eligibility to add new Subject
            if (Session["UserID"] != null && Session["Role"].Equals("Administrator"))
            {
                btnAddNewTopic.Visible = true;
                chkboxVisibility.Visible = true;
                txtboxTopicName.Visible = true;
            }
            else
            {
                btnAddNewTopic.Visible = false;
                chkboxVisibility.Visible = false;
                txtboxTopicName.Visible = false;
            }


        }

        protected void btnAddNewTopic_Click(object sender, EventArgs e)
        {
            Boolean topicAdded = Database.addNewTopic(Session["UserID"].ToString(), Request.QueryString["SubjectID"], txtboxTopicName.Text, chkboxVisibility.Checked);
            if (topicAdded)
            {
                // If visibility is T, reload the page and show it on the page
            }
            else
            {

            }      
        }
    }
}