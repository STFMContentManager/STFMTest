<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SampleCurriculum.aspx.cs" Inherits="RCRSubmission.SampleCurriculum" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <asp:Table HorizontalAlign="Center" Width="875px" CellPadding="0" CellSpacing="0" runat="server" ID="tabMain">
      <asp:TableRow>
       <asp:TableCell HorizontalAlign="Center" ColumnSpan="2">
        <asp:HyperLink runat="server" NavigateUrl="~/Default.aspx"><asp:Image ID="Image1" BorderStyle="None" runat="server" ImageUrl="~/Images/Header.jpg" /></asp:HyperLink>
       </asp:TableCell>
      </asp:TableRow>
      <asp:TableRow>
       <asp:TableCell ColumnSpan="2">
        <p style="padding-top:10px">
         <b>
          Residency Curriculum Resource Sample Curriculum
         </b>
        </p>
       </asp:TableCell>
      </asp:TableRow>
      <asp:TableRow>
       <asp:TableCell HorizontalAlign="Center">
        <asp:HyperLink ID="HyperLink1" runat="server" Text="TBandHIV-3.pptx" NavigateUrl="~/Samples/TBandHIV-3.pptx" Target="_blank"></asp:HyperLink>
       </asp:TableCell>
       <asp:TableCell HorizontalAlign="Center">
        <asp:HyperLink ID="HyperLink2" runat="server" Text="TB and HIV_Quiz.docx" NavigateUrl="~/Samples/TB and HIV_Quiz.docx" Target="_blank"></asp:HyperLink>
       </asp:TableCell>
      </asp:TableRow>
      <asp:TableRow>
       <asp:TableCell Height="30px">
        &nbsp;
       </asp:TableCell>
      </asp:TableRow>
      <asp:TableRow>
       <asp:TableCell HorizontalAlign="Center">
        <asp:HyperLink ID="hlSample3" runat="server" Text="Case Studies_TB and HIV_Learner.docx" NavigateUrl="~/Samples/Case Studies_TB and HIV_Learner.docx" Target="_blank"></asp:HyperLink>
       </asp:TableCell>
       <asp:TableCell HorizontalAlign="Center">
        <asp:HyperLink ID="hlSample4" runat="server" Text="Case Studies_TB and HIV_Facilitator.docx" NavigateUrl="~/Samples/Case Studies_TB and HIV_Facilitator.docx" Target="_blank"></asp:HyperLink>
       </asp:TableCell>
      </asp:TableRow>
     </asp:Table>
    </div>
    </form>
</body>
</html>
