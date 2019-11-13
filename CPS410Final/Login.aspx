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
                <asp:Button ID="btnLogin" runat="server" Text="Login" BackColor="deepskyblue" ForeColor="White" Font-Size="X-Large" OnClick="btnLogin_Click" />
                <p class="message">Not Registered? <a href="Registration.aspx" style="color: yellow">Register</a></p>
            </form>
        </div>
    </div>
</body>
    <script type="text/javascript">
        function clickButton(e, btnLogin) {
            var evt = e ? e : window.event;
            var bt = document.getElementById(btnLogin);
            if (bt) {
                if (evt.keyCode == 13) {
                    bt.click();
                    return false;
                }
            }
        }
    </script>
</asp:Content>



