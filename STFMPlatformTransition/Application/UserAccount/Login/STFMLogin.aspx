<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="STFMLogin.aspx.cs" Inherits="STFM_Account_Manager_3.WebForm1" %>

<asp:Content ID="Foundation4" runat="server" ContentPlaceHolderID="MainContent">

<asp:Panel ID="bodypanel" Width="875px" runat="server">

<h2>STFM.org Login</h2>

<p>Please enter your username and password below.  Forgot your password? Go to URL HERE.</p>

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

</asp:Table>

<asp:LinkButton runat="server" ID="linkbackbutton" Text="Back" OnClick="clkbackbtn"/>
<asp:LinkButton runat="server" ID="linknextbutton" Text="Next" OnClick="clknextbtn"/>

</asp:Panel>
</asp:Content>
