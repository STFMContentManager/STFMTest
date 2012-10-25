<%@ Page Language="C#" MasterPageFile="~/Timesheet.master" AutoEventWireup="true" CodeFile="ReportCostCentre.aspx.cs" Inherits="ReportCostCentre" Title="Untitled Page" %>
<%@ Register Src="~/Controls/DateSelector.ascx" TagName="DateSelector" TagPrefix="kaz" %>
<asp:Content ID="Content1" runat="Server" ContentPlaceHolderID="ContentPlaceHolder1">
	<asp:Table ID="MainPage" runat="server" Width="777px">
		<asp:TableRow><asp:TableCell ColumnSpan="2" CssClass="PageHeader">
				<asp:Label ID="LblPageTitle" runat="server" Text="LblPageTitle"></asp:Label>
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
		<asp:TableRow>
			<asp:TableCell ColumnSpan="2" CssClass="DateSelection">
				<kaz:DateSelector ID="cc2DateSelector" runat="server" EnableViewState="true" />
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
		<asp:TableRow>
			<asp:TableCell CssClass="FormRight" Width="50%">
				Report from:
			</asp:TableCell>
			<asp:TableCell CssClass="FormLeft" Width="50%">
				<b><asp:Label ID="LblFrom" runat="server" Text="LblFrom" /></b>
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow>
			<asp:TableCell CssClass="FormRight">
				Report to:
			</asp:TableCell>
			<asp:TableCell CssClass="FormLeft">
				<b><asp:Label ID="LblTo" runat="server" Text="LblTo" /></b>
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow>
			<asp:TableCell CssClass="FormRight" Width="50%">
				Productive hours:
			</asp:TableCell>
			<asp:TableCell CssClass="FormLeft" Width="50%">
				<b><asp:Label ID="LblProductive" runat="server" Text="LblProductive" /></b>
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow>
			<asp:TableCell CssClass="FormRight">
				Unproductive hours:
			</asp:TableCell>
			<asp:TableCell CssClass="FormLeft">
				<b><asp:Label ID="LblUnproductive" runat="server" Text="LblUnproductive" /></b>
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow>
			<asp:TableCell CssClass="FormRight">
				Productive percentage:
			</asp:TableCell>
			<asp:TableCell CssClass="FormLeft">
				<b><asp:Label ID="LblProductivePercent" runat="server" Text="LblProductivePercent" /></b>
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
		<asp:TableRow>
			<asp:TableCell ColumnSpan="2" CssClass="FormCenter">
				<asp:GridView ID="GridTime" runat="server" AlternatingRowStyle-BackColor="Beige" AutoGenerateColumns="false" CellPadding="0" CellSpacing="1" GridLines="None" OnRowCommand="GridTime_RowCommand" OnRowDataBound="GridTime_RowDataBound" OnRowDeleted="GridTime_RowDeleted" OnRowDeleting="GridTime_RowDeleting" OnRowEditing="GridTime_RowEditing" ShowFooter="true">
					<Columns>
						<asp:BoundField
							DataField="CostCentre"
							FooterStyle-CssClass="HeaderLeft"
							FooterStyle-Font-Bold="true"
							HeaderStyle-CssClass="HeaderLeft"
							HeaderText="Cost"
							ItemStyle-HorizontalAlign="left"
							ItemStyle-Width="200px"
							ReadOnly="true"
						/>
						<asp:BoundField
							DataField="IsProductive"
							FooterStyle-CssClass="HeaderCenter"
							FooterStyle-Font-Bold="true"
							HeaderStyle-CssClass="HeaderCenter"
							HeaderText="Productive?"
							ItemStyle-HorizontalAlign="center"
							ItemStyle-Width="100px"
							ReadOnly="true"
						/>
						<asp:TemplateField
							FooterStyle-CssClass="HeaderRight"
							FooterStyle-Font-Bold="true"
							FooterStyle-HorizontalAlign="right"
							HeaderStyle-CssClass="HeaderRight"
							HeaderText="Hours"
							ItemStyle-HorizontalAlign="right"
							ItemStyle-Width="60px"
							>
							<ItemTemplate>
								<asp:Label ID="LblHours" runat="server" Text='<%# ShowHours(Eval("Hours").ToString()).ToString("N2") %>' />
							</ItemTemplate>
							<FooterTemplate>
								<%# ShowTotalHours().ToString("N2") %>
							</FooterTemplate>
						</asp:TemplateField>
						<asp:TemplateField
							FooterStyle-CssClass="HeaderRight"
							FooterStyle-Font-Bold="true"
							FooterStyle-HorizontalAlign="right"
							HeaderStyle-CssClass="HeaderRight"
							HeaderText="%age"
							ItemStyle-HorizontalAlign="right"
							ItemStyle-Width="60px"
							>
							<ItemTemplate>
								<asp:Label ID="LblPercent" runat="server" Text='<%# ShowHours(Eval("PercentHours").ToString()).ToString("N2") %>' />
							</ItemTemplate>
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
				<asp:Button ID="BtnExcel" runat="server" CssClass="Button" OnClick="BtnToExcel_Click" Text="Export To Microsoft Excel" />
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
		<asp:TableRow>
			<asp:TableCell ColumnSpan="2" CssClass="FormCenter">
				<asp:Button ID="BtnCSV" runat="server" CssClass="Button" OnClick="BtnToCSV_Click" Text="Export To CSV" />
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
<!-- $Filename: D:\Inetpub\wwwroot\TimeRep\ReportCostCentre.aspx $ -->
</asp:Content>
