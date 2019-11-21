<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Account.aspx.cs" Inherits="CPS410Final.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        
        #Menu1{
            margin-left:10%;
            width: 15%;
            
            height: 230px;
            font-size: 30px;
            justify-content: center;
            border-style: solid;
            border-color: deepskyblue;
        }

       

        .menuu a{
            margin-bottom: 20px;
            position: center;
            margin-left: 10%;
            margin-right: 10%;
            margin-top: 5%;
            margin-bottom: 5%;
        }
        
        .vertical-menu {
            margin-left: 2%;
            margin-top: 30px;
            width: 12%;
            float: left;
        }
        .overview{
            margin-top: 30px;
            float: left;
            margin-left: 2%;
            background-color: white;
            width: 82%;
            text-align: center;
        }

        .username{
            margin-top: 30px;
            float: left;
            margin-left: 2%;
            background-color: white;
            width: 82%;
            text-align: center;
            padding-bottom: 45px;
        }

        .password{
            margin-top: 30px;
            float: left;
            margin-left: 2%;
            background-color: white;
            width: 82%;
            text-align: center;
            padding-bottom: 45px;
        }

        .info{
            margin-top: 30px;
            float: left;
            margin-left: 2%;
            background-color: white;
            width: 82%;
            text-align: center;
            padding-bottom: 45px;
        }

        .tutorInfo{
            margin-top: 30px;
            float: left;
            margin-left: 2%;
            background-color: white;
            width: 82%;
            text-align: center;
            padding-bottom: 45px;
        }

        .about{
            white-space: pre-wrap;
        }

.vertical-menu a {
  background-color: white;
  color: black; 
  display: block;
  padding: 12px; 
  text-decoration: none; 
}

.vertical-menu a:hover {
  background-color: darkgray;
}

.vertical-menu a.active {
  background-color: deepskyblue;
  color: white;
}

.Buttons {
    background-color: lightgray;
    color: black;
    width: 100%;
    height: 35px;
    border: none;
}

.buttonActive{
    background-color: deepskyblue;
    color: black;
    width: 100%;
    height: 35px;
    border: none;
}

.inactive {
    display: none;
}



        /* .password {
            margin-right: auto;
            margin-left: auto;
            width: 35%;
            vertical-align: middle;

        } */

        h1 {
            text-align: center;
            color: deepskyblue;
            position: center;
        }

        .buttonSubmit{
            
            background-color: deepskyblue;
            color: black;
            position: center;
            height: 50px;
        }
        .buttonSubmit:hover{
            color: white;
            font-style: oblique;
            border: none;
           
           
        }
        .tdalign{
            text-align: right;
            width: 65%;
            height: 40px;
        }
        .tdalign2{
            text-align: left;
            color: red;
        }
        .labelalign{
            text-align: left;
            padding-right: 10px;
        }



        .auto-style5 {
            margin-bottom: 0px;
        }


        .auto-style13 {
            width: 69%;
            margin-left: 130px;
            margin-right: 181px;
        }




        .auto-style14 {
            width: 69%;
            margin-left: 175px;
        }



        .auto-style16 {
            width: 69%;
            height: 252px;
            margin-right: 171px;
            margin-bottom: 0px;
        }
                


        .auto-style23 {
            width: 574px;
            height: 40px;
        }
                


        .auto-style25 {
            width: 275px;
        }
                


        .auto-style28 {
            width: 482px;
            height: 70px;
        }
        .auto-style30 {
            width: 518px;
            height: 40px;
        }
        .auto-style31 {
            height: 40px;
        }
        


        .auto-style32 {
            height: 70px;
        }
        


        .auto-style33 {
            width: 518px;
        }
        


        .auto-style35 {
            text-align: right;
            width: 60%;
            height: 40px;
        }
        


        .auto-style37 {
            width: 467px;
            margin-right: 181px;
            margin-left: 176px;
        }
                


        .auto-style43 {
            width: 198px;
        }
        


        .auto-style44 {
            width: 198px;
            height: 40px;
        }
        .auto-style45 {
            width: 198px;
            height: 70px;
        }
        


        .auto-style46 {
            height: 1875px;
        }
        


        .auto-style47 {
            width: 231px;
            height: 40px;
        }
        .auto-style48 {
            width: 231px;
            height: 70px;
        }
        


        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <%-- -------------------SIDE NAV-BAR------------------- --%>
   <div class="vertical-menu">
       <asp:Button ID="btnOverview" runat="server" Text="Account Overview" CssClass="buttonActive" OnClick="btnOverview_Click" CausesValidation="False" />
       <asp:Button ID="btnUsername" runat="server" Text="Change Username" CssClass="Buttons" OnClick="btnUsername_Click" CausesValidation="False" />
       <asp:Button ID="btnPassword" runat="server" Text="Change Password" CssClass="Buttons" OnClick="btnPassword_Click" CausesValidation="False" />
       <asp:Button ID="btnInfo" runat="server" Text="Edit Information" CssClass="Buttons" OnClick="btnInfo_Click" CausesValidation="False" />
       <asp:Button ID="btnTutor" runat="server" Text="Edit Tutor Information" CssClass="Buttons" OnClick="btnTutor_Click" CausesValidation="False" />
   </div>
    <%-- -------------------------------------------------------------------------------- --%>


    <div class="auto-style46" id="content" runat="server">

        <%-- -------------------ACCOUNT OVERVIEW SIDE NAV-BAR------------------- --%>
        <div class="overview" id="overview" runat="server">
            <h1>Account Overview</h1>
            <p>
                <asp:Label ID="lblAccountLabel" runat="server" Text="Account Type" Font-Underline="True"></asp:Label>
                : 
                <asp:Label ID="lblAccountType" runat="server"></asp:Label>
            </p>
            <p>
                <asp:Label ID="lblDegreeLabel" runat="server" Text="Degree" Font-Underline="True"></asp:Label>
                :   
                <asp:Label ID="lblMajor" runat="server"></asp:Label></p>
            <p>
                <asp:Label ID="lblACSchool" runat="server" Font-Underline="True" Text="School"></asp:Label>
                :
                <asp:Label ID="lblACSchoolLabel" runat="server"></asp:Label>
            </p>
            <p>
                <asp:Label ID="lblGradDateLabel" runat="server" Text="Expected Graduation Date" Font-Underline="True"></asp:Label>
                :   
                <asp:Label ID="lblGradDate" runat="server"></asp:Label></p>
            <p>
                <asp:Label ID="lblAboutLabel" runat="server" Text="About / Experience" Font-Underline="True"></asp:Label>
                : <asp:Label ID="lblAboutSection" runat="server"></asp:Label></p>
            <p>

                <asp:Label ID="lblTutorContact" runat="server" Text="Contact Information:" Font-Underline="True"></asp:Label>
                &nbsp;<asp:Label ID="lblTutorContactInfo" runat="server"></asp:Label></p>
            <p>
                <asp:Label ID="lblTutorSubjectsLabel" runat="server" Font-Underline="True" Text="Subjects You Help With:"></asp:Label>
&nbsp;<asp:Label ID="lblTutorSubjOverview" runat="server"></asp:Label>
            </p>
        </div>
        <%-- -------------------------------------------------------------------------------- --%><%-- -------------------EDIT USERNAME SIDE NAV-BAR------------------- --%>
        <div class="username" id="username" runat="server">
            <h1>Change Username</h1>
            <table class="auto-style14">
                <tr>
                    <td class="auto-style35">
                        <asp:TextBox ID="txtboxNewUsername" placeholder="New username" runat="server"></asp:TextBox></td>
                    <td class="tdalign2">
                        <asp:RequiredFieldValidator ID="rfvNewUsername" runat="server" ErrorMessage="Required Field" ControlToValidate="txtboxNewUsername"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style35">
                        <asp:TextBox ID="txtboxConfirmNewUsername" placeholder="Confirm new username" runat="server"></asp:TextBox></td>
                    <td class="tdalign2">
                        <asp:RequiredFieldValidator ID="rfvConfirmNewUsername" runat="server" ErrorMessage="Required Field" ControlToValidate="txtboxConfirmNewUsername"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style35">
                        <asp:TextBox ID="txtboxTypePassword" placeholder="Password" runat="server" TextMode="Password"></asp:TextBox></td>
                    <td class="tdalign2">
                        <asp:RequiredFieldValidator ID="rfvTypePassword" runat="server" ErrorMessage="Required Field" ControlToValidate="txtboxTypePassword"></asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
            <asp:Button ID="btnChangeUsername" padding-left="35%" CssClass="buttonSubmit" runat="server" Text="Change Username" BackColor="DeepSkyBlue" Width="30%" OnClick="btnChangeUsername_Click" />&nbsp;<p>
                <asp:Label ID="lblUsernameStatus" runat="server"></asp:Label>
            </p>
        </div>
        <%-- -------------------------------------------------------------------------------- --%><%-- -------------------EDIT PASSWORD SIDE NAV-BAR------------------- --%>
        <div class="password" id="password" runat="server">
            <h1>Create New Password</h1>
            <table class="auto-style13" style="margin-left: 175px;">
                <tr>
                    <td class="auto-style35">
                        <asp:TextBox ID="txtboxCurrentPassword" placeholder="Current Password" runat="server" CssClass="auto-style5" TextMode="Password"></asp:TextBox>
                    </td>
                    <td class="tdalign2">
                        <asp:RequiredFieldValidator ID="rfvCurrentPass" runat="server" ControlToValidate="txtboxCurrentPassword" ErrorMessage="Required Field"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style35">
                        <asp:TextBox ID="txtboxNewPassword" placeholder="New Password" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                    <td class="tdalign2">
                        <asp:RequiredFieldValidator ID="rfvNewPass" runat="server" ControlToValidate="txtboxNewPassword" ErrorMessage="Required Field"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style35">
                        <asp:TextBox ID="txtboxConfirmNewPass" placeholder="Confirm New Password" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                    <td class="tdalign2">
                        <asp:RequiredFieldValidator class="" ID="rfvConfirmPass" runat="server" ControlToValidate="txtboxConfirmNewPass" ErrorMessage="Required Field"></asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
            <asp:Button ID="btnChangePass" padding-left="35%" CssClass="buttonSubmit" runat="server" Text="Change Password" BackColor="DeepSkyBlue" Width="30%" OnClick="btnChangePass_Click" />

            <p>
                <asp:Label ID="lblPasswordStatus" runat="server"></asp:Label>
            </p>

        </div>
        <%-- -------------------------------------------------------------------------------- --%><%-- -------------------EDIT (STUDENT) ACCOUNT INFORMATION SIDE NAV-BAR------------------- --%>
        <div class="info" id="info" runat="server">
            <h1>Edit Account Information</h1>
            <table class="auto-style16" style="margin-left: 175px">
                <tr>
                    <td style="text-align: right" class="auto-style25">
                        <asp:Label ID="lblDegree" runat="server" Text="Degree" CssClass="labelalign"></asp:Label>
                    </td>
                    <td style="text-align: left" class="auto-style33">
                        <asp:TextBox ID="txtboxMajor" runat="server" Width="80%"></asp:TextBox>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td style="text-align: right" class="auto-style25">
                        <asp:Label ID="lblGradYear" runat="server" Text="Graduation Year" CssClass="labelalign"></asp:Label>
                    </td>
                    <td style="text-align: left" class="auto-style33">
                        <asp:DropDownList ID="ddlGradYear" runat="server" Width="40%" Height="16px">
                            <asp:ListItem>2019</asp:ListItem>
                            <asp:ListItem>2020</asp:ListItem>
                            <asp:ListItem>2021</asp:ListItem>
                            <asp:ListItem>2022</asp:ListItem>
                            <asp:ListItem>2023</asp:ListItem>
                            <asp:ListItem>2024</asp:ListItem>

                        </asp:DropDownList>
                    </td>
                    <td class="auto-style23"></td>
                </tr>
                <tr>
                    <td style="text-align: right" class="auto-style31">
                        <asp:Label ID="lblSchool" runat="server" Text="School" CssClass="labelalign"></asp:Label>
                    </td>
                    <td style="text-align: left" class="auto-style30">
                        <asp:TextBox ID="txtboxSchool" runat="server" Width="80%"></asp:TextBox>
                    </td>
                    <td class="auto-style31"></td>
                </tr>
                <tr>
                    <td style="text-align: right; padding-bottom: 25px" class="auto-style32">
                        <asp:Label ID="lblAbout" CssClass="labelalign" runat="server" Text="About"></asp:Label>
                    </td>
                    <td style="text-align: left" class="auto-style28" colspan="2">
                        <asp:TextBox ID="txtboxAbout" runat="server" Height="53px" TextMode="MultiLine" Width="276px" Font-Names="Arial" Font-Size="12px"></asp:TextBox>
                        <br />
                        </td>
                </tr>
            </table>
            <p>
                <asp:Label ID="lblAccountStatus" runat="server"></asp:Label>
            </p>
            <p>
                <asp:Button ID="btnSubmitAccountInfo" padding-left="35%" CssClass="buttonSubmit" runat="server" Text="Submit Changes" BackColor="DeepSkyBlue" Width="30%" OnClick="btnSubmit_Click" />
            </p>
        </div>
        <%-- -------------------------------------------------------------------------------- --%><%-- -------------------EDIT (TUTOR) ACCOUNT INFORMATION SIDE NAV-BAR------------------- --%>
        <div class="tutorInfo" id="tutorInfo" runat="server">
            <h1>Tutor Information</h1>
                <table class="auto-style37">
                    <tr>
                        <td style="text-align: right" class="auto-style43">
                            <asp:Label ID="lblGraduationDate" runat="server" Text="Graduation Date"></asp:Label>
                        </td>
                        <td class="auto-style47" style="text-align: left">
                            <asp:TextBox ID="txtboxGraduationDate" placeholder="Graduation Date" runat="server" Width="120%"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="text-align: right" class="auto-style43">
                            <asp:Label ID="lblTutorSchoolLabel" runat="server" Text="School"></asp:Label>
                        </td>
                        <td class="auto-style47" style="text-align: left">
                            <asp:TextBox ID="txtboxTutorSchool" runat="server" Width="120%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right" class="auto-style43">
                            <asp:Label ID="lblDegreeReceived" runat="server" Text="Degree Received"></asp:Label>
                        </td>
                        <td class="auto-style47" style="text-align: left">
                            <asp:TextBox ID="txtboxDegree" placeholder="Degree Received" runat="server" Width="120%"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="text-align: right" class="auto-style45">
                            <asp:Label ID="lblExperience" runat="server" Text="Experience"></asp:Label>
                        </td>
                        <td class="auto-style48" style="text-align: left">
                            <asp:TextBox ID="txtboxExperience" TextMode="MultiLine" placeholder="Work Experience" runat="server" Width="120%" Height="50px" Style="resize: none" Font-Names="Arial" Font-Size="12px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="text-align: right" class="auto-style44">
                            <asp:Label ID="lblContactInformation" runat="server" Text="Contact Information"></asp:Label>
                        </td>
                        <td class="auto-style47" style="text-align: left">
                            <asp:TextBox ID="txtboxContactInformation" TextMode="MultiLine" placeholder="Ways to contact you" runat="server" Width="120%" Height="50px" Style="resize: none" Font-Names="Arial" Font-Size="12px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="text-align: right" class="auto-style44">
                            <asp:Label ID="lblTutorSubjects" runat="server" Text="Subjects/Topics You Can Help"></asp:Label>
                        </td>
                        <td class="auto-style47" style="text-align: left">
                            <asp:TextBox ID="txtboxTutorSubjects" TextMode="MultiLine" placeholder="Ways to contact you" runat="server" Width="120%" Height="50px" Style="resize: none" Font-Names="Arial" Font-Size="12px"></asp:TextBox></td>
                    </tr>
                </table>
            <p>
                <asp:Label ID="lblTutorStatus" runat="server"></asp:Label>
            </p>
            <p>
                <asp:Button ID="btnTutorInfo" padding-left="35%" CssClass="buttonSubmit" runat="server" Text="Submit Changes" BackColor="DeepSkyBlue" Width="30%" OnClick="btnSubmitTutor_Click" /></p>
        </div>
        <%-- -------------------------------------------------------------------------------- --%>
    </div>

    <script type="text/javascript">
        function clickButton(e, btnUser) {
            var evt = e ? e : window.event;
            var bt = document.getElementById(btnUser);
            if (bt) {
                if (evt.keyCode == 13) {
                    bt.click();
                    return false;
                }
            }
        }
    </script>

     <script type="text/javascript">
         function clickButton(e, btnPass) {
             var evt = e ? e : window.event;
             var bt = document.getElementById(btnPass);
             if (bt) {
                 if (evt.keyCode == 13) {
                     bt.click();
                     return false;
                 }
             }
         }
    </script>


     <script type="text/javascript">
         function clickButton(e, btnEdit) {
             var evt = e ? e : window.event;
             var bt = document.getElementById(btnEdit);
             if (bt) {
                 if (evt.keyCode == 13) {
                     bt.click();
                     return false;
                 }
             }
         }
    </script>

    <script type="text/javascript">
        function clickButton(e, btnTutorInfo) {
            var evt = e ? e : window.event;
            var bt = document.getElementById(btnTutorInfo);
            if (bt) {
                if (evt.keyCode == 13) {
                    bt.click();
                    return false;
                }
            }
        }
    </script>
        
</asp:Content>
