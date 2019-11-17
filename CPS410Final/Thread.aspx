<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Thread.aspx.cs" Inherits="CPS410Final.DBThread" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="mainDiv" runat="server">

        <asp:Button ID="btnNewThread" runat="server" OnClick="Button1_Click" Text="New Thread" />

        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:siteDBConnectionString %>" SelectCommand="SELECT [ThreadID], [ThreadName], [ThreadViews], [ThreadReplies], [UserID], [TimeModified] FROM [Threads] WHERE ([ThreadTopic] = @ThreadTopic)">
            <SelectParameters>
                <asp:QueryStringParameter Name="ThreadTopic" QueryStringField="TopicID" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" DataKeyNames="ThreadID">
            <Columns>
                <asp:HyperLinkField DataTextField="ThreadName" 
                    DataNavigateUrl=""
                    HeaderText="ThreadName" 
                    SortExpression="ThreadName" />
                <asp:BoundField DataField="ThreadViews" HeaderText="ThreadViews" SortExpression="ThreadViews" />
                <asp:BoundField DataField="ThreadReplies" HeaderText="ThreadReplies" SortExpression="ThreadReplies" />
                <asp:BoundField DataField="UserID" HeaderText="UserID" SortExpression="UserID" />
                <asp:BoundField DataField="TimeModified" HeaderText="TimeModified" SortExpression="TimeModified" />
            </Columns>
        </asp:GridView>

    </div>
</asp:Content>
