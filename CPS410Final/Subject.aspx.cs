using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using static System.Drawing.ContentAlignment;


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
            string oldTopic = "";

            string getInfo = "Select Subjects.SubjectID, Subjects.SubjectName, Topics.TopicID, Topics.TopicName, " +
                "Topics.TopicSubject from Subjects INNER JOIN Topics ON Subjects.SubjectID = Topics.TopicSubject ORDER BY Subjects.SubjectID ASC";

            SqlCommand informationCommand = new SqlCommand(getInfo, Database.connection);
            SqlDataReader getInformation;

            HtmlGenericControl mainDiv = new HtmlGenericControl("div");
            mainDiv.Attributes.Add("class", "mainDiv");
            Form.Controls.Add(mainDiv);

            HtmlGenericControl subjectDiv = new HtmlGenericControl("div");
            HtmlGenericControl topicContainer = new HtmlGenericControl("div");

            Database.openDB();
            getInformation = informationCommand.ExecuteReader();

            // subject loop
            while (getInformation.Read())
            {
                // get id and name here
                string subID = getInformation["SubjectID"].ToString();
                string subName = getInformation["SubjectName"].ToString();
                string topicName = getInformation["topicName"].ToString();

                //topicContainer = new HtmlGenericControl("div");
                //topicContainer.Visible = false;

                Button myButton = new Button();
                myButton.Text = "expand";
               

                if (oldTopic.Equals(subID))
                {
                    // add this topic to the same topic div
                    Label topicLbl = new Label();
                    topicLbl.Text = topicName;
                    topicLbl.CssClass = "sublabel";
                    HtmlGenericControl topicDiv = new HtmlGenericControl("div");
                    topicDiv.Attributes.Add("class", "topicDiv");
                    topicDiv.Attributes.Add("id", topicName);
                    topicDiv.Controls.Add(topicLbl);
                    topicContainer.Controls.Add(topicDiv);
                }
                else
                {
                    // we have moved on to a new subject so make a new subject div
                    subjectDiv = new HtmlGenericControl("div");
                    subjectDiv.Attributes.Add("class", "subjectDiv");
                    subjectDiv.Attributes.Add("id", subName);
                    subjectDiv.Controls.Add(myButton);

                    Label subjectLbl = new Label();
                    subjectLbl.Text = subName;
                    subjectLbl.CssClass = "sublabel";

                    subjectDiv.Controls.Add(subjectLbl);
                    mainDiv.Controls.Add(subjectDiv);

                    topicContainer = new HtmlGenericControl("div");
                    mainDiv.Controls.Add(topicContainer);

                    Label topicLbl = new Label();
                    topicLbl.Text = topicName;
                    topicLbl.CssClass = "sublabel";
                    HtmlGenericControl topicDiv = new HtmlGenericControl("div");
                    topicDiv.Attributes.Add("class", "topicDiv");
                    topicDiv.Attributes.Add("id", topicName);
                    topicDiv.Controls.Add(topicLbl);
                    topicContainer.Controls.Add(topicDiv);
                    topicContainer.Attributes.Add("class", "topicContainer");

                    oldTopic = subID;

                }
            }
            Database.closeDB();
        }


        protected void btnAddSubject_Click(object sender, EventArgs e)
        {
            
      
        }
    }
}