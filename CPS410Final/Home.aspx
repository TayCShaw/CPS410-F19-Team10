<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="CPS410Final.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel ="stylesheet" href ="home.css" />
    <div class="everything">
    <div class="title">
        <h1>About Us</h1>
    </div>
        <div class="about">
            <p> LearnQuick is an all-in-one destination for your academic needs. You can find tutors for specific
                subjects, using our <a href="Tutor.aspx">Find Tutor</a> feature. You can also discuss with other students using our <a href="Subject.aspx">Discussion Board</a>
                feature. You will find links to 
                each feature up top along the navigation bar. <a href="Login.aspx">Register</a> today and get started on your academic journey!
            </p>
        </div>
        <h1 class="title">Contact Us
        </h1>
        <div class="about">
        <p>If you have any questions or concerns regarding LearnQuick, you can contact us at the email listed below:<br />
            learnquickassistance@gmail.com
        </p>
            </div>
        </div>
</asp:Content>



