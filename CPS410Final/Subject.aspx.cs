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
            ContentPlaceHolder content = (ContentPlaceHolder)this.Master.FindControl("ContentPlaceHolder1");
 
            HtmlGenericControl topicContainer = new HtmlGenericControl("div");

            Database.openDB();
            getInformation = informationCommand.ExecuteReader();

            // subject loop
            while (getInformation.Read())
            {
                // get id and name here
                string subID = getInformation["SubjectID"].ToString();
                string subName = getInformation["SubjectName"].ToString();
                string topicName = getInformation["TopicName"].ToString();
                string topicID = getInformation["TopicID"].ToString();

                if (oldSubject.Equals(subID))
                {
                    // add this topic to the same topic div
                    topicContainer.Controls.Add(topicDiv(topicName, topicID));
                }
                else
                {
                    //Form.Controls.Add(subJectDiv(subName));
                    //content.Controls.Add(subJectDiv(subName));

                    topicContainer = new HtmlGenericControl("div");
                    topicContainer.Attributes.Add("id", "topicContainer" + subName);
                    //Form.Controls.Add(topicContainer);
                    //content.Controls.Add(topicContainer);
                    
                    topicContainer.Controls.Add(topicDiv(topicName,topicID));
                    oldSubject = subID;

                    
                        myTest.Controls.Add(subJectDiv(subName));
                        myTest.Controls.Add(topicContainer);
                   
                }
            }
            Database.closeDB();



        }

        private HtmlGenericControl subJectDiv(String name)
        {
            // make the div and add the css to the div
            HtmlGenericControl sub = new HtmlGenericControl("div");
            sub.Attributes.Add("class", "subjectDiv");
            sub.Attributes.Add("id", "div "+ name);
            sub.Attributes.Add("runat", "server");


            // make the button and add it to the div
            Button b = new Button();
            b.Text = name;
            b.Attributes.Add("class", "allMyBtn");
            b.Attributes.Add("runat", "server");
            b.Attributes.Add("id", "div " + name);
            b.Click += new EventHandler(Btn_Click);
            sub.Controls.Add(b);

            // return the div
            return sub;
        }


        private HtmlGenericControl topicDiv(String name, string id)
        {
            // make the div and add the css to the div
            HtmlGenericControl sub = new HtmlGenericControl("div");
            sub.Attributes.Add("class", "topicDiv");
            sub.Attributes.Add("id", name);
            sub.Attributes.Add("runat", "server");

            // make the button and add it to the div
            Button b = new Button();
            b.Attributes.Add("class", "allMyBtn");
            b.Attributes.Add("ID", "topic " + id);
            b.CommandName = id;
            sub.Controls.Add(b);
            b.Text = name;
            // add method for this button here
            b.Click += new EventHandler(Btn_topic);
            // return the div
            return sub;
        }


        protected void Btn_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            lbl1.Text = "";

            print(Form);
            /*
            ContentPlaceHolder content = (ContentPlaceHolder)this.Master.FindControl("ContentPlaceHolder1");
            foreach (Control childControl in content.Controls)
            {
                lbl1.Text += " " + childControl.ID;
            }

            */

            //String controlToFind = "tp " + b.ID;

            //lbl1.Text = "";

            //int count = 0;
            /*            foreach (Control childControl in this.Controls)
                        {
                            lbl1.Text = lbl1.Text + " " + childControl.ClientID;

                            count++;

                        }
            */
            //lbl1.Text += count;
        }

        private void print(Control level)
        {

            lbl1.Text = level.Controls.Count.ToString();
       /*     foreach (Control child in level.Controls)
            {
                Control c = child;
                lbl1.Text += " " + child.ID;
                if (child.HasControls())
                {
                    print(child);

                }
                else
                {
                    child = child.Parent;
                }
            }
            */
            level = (ContentPlaceHolder)this.Master.FindControl("ContentPlaceHolder1");
            for (int i = 0; i < level.Controls.Count; i++)
            {
                Control ch = level.Controls[i];
                lbl1.Text += " " + ch.ID;
                /*if (ch.Controls[i].HasControls())
                {
                    for (int j = 0; j < ch.Controls[i].Controls.Count; j++)
                    {
                        lbl1.Text = ch.Controls[i].Controls[j].ID;
                    }
                */
                
            }
        }


        protected void Btn_topic(object sender, EventArgs e)
        {
            Button s = (Button) sender;
            lbl1.Text = s.CommandName;
            Response.Redirect("Thread.aspx?TopicID=" + s.CommandName);
        }
    }
}