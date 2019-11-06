<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ChangeUsername.aspx.cs" Inherits="CPS410Final.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">


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



    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
   <div class="vertical-menu">
  <a href="Account.aspx">Account Overview</a>
  <a href="ChangeUsername.aspx"class="active">Change Username</a>
  <a href="ChangePassword.aspx">Change Password</a>
  <a href="EditAccount.aspx">Edit Information</a>
</div>

    
    
        
</asp:Content>
