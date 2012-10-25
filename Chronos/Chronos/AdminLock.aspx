<%@ Page Language="C#" MasterPageFile="~/Timesheet.master" AutoEventWireup="true" CodeFile="AdminLock.aspx.cs" Inherits="AdminLock" Title="Untitled Page" %>
<%@ Register TagPrefix="kaz" TagName="DateSelector" Src="~/Controls/DateSelector.ascx" %>
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
			<asp:TableCell CssClass="FormCenter" ColumnSpan="2">
				<asp:GridView
					runat="server"
					ID="GridUsers"
					DataKeyNames="UserId"
					AlternatingRowStyle-BackColor="Beige"
					AutoGenerateColumns="false"
					GridLines="both"
					CellPadding="0"
					CellSpacing="1"
					ShowFooter="false"
					AllowPaging="false"
					OnRowCommand="GridUsers_RowCommand"
					OnRowDataBound="GridUsers_RowDataBound"
					OnRowDeleting="GridUsers_RowDeleting"
					OnRowDeleted="GridUsers_RowDeleted"
					OnRowEditing="GridUsers_RowEditing"
				>
				<Columns>
					<asp:TemplateField Visible="false">
						<ItemTemplate>
							<asp:Label runat="server" ID="LblUserId" Text='<%# Eval("UserId").ToString() %>' />
						</ItemTemplate>
					</asp:TemplateField>
					<asp:BoundField
						HeaderStyle-CssClass="HeaderLeft"
						HeaderText="User Name"
						DataField="UserName"
						ReadOnly="true"
						ItemStyle-Width="150px"
						ItemStyle-HorizontalAlign="left"
					/>
					<asp:BoundField
						HeaderStyle-CssClass="HeaderLeft"
						HeaderText="Surname"
						DataField="Surname"
						ReadOnly="true"
						ItemStyle-Width="150px"
						ItemStyle-HorizontalAlign="left"
					/>
					<asp:BoundField
						HeaderStyle-CssClass="HeaderLeft"
						HeaderText="Forename"
						DataField="Forename"
						ReadOnly="true"
						ItemStyle-Width="150px"
						ItemStyle-HorizontalAlign="left"
					/>
					<asp:TemplateField
						HeaderText="Lock?"
						HeaderStyle-CssClass="HeaderCenter"
					>
						<ItemStyle Width="50px" HorizontalAlign="center" />
						<ItemTemplate>
							<asp:CheckBox
								runat="server"
								ID="ChkLock"
								Checked="true"
							/>
						</ItemTemplate>
					</asp:TemplateField>
				</Columns>
				</asp:GridView>
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
		<asp:TableRow>
			<asp:TableCell ColumnSpan="2" CssClass="FormCenter">
				<asp:Button ID="BtnLock" runat="server" CssClass="Button" OnClick="BtnLock_Click" Text="Lock Timesheets" />
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
		<asp:TableRow>
			<asp:TableCell ColumnSpan="2" CssClass="FormCenter">
				<asp:Button ID="BtnUnlock" runat="server" CssClass="Button" OnClick="BtnUnlock_Click" Text="Unlock Timesheets" />
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
		<asp:TableRow>
			<asp:TableCell ColumnSpan="2" CssClass="FormCenter">
				<asp:Button ID="BtnAdminMenu" runat="server" CssClass="Button" OnClick="BtnAdminMenu_Click" Text="Return To Admin Menu" />
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
	</asp:Table>
<!-- $Filename: D:\Inetpub\wwwroot\TimeRep\AdminLock.aspx $   $Revision: 1.1 $ -->
</asp:Content>
