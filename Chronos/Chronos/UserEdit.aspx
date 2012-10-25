<%@ Page Language="C#" MasterPageFile="~/Timesheet.master" AutoEventWireup="true" CodeFile="UserEdit.aspx.cs" Inherits="UserEdit" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<asp:Table ID="MainPage" runat="server" Width="777px">
		<asp:TableRow>
			<asp:TableCell ColumnSpan="3" CssClass="PageHeader">
				<asp:Label ID="LblPageTitle" runat="server" Text="LblPageTitle"></asp:Label>
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow><asp:TableCell ColumnSpan="3">&nbsp;</asp:TableCell></asp:TableRow>
		<asp:TableRow>
			<asp:TableCell CssClass="FormRight" Width="20%">
				Logon name:
			</asp:TableCell>
			<asp:TableCell CssClass="FormLeft" Width="47%">
				<asp:TextBox runat="server" ID="TxtUserName" TabIndex="1" Width="280px" />
			</asp:TableCell>
			<asp:TableCell CssClass="FormCenter" Width="33%" RowSpan="10" VerticalAlign="top">
				<asp:Table runat="server" Width="33%">
				<asp:TableRow>
					<asp:TableHeaderCell CssClass="Header" Width="280px">
						Assigned Projects
					</asp:TableHeaderCell>
				</asp:TableRow>
				<asp:TableRow>
					<asp:TableCell CssClass="FormLeft">
						<asp:CheckBoxList ID="ClstProjects" runat="server" Width="280px" BorderColor="black" BorderStyle="solid" BorderWidth="1" />
					</asp:TableCell>
				</asp:TableRow>
				</asp:Table>
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow>
			<asp:TableCell CssClass="FormRight" Width="50%">
				Password:
			</asp:TableCell>
			<asp:TableCell CssClass="FormLeft" Width="50%">
				<asp:TextBox ID="TxtPassword" runat="server" TabIndex="2" Width="280px" />
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
		<asp:TableRow>
			<asp:TableCell CssClass="FormRight" Width="50%">
				Team:
			</asp:TableCell>
			<asp:TableCell CssClass="FormLeft" Width="50%">
				<asp:DropDownList ID="DdlTeam" runat="server" TabIndex="3" Width="285px" />
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow>
			<asp:TableCell CssClass="FormRight" Width="50%">
				User group:
			</asp:TableCell>
			<asp:TableCell CssClass="FormLeft" Width="50%">
				<asp:DropDownList ID="DdlUserGroup" runat="server" TabIndex="4" Width="285px" />
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
		<asp:TableRow>
			<asp:TableCell CssClass="FormRight" Width="50%">
				Surname:
			</asp:TableCell>
			<asp:TableCell CssClass="FormLeft" Width="50%">
				<asp:TextBox ID="TxtSurname" runat="server" TabIndex="5" Width="280px" />
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow>
			<asp:TableCell CssClass="FormRight" Width="50%">
				Forename:
			</asp:TableCell>
			<asp:TableCell CssClass="FormLeft" Width="50%">
				<asp:TextBox ID="TxtForename" runat="server" TabIndex="6" Width="280px" />
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
		<asp:TableRow>
			<asp:TableCell CssClass="FormRight" Width="50%">
				Email address:
			</asp:TableCell>
			<asp:TableCell CssClass="FormLeft" Width="50%">
				<asp:TextBox ID="TxtEmailAddress" runat="server" TabIndex="7" Width="280px" />
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
		<asp:TableRow>
			<asp:TableCell CssClass="FormRight" Width="50%">
				Hourly rate:
			</asp:TableCell>
			<asp:TableCell CssClass="FormLeft" Width="50%">
				<asp:TextBox ID="TxtHourlyRate" runat="server" TabIndex="8" Width="280px" />
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow><asp:TableCell ColumnSpan="3">&nbsp;</asp:TableCell></asp:TableRow>
		<asp:TableRow>
			<asp:TableCell CssClass="FormCenter" ColumnSpan="3">
				<asp:Button runat="server" ID="BtnSubmit" Text="Submit" OnClick="BtnSubmit_Click" CssClass="Button" />
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow><asp:TableCell ColumnSpan="3">&nbsp;</asp:TableCell></asp:TableRow>
		<asp:TableRow>
			<asp:TableCell ColumnSpan="3" CssClass="FormCenter">
				<asp:Button ID="BtnCancel" runat="server" Text="Cancel" OnClick="BtnCancel_Click" CssClass="Button" />
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
	</asp:Table>
<!-- $Filename: D:\Inetpub\wwwroot\TimeRep\UserEdit.aspx $   $Revision: 1.2 $ -->
</asp:Content>
