using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

/**
 * Page where view the thread (located under a specific subject > topic) you wanted to explore.
 * E.g.: The user has already picked a subject (say Math), already picked a topic (say Algebra)
 *        and have already selected a thread to view. This page handles showing the posts/responses
 *        of the specified thread the user selected.
 */
namespace CPS410Final
{
    public partial class DBThread : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            threadsTable.Visible = false;
            ReplyInfo.Visible = false;
            selectedThreadPosts.Visible = false;

            if (Request.QueryString["Viewing"] != null)
            {
                selectedThreadPosts.Visible = true;
            }
            else
            {
                threadsTable.Visible = true;

                String TopicID = Request.QueryString["TopicID"];
                SqlCommand infoCommand = new SqlCommand("SELECT * FROM Threads WHERE Threads.ThreadTopic = @topic", Database.connection);
                infoCommand.Parameters.AddWithValue("@topic", TopicID);
                SqlDataReader getInfo;

                Database.openDB();
                getInfo = infoCommand.ExecuteReader();

                while (getInfo.Read())
                {
                    string name = getInfo["ThreadName"].ToString();
                    string timeCreated = getInfo["TimeCreated"].ToString();
                    string replies = getInfo["ThreadReplies"].ToString();

                    string views = getInfo["ThreadViews"].ToString();

                    HtmlGenericControl divTest = new HtmlGenericControl();
                    divTest.Controls.Add(genName(name, timeCreated));
                    divTest.Controls.Add(genRpV(replies, views));

                    mainDiv.Controls.Add(divTest);
                }
                Database.closeDB();
            }
            
        }

        private Control genRpV(string replies, string views)
        {
            // holds labels for replies and views
            HtmlGenericControl labels = new HtmlGenericControl("div");

            HtmlGenericControl l1 = new HtmlGenericControl("div");
            Label rep = new Label();
            rep.Text = "Replies";
            l1.Controls.Add(rep);

            HtmlGenericControl l2 = new HtmlGenericControl("div");
            Label vie = new Label();
            vie.Text = "Views";
            l2.Controls.Add(vie);

            labels.Controls.Add(l1);
            labels.Controls.Add(l2);

            // make the data side
            HtmlGenericControl viewDiv = new HtmlGenericControl("div");
            Label dataV = new Label();
            dataV.Text = views;
            viewDiv.Controls.Add(dataV);

            HtmlGenericControl replDiv = new HtmlGenericControl("div");
            Label dataRpl = new Label();
            dataRpl.Text = replies;
            replDiv.Controls.Add(dataRpl);

            HtmlGenericControl dataSide = new HtmlGenericControl("div");
            dataSide.Controls.Add(replDiv);
            dataSide.Controls.Add(viewDiv);

            //combine them
            HtmlGenericControl total = new HtmlGenericControl("div");
            total.Controls.Add(labels);
            total.Controls.Add(dataSide);

            return total;
        }

        private Control genName(string name, string timeCreated)
        {

            // create the name label
            HtmlGenericControl l1 = new HtmlGenericControl("div");
            Label lblName = new Label();
            lblName.Text = name;
            l1.Controls.Add(lblName);

            // create the time label
            HtmlGenericControl l2 = new HtmlGenericControl("div");
            Label lblD = new Label();
            lblD.Text = timeCreated;
            l2.Controls.Add(lblD);

            // package both into a div
            HtmlGenericControl div = new HtmlGenericControl("div");
            div.Controls.Add(l1);
            div.Controls.Add(l2);

            return div;
        }

        protected void btnNewThread_Click(object sender, EventArgs e)
        {
            Response.Redirect("Create.aspx?Create=Thread&TopicID=" + Request.QueryString["TopicID"]);
        }

        protected void btnBackToThreads_Click(object sender, EventArgs e)
        {
            Response.Redirect("Thread.aspx?TopicID=" + Request.QueryString["Topic"]);
        }

        protected void btnReply_Click(object sender, EventArgs e)
        {
            if (Session["UserID"] != null)
            {
                if (!ReplyInfo.Visible)
                {
                    ReplyInfo.Visible = true;
                    btnReply.Visible = false;
                }
            }
            else
            {
                //User not logged in
                Response.Redirect("Login.aspx");
            }

        }

        protected void btnSubmitReply_Click(object sender, EventArgs e)
        {
            String response = Database.addNewPost(Session["UserID"].ToString(), Request.QueryString["Viewing"], txtboxThreadReply.Text);

            if (response.Contains("ERROR"))
            {
                lblReplyError.Text = response;
            }
            else
            {
                Response.Redirect(HttpContext.Current.Request.Url.AbsoluteUri);
            }
        }

        protected void btnCancelReply_Click(object sender, EventArgs e)
        {
            if (txtboxThreadReply.Text.Length > 0)
            {
                txtboxThreadReply.Text = "";
            }
            ReplyInfo.Visible = false;
        }

        protected void btnBackToSubjects_Click(object sender, EventArgs e)
        {
            Response.Redirect("Subject.aspx");
        }
    }
}