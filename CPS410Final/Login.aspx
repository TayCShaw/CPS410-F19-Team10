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
            <form class="register-form">
                <input type="text" placeholder="name" />
                <input type="text" placeholder="password" />
                <input type="text" placeholder="email" />
                <button>Create</button>
                <p class="message">Already Registered? <a href="#" onclick="switchForm();">Login</a></p>
            </form>

            <form class="login-form">
                <input type="text" placeholder="username" />
                <input type="text" placeholder="password" />
                <button>Login</button>
                <p class="message">Not Registered? <a href="#" onclick="switchForm();">Register</a></p>
            </form>

            <script>
                function switchForm() {
                    if (document.getElementById('login-form')) {
                        if (document.getElementById('login-form').style.display == 'none') {
                            document.getElementById('login-form').style.display = 'block';
                            document.getElementById('register-form').style.display = 'none';
                        }
                        else {
                            document.getElementById('login-form').style.display = 'none';
                            document.getElementById('register-form').style.display = 'block';
                        }
                    }
                }
            </script>

        </div>
    </div>



</body>
</asp:Content>



