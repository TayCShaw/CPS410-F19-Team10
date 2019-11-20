<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Thread.aspx.cs" Inherits="CPS410Final.DBThread" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel ="stylesheet" href ="Thread.css" />
    <div id="mainDiv" runat="server">

        <table id="threadsTable" style="width: 100%;" runat="server">
            <tr>
                <td>
                    <asp:Button ID="btnNewThread" runat="server" Text="New Thread" OnClick="btnNewThread_Click" />

                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:siteDBConnectionString %>" SelectCommand="SELECT [ThreadID], [ThreadName], [ThreadViews], [ThreadReplies], [UserID], [TimeModified] FROM [Threads] WHERE ([ThreadTopic] = @ThreadTopic)">
                        <SelectParameters>
                            <asp:QueryStringParameter Name="ThreadTopic" QueryStringField="TopicID" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" DataKeyNames="ThreadID">
                        <Columns>
                            <asp:HyperLinkField DataTextField="ThreadName"
                                DataNavigateUrlFields="ThreadID"
                                DataNavigateUrlFormatString="/Thread.aspx?Viewing={0}"
                                HeaderText="ThreadName"
                                SortExpression="ThreadName" />
                            <asp:BoundField DataField="ThreadViews" HeaderText="ThreadViews" SortExpression="ThreadViews" />
                            <asp:BoundField DataField="ThreadReplies" HeaderText="ThreadReplies" SortExpression="ThreadReplies" />
                            <asp:BoundField DataField="UserID" HeaderText="UserID" SortExpression="UserID" />
                            <asp:BoundField DataField="TimeModified" HeaderText="TimeModified" SortExpression="TimeModified" />
                        </Columns>
                    </asp:GridView>

                </td>
            </tr>
        </table>
    </div>



    <div id ="threadPosts" runat="server" class="g  ">
        
    </div>




    <table id="selectedThreadPosts" style="width:100%;" runat="server">
        <tr>
            <td>
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="PostID" DataSourceID="sqldsPosts">
                    <Columns>
                        <asp:BoundField DataField="PostContent" HeaderText="PostContent" SortExpression="PostContent" />
                        <asp:BoundField DataField="Username" HeaderText="Username" SortExpression="Username" />
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="sqldsPosts" runat="server" ConnectionString="<%$ ConnectionStrings:siteDBConnectionString %>" SelectCommand="SELECT Posts.PostID, Posts.PostContent, Users.Username FROM Posts INNER JOIN Users ON Posts.UserID = Users.UserID AND Posts.ThreadID = @ThreadID">
                    <SelectParameters>
                        <asp:QueryStringParameter DefaultValue="" Name="ThreadID" QueryStringField="Viewing" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnReply" runat="server" OnClick="btnReply_Click" Text="Reply" />
                <asp:Button ID="btnBackToThreads" runat="server" CausesValidation="False" OnClick="btnBackToThreads_Click" Text="Back To Threads" />
            </td>
        </tr>
    </table>

    <div id ="postsMainDiv" runat="server" class ="PostsMainDiv">

    </div>
</asp:Content>
