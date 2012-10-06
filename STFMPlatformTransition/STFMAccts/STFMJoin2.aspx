<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="STFMJoin2.aspx.cs" Inherits="STFM_Account_Manager_3.STFMJoin2" %>

<asp:Content runat="server" ID="Join2Content" ContentPlaceHolderID="MainContent">

<asp:Table ID="Table3" runat="server" CssClass="App_Body" HorizontalAlign="Center">
 <asp:TableRow>
  <asp:TableCell>
<h2>STFM Member Application - Step 2</h2>

    <p>Confirm your selections below.  Click "Back" to make any changes.  Click "Next" to advance to the payment processing system.</p>
   
    <asp:Table ID="Table1" runat="server">
    
        <asp:tablerow>
    
            <asp:TableCell Width="200px">Membership Type:</asp:TableCell><asp:TableCell runat="server" ID="memtypename"></asp:TableCell>

        </asp:tablerow>

        <asp:tablerow>
    
            <asp:TableCell Width="200px">Position:</asp:TableCell><asp:TableCell runat="server" ID="mempos"></asp:TableCell>

        </asp:tablerow>

       <asp:tablerow>
    
            <asp:TableCell Width="200px">Rank:</asp:TableCell><asp:TableCell runat="server" ID="memrank"></asp:TableCell>

        </asp:tablerow>

        <asp:tablerow>
    
            <asp:TableCell Width="200px">Disicpline:</asp:TableCell><asp:TableCell runat="server" ID="memdiscipline"></asp:TableCell>

        </asp:tablerow>

        <asp:tablerow >
    
            <asp:TableCell Width="200px">Release Demographic Data:</asp:TableCell><asp:TableCell runat="server" ID="memdemo"></asp:TableCell>

        </asp:tablerow>

        <asp:tablerow>
    
            <asp:TableCell Width="200px">Ethnicity:</asp:TableCell><asp:TableCell runat="server" ID="memethnicity"></asp:TableCell>

        </asp:tablerow>

    </asp:Table>
        
    <asp:LinkButton runat="server" ID="backbtn" OnClick="ClickBackButton" Text="Make Changes"></asp:LinkButton>
    <asp:LinkButton runat="server" ID="nextbtn" OnClick="ClickForwardButton" Text="Next"></asp:LinkButton>
  </asp:TableCell>
 </asp:TableRow>
</asp:Table>
    </asp:Content>

