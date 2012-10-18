<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="STFM_Account_Manager_3.MainPage" %>
<%@ Register TagName="ThreeColumnTemplate" TagPrefix="UC" Src="~/Controls/ThreeColumnTemplate.ascx" %>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<asp:Table runat="server" Width="876px" HorizontalAlign="Center">
 <asp:TableRow>
  <asp:TableCell>
    <h2>STFM Account & Join Admin Test Area</h2>

    <asp:LinkButton ID="LinkButton1" runat="server" Text="Create Account" OnClick="CreateAcct"></asp:LinkButton><br />
    <asp:LinkButton ID="LinkButton2" runat="server" Text="Password Recovery" OnClick="PasswordRecover"></asp:LinkButton><br />
    <asp:LinkButton ID="LinkButton6" runat="server" Text="Password Change" OnClick="PasswordChange"></asp:LinkButton><br />
    <asp:LinkButton ID="LinkButton3" runat="server" Text="Upadte Personal Information" OnClick="AcctUpdateTest"></asp:LinkButton><br />
    <asp:LinkButton ID="LinkButton4" runat="server" Text="Join - no account" OnClick="NoAcctSTFMJoin"></asp:LinkButton><br />
    <asp:LinkButton ID="LinkButton5" runat="server" Text="Join - with account" OnClick="JoinPage"></asp:LinkButton><br />
    <asp:LinkButton ID="LinkButton7" runat="server" Text="Renew" OnClick="JoinPage"></asp:LinkButton><br />

    <br /><br />
    Custom Applications - Interface and Most DB completed
    <br /><br />
    <asp:LinkButton ID="LinkButton8" runat="server" Text="Advocacy Contact" OnClick="Advocacy"></asp:LinkButton><br />
    <asp:LinkButton ID="LinkButton9" runat="server" Text="Membership Directory" OnClick="MembershipDirectory"></asp:LinkButton><br />
    <asp:LinkButton ID="LinkButton10" runat="server" Text="Foundation" OnClick="Foundation"></asp:LinkButton><br />
    <asp:LinkButton ID="FMLinkBtn" runat="server" Text="FM Hub Admin" OnClick="FMHub"></asp:LinkButton><br />

    <br /><br />
    Custom Applications - Phase 2013
    <br /><br />
    Full Participation (emails program directors)<br />
    Member profiles display<br />

    <asp:LinkButton runat="server" Text="Create Account" OnClick="CreateAcct" Visible="false"></asp:LinkButton>
    <asp:LinkButton runat="server" Text="Test Database" OnClick="testdb" Visible="false"></asp:LinkButton>
    <asp:LinkButton runat="server" Text="Address Entry" OnClick="addr" Visible="false"></asp:LinkButton>
    <asp:LinkButton runat="server" Text="Update Account" OnClick="AcctUpdateTest" Visible="false"></asp:LinkButton>
    <asp:LinkButton runat="server" Text="Join STFM Member - No Previous Account" OnClick="NoAcctSTFMJoin" Visible="false"></asp:LinkButton>
    <asp:LinkButton runat="server" Text="Join System - Direct Access" OnClick="JoinPage" Visible="false"></asp:LinkButton>
    <asp:LinkButton runat="server" Text="Foundation Interface - No Previous Account" OnClick="Foundation" Visible="false"></asp:LinkButton>
    <asp:LinkButton runat="server" Text="Report Advocacy Activity Form" OnClick="Advocacy" Visible="false"></asp:LinkButton>
  </asp:TableCell>
 </asp:TableRow>
</asp:Table>

</asp:Content>
