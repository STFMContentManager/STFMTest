<%@ Page Language="C#" MasterPageFile="~/Timesheet.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" Title="Untitled Page" %>
<asp:Content ID="Content1" runat="Server" ContentPlaceHolderID="ContentPlaceHolder1">
	<asp:Table ID="MainPage" runat="server" Width="777px">
		<asp:TableRow>
			<asp:TableCell ColumnSpan="2" CssClass="PageHeader">
				<asp:Label ID="LblPageTitle" runat="server" Text="LblPageTitle" />
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow>
			<asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
		<asp:TableRow>
			<asp:TableCell CssClass="FormRight" Width="50%">
				User name:
			</asp:TableCell>
			<asp:TableCell CssClass="FormLeft" Width="50%">
				<asp:TextBox ID="TxtUserName" runat="server" Width="200px">
				</asp:TextBox>
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow>
			<asp:TableCell CssClass="FormRight">
				Password:
			</asp:TableCell>
			<asp:TableCell CssClass="FormLeft">
				<asp:TextBox ID="TxtPassword" runat="server" Width="200px" TextMode="Password">
				</asp:TextBox>
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
		<asp:TableRow>
			<asp:TableCell ColumnSpan="2" CssClass="FormCenter">
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow ID="RowMessage1"><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
		<asp:TableRow ID="RowMessage2">
			<asp:TableCell CssClass="FormCenter" ColumnSpan="2">
				<asp:Label runat="server" ID="LblMessage" Text="LblMessage" />
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
		<asp:TableRow>
			<asp:TableCell ColumnSpan="2" CssClass="FormCenter">
				<asp:Button ID="BtnSubmit" runat="server" OnClick="BtnSubmit_Click" Text="Log On" CssClass="Button" />
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow><asp:TableCell>&nbsp;</asp:TableCell></asp:TableRow>
		<asp:TableRow>
			<asp:TableCell ColumnSpan="2" CssClass="FormCenter">
				<asp:Button runat="server" ID="BtnContact" CssClass="Button" Visible="false" Text="Send Message To Administrator" OnClick="BtnContact_Click" />
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
		<asp:TableRow>
			<asp:TableCell ColumnSpan="2" CssClass="FormCenter">
				<asp:Button ID="BtnAbout" runat="server" OnClick="BtnAbout_Click" Text="About" Visible="false" CssClass="Button" />
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow ID="RowMessage" Visible="false">
			<asp:TableCell ColumnSpan="2" CssClass="ErrorMsg">
				<asp:Label ID="LblMsg" runat="server" Text="LblMsg" />
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
	</asp:Table>
<!-- $Filename: D:\Inetpub\wwwroot\TimeRep\Login.aspx $   $Revision: 1.2 $ -->
</asp:Content>
