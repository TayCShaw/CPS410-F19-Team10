<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Thread.aspx.cs" Inherits="CPS410Final.DBThread" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">

        .auto-style14 {
            width: 74px;
        }
        .auto-style13 {
            width: 394px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="mainDiv" runat="server">

        <table id="threadsTable" style="width: 100%;" runat="server">
            <tr>
                <td>
                    <asp:Button ID="btnNewThread" runat="server" Text="New Thread" OnClick="btnNewThread_Click" />

                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:siteDBConnectionString %>" SelectCommand="SELECT Threads.ThreadID, Threads.ThreadTopic, Threads.ThreadName, 
Threads.ThreadViews, Threads.ThreadReplies, Users.Username , Threads.TimeModified
FROM Threads INNER JOIN Users ON Threads.UserID = Users.UserID
WHERE ThreadTopic = @ThreadTopic">
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
                                DataNavigateUrlFields="ThreadID, ThreadTopic"
                                DataNavigateUrlFormatString="/Thread.aspx?Viewing={0}&Topic={1}"
                                HeaderText="ThreadName" 
                                SortExpression="ThreadName" />
                            <asp:BoundField DataField="ThreadViews" HeaderText="ThreadViews" SortExpression="ThreadViews" />
                            <asp:BoundField DataField="ThreadReplies" HeaderText="ThreadReplies" SortExpression="ThreadReplies" />
                            <asp:BoundField DataField="Username" HeaderText="Username" SortExpression="Username" />
                            <asp:BoundField DataField="TimeModified" HeaderText="TimeModified" SortExpression="TimeModified" />
                        </Columns>
                    </asp:GridView>

                    <asp:Button ID="btnBackToSubjects" runat="server" OnClick="btnBackToSubjects_Click" Text="Back to Subjects" />

                </td>
            </tr>
        </table>
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

    <table id="ReplyInfo" style="width:100%;" runat="server">
        <tr>
            <td class="auto-style14">
                &nbsp;</td>
            <td class="auto-style13">
                &nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style14">
                <asp:Label ID="lblYourReply" runat="server" Text="Your Reply"></asp:Label>
            </td>
            <td class="auto-style13">
                <asp:TextBox ID="txtboxThreadReply" runat="server" TextMode="MultiLine" Height="97px" Width="476px" Font-Names="Arial" Font-Size="12px"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfvThreadReply" runat="server" ErrorMessage="Required Field" ControlToValidate="txtboxThreadReply"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style14">&nbsp;</td>
            <td class="auto-style13">
                <asp:Button ID="btnSubmitReply" runat="server" OnClick="btnSubmitReply_Click" Text="Submit Reply" />
                <asp:Button ID="btnCancelReply" runat="server" OnClick="btnCancelReply_Click" Text="Cancel" CausesValidation="False" />
            </td>
            <td>
                <asp:Label ID="lblReplyError" runat="server" Visible="False"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
