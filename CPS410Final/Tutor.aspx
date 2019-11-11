<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Tutor.aspx.cs" Inherits="CPS410Final.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="tutor.css" />
    
    <div class="tutorsearch">
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
            
                <asp:Button ID="btnTutor" runat="server" Text="Find Tutor" CssClass="fTutor" Height="50px" />
            
        </form>
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
