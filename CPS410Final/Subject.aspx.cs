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
            string oldSubject = "";

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

                
               

                if (oldSubject.Equals(subID))
                {
                    // add this topic to the same topic div
                    topicContainer.Controls.Add(topicDiv(topicName));
                }
                else
                {
                    // we have moved on to a new subject so make a new subject div
                    // add the div for the new subject
                    mainDiv.Controls.Add(subJectDiv(subName));

                    topicContainer = new HtmlGenericControl("div");
                    topicContainer.Attributes.Add("id", ("topicContainer " + subName));

                    // add the topic container to the maindiv
                    mainDiv.Controls.Add(topicContainer);

                    // add the first topic
                    topicContainer.Controls.Add(topicDiv(topicName));


                    oldSubject = subID;

                }
            }
            Database.closeDB();
        }

        private HtmlGenericControl subJectDiv(String name)
        {
            // make the div and add the css to the div
            HtmlGenericControl sub = new HtmlGenericControl("div");
            sub.Attributes.Add("class", "subjectDiv");
            sub.Attributes.Add("id", name);

            // make the button and add it to the div
            Button b = new Button();
            b.Text = name;
            b.Attributes.Add("class", "invBtn");
            sub.Controls.Add(b);
            // add method for this button here

            // return the div
            return sub;
        }

        private HtmlGenericControl topicDiv(String name)
        {
            // make the div and add the css to the div
            HtmlGenericControl sub = new HtmlGenericControl("div");
            sub.Attributes.Add("class", "topicDiv");
            sub.Attributes.Add("id", name);

            // make the button and add it to the div
            Button b = new Button();
            b.Text = name;
           // b.CssClass = "topicDiv";
            b.Attributes.Add("class", "allMyBtn");
            sub.Controls.Add(b);
            // add method for this button here

            // return the div
            return sub;
        }


        protected void btnAddSubject_Click(object sender, EventArgs e)
        {
            
      
        }
    }
}