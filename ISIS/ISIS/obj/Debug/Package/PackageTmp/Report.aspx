<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="Report.aspx.cs" Inherits="ISIS.Report" %>
<%@ Register TagName="FullInventoryReport" TagPrefix="uc" Src="~/Controls/FullInventoryReport.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        .lblYear { color: Blue }     
        .lblQFont { font-size: 12px }
        .lblQPadding { padding-left: 8px }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>

      <asp:Table runat="server" Width="100%" ID="tabHeader">
       <asp:TableRow>
        <asp:TableCell Width="45%" style="font-size:30px; color:#000000; border-bottom: solid .1ex #0000aa">
         Society of Teachers of Family Medicine Project Inventory <font color="red">View Full Inventory Report</font>
        </asp:TableCell>
       </asp:TableRow>
      </asp:Table>
      
      <br />

      <asp:Table ID="tabMenu" Width="35%" runat="server">
      <asp:TableRow>
       <asp:TableCell>
       <asp:Image runat="server" ID="imgHomeIcon" ImageUrl="~/Images/Edit_Report_Icon.gif" />&nbsp;<asp:LinkButton runat="server" ID="LinkButton6" Text="Edit Projects" OnClick="GoHome"></asp:LinkButton>
       </asp:TableCell>
       <asp:TableCell>
       <asp:Image runat="server" ID="imgAdminIcon" ImageUrl="~/Images/Admin_Icon.gif" />&nbsp;<asp:LinkButton runat="server" ID="lbManageProjects" OnClick="ManageProjects" Text="Manage Projects" />
       </asp:TableCell>
       <asp:TableCell>
       <asp:Image runat="server" ID="Image1" ImageUrl="~/Images/Printable_Report_Icon.gif" />&nbsp;<asp:HyperLink runat="server" ID="LinkButton1" NavigateUrl="PrintableReport.aspx" Target="_blank" Text="View Printable Report" />
       </asp:TableCell>
      </asp:TableRow>
    </asp:Table>

    <br />

     <uc:FullInventoryReport runat="server" id="ucFullInventoryReport" />

    </div>
    </form>
</body>
</html>
