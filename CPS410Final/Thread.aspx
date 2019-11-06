<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Thread.aspx.cs" Inherits="CPS410Final.DBThread" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:siteDBConnectionString %>" SelectCommand="SELECT [ThreadID], [ThreadName], [ThreadReplies], [ThreadViews] FROM [Threads] WHERE ([ThreadTopic] = @ThreadTopic)">
        <SelectParameters>
            <asp:QueryStringParameter Name="ThreadTopic" QueryStringField="TopicID" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ThreadID" DataSourceID="SqlDataSource1">
        <Columns>
            <asp:BoundField DataField="ThreadName" HeaderText="ThreadName" SortExpression="ThreadName" />
            <asp:BoundField DataField="ThreadReplies" HeaderText="ThreadReplies" SortExpression="ThreadReplies" />
            <asp:BoundField DataField="ThreadViews" HeaderText="ThreadViews" SortExpression="ThreadViews" />
        </Columns>
    </asp:GridView>
</asp:Content>
