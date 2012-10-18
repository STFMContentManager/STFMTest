<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="STFMLogin.aspx.cs" Inherits="STFM_Account_Login.WebForm1" %>

<asp:Content ID="Foundation4" runat="server" ContentPlaceHolderID="MainContent">

<asp:Table ID="LoginTableMain" Width="875px" runat="server" HorizontalAlign="Center" BorderStyle="None" BorderWidth="0px">
<asp:TableRow>
<asp:TableCell>
<h2>STFM.org Login</h2>

<p>Please enter your username and password below.  Forgot your password? Go to URL HERE.</p>

<asp:Table ID="LoginTable" runat="server">
    <asp:TableRow>
        <asp:TableCell ColumnSpan = 2 runat="server" ID="PWerror" Visible="false" ForeColor="Red"></asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell CssClass="lblrow">Username:</asp:TableCell>
        <asp:TableCell><asp:TextBox runat="server" ID="tbusername" Width="200px"></asp:TextBox></asp:TableCell>
    </asp:TableRow>

    <asp:TableRow>
        <asp:TableCell CssClass="lblrow">Password:</asp:TableCell>
        <asp:TableCell><asp:TextBox runat="server" ID="tbpassword" TextMode="Password" Width="200px"></asp:TextBox></asp:TableCell>
    </asp:TableRow>

</asp:Table><br />

<asp:LinkButton runat="server" ID="linkbackbutton" Text="Back" OnClick="clkbackbtn"/>&nbsp;
<asp:LinkButton runat="server" ID="linknextbutton" Text="Next" OnClick="clknextbtn"/>
</asp:TableCell>
</asp:TableRow>
</asp:Table>
</asp:Content>
