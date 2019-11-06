<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Topic.aspx.cs" Inherits="CPS410Final.Topic" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:SqlDataSource ID="sqldsTopics" runat="server" ConnectionString="<%$ ConnectionStrings:siteDBConnectionString %>" SelectCommand="SELECT [TopicID], [TopicName], [TopicThreads] FROM [Topics] WHERE ([TopicSubject] = @TopicSubject)">
        <SelectParameters>
            <asp:QueryStringParameter Name="TopicSubject" QueryStringField="SubjectID" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="TopicID" DataSourceID="sqldsTopics">
        <Columns>
            <asp:HyperLinkField DataTextField="TopicName" 
                DataNavigateUrlFields="TopicID"
                DataNavigateUrlFormatString="~/Thread.aspx?TopicID={0}"
                HeaderText="Topic"
                SortExpression="TopicName" />
            <asp:BoundField DataField="TopicThreads" HeaderText="TopicThreads" SortExpression="TopicThreads" />
        </Columns>
    </asp:GridView>
    <asp:Button ID="btnAddNewTopic" runat="server" OnClick="btnAddNewTopic_Click" Text="Add New Topic" />
    <asp:CheckBox ID="chkboxVisibility" runat="server" Text="Set Public" Visible="False" />
    <asp:TextBox ID="txtboxTopicName" runat="server"></asp:TextBox>
</asp:Content>
