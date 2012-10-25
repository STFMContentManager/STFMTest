<%@ Page Language="C#" MasterPageFile="~/Timesheet.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" Title="Untitled Page" %>
<asp:Content ID="Content1" runat="Server" ContentPlaceHolderID="ContentPlaceHolder1">
	<asp:Table ID="MainPage" runat="server" Width="777px">
        <asp:TableRow>
         <asp:TableCell ColumnSpan="2">
          <asp:Image runat="server" ID="imgChronos" ImageUrl="~/Images/Chronos.jpg" />
         </asp:TableCell>
        </asp:TableRow>
		<asp:TableRow>
			<asp:TableCell ColumnSpan="2" CssClass="PageHeader">
				<asp:Label ID="LblPageTitle" runat="server" Text="LblPageTitle" />
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
		<asp:TableRow>
			<asp:TableCell CssClass="FormCenter" Width="350px">
				<asp:Table runat="server" Width="350px">
					<asp:TableRow>
						<asp:TableCell CssClass="FormCenter">
							<b><asp:Label runat="server" ID="LblCompanyName" Text="LblCompanyName" /></b>
						</asp:TableCell>
					</asp:TableRow>
					<asp:TableRow ID="RowConfig1"><asp:TableCell>&nbsp;</asp:TableCell></asp:TableRow>
					<asp:TableRow ID="RowConfig2">
						<asp:TableCell CssClass="FormCenter">
							<asp:Button runat="server" ID="BtnConfig" CssClass="Button" Text="Configuration" OnClick="BtnConfig_Click" />
						</asp:TableCell>
					</asp:TableRow>
					<asp:TableRow ID="RowAdmin1"><asp:TableCell>&nbsp;</asp:TableCell></asp:TableRow>
					<asp:TableRow ID="RowAdmin2">
						<asp:TableCell CssClass="FormCenter">
							<asp:Button runat="server" ID="BtnAdminMenu" CssClass="Button" Text="Administration" OnClick="BtnAdmin_Click" />
						</asp:TableCell>
					</asp:TableRow>
					<asp:TableRow ID="RowTime1"><asp:TableCell>&nbsp;</asp:TableCell></asp:TableRow>
					<asp:TableRow ID="RowTime2">
						<asp:TableCell CssClass="FormCenter">
							<asp:Button runat="server" ID="BtnTime" CssClass="Button" Text="Enter Timesheet" OnClick="BtnTime_Click" />
						</asp:TableCell>
					</asp:TableRow>
					<asp:TableRow ID="RowReports1"><asp:TableCell>&nbsp;</asp:TableCell></asp:TableRow>
					<asp:TableRow ID="RowReports2">
						<asp:TableCell CssClass="FormCenter">
							<asp:Button runat="server" ID="BtnReports" CssClass="Button" Text="Reports" OnClick="BtnReports_Click" />
						</asp:TableCell>
					</asp:TableRow>
					<asp:TableRow ID="RowUserAdmin1"><asp:TableCell>&nbsp;</asp:TableCell></asp:TableRow>
					<asp:TableRow ID="RowUserAdmin2">
						<asp:TableCell CssClass="FormCenter">
							<asp:Button runat="server" ID="BtnUserAdmin" CssClass="Button" Text="User Administration" OnClick="BtnUserAdmin_Click" />
						</asp:TableCell>
					</asp:TableRow>
					<asp:TableRow><asp:TableCell>&nbsp;</asp:TableCell></asp:TableRow>
					<asp:TableRow>
						<asp:TableCell CssClass="FormCenter">
							<asp:Button runat="server" ID="BtnContact" CssClass="Button" Text="Message To Administrator" OnClick="BtnContact_Click" />
						</asp:TableCell>
					</asp:TableRow>
					<asp:TableRow><asp:TableCell>&nbsp;</asp:TableCell></asp:TableRow>
					<asp:TableRow>
						<asp:TableCell CssClass="FormCenter">
							<asp:Button runat="server" ID="BtnLogoff" CssClass="Button" Text="Log Off" OnClick="BtnLogoff_Click" />
						</asp:TableCell>
					</asp:TableRow>
				</asp:Table>
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
		<asp:TableRow>
			<asp:TableCell CssClass="FormCenter" ColumnSpan="2">
				<asp:Label runat="server" Visible="false" ID="LblVersion" Text="LblVersion" />
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
	</asp:Table>
<!-- $Filename: D:\Inetpub\wwwroot\TimeRep\Default.aspx $   $Revision: 1.4 $ -->
</asp:Content>
