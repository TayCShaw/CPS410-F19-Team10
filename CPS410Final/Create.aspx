<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="CPS410Final.Create" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style4 {
            width: 299px;
        }
        .auto-style5 {
            width: 191px;
        }
        .auto-style6 {
            width: 100%;
        }
        .auto-style7 {
            width: 193px;
        }
        .auto-style8 {
            width: 190px;
        }
        .auto-style9 {
            width: 100%;
            height: 40px;
        }
        .auto-style11 {
            width: 196px;
        }
        .auto-style13 {
            width: 199px;
        }
        .auto-style14 {
            width: 187px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        <br />
        <br />
    </p>
    <table id="SubjectInfo" class="auto-style9" runat="server">
        <tr>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style5">
                <asp:Label ID="lblSubjectName" runat="server" Text="New Subject Name"></asp:Label>
            </td>
            <td class="auto-style7">
                <asp:TextBox ID="txtboxNewSubjectName" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfvNewSubjectName" runat="server" ControlToValidate="txtboxNewSubjectName" ErrorMessage="Required Field"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style5">
                <asp:Label ID="lblSubjectTopic" runat="server" Text="First Topic Name"></asp:Label>
            </td>
            <td class="auto-style7">
                <asp:TextBox ID="txtboxFirstTopic" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfvFirstTopic" runat="server" ControlToValidate="txtboxFirstTopic" ErrorMessage="Required Field"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style5">
                &nbsp;</td>
            <td class="auto-style7">
                <asp:Button ID="btnSubmitSubject" runat="server" OnClick="btnSubmitSubject_Click" Text="Submit Subject" />
            </td>
            <td>
                <asp:Label ID="lblSubjectError" runat="server"></asp:Label>
            </td>
        </tr>
    </table>

    <table id="TopicInfo" class="auto-style6" runat="server">
        <tr>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style8">
                <asp:Label ID="lblNewTopicName" runat="server" Text="New Topic Name"></asp:Label>
            </td>
            <td class="auto-style11">
                <asp:TextBox ID="txtboxNewTopicName" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfvNewTopicName" runat="server" ErrorMessage="Required Field" ControlToValidate="txtboxNewTopicName" Visible="False"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style8">
                <asp:Label ID="Label2" runat="server" Text="PLACEHOLDER"></asp:Label>
            </td>
            <td class="auto-style11">
                <asp:Label ID="Label1" runat="server" Text="PLACEHOLDER, POSSIBLY HAVE TOPIC DESCRIPTION"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style8">&nbsp;</td>
            <td class="auto-style11">
                <asp:Button ID="btnSubmitTopic" runat="server" Text="Submit Topic" OnClick="btnSubmitTopic_Click" />
            </td>
            <td>
                <asp:Label ID="lblTopicError" runat="server" Visible="False"></asp:Label>
            </td>
        </tr>
    </table>

    <table id="ThreadInfo" style="width:100%;" runat="server">
        <tr>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style8">
                <asp:Label ID="lblThreadName" runat="server" Text="New Thread Name"></asp:Label>
            </td>
            <td class="auto-style11">
                <asp:TextBox ID="txtboxNewThreadName" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfvNewThreadName" runat="server" ErrorMessage="Required Field" ControlToValidate="txtboxNewThreadName"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style8">
                <asp:Label ID="lblThreadOP" runat="server" Text="Your Post"></asp:Label>
            </td>
            <td class="auto-style11">
                <asp:TextBox ID="txtboxThreadOP" runat="server" TextMode="MultiLine"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfvThreadOP" runat="server" ErrorMessage="Required Field" ControlToValidate="txtboxThreadOP"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style8">&nbsp;</td>
            <td class="auto-style11">
                <asp:Button ID="btnSubmitThread" runat="server" OnClick="btnSubmitThread_Click" Text="Submit Thread" />
            </td>
            <td>
                <asp:Label ID="lblThreadError" runat="server" Visible="False"></asp:Label>
            </td>
        </tr>
    </table>

    <table id="ReplyInfo" style="width:100%;" runat="server">
        <tr>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style14">
                <asp:Label ID="Label4" runat="server" Text="PLACEHOLDER"></asp:Label>
            </td>
            <td class="auto-style13">
                <asp:Label ID="Label5" runat="server" Text="PLACEHOLDER, possibly put the OP here"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style14">
                <asp:Label ID="lblYourReply" runat="server" Text="Your Reply"></asp:Label>
            </td>
            <td class="auto-style13">
                <asp:TextBox ID="txtboxThreadReply" runat="server" TextMode="MultiLine"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfvThreadReply" runat="server" ErrorMessage="Required Field" ControlToValidate="txtboxThreadReply"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style14">&nbsp;</td>
            <td class="auto-style13">
                <asp:Button ID="btnSubmitReply" runat="server" OnClick="btnSubmitReply_Click" Text="Submit Reply" />
            </td>
            <td>
                <asp:Label ID="lblReplyError" runat="server" Visible="False"></asp:Label>
            </td>
        </tr>
    </table>

</asp:Content>
