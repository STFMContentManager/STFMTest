<%@ Page Language="C#" MasterPageFile="~/Timesheet.master" AutoEventWireup="true" CodeFile="ReportBudget.aspx.cs" Inherits="ReportBudget" Title="Untitled Page" %>
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
				<asp:Table ID="Table2" runat="server">
				<asp:TableRow>
					<asp:TableHeaderCell CssClass="HeaderCenter">
						Project:
					</asp:TableHeaderCell>
				</asp:TableRow>
				<asp:TableRow>
					<asp:TableCell CssClass="FormCenter">
						<asp:DropDownList runat="server" ID="ddlProjects" Width="250px" AutoPostBack="true" OnSelectedIndexChanged="ddlProjects_SelectedIndexChanged" />
					</asp:TableCell>
				</asp:TableRow>
				</asp:Table>
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
		<asp:TableRow>
			<asp:TableCell CssClass="FormCenter" ColumnSpan="2">
				<asp:GridView
					ID="GridTime"
					runat="server"
					AlternatingRowStyle-BackColor="Beige"
					AutoGenerateColumns="false"
					GridLines="None"
					CellPadding="0"
					CellSpacing="1"
					OnRowCommand="GridTime_RowCommand"
					OnRowDataBound="GridTime_RowDataBound"
					OnRowDeleting="GridTime_RowDeleting"
					OnRowDeleted="GridTime_RowDeleted"
					OnRowEditing="GridTime_RowEditing"
					ShowFooter="true"
				>
				<Columns>
					<asp:BoundField
						HeaderStyle-CssClass="HeaderLeft"
						FooterStyle-CssClass="HeaderLeft"
						HeaderText="Task Name"
						DataField="TaskName"
						ReadOnly="true"
						ItemStyle-Width="200px"
						ItemStyle-HorizontalAlign="left"
						FooterStyle-Font-Bold="true"
					/>
					<asp:BoundField
						HeaderStyle-CssClass="HeaderLeft"
						FooterStyle-CssClass="HeaderLeft"
						HeaderText="Job Reference"
						DataField="JobRef"
						ReadOnly="true"
						ItemStyle-Width="200px"
						ItemStyle-HorizontalAlign="left"
						FooterStyle-Font-Bold="true"
					/>
					<asp:TemplateField
						HeaderStyle-CssClass="HeaderRight"
						FooterStyle-CssClass="HeaderRight"
						HeaderText="Budget"
						ItemStyle-Width="60px"
						ItemStyle-HorizontalAlign="right"
						FooterStyle-HorizontalAlign="right"
						FooterStyle-Font-Bold="true"
					>
						<ItemTemplate>
							<asp:Label ID="LblBudget" runat="server" Text='<%# ShowHours(Eval("Budget").ToString()).ToString("N2") %>' />
						</ItemTemplate>
						<FooterTemplate>
							<%# GetTotalBudget().ToString("N2") %>
						</FooterTemplate>
					</asp:TemplateField>
					<asp:TemplateField
						HeaderStyle-CssClass="HeaderRight"
						FooterStyle-CssClass="HeaderRight"
						HeaderText="Actual"
						ItemStyle-Width="60px"
						ItemStyle-HorizontalAlign="right"
						FooterStyle-HorizontalAlign="right"
						FooterStyle-Font-Bold="true"
					>
						<ItemTemplate>
							<asp:Label ID="LblActual" runat="server" Text='<%# ShowHours(Eval("Actual").ToString()).ToString("N2") %>' />
						</ItemTemplate>
						<FooterTemplate>
							<%# GetTotalActual().ToString("N2") %>
						</FooterTemplate>
					</asp:TemplateField>
					<asp:TemplateField
						HeaderStyle-CssClass="HeaderRight"
						FooterStyle-CssClass="HeaderRight"
						HeaderText="Over"
						ItemStyle-Width="60px"
						ItemStyle-HorizontalAlign="right"
						FooterStyle-HorizontalAlign="right"
						FooterStyle-Font-Bold="true"
					>
						<ItemTemplate>
							<asp:Label ID="LblOverspend" runat="server" Text='<%# ShowHours((Convert.ToDouble(Eval("Actual").ToString()) - Convert.ToDouble(Eval("Budget").ToString())).ToString()).ToString("N2") %>' />
						</ItemTemplate>
						<FooterTemplate>
							<%# GetTotalOverspend().ToString("N2") %>
						</FooterTemplate>
					</asp:TemplateField>
				</Columns>
				</asp:GridView>
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow ID="RowError1" Visible="false"><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
		<asp:TableRow ID="RowError2" Visible="false">
			<asp:TableCell CssClass="ErrorMsg" ColumnSpan="2">
				<asp:Label runat="server" ID="LblMsg" Text="LblMsg" />
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
		<asp:TableRow>
			<asp:TableCell ColumnSpan="2" CssClass="FormCenter">
				<asp:Button ID="BtnExportToExcel" runat="server" CssClass="Button" OnClick="BtnExportToExcel_Click" Text="Export To Microsoft Excel" />
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
		<asp:TableRow>
			<asp:TableCell ColumnSpan="2" CssClass="FormCenter">
				<asp:Button ID="BtnExportToCSV" runat="server" CssClass="Button" OnClick="BtnExportToCSV_Click" Text="Export To CSV" />
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
		<asp:TableRow>
			<asp:TableCell ColumnSpan="2" CssClass="FormCenter">
				<asp:Button ID="BtnSubmit" runat="server" OnClick="BtnSubmit_Click" Text="Return To Report Menu" CssClass="Button" />
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
	</asp:Table>
<!-- $Filename: D:\Inetpub\wwwroot\TimeRep\ReportBudget.aspx $   $Revision: 1.1 $ -->
</asp:Content>
