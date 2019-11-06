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



    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
   <div class="vertical-menu">
       <asp:Button ID="btnOverview" runat="server" Text="Account Overview" CssClass="buttonActive" OnClick="btnOverview_Click" />
       <asp:Button ID="btnUsername" runat="server" Text="Change Username" CssClass="Buttons" OnClick="btnUsername_Click" />
       <asp:Button ID="btnPassword" runat="server" Text="Change Password" CssClass="Buttons" OnClick="btnPassword_Click" />
       <asp:Button ID="btnInfo" runat="server" Text="Edit Information" CssClass="Buttons" OnClick="btnInfo_Click" />
       
   </div>

    <div class="overview" id="overview" runat="server">
        <p>Username: (username placeholder)</p>
        <p>Account Type: (Student or Tutor)</p>
        <p>Major</p>
        <p>Expected Graduation Date</p>
        <p style="height: 90px;">Biography and entire life story</p>

    </div>

    <div class="username" id="username" runat="server">
        <p>There is shit here</p>
    </div>

    <div class="password" id="password" runat="server">
        <p>There is doodoo here</p>
    </div>

    <div class="info" id="info" runat="server">
        <p>There is feces here</p>
    </div>
    
        
</asp:Content>
