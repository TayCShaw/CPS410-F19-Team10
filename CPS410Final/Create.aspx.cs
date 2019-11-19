using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CPS410Final
{
    public partial class Create : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check to see that a user is actually logged in before trying to create anything
            if (Session["UserID"] != null)
            {
                // Hide all tables to only show necessary information
                HideAll();

                if (Request.QueryString["Create"].Equals("Subject") && Session["UserRole"].ToString().Equals("Administrator"))
                {
                    SubjectInfo.Visible = true;
                }
                else if (Request.QueryString["Create"].Equals("Topic") && Session["UserRole"].ToString().Equals("Administrator"))
                {
                    TopicInfo.Visible = true;
                }
                else if (Request.QueryString["Create"].Equals("Thread"))
                {
                    ThreadInfo.Visible = true;
                }
            }
            else
            {
                //Redirect because NOT LOGGED IN
                Response.Redirect("Login.aspx");
            }
        }


        /*
         * 
         */
        protected void HideAll()
        {
            SubjectInfo.Visible = false;
            TopicInfo.Visible = false;
            ThreadInfo.Visible = false;
        }


        /*
         * 
         */
        protected void btnSubmitSubject_Click(object sender, EventArgs e)
        {
            if (Database.addNewSubject(Session["UserID"].ToString(), txtboxNewSubjectName.Text, true))
            {
                if (Database.addNewTopic(Session["UserID"].ToString(), Database.getSubjectID(txtboxNewSubjectName.Text), txtboxFirstTopic.Text, true))
                {
                    // Redirect to the Subject.aspx page to see all Subjects, including the one just made
                    Response.Redirect("Subject.aspx");
                }
                else
                {
                    String result = Database.removeSubject(txtboxNewSubjectName.Text);
                    if (result.Contains("ERROR"))
                    {
                        lblSubjectError.Text = "ERROR: Topic could not be created, but Subject has been created and could not be removed. Contact an administrator.";
                    }
                    else
                    {
                        lblSubjectError.Text = "ERROR: Topic could not be created, therefore Subject not created. Double check connection and try again later.";
                    }
                }
            }
            else
            {
                lblSubjectError.Text = "ERROR: Subject not added. Double check Subject does not already exist and try again later.";
            }
        }


        /*
         * 
         */
        protected void btnSubmitTopic_Click(object sender, EventArgs e)
        {

        }


        /*
         * 
         */
        protected void btnSubmitThread_Click(object sender, EventArgs e)
        {
            String TopicID = Request.QueryString["TopicID"];
            String response = Database.addNewThread(Session["UserID"].ToString(), TopicID, txtboxNewThreadName.Text, Database.getTopicSubject(TopicID));
            String[] chunk = response.Split(',');
            if (response.Contains("true"))
            {
                String threadID = chunk[1];

                response = Database.addNewPost(Session["UserID"].ToString(), threadID, txtboxThreadOP.Text);
                chunk = response.Split(',');
                if (response.Contains("true"))
                {
                    Response.Redirect("/Thread.aspx?Viewing=" + threadID + "&Topic=" + TopicID);
                }
                else
                {
                    String removeResponse = Database.removeThread(threadID);
                    if (removeResponse.Contains("ERROR"))
                    {
                        lblThreadError.Text = chunk[1] + "\n" + removeResponse;
                    }
                    else
                    {
                        lblThreadError.Text = "Error attempting to create the thread. Thread not created.";
                    }
                }
            }
            else
            {
                String errorMessage = chunk[1];
                lblThreadError.Text = errorMessage;
            }
        }
    }
}