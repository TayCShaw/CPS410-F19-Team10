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

                    mainDiv.Controls.Add(messagediv(name, timeCreated, replies));
                }
                Database.closeDB();
            }
            
        }



        private HtmlGenericControl messagediv(string name, string time, string replies)
        {
            HtmlGenericControl div = new HtmlGenericControl("div");

            // add css to get next two divs horzontal

            HtmlGenericControl but = new HtmlGenericControl("div");
            Button b = new Button();
            b.Text = name;

            div.Controls.Add(but);

            HtmlGenericControl info = new HtmlGenericControl("div");
            // add info here
            HtmlGenericControl rep = new HtmlGenericControl("div");
            info.Controls.Add(rep);
            Label l = new Label();
            l.Text = replies;
            rep.Controls.Add(l);

            HtmlGenericControl tim = new HtmlGenericControl("div");
            info.Controls.Add(rep);
            Label t = new Label();
            t.Text = time;
            rep.Controls.Add(t);


            div.Controls.Add(info);

            return div;

        }

        protected void btnNewThread_Click(object sender, EventArgs e)
        {
            Response.Redirect("Create.aspx?Create=Thread&TopicID=" + Request.QueryString["TopicID"]);
        }

        protected void btnBackToThreads_Click(object sender, EventArgs e)
        {

        }

        protected void btnReply_Click(object sender, EventArgs e)
        {
            Response.Redirect("Create.apsx?Create=Reply&Thread=" + Request.QueryString["ThreadID"]);
        }
    }
}