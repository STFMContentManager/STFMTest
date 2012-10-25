<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PasswordChange.aspx.cs" Inherits="STFMPlatformTransition.Application.UserAccount.PasswordChange.PasswordChange" %>

<asp:Content ID="PWChangeContent" runat="server" ContentPlaceHolderID="MainContent">

<asp:Table ID="Table3" runat="server" CssClass="App_Body" HorizontalAlign="Center">
 <asp:TableRow>
  <asp:TableCell>

<h2>STFM User Password Change</h2>

<p>Complete this form to change your username and/or password.</p>



<asp:Table ID=tusername runat="server" Width="400px" HorizontalAlign="Center">

<asp:TableRow Height="50px" VerticalAlign="Bottom">

    <asp:TableCell>
        <p><strong>Username:</strong>  </p>
    </asp:TableCell>

    <asp:TableCell>
        <asp:TextBox runat="server" ID="tbcurrusername" Width="150"></asp:TextBox> 
    </asp:TableCell>

</asp:TableRow>

<asp:TableRow>

    <asp:TableCell>
        <p><strong>Password:</strong>  </p>
    </asp:TableCell>

    <asp:TableCell>
        <asp:TextBox runat="server" ID="tbcurrpassword" Width="150" TextMode="Password"></asp:TextBox> 
    </asp:TableCell>

</asp:TableRow>

<asp:TableRow>

    <asp:TableCell>
        <p><strong>New Username:</strong> <br />(It can be the same as your current username)</p>
    </asp:TableCell>

    <asp:TableCell VerticalAlign="Top">
        <asp:TextBox runat="server" ID="tbnewusername" Width="150"></asp:TextBox> 
    </asp:TableCell>

</asp:TableRow>

<asp:TableRow>

    <asp:TableCell>
        <p><strong>Password:</strong><br />(It can be the same as your current username)</p>
    </asp:TableCell>

    <asp:TableCell VerticalAlign="Top">
        <asp:TextBox runat="server" ID="tbnewpassword" Width="150" TextMode="Password"></asp:TextBox> 
    </asp:TableCell>

</asp:TableRow>

<asp:TableRow>

    <asp:TableCell>
        <p><strong>Confirm New Password:</strong></p>
    </asp:TableCell>

    <asp:TableCell>
        <asp:TextBox runat="server" ID="tbconfirmnewpw" Width="150" TextMode="Password"></asp:TextBox> 
    </asp:TableCell>

</asp:TableRow>

<asp:TableRow>
    <asp:TableCell HorizontalAlign="Center" Height="40px" VerticalAlign="Bottom" ColumnSpan=2>
        <asp:LinkButton runat="server" ID="linkbtnchange" Text="Make Changes"/>
    </asp:TableCell>
</asp:TableRow>

</asp:Table>
<br />
Use one of the forms below to recover your username and password. If you don't know any of the information 
needed to complete one of the forms, please contact Richard Theobald at <a href= "mailto:rtheobald@stfm.org">rtheobald@stfm.org</a> 
or call 800-274-7928 ext. 5407.

  </asp:TableCell>
 </asp:TableRow>
</asp:Table>
</asp:Content>
