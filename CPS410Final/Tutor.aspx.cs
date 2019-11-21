using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

namespace CPS410Final
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["Redirect"] = null;
            //show tutor search box when page loads, after search button is pressed
            //hide the tutorsearch div, and populate page with list of potential tutors
            tutorsearch.Visible = true;
            tutorlist.Visible = false;

            //if user presses enter in a textbox, treat it as if they clicked the find tutor button
            txtboxSubject.Attributes.Add("onkeypress", "return clickButton(event,'" + btnTutor.ClientID + "')");
            txtboxSchool.Attributes.Add("onkeypress", "return clickButton(event,'" + btnTutor.ClientID + "')");
            txtboxCommunication.Attributes.Add("onkeypress", "return clickButton(event,'" + btnTutor.ClientID + "')");
            txtboxDegree.Attributes.Add("onkeypress", "return clickButton(event,'" + btnTutor.ClientID + "')");


        }

        protected SqlCommand buildQueryString()
        {
            int whereAdded = 0;
            String baseQuery = "SELECT Tutors.TutorDegree, Tutors.TutorContactInfo, Tutors.TutorSchool, Tutors.TutorExperience, " +
                "Users.Username FROM Tutors INNER JOIN Users on Tutors.UserID = Users.UserID";
            SqlCommand getTutors = new SqlCommand(baseQuery, Database.connection);

            if (txtboxSubject.Text.Length != 0)
            {
                getTutors.CommandText += " WHERE Tutors.TutorSubjects LIKE '%' + @subj + '%'";
                getTutors.Parameters.AddWithValue("@subj", txtboxSubject.Text);
                whereAdded = 1;
            }

            if (txtboxSchool.Text.Length != 0 && whereAdded == 1)
            {
                getTutors.CommandText += " AND Tutors.TutorSchool LIKE '%' + @school + '%'";
                getTutors.Parameters.AddWithValue("@school", txtboxSchool.Text);

            }
            else if (txtboxSchool.Text.Length != 0 && whereAdded == 0)
            {
                getTutors.CommandText += " WHERE Tutors.TutorSchool LIKE '%' + @school + '%'";
                getTutors.Parameters.AddWithValue("@school", txtboxSchool.Text);
                whereAdded = 1;
            }

            if (txtboxDegree.Text.Length != 0 && whereAdded == 1)
            {
                getTutors.CommandText += " AND Tutors.TutorDegree LIKE '%' + @deg + '%'";
                getTutors.Parameters.AddWithValue("@deg", txtboxDegree.Text);

            }
            else if (txtboxDegree.Text.Length != 0 && whereAdded == 0)
            {
                getTutors.CommandText += " WHERE Tutors.TutorDegree LIKE '%' + @deg + '%'";
                getTutors.Parameters.AddWithValue("@deg", txtboxDegree.Text);
                whereAdded = 1;
            }

            if (txtboxCommunication.Text.Length != 0 && whereAdded == 1)
            {
                getTutors.CommandText += " AND Tutors.TutorContactInfo LIKE '%' + @comm + '%'";
                getTutors.Parameters.AddWithValue("@comm", txtboxCommunication.Text);

            }
            else if (txtboxCommunication.Text.Length != 0 && whereAdded == 0)
            {
                getTutors.CommandText += " WHERE Tutors.TutorContactInfo LIKE '%' + @comm + '%'";
                getTutors.Parameters.AddWithValue("@comm", txtboxCommunication.Text);
                whereAdded = 1;
            }



            return getTutors;
        }

        private HtmlGenericControl tutorDiv(String name, String school, String degree, String experience, String contact)
        {
            HtmlGenericControl tutor = new HtmlGenericControl("div");
            tutor.Attributes.Add("class", "atutor");
            string newline = Environment.NewLine;
            HtmlGenericControl l1 = new HtmlGenericControl("div");
            Label tName = new Label();
            l1.Controls.Add(tName);
            tName.Text = "Name: " + name;
            tutor.Controls.Add(l1);

            HtmlGenericControl l2 = new HtmlGenericControl("div");
            Label tSchool = new Label();
            l2.Controls.Add(tSchool);
            tSchool.Text = "School: " + school;
            tutor.Controls.Add(l2);

            HtmlGenericControl l3 = new HtmlGenericControl("div");
            Label tDegree = new Label();
            l3.Controls.Add(tDegree);
            tDegree.Text = "Degree: " + degree;
            tutor.Controls.Add(l3);

            HtmlGenericControl l4 = new HtmlGenericControl("div");
            Label tExperience = new Label();
            l4.Controls.Add(tExperience);
            tExperience.Text = "Experience: " + experience;
            tutor.Controls.Add(l4);

            HtmlGenericControl l5 = new HtmlGenericControl("div");
            Label tContact = new Label();
            l5.Controls.Add(tContact);
            tContact.Text = "Contact: " + contact;
            tutor.Controls.Add(l5);
            return tutor;

        }
        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {

        }

        protected void btnTutor_Click(object sender, EventArgs e)
        {
            HtmlGenericControl m = new HtmlGenericControl("div");
            m.Attributes.Add("id", "resultDiv");
            m.Attributes.Add("class", "results");
            m.Attributes.Add("runat", "server");

            Form.Controls.Add(m);

            SqlCommand getInfo = buildQueryString();
            SqlDataReader reader;
            Database.openDB();

            reader = getInfo.ExecuteReader();
            //lblLiterally.Text = getInfo.CommandText;
            while (reader.Read())
            {
                string name = reader["Username"].ToString();
                string school = reader["TutorSchool"].ToString();
                string degree = reader["TutorDegree"].ToString();
                string experience = reader["TutorExperience"].ToString();
                string contact = reader["TutorContactInfo"].ToString();

                m.Controls.Add(tutorDiv(name, school, degree, experience, contact));
            }
            Database.closeDB();

            tutorsearch.Visible = false;
            tutorlist.Visible = true;
        }

        protected void back_Click(object sender, EventArgs e)
        {
            tutorsearch.Visible = true;
            tutorlist.Visible = false;
        }
    }
}