<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PasswordRecover.aspx.cs" Inherits="STFMPlatformTransition.Application.UserAccount.PasswordFind.PasswordRecover" %>

<asp:Content ID="PWRecoverContent" runat="server" ContentPlaceHolderID="MainContent">

<asp:Table ID="Table3" runat="server" CssClass="App_Body" HorizontalAlign="Center">
 <asp:TableRow>
  <asp:TableCell>

<h2>STFM User Password Recovery</h2>

<p>Use one of the forms below to recover your username and password. If you don't know any of the information .
needed to complete one of the forms, please contact Richard Theobald at <a href= "mailto:rtheobald@stfm.org">rtheobald@stfm.org</a> or call 800-274-7928 ext. 5407.</p>

<asp:Table ID=tusername runat="server" Width="60%" CssClass="tblset" HorizontalAlign="Center">

<asp:TableRow><asp:TableCell><span style="font-weight:bold;">Enter your STFM username and then click the Find Me button. 
We will create a new password and email it to the email address 
associated with the provided username.</span><br /><br /> STFM Username: <asp:TextBox runat="server" ID="tbusername" Width="250"></asp:TextBox> 
</asp:TableCell></asp:TableRow>
<asp:TableRow><asp:TableCell HorizontalAlign="Center" Height="40px" VerticalAlign="Bottom">
<asp:LinkButton runat="server" ID="usrrecoverbbtn" Text="Find Me"/></asp:TableCell></asp:TableRow>

</asp:Table>
<br />

<asp:Table ID=temail runat="server" Width="60%" CssClass="tblset" HorizontalAlign="Center">

<asp:TableRow><asp:TableCell><span style="font-weight:bold;">Enter your email address and then click the Find Me button. 
If we find your email address associated with a STFM account we will create a new password 
and email your username and new password to the email address.</span><br /><br /> Email Address: <asp:TextBox runat="server" ID="tbemail" Width="250"></asp:TextBox> 
</asp:TableCell></asp:TableRow>
<asp:TableRow><asp:TableCell HorizontalAlign="Center" Height="40px" VerticalAlign="Bottom">
<asp:LinkButton runat="server" ID="emailrecoverbtn" Text="Find Me"/>.
</asp:TableCell></asp:TableRow>

</asp:Table>

  </asp:TableCell>
 </asp:TableRow>
</asp:Table>

</asp:Content>
