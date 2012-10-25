<%@ Page Language="C#" MasterPageFile="~/Timesheet.master" AutoEventWireup="true" CodeFile="JobMaintenance.aspx.cs" Inherits="JobMaintenance" Title="Untitled Page" %>
<asp:Content ID="Content1" runat="Server" ContentPlaceHolderID="ContentPlaceHolder1">
	<asp:Table ID="MainPage" runat="server" Width="777px">
		<asp:TableRow>
			<asp:TableCell ColumnSpan="2" CssClass="PageHeader">
				<asp:Label ID="LblPageTitle" runat="server" Text="LblPageTitle"></asp:Label>
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
		<asp:TableRow>
			<asp:TableCell CssClass="FormRight" Width="50%">
				Project:
			</asp:TableCell>
			<asp:TableCell CssClass="FormLeft" Width="50%">
				<asp:DropDownList ID="ddlProjects" runat="server" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="ddlProjects_Change" />
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow>
			<asp:TableCell CssClass="FormRight">
				Task:
			</asp:TableCell>
			<asp:TableCell CssClass="FormLeft">
				<asp:DropDownList ID="DdlTasks" runat="server" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="DdlTasks_Change" />
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
		<asp:TableRow>
			<asp:TableHeaderCell CssClass="Header" ColumnSpan="2">
				Job Definition
			</asp:TableHeaderCell>
		</asp:TableRow>
		<asp:TableRow>
			<asp:TableCell CssClass="TimeEntry" ColumnSpan="2">
				<asp:Table runat="server">
				<asp:TableRow>
					<asp:TableCell CssClass="HeaderLeft">
						Job Reference
					</asp:TableCell>
					<asp:TableCell CssClass="HeaderLeft">
						Description
					</asp:TableCell>
					<asp:TableCell CssClass="HeaderLeft">
						Budget Hours
					</asp:TableCell>
					<asp:TableCell CssClass="HeaderCenter">
						Active?
					</asp:TableCell>
					<asp:TableCell CssClass="HeaderCenter">
						&nbsp;
					</asp:TableCell>
				</asp:TableRow>
				<asp:TableRow>
					<asp:TableCell CssClass="FormLeft">
						<asp:TextBox runat="server" ID="TxtJobRef" Width="150px" />
					</asp:TableCell>
					<asp:TableCell CssClass="FormLeft">
						<asp:TextBox runat="server" ID="TxtDescription" Width="250px" />
					</asp:TableCell>
					<asp:TableCell CssClass="FormLeft">
						<asp:TextBox runat="server" ID="TxtBudgetHours" Width="80px" />
					</asp:TableCell>
					<asp:TableCell CssClass="FormCenter">
						<asp:CheckBox runat="server" ID="ChkActive" />
					</asp:TableCell>
					<asp:TableCell CssClass="FormCenter">
						<asp:Button runat="server" ID="BtnSubmit" CssClass="Button" Width="100px" Text="Submit" OnClick="BtnSubmit_Click" />
					</asp:TableCell>
				</asp:TableRow>
				<asp:TableRow ID="RowTimeError" Visible="false">
					<asp:TableCell CssClass="FormCenter" ColumnSpan="7">
						<asp:Label runat="server" ID="LblTimeError" Text="LblTimeError" CssClass="ErrorMsg" Width="100%" />
					</asp:TableCell>
				</asp:TableRow>
				</asp:Table>
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
		<asp:TableRow>
			<asp:TableHeaderCell CssClass="Header" ColumnSpan="2">
				Job List
			</asp:TableHeaderCell>
		</asp:TableRow>
		<asp:TableRow>
			<asp:TableCell CssClass="FormCenter" ColumnSpan="2" BackColor="lightblue" BorderColor="black" BorderStyle="solid" BorderWidth="1" Width="777px">
				<asp:GridView
					ID="GridJob"
					runat="server"
					AlternatingRowStyle-BackColor="DarkCyan"
					AutoGenerateColumns="false"
					GridLines="None"
					CellPadding="0"
					CellSpacing="1"
					OnRowCommand="GridJob_RowCommand"
					OnRowDataBound="GridJob_RowDataBound"
					OnRowDeleting="GridJob_RowDeleting"
					OnRowDeleted="GridJob_RowDeleted"
					OnRowEditing="GridJob_RowEditing"
					DataKeyNames="JobId"
					ShowFooter="false"
					AllowPaging="true"
					PagerSettings-Mode="NumericFirstLast"
					PageSize="50"
					OnPageIndexChanging="GridJob_PageIndexChanging"
				>
				<Columns>
					<asp:TemplateField
						HeaderText="Edit"
						HeaderStyle-CssClass="HeaderCenter"
						FooterStyle-CssClass="HeaderLeft"
					>
						<ItemStyle Width="50px" HorizontalAlign="center" />
						<ItemTemplate>
							<asp:ImageButton
								ID="ImgEdit"
								runat="server"
								ImageUrl="~/Images/Edit.gif"
								CommandArgument='<%# Eval("JobId").ToString() %>'
								CommandName="Edit"
								ToolTip='<%# "Edit #" + Eval("JobRef").ToString() %>'
							/>
						</ItemTemplate>
					</asp:TemplateField>
					<asp:BoundField
						HeaderStyle-CssClass="HeaderLeft"
						FooterStyle-CssClass="HeaderLeft"
						HeaderText="Job Ref"
						DataField="JobRef"
						ReadOnly="true"
						ItemStyle-Width="150px"
						ItemStyle-HorizontalAlign="left"
					/>
					<asp:BoundField
						HeaderStyle-CssClass="HeaderLeft"
						FooterStyle-CssClass="HeaderLeft"
						HeaderText="Description"
						DataField="Description"
						ReadOnly="true"
						ItemStyle-Width="350px"
						ItemStyle-HorizontalAlign="left"
					/>
					<asp:BoundField
						HeaderStyle-CssClass="HeaderRight"
						FooterStyle-CssClass="HeaderRight"
						HeaderText="Budget"
						DataField="BudgetHours"
						DataFormatString="{0:f2}"
						HtmlEncode="false"
						ReadOnly="true"
						ItemStyle-Width="60px"
						ItemStyle-HorizontalAlign="right"
					/>
					<asp:BoundField
						HeaderStyle-CssClass="HeaderRight"
						FooterStyle-CssClass="HeaderRight"
						HeaderText="Booked"
						DataField="BookedHours"
						DataFormatString="{0:f2}"
						HtmlEncode="false"
						ReadOnly="true"
						ItemStyle-Width="60px"
						ItemStyle-HorizontalAlign="right"
					/>
					<asp:TemplateField
						HeaderText="Active?"
						HeaderStyle-CssClass="HeaderCenter"
						FooterStyle-CssClass="HeaderCenter"
						ItemStyle-Width="60px"
						ItemStyle-HorizontalAlign="Center"
					>
					<ItemTemplate>
						<asp:CheckBox runat="server" ID="ChkActive" Checked='<%# Bind("Active") %>' />
						<asp:Label runat="server" ID="LblJobId" Text=<%# Bind("JobId") %> Visible="false" />
					</ItemTemplate>
					</asp:TemplateField>
					<asp:TemplateField
						HeaderStyle-CssClass="HeaderCenter"
						HeaderText="Del"
					>
						<ItemStyle Width="50px" HorizontalAlign="center" />
						<ItemTemplate>
							<asp:ImageButton
								ID="ImgTrash"
								runat="server"
								ImageUrl="~/Images/Trash.gif"
								CommandArgument='<%# Eval("JobId") %>'
								CommandName="Delete"
								ToolTip='<%# "Delete #" + Eval("JobRef").ToString() %>'
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
				<asp:Button ID="BtnReturn" runat="server" OnClick="BtnReturn_Click" Text="Return" CssClass="Button" />
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
	</asp:Table>
<!-- $Filename: D:\Inetpub\wwwroot\TimeRep\JobMaintenance.aspx $   $Revision: 1.2 $ -->
</asp:Content>
