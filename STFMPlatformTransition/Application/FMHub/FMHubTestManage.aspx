<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FMHubTestManage.aspx.cs" Inherits="STFMPlatformTransition.Application.FMHub.FMHubTestManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <a href="FMJournal.aspx?IssueID=33">TEST ISSUE GET</a></br>

        <asp:Button runat="server" ID="XMLButton" OnClick="XMLIssue" Text="Generate XML"/>
    </div>
    </form>
</body>
</html>
