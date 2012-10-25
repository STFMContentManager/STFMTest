<%@ Page Language="C#" MasterPageFile="~/Timesheet.master" AutoEventWireup="true" CodeFile="GraphUser.aspx.cs" Inherits="GraphUser" Title="Untitled Page" %>
<%@ Register TagPrefix="kaz" TagName="DateSelector" Src="~/Controls/DateSelector.ascx" %>
<%@ Register TagPrefix="ZGW" Namespace="ZedGraph.Web" Assembly="ZedGraph.Web" %>
<asp:Content ID="Content1" runat="Server" ContentPlaceHolderID="ContentPlaceHolder1">
	<asp:Table ID="MainPage" runat="server" Width="777px">
		<asp:TableRow>
			<asp:TableCell ColumnSpan="2" CssClass="PageHeader">
				<asp:Label ID="LblPageTitle" runat="server" Text="LblPageTitle"></asp:Label>
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
		<asp:TableRow>
			<asp:TableCell ColumnSpan="2" CssClass="DateSelection">
				<kaz:DateSelector runat="server" ID="cc2DateSelector" EnableViewState="true" />
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
		<asp:TableRow>
			<asp:TableCell CssClass="FormRight" Width="50%">
				Team:
			</asp:TableCell>
			<asp:TableCell CssClass="FormLeft" Width="50%">
				<asp:DropDownList runat="server" ID="DdlTeams" Width="220px" OnSelectedIndexChanged="DdlTeams_IndexChanged" AutoPostBack="true" />
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow>
			<asp:TableCell CssClass="FormRight" Width="50%">
				User:
			</asp:TableCell>
			<asp:TableCell CssClass="FormLeft" Width="50%">
				<asp:DropDownList runat="server" ID="DdlUsers" Width="220px" OnSelectedIndexChanged="DdlUsers_IndexChanged" AutoPostBack="true" />
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
		<asp:TableRow>
			<asp:TableCell CssClass="FormCenter" ColumnSpan="2">
				<ZGW:ZEDGRAPHWEB id="ZedGraphWeb" runat="server" PaneFill-Color="Gainsboro" RenderMode="ImageTag" Width="700" Height="500" />
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
		<asp:TableRow>
			<asp:TableCell CssClass="FormCenter" ColumnSpan="2">
				User productivity relates to the number of chargeable hours vs total hours booked.<br />
				A task is marked as chargeable/non-chargeable on the Edit Task page.
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
		<asp:TableRow>
			<asp:TableCell ColumnSpan="2" CssClass="FormCenter">
				<asp:Button ID="BtnReportMenu" runat="server" CssClass="Button" OnClick="BtnReportMenu_Click" Text="Return To Report Menu" />
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
	</asp:Table>
<!-- $Filename: D:\Inetpub\wwwroot\TimeRep\GraphUser.aspx $   $Revision: 1.3 $ -->
</asp:Content>
