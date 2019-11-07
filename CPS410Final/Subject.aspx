<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Subject.aspx.cs" Inherits="CPS410Final.DBSubject" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style type="text/css">

    .grid{
        text-align: center;
        border: solid 2px black;
        width: 20%;

    }
    .rows{
        background-color: lightgray;
        font-family: Dubai;
    }
    .rows:hover{
        background-color: darkgray;
    }
    .selectedrow{
        background-color: deepskyblue;
    }
    
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:siteDBConnectionString %>" SelectCommand="SELECT [SubjectName], [SubjectID] FROM [Subjects] WHERE ([SubjectVisibility] = @SubjectVisibility)">
        <SelectParameters>
            <asp:Parameter DefaultValue="T" Name="SubjectVisibility" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:GridView ID="GridView1" CssClass="grid" RowStyle-CssClass="rows" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" DataKeyNames="SubjectID">
        <Columns>
            <asp:HyperLinkField DataTextField="SubjectName"
                DataNavigateUrlFields="SubjectID"
                DataNavigateUrlFormatString="~/Topic.aspx?SubjectID={0}"
                HeaderText="SubjectName" 
                SortExpression="SubjectName"
                 />
        </Columns>
    </asp:GridView>
    <asp:Button ID="btnAddSubject" runat="server" Text="Add New Subject" OnClick="btnAddSubject_Click" Visible="False" />
    <asp:CheckBox ID="chkboxVisibility" runat="server" Text="Set Public" Visible="False" />
    <asp:TextBox ID="txtboxSubjectName" runat="server"></asp:TextBox>
</asp:Content>

