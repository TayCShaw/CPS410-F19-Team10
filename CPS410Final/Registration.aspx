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
                    <asp:Label CssClass="errors" ID="lblError" runat="server" Text=""></asp:Label>
                </div>
                
                <asp:TextBox ID="txtboxUsername" placeholder="Username" runat="server"></asp:TextBox>
                <asp:TextBox ID="txtboxPassword" placeholder="Password" runat="server" TextMode="Password"></asp:TextBox>
                <asp:TextBox ID="TextBoxConfirmPass" placeholder="Password" runat="server" TextMode="Password"></asp:TextBox>
                <asp:TextBox ID="txtboxEmail" placeholder="Email" runat="server" TextMode="Email"></asp:TextBox>
                <asp:Button ID="btnRegister" runat="server" OnClick="btnRegister_Click" Text="Register" BackColor="#009933" Font-Size="X-Large" ForeColor="White" />
                <p class="message">Already Registered? <a href="Login.aspx">Login</a></p>
            </form>
        </div>
    </div>
</body>
    <script type="text/javascript">
        function clickButton(e, btnRegister) {
            var evt = e ? e : window.event;
            var bt = document.getElementById(btnRegister);
            if (bt) {
                if (evt.keyCode == 13) {
                    bt.click();
                    return false;
                }
            }
        }
    </script>
</asp:Content>
