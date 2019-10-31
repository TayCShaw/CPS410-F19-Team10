<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ChangeUsername.aspx.cs" Inherits="CPS410Final.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        
        
        form input{
            width: 55%;
            margin-bottom: 30px;
            vertical-align: middle;
            

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
        .content{
            margin-top: 30px;
            float: left;
            margin-left: 2%;
            align-content: center;
            width: 82%;
            text-align: center;
        }

        .bio {
            height: 60px;
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



        .auto-style4 {
            float: left;
            width: 1452px;
            height: 499px;
        }
        .button {
            width: 30%;
            
            margin-left: 34%;
        }


    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
   <div class="vertical-menu">
  <a href="Account.aspx">Account Overview</a>
  <a href="ChangeUsername.aspx">Change Username</a>
  <a href="ChangePassword.aspx">Change Password</a>
  <a href="EditAccount.aspx" class="active">Edit Information</a>
</div>

    <div class="content">
        <form>
            
            <input type="text" placeholder="Major" />
            <input type="text" placeholder="Expected Graduation Date" />
            <input class="bio" type="text" placeholder="Bio" />
            <input type="text" placeholder="Confirm Password" />

            <div class="button">

            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit Changes" BackColor="DeepSkyBlue" />

        </div>
            

        </form>
        
    </div>
    
    
        
</asp:Content>
