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



        .auto-style4 {
            float: left;
            width: 1452px;
            height: 499px;
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
        



    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
   <div class="vertical-menu">
       <asp:Button ID="btnOverview" runat="server" Text="Account Overview" CssClass="buttonActive" OnClick="btnOverview_Click" />
       <asp:Button ID="btnUsername" runat="server" Text="Change Username" CssClass="Buttons" OnClick="btnUsername_Click" />
       <asp:Button ID="btnPassword" runat="server" Text="Change Password" CssClass="Buttons" OnClick="btnPassword_Click" />
       <asp:Button ID="btnInfo" runat="server" Text="Edit Information" CssClass="Buttons" OnClick="btnInfo_Click" />
       <asp:Button ID="btnTutor" runat="server" Text="Edit Tutor Information" CssClass="Buttons" OnClick="btnTutor_Click" />


   </div>
    <div class="content" id="content" runat="server">
    <div class="overview" id="overview" runat="server">
        <h1>Account Overview</h1>
        <p>
         Account Type:  <asp:Label ID="Label1" runat="server" Text="Student/Tutor"></asp:Label></p>
        <p>Major:    <asp:Label ID="Label2" runat="server" Text="Major"></asp:Label></p>
        <p>Expected Graduation Date:    <asp:Label ID="Label3" runat="server" Text="Graduation Date"></asp:Label></p>
        <p>Biography and entire life story:     <asp:Label ID="Label4" runat="server" Text="Biography"></asp:Label></p>

    </div>

    <div class="username" id="username" runat="server">
        <h1>Change Username</h1>
       <p> <asp:TextBox ID="newUsername" placeholder="New username" runat="server"></asp:TextBox></p>
       <p> <asp:TextBox ID="confirmNewUsername" placeholder="Confirm new username"  runat="server"></asp:TextBox></p>
        <p><asp:TextBox ID="typePassword" placeholder="Password" runat="server"></asp:TextBox></p>
        <asp:Button ID="btnUser" padding-left="35%" CssClass="buttonSubmit" runat="server" Text="Change Username" BackColor="DeepSkyBlue" Width="30%" OnClick="btnUser_Click" /></p>
       
    </div>

    <div class="password" id="password" runat="server">
        <h1>Create New Password</h1>
       <p> <asp:TextBox ID="oldPassword" placeholder="Current Password" runat="server"></asp:TextBox></p>
        <p><asp:TextBox ID="newPass" placeholder="New Password"  runat="server"></asp:TextBox></P>
       <p> <asp:TextBox ID="confirmNewPass" placeholder="Confirm New Password" runat="server"></asp:TextBox></p>
       <asp:Button ID="btnPass" padding-left="35%" CssClass="buttonSubmit" runat="server" Text="Change Password" BackColor="DeepSkyBlue" Width="30%" OnClick="btnPass_Click" /></p>

    </div>

    <div class="info" id="info" runat="server">
        <h1>Edit Account Information</h1>
        <p> <asp:TextBox ID="major" placeholder="Major" runat="server" Width="20%"></asp:TextBox></p>
        Graduation Date: <asp:DropDownList ID="dropDownList" runat="server" Width="20%">
            <asp:ListItem>2019</asp:ListItem>
            <asp:ListItem>2020</asp:ListItem>
            <asp:ListItem>2021</asp:ListItem>
            <asp:ListItem>2022</asp:ListItem>
            <asp:ListItem>2023</asp:ListItem>
            <asp:ListItem>2024</asp:ListItem>
          
        </asp:DropDownList>
        <p> <asp:TextBox CssClass="about" TextMode="MultiLine" ID="about" placeholder="About" runat="server" Width="45%" Height="100px" style="resize:none"></asp:TextBox></p>
        <p>
            <asp:Button ID="btnSubmit" padding-left="35%" CssClass="buttonSubmit" runat="server" Text="Submit Changes" BackColor="DeepSkyBlue" Width="30%" OnClick="btnSubmit_Click" /></p>
    </div>

    <div class="tutorInfo" id ="tutorInfo" runat="server">
        <h1>Tutor Information</h1>
        <p> <asp:TextBox ID="gradDate" placeholder="Graduation Date" runat="server" Width="20%"></asp:TextBox></p>
        <p> <asp:TextBox ID="degree" placeholder="Degree Received" runat="server" Width="20%"></asp:TextBox></p>
        <p> <asp:TextBox ID="experience" TextMode="MultiLine" placeholder="Work Experience" runat="server" Width="45%" Height="75px" style="resize:none"></asp:TextBox></p>
        <p> <asp:TextBox ID="contact" TextMode="MultiLine" placeholder="Ways to contact you" runat="server" Width="45%" Height="75px" style="resize:none"></asp:TextBox></p>
      <p> <asp:Button ID="btnTutorInfo" padding-left="35%" CssClass="buttonSubmit" runat="server" Text="Submit Changes" BackColor="DeepSkyBlue" Width="30%" OnClick="btnTutorInfo_Click" /></p>


    </div>
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
