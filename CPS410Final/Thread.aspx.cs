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
            String TopicID = Request.QueryString["TopicID"];

            string search = "select * from Threads where Threads.ThreadTopic = " + TopicID;

            SqlCommand infoCommand = new SqlCommand(search, Database.connection);
            SqlDataReader getInfo;

            Database.openDB();
            getInfo = infoCommand.ExecuteReader();

            while (getInfo.Read())
            {
                string name = getInfo["ThreadName"].ToString();
                string timeCreated = getInfo["TimeCreated"].ToString();
                string replies = getInfo["ThreadReplies"].ToString();

                mainDiv.Controls.Add(mesasgediv(name, timeCreated, replies));
            }
            Database.closeDB();
        }

        private HtmlGenericControl mesasgediv(string name, string time, string replies)
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
    }
}