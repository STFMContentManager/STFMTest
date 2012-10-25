<%@ Page Language="C#" MasterPageFile="~/Timesheet.master" AutoEventWireup="true" CodeFile="TaskEdit.aspx.cs" Inherits="TaskEdit" Title="Untitled Page" %>
<asp:Content ID="Content1" runat="Server" ContentPlaceHolderID="ContentPlaceHolder1">
	<asp:Table ID="MainPage" runat="server" Width="777px">
		<asp:TableRow>
			<asp:TableCell ColumnSpan="2" CssClass="PageHeader">
				<asp:Label ID="LblPageTitle" runat="server" Text="LblPageTitle"></asp:Label>
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow>
			<asp:TableCell CssClass="FormRight" Width="50%">
				Project:
			</asp:TableCell>
			<asp:TableCell CssClass="FormLeft" Width="50%">
				<b><asp:Label ID="LblProject" runat="server" Text="LblProject" /></b>
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
		<asp:TableRow>
			<asp:TableCell CssClass="FormRight" Width="50%">
				Task name:
			</asp:TableCell>
			<asp:TableCell CssClass="FormLeft" Width="50%">
				<asp:TextBox runat="server" ID="TxtTaskName" Width="200px" />
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow>
			<asp:TableCell CssClass="FormRight">
				Cost:
			</asp:TableCell>
			<asp:TableCell CssClass="FormLeft">
				<asp:TextBox runat="server" ID="TxtCostCentre" Width="200px" />
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow>
			<asp:TableCell CssClass="FormRight">
				Task is chargeable:
			</asp:TableCell>
			<asp:TableCell CssClass="FormLeft">
				<asp:DropDownList ID="DdlProductive" runat="server" Width="205px">
				<asp:ListItem Value="0" Text="No" />
				<asp:ListItem Value="1" Text="Yes" />
				</asp:DropDownList>
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow>
			<asp:TableCell CssClass="FormRight">
				Task is active:
			</asp:TableCell>
			<asp:TableCell CssClass="FormLeft">
				<asp:DropDownList ID="DdlActive" runat="server" Width="205px">
				<asp:ListItem Value="0" Text="No" />
				<asp:ListItem Value="1" Text="Yes" />
				</asp:DropDownList>
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow>
			<asp:TableCell CssClass="FormRight">
				Validation type:
			</asp:TableCell>
			<asp:TableCell CssClass="FormLeft">
				<asp:DropDownList ID="DdlValidationType" runat="server" Width="205px">
				<asp:ListItem Value="1" Text="No validation" />
				<asp:ListItem Value="2" Text="Job must pre-exist" />
				<asp:ListItem Value="4" Text="Use regular expression" />
				<asp:ListItem Value="8" Text="Use dropdown listbox" />
				</asp:DropDownList>
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow>
			<asp:TableCell CssClass="FormRight">
				Reference regular expression:
			</asp:TableCell>
			<asp:TableCell CssClass="FormLeft">
				<asp:TextBox runat="server" ID="TxtReferenceRegEx" Width="200px" />
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow>
			<asp:TableCell CssClass="FormRight" VerticalAlign="top">
				Description:
			</asp:TableCell>
			<asp:TableCell CssClass="FormLeft">
				<asp:TextBox runat="server" ID="TxtDescription" TextMode="multiLine" Rows="5" Width="200px" />
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
		<asp:TableRow>
			<asp:TableCell ColumnSpan="2" CssClass="FormCenter">
				<asp:Button ID="BtnSubmit" runat="server" OnClick="BtnSubmit_Click" Text="Submit" CssClass="Button" />
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
		<asp:TableRow>
			<asp:TableCell ColumnSpan="2" CssClass="FormCenter">
				<asp:Button ID="BtnCancel" runat="server" OnClick="BtnCancel_Click" Text="Cancel" CssClass="Button" />
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
	</asp:Table>
<!-- $Filename: D:\Inetpub\wwwroot\TimeRep\TaskEdit.aspx $   $Revision: 1.3 $ -->
</asp:Content>
