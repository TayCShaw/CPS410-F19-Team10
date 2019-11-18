<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Tutor.aspx.cs" Inherits="CPS410Final.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="tutor.css" />
    
    <div class="tutorsearch" id="tutorsearch" runat="server">
        <h1 class="title">Tutor Search</h1>
      
        <div class="inputFields">
        <form class="form">
            <label>
            <asp:TextBox ID="txtboxSubject" placeholder="Subject" runat="server"></asp:TextBox>
            </label>
            <label>
            <asp:TextBox ID="txtboxSchool" placeholder="School (Optional)" runat="server"></asp:TextBox>
            </label>
            <label>
            <asp:TextBox ID="txtboxDegree" placeholder="Degree" runat="server"></asp:TextBox>
            </label>
            <label>
            <asp:TextBox ID="txtboxCommunication" placeholder="Communication Method" runat="server"></asp:TextBox>
             </label>
            
                <asp:Button ID="btnTutor" runat="server" Text="Find Tutor" CssClass="fTutor" Height="50px" OnClick="btnTutor_Click" />
            
        </form>
        </div>
        


    </div> 

    <div class="tutorlist" id="tutorlist" runat="server">
        <asp:Button ID="back" runat="server" Text="&lt;&lt; Return To Search" BackColor="DeepSkyBlue" OnClick="back_Click" Width="25%" BorderStyle="None" CssClass="btnBack" />

        <asp:Label ID="lblLiterally" runat="server"></asp:Label>

        <div class="tutor" id="tutor" runat="server">
            


            <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
            <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1">
            </asp:GridView>
            


        </div>


    </div>

    <script type="text/javascript">
        function clickButton(e, btnTutor) {
            var evt = e ? e : window.event;
            var bt = document.getElementById(btnTutor);
            if (bt) {
                if (evt.keyCode == 13) {
                    bt.click();
                    return false;
                }
            }
        }
    </script>
</asp:Content>
