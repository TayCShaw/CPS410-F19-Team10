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
/*
            HtmlGenericControl mainDiv = new HtmlGenericControl("div");
            mainDiv.Attributes.Add("class", "mainDiv");
            mainDiv.Attributes.Add("runat", "server");
            Form.Controls.Add(mainDiv);
*/
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
                    //Form.Controls.Add(subJectDiv(subName));
                    this.Controls.Add(subJectDiv(subName));

                    topicContainer = new HtmlGenericControl("div");
                    topicContainer.Attributes.Add("id", ("tp " + subName));
                    topicContainer.Attributes.Add("runat", "server");
                    topicContainer.Visible = true;

                    // add the topic container to the maindiv
                   // Form.Controls.Add(topicContainer);
                    this.Controls.Add(topicContainer);

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
            sub.Attributes.Add("id", "div"+ name);
            sub.Attributes.Add("runat", "server");

            // make the button and add it to the div
            Button b = new Button();
            b.Text = name;
            b.ID = name;
            b.Attributes.Add("class", "allMyBtn");
            b.Attributes.Add("runat", "server");
            b.Click += new EventHandler(Btn_Click);
            sub.Controls.Add(b);

            // return the div
            return sub;
        }

        private HtmlGenericControl topicDiv(String name)
        {
            // make the div and add the css to the div
            HtmlGenericControl sub = new HtmlGenericControl("div");
            sub.Attributes.Add("class", "topicDiv");
            sub.Attributes.Add("id", name);
            sub.Attributes.Add("runat", "server");

            // make the button and add it to the div
            Button b = new Button();
            b.Attributes.Add("class", "allMyBtn");
            sub.Controls.Add(b);
            b.Text = name;
            // add method for this button here

            // return the div
            return sub;
        }


        protected void Btn_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            String controlToFind = "tp " + b.ID;

            lbl1.Text = "";
            int count = 0;
            foreach (Control childControl in this.Controls)
            {
                lbl1.Text = lbl1.Text + " " + childControl.ClientID;
               
                count++;
                
            }
            lbl1.Text += count;
        }
    }
}