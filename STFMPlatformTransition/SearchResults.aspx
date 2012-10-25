<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchResults.aspx.cs" Inherits="STFMPlatformTransition.SearchResults1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:HyperLink runat="server" ID="hlReturn" NavigateUrl="~/Vulcan/Forge.aspx" Text="Return to the Forge" />
    <br /><br />
    <div>
     <asp:DataGrid runat="server" ID="dgSearchResults" />
    </div>
    </form>
</body>
</html>
