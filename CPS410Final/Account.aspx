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
        .content{
            margin-top: 30px;
            float: left;
            margin-left: 2%;
            background-color: white;
            width: 82%;
            text-align: center;
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



    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
   <div class="vertical-menu">
  <a href="#" class="active">Account Overview</a>
  <a href="#">Change Username</a>
  <a href="#">Change Password</a>
  <a href="#">Edit Information</a>
</div>

    <div class="content">
        <p>Username: (username placeholder)</p>
        <p>Account Type: (Student or Tutor)</p>
        <p>Major</p>
        <p>Expected Graduation Date</p>
        <p>Biography and entire life story</p>

    </div>
    
        
</asp:Content>
