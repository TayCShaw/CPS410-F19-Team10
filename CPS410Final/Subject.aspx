<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Subject.aspx.cs" Inherits="CPS410Final.DBSubject" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:siteDBConnectionString %>" SelectCommand="SELECT [SubjectName] FROM [Subjects]"></asp:SqlDataSource>
    <asp:Button ID="btnAddSubject" runat="server" Text="Add New Subject" OnClick="btnAddSubject_Click" Visible="False" />
    <asp:CheckBox ID="chkboxVisibility" runat="server" Text="Set Public" Visible="False" />
    <asp:TextBox ID="txtboxSubjectName" runat="server"></asp:TextBox>
</asp:Content>

