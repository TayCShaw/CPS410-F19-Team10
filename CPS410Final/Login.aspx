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
                     <asp:Label CssClass="errors" ID="lblError" runat="server" Text=""></asp:Label>
                </div>
                 <asp:TextBox ID="txtboxUsername" placeholder="Username" runat="server"></asp:TextBox>
                <asp:TextBox ID="txtboxPassword" placeholder="Password" runat="server"></asp:TextBox>
                <asp:Button ID="btnLogin" runat="server" Text="Login" BackColor="#009900" Font-Size="X-Large" OnClick="btnLogin_Click" />
                <p class="message">Not Registered? <a href="Registration.aspx">Register</a></p>
            </form>
        </div>
    </div>
</body>
</asp:Content>



