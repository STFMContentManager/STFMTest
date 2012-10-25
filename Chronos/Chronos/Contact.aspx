<%@ Page Language="C#" MasterPageFile="~/Timesheet.master" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="Contact" Title="Contact" %>
<asp:Content ID="Content1" runat="Server" ContentPlaceHolderID="ContentPlaceHolder1">
	<asp:Table ID="MainPage" runat="server" Width="777px">
		<asp:TableRow>
			<asp:TableCell ColumnSpan="2" CssClass="PageHeader">
				<asp:Label ID="LblPageTitle" runat="server" Text="LblPageTitle"></asp:Label>
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
		<asp:TableRow>
			<asp:TableCell CssClass="FormCenter" ColumnSpan="2">
				You can send the system administrator a message by entering it below.
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
		<asp:TableRow>
			<asp:TableCell CssClass="FormRight" Width="50%">
				Your name:
			</asp:TableCell>
			<asp:TableCell CssClass="FormLeft" Width="50%">
				<asp:TextBox runat="server" ID="TxtUserName" Width="200px" />
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow>
			<asp:TableCell CssClass="FormRight">
				Telephone number:
			</asp:TableCell>
			<asp:TableCell CssClass="FormLeft">
				<asp:TextBox runat="server" ID="TxtTelephone" Width="200px" />
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow>
			<asp:TableCell CssClass="FormRight">
				Email address:
			</asp:TableCell>
			<asp:TableCell CssClass="FormLeft">
				<asp:TextBox runat="server" ID="TxtEmail" Width="200px" />
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
		<asp:TableRow>
			<asp:TableCell CssClass="FormRight">
				Subject:
			</asp:TableCell>
			<asp:TableCell CssClass="FormLeft">
				<asp:TextBox runat="server" ID="TxtSubject" Width="200px" />
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow>
			<asp:TableCell CssClass="FormRight" VerticalAlign="top">
				Message:
			</asp:TableCell>
			<asp:TableCell CssClass="FormLeft">
				<asp:TextBox runat="server" ID="TxtBody" Width="200px" TextMode="multiLine" Rows="5" />
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow ID="RowMsg1" Visible="false"><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
		<asp:TableRow ID="RowMsg2" Visible="false">
			<asp:TableCell ColumnSpan="2" CssClass="FormCenter">
				<b><asp:Label runat="server" ID="LblMsg" Text="LblMsg" /></b>
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
		<asp:TableRow>
			<asp:TableCell ColumnSpan="2" CssClass="FormCenter">
				<asp:Button ID="BtnSubmit" runat="server" CssClass="Button" OnClick="BtnSubmit_Click" Text="Submit" Width="300px" />
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
		<asp:TableRow>
			<asp:TableCell ColumnSpan="2" CssClass="FormCenter">
				<asp:Button ID="BtnCancel" runat="server" CssClass="Button" OnClick="BtnCancel_Click" Text="Cancel" Width="300px" />
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
	</asp:Table>
<!-- $Filename$ -->
</asp:Content>
