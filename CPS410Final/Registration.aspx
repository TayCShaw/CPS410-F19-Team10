<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="CPS410Final.Registration" %>
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
            <form class="register-form">
                <div class="errors">
                    <p class="errorMSG">this is where it is. this is whewew all the errors will be desplayed</p>
                </div>
                <input type="text" placeholder="name" />
                <input type="text" placeholder="password" />
                <input type="text" placeholder="email" />
                <button>Create <a onclick="buttonClicked()"></a></button>
                <p class="message">Already Registered? <a href="Login.aspx">Login</a></p>
            </form>
        </div>
    </div>
</body>
</asp:Content>
