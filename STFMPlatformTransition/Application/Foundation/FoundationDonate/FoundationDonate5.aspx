<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FoundationDonate5.aspx.cs" Inherits="STFMFoundationDonor.WebForm1" %>

<asp:Content runat="server" ID="Foundation5" ContentPlaceHolderID="MainContent">
    <div class="App_Body">
        <p>Thank you for your donation to the STFM foundation.  A transaction receipt has been sent to the email you provided.</p><br />
        We have created an account at STFM.org for you to expedite the process in the future.<br />
        Your username is: <asp:Label runat="server" ID="lblusername"></asp:Label><br />
        Your password is: <asp:Label runat="server" ID="lblpassword"></asp:Label><br /><br />

        You can change your username and password at STFM.org at any by logging in and clicking "Change my Login". 

        <a href="http://www.stfm.org">Return to STFM.org</a>

    </div>

</asp:Content>