<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CPS410Final.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <head>
    <meta charset="utf-8" />
    <title>LearnQuick Login</title>
    <link rel="stylesheet" href="style.css" />
</head>
<body>
    <div class="login-page">
        <div class="form">
            <form class="login-form">
                 <div class="errors">
                    <p class="errorMSG">this is where it is. this is whewew all the errors will be desplayed</p>
                </div>
                 <input id="txtUsername" type="text" />
                 <input id="txtPassword" type="text" />
                <button>Login <a onclick="buttonClicked()"></button>
                <p class="message">Not Registered? <a href="Registration.aspx">Register</a></p>
            </form>
        </div>
    </div>
</body>
</asp:Content>



