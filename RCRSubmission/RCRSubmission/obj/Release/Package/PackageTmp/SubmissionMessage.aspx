<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SubmissionMessage.aspx.cs" Inherits="RCRSubmission.SubmissionMessage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body style="margin:0">
    <form id="form1" runat="server">
    <div>
     <asp:Table HorizontalAlign="Center" Width="875px" CellPadding="0" CellSpacing="0" runat="server" ID="tabMain">
      <asp:TableRow>
       <asp:TableCell HorizontalAlign="Center">
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx"><asp:Image ID="Image1" BorderStyle="None" runat="server" ImageUrl="~/Images/Header.jpg" /></asp:HyperLink>
       </asp:TableCell>
      </asp:TableRow>
      <asp:TableRow>
       <asp:TableCell>
        <p style="padding-top:10px">
         <b>
          Thank You!  Your Resource Curriculum Proposal Has Been Successfully Submitted!
         </b>
        </p>
        <asp:HyperLink runat="server" NavigateUrl="~/Default.aspx" Font-Size="12px" Text="Click here to go back to the main page"></asp:HyperLink>
       </asp:TableCell>
      </asp:TableRow>
     </asp:Table>

<br /><br />

    </div>
    </form>
</body>
</html>
