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
                String threadID = Request.QueryString["Viewing"];
                selectedThreadPosts.Visible = true;
                if (!IsPostBack)
                {
                    Database.updateThreadViews(threadID);
                }
            }
            else
            {
                threadsTable.Visible = true;
            }
        }

        protected void btnNewThread_Click(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                String page = Request.RawUrl;
                Session["Redirect"] = page;
               
            }
            Response.Redirect("Create.aspx?Create=Thread&TopicID=" + Request.QueryString["TopicID"]);
        }

        protected void btnBackToThreads_Click(object sender, EventArgs e)
        {
            Response.Redirect("Thread.aspx?TopicID=" + Request.QueryString["Topic"]);
        }

        protected void btnReply_Click(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                String page = Request.RawUrl;
                Session["Redirect"] = page;
                Response.Redirect("login.aspx");
            }
            else
            {
                if (!ReplyInfo.Visible)
                {
                    ReplyInfo.Visible = true;
                    btnReply.Visible = false;
                }
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
                Database.updateThreadReplies(Request.QueryString["Viewing"]);
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