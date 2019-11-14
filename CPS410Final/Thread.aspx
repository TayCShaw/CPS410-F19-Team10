<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Thread.aspx.cs" Inherits="CPS410Final.DBThread" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="mainDiv" runat="server">

        <asp:Button ID="btnNewThread" runat="server" OnClick="Button1_Click" Text="New Thread" />

    </div>
</asp:Content>
