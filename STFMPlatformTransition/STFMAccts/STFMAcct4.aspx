<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="STFMAcct4.aspx.cs" Inherits="STFM_Account_Manager_3.WebForm1" %>

<asp:Content ID="Foundation4" runat="server" ContentPlaceHolderID="MainContent">

<asp:Table ID="Table3" runat="server" CssClass="App_Body" HorizontalAlign="Center">
 <asp:TableRow>
  <asp:TableCell>


<h2>STFM.org account creation system - Step 4 of 4 create username and password</h2>

<p>Please set your username and password below.  Click "Submit" to finish creating your STFM.org account</p>

<asp:Table ID="Table1" runat="server">
    <asp:TableRow>
        <asp:TableCell ColumnSpan = 2 runat="server" ID="PWerror" Visible="false" ForeColor="Red"></asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell CssClass="lblrow">Username:</asp:TableCell>
        <asp:TableCell><asp:TextBox runat="server" ID="tbusername"></asp:TextBox></asp:TableCell>
    </asp:TableRow>

    <asp:TableRow>
        <asp:TableCell CssClass="lblrow">Password:</asp:TableCell>
        <asp:TableCell><asp:TextBox runat="server" ID="tbpassword" TextMode="Password"></asp:TextBox></asp:TableCell>
    </asp:TableRow>

    <asp:TableRow>
        <asp:TableCell CssClass="lblrow">Confirm Password:</asp:TableCell>
        <asp:TableCell><asp:TextBox runat="server" ID="tbpasswordconf" TextMode="Password"></asp:TextBox></asp:TableCell>
    </asp:TableRow>

</asp:Table>

<asp:LinkButton runat="server" ID="linkbackbutton" Text="Back" OnClick="clkbackbtn"/>
<asp:LinkButton runat="server" ID="linknextbutton" Text="Next" OnClick="clknextbtn"/>

  </asp:TableCell>
 </asp:TableRow>
</asp:Table>
</asp:Content>
