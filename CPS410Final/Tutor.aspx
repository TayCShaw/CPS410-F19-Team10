<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Tutor.aspx.cs" Inherits="CPS410Final.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="tutor.css" />
    <h1 class="title">Tutor Search</h1>
    <div class="tutorsearch">
      
        <div class="inputFields">
        <form class="form">
            <label>
            <input type="text" placeholder="Subject" />
            </label>
            <label>
            <input type="text" placeholder="School(Optional)" />
            </label>
            <label>
            <input type="text" placeholder="Degree" />
            </label>
            <label>
            <input type="text" placeholder="Communication Method Preference" />
             </label>
        </form>
        </div>
        <div class="dropdown">

        
        <button class="dropbtn">Subject
        </button>
        
            <div class="dropdown-content">
                <a href ="#">Math</a>
                <a href ="#">Chemistry</a>
                <a href ="#">Physics</a>
                <a href ="#">Computer Science</a>
                <a href ="#">English</a>
            </div>
            </div>


    </div>
</asp:Content>
