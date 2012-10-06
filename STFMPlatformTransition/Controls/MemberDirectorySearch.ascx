<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MemberDirectorySearch.ascx.cs" Inherits="STFMPlatformTransition.Controls.MemberDirectorySearch" %>

<asp:Table HorizontalAlign="Center" runat="server" ID="tabMain">
 <asp:TableRow>
  <asp:TableCell>
   <b>Member Directory Search</b>
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell Height="30px">
   &nbsp;
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell>
   <asp:Label runat="server" ID="lblFName" Text="First Name"></asp:Label>
  </asp:TableCell>
  <asp:TableCell ColumnSpan="2">
   <asp:Label runat="server" ID="lblLastName" Text="Last Name"></asp:Label>
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell>
   <asp:TextBox runat="server" ID="txtFName"></asp:TextBox>
  </asp:TableCell>
  <asp:TableCell ColumnSpan="2">
   <asp:TextBox runat="server" ID="txtLName"></asp:TextBox>
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell>
   <asp:Label runat="server" ID="lblInstitution" Text="Institution"></asp:Label>
  </asp:TableCell>
  <asp:TableCell ColumnSpan="2">
   <asp:Label runat="server" ID="lblEmail" Text="Email"></asp:Label>
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell>
   <asp:DropDownList runat="server" ID="ddlInstitution"></asp:DropDownList>
  </asp:TableCell>
  <asp:TableCell ColumnSpan="2">
   <asp:TextBox runat="server" ID="txtEmail"></asp:TextBox>
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell>
   <asp:Label runat="server" ID="lblCity" Text="City"></asp:Label>
  </asp:TableCell>
  <asp:TableCell>
   <asp:Label runat="server" ID="lblState" Text="State"></asp:Label>
  </asp:TableCell>
  <asp:TableCell>
   <asp:Label runat="server" ID="lblZipCode" Text="Zip Code"></asp:Label>
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell>
   <asp:TextBox runat="server" ID="txtCity"></asp:TextBox>
  </asp:TableCell>
  <asp:TableCell>
   <asp:DropDownList runat="server" ID="ddlStates"></asp:DropDownList>
  </asp:TableCell>
  <asp:TableCell>
   <asp:TextBox runat="server" ID="txtZipCode"></asp:TextBox>
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell Height="30px">
   &nbsp;
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell ColumnSpan="3">
   <asp:LinkButton runat="server" ID="lbSearch" Text="Click Here to Search" OnClick="ShowSearchResults"></asp:LinkButton>
  </asp:TableCell>
 </asp:TableRow>
</asp:Table>

<asp:Table runat="server" ID="tabResults" Visible="false">
 <asp:TableRow>
  <asp:TableCell>
   <asp:Label runat="server" ID="lblDisplayFName" Text="First Name"></asp:Label>&nbsp;&nbsp;
   <asp:Label runat="server" ID="lblDisplayMName" Text="Middle Name"></asp:Label>&nbsp;&nbsp;
   <asp:Label runat="server" ID="lblDisplayLName" Text="Last Name"></asp:Label>
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell>
   <asp:Label runat="server" ID="lblDisplayAddress1" Text="Address 1"></asp:Label>
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell>
   <asp:Label runat="server" ID="lblDisplayAddress2" Text="Address 2"></asp:Label>
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell>
   <asp:Label runat="server" ID="lblDisplayCity" Text="City"></asp:Label>,&nbsp;&nbsp;
   <asp:Label runat="server" ID="lblDisplayState" Text="State"></asp:Label>&nbsp;&nbsp;
   <asp:Label runat="server" ID="lblDisplayZipCode" Text="Zip"></asp:Label>
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell>
   <asp:Label runat="server" ID="lblDisplayPhone" Text="Phone Number"></asp:Label>
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell>
   <asp:Label runat="server" ID="lblDisplayFax" Text="Fax Number"></asp:Label>
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell>
   <asp:Label runat="server" ID="lblDisplayEmail" Text="Email Address"></asp:Label>
  </asp:TableCell>
 </asp:TableRow>
</asp:Table>
