using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

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
            string getSubjects = "select * from Subjects";
            string getTopics = "select * from Topics where Topics.TopicSubject = @subID";
            SqlCommand subjectInformation = new SqlCommand(getSubjects, Database.connection);
            SqlCommand topicsInformation = new SqlCommand(getTopics, Database.connection);
            SqlDataReader topicsReader;
            SqlDataReader subjectReader;

            HtmlGenericControl mainDiv = new HtmlGenericControl("div");
            mainDiv.Attributes.Add("class", "mainDiv");
          //  try
          //  {
                Database.openDB();
                subjectReader = subjectInformation.ExecuteReader();
                
                // subject loop
                while (subjectReader.Read())
                {
                    // get id and name here
                    string subID = subjectReader["SubjectID"].ToString();
                    string subName = subjectReader["SubjectName"].ToString();
                    topicsInformation.Parameters.AddWithValue("@subID", subID);

                    // reset the reader
                    topicsReader = topicsInformation.ExecuteReader();

                    //make a div for each subject
                    HtmlGenericControl subjectDiv = new HtmlGenericControl("div");
                    subjectDiv.Attributes.Add("class", "subjectDiv");
                    mainDiv.Controls.Add(subjectDiv);
                    
                    // need to make subject header div here

                    // while there are topics sill under the current subject add them to the current div
                    while (topicsReader.Read())
                    {
                        // make a div for each topic
                        HtmlGenericControl topicDiv = new HtmlGenericControl("div");
                        topicDiv.Attributes.Add("class", "topics");
                        subjectDiv.Controls.Add(topicDiv);
                    }

                    topicsReader.Close();

                }
           // }
           // catch
          //  {
               // Form.Controls.Add(mainDiv);
          //  }
            Form.Controls.Add(mainDiv);

        }


        protected void btnAddSubject_Click(object sender, EventArgs e)
        {
            
      
        }
    }
}