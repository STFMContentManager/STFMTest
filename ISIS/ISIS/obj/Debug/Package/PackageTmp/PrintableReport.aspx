<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintableReport.aspx.cs" Inherits="ISIS.PrintableReport" %>
<%@ Register TagName="FullInventoryReport" TagPrefix="uc" Src="~/Controls/FullInventoryReport.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <uc:FullInventoryReport runat="server" id="ucFullInventoryReport" />
    </div>
    </form>
</body>
</html>
