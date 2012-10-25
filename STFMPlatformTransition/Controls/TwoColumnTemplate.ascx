<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TwoColumnTemplate.ascx.cs" Inherits="STFMPlatformTransition.TwoColumnTemplate1" %>
<%@ Register TagPrefix="FTB" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>

<asp:Table ID="tabDisplay" HorizontalAlign="Center" runat="server" Width="875px" Visible="true">
 <asp:TableRow>
  <asp:TableCell ColumnSpan="3" VerticalAlign="Top">
     
   <asp:Table ID="Table1" Width="100%" runat="server">
<%--    <asp:TableRow>
     <asp:TableCell HorizontalAlign="Center" ColumnSpan="3" Height="80px" ID="tcHeaderLinks" ForeColor="#ffffff" style="background-image:url(/images/blue_gradientgreybar.gif)">
      <asp:Label runat="server" ID="lblHeaderLinks"></asp:Label>
     </asp:TableCell>   
    </asp:TableRow>--%>
    <asp:TableRow>
     <asp:TableCell Width="50%" VerticalAlign="Top"><asp:Label runat="server" ID="lblLeftColumn" Font-Size="12px" style="font-family:Arial"></asp:Label></asp:TableCell>
     <asp:TableCell width="50%" VerticalAlign="Top"><asp:Label runat="server" ID="lblRightColumn" Font-Size="12px" style="font-family:Arial"></asp:Label></asp:TableCell>
    </asp:TableRow>
   </asp:Table>

  </asp:TableCell>
 </asp:TableRow>
</asp:Table>

<asp:Table ID="tabCMSDisplay" HorizontalAlign="Center" runat="server" Width="100%" Visible="false">
 <asp:TableRow>
  <asp:TableCell ColumnSpan="3" VerticalAlign="Top">
     
   <asp:Table ID="Table3" Width="100%" runat="server">
<%--    <asp:TableRow>
     <asp:TableCell HorizontalAlign="Left" ColumnSpan="3" Height="80px" ID="TableCell1" ForeColor="#ffffff">
      <asp:LinkButton runat="server" ID="lbSaveHeaderLinks" OnClick="SaveContent" CausesValidation="false" Visible="true" ForeColor="Red" Font-Size="10px">[Save]</asp:LinkButton>
      <FTB:FreeTextBox id="ftbHeaderLinks" Visible="true" Width="100%" Height="80px" runat="Server" />
     </asp:TableCell>   
    </asp:TableRow>
--%>    <asp:TableRow>
     <asp:TableCell Width="50%">
      <asp:LinkButton runat="server" ID="lbSaveLeftColumn" OnClick="SaveContent" Visible="true" ForeColor="Red" Font-Size="10px">[Save]</asp:LinkButton>
      <FTB:FreeTextBox id="ftbLeftColumn" Visible="true" Width="100%" Height="500px" runat="Server" />
     </asp:TableCell>
     <asp:TableCell width="50%">
      <asp:LinkButton runat="server" ID="lbSaveRightColumn" Visible="true" ForeColor="Red" Font-Size="10px">[Save]</asp:LinkButton>
      <FTB:FreeTextBox id="ftbRightColumn" Visible="true" Width="100%" Height="500px" runat="Server" />
     </asp:TableCell>
    </asp:TableRow>
   </asp:Table>

  </asp:TableCell>
 </asp:TableRow>
</asp:Table>
