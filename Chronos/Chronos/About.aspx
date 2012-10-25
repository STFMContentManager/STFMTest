<%@ Page Language="C#" MasterPageFile="~/Timesheet.master" AutoEventWireup="true" CodeFile="About.aspx.cs" Inherits="About" Title="Untitled Page" %>

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
				<asp:Table ID="Table1" runat="server" Width="777px">
				<asp:TableRow>
					<asp:TableCell Width="10%">&nbsp;</asp:TableCell>
					<asp:TableCell CssClass="FormLeft">
						The TimeRep application was developed by KazMax Ltd. KazMax are delighted to
						offer thanks to the following people and organisations for their help in making
						this application possible.
						<p>
							Authors Web Site: <asp:HyperLink ID="LnkKazMax" runat="server" Target="_blank"
							Text="KazMax Ltd" NavigateUrl="http://www.kazmax.co.uk" />
						</p>
					</asp:TableCell>
					<asp:TableCell Width="10%">&nbsp;</asp:TableCell>
				</asp:TableRow>
				</asp:Table>
			</asp:TableCell>
		</asp:TableRow>
		
		<asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
		<asp:TableRow>
			<asp:TableCell CssClass="FormCenter" ColumnSpan="2">
				<asp:Table ID="Table4" runat="server" Width="777px">
				<asp:TableHeaderRow>
					<asp:TableHeaderCell Width="10%">&nbsp;</asp:TableHeaderCell>
					<asp:TableHeaderCell CssClass="HeaderLeft">
						Voluntary Contribution
					</asp:TableHeaderCell>
					<asp:TableHeaderCell Width="10%">&nbsp;</asp:TableHeaderCell>
				</asp:TableHeaderRow>
				<asp:TableRow>
					<asp:TableCell>&nbsp;</asp:TableCell>
					<asp:TableCell CssClass="FormLeft">
						<asp:Table ID="Table5" runat="server">
						<asp:TableRow>
							<asp:TableCell CssClass="FormCenter">
								<asp:ImageButton ID="BtnPayPal" runat="server" ImageUrl="~/Images/PayPal.gif" OnClick="BtnPayPal_Click" />
							</asp:TableCell>
						</asp:TableRow>
						<asp:TableRow>
							<asp:TableCell CssClass="FormLeft">
								You can help keep TimeRep updated and available by making a <b>voluntary
								contribution</b> of any amount you feel would be appropriate. By
								receiving voluntary donations I know that people are finding this
								application useful, and it will encourage me to keep responding to
								issues that real users are experiencing and/or requesting.
								<p>
								This application is released via the <a href="http://www.gnu.org/copyleft/gpl.html" target="_blank">GNU General Public License</a>.
								</p>
							</asp:TableCell>
						</asp:TableRow>
						</asp:Table>
					</asp:TableCell>
					<asp:TableCell>&nbsp;</asp:TableCell>
				</asp:TableRow>
				</asp:Table>
			</asp:TableCell>
		</asp:TableRow>
		
		<asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
		<asp:TableRow>
			<asp:TableCell CssClass="FormCenter" ColumnSpan="2">
				<asp:Table ID="Table6" runat="server" Width="777px">
				<asp:TableHeaderRow>
					<asp:TableHeaderCell Width="10%">&nbsp;</asp:TableHeaderCell>
					<asp:TableHeaderCell CssClass="HeaderLeft">
						Dan Wahlin
					</asp:TableHeaderCell>
					<asp:TableHeaderCell Width="10%">&nbsp;</asp:TableHeaderCell>
				</asp:TableHeaderRow>
				<asp:TableRow>
					<asp:TableCell>&nbsp;</asp:TableCell>
					<asp:TableCell CssClass="FormLeft">
						<asp:Table ID="Table7" runat="server">
						<asp:TableRow>
							<asp:TableCell CssClass="FormCenter">
								<asp:HyperLink
									runat="server"
									ID="HyperLink7"
									ImageUrl="~/Images/InterfaceTechnicalTraining.gif"
									ToolTip="Vbcity.com"
									NavigateUrl="http://blogs.interfacett.com/dan-wahlins-blog/2007/1/18/video-creating-custom-events-and-delegates-with-c.html"
									Target="_blank"
									BorderColor="black"
									BorderStyle="solid"
									BorderWidth="1"
								/>
							</asp:TableCell>
						</asp:TableRow>
						<asp:TableRow>
							<asp:TableCell CssClass="FormLeft">
								<asp:HyperLink ID="HyperLink8" runat="server" Text="Dan Wahlin" NavigateUrl="http://blogs.interfacett.com/dan-wahlins-blog/" Target="_blank" />
								is a trainer with Interface Technical Training based in Phoenix, Arizona. Dan has a series of outstanding
								videos available on his web site which were of great assistance whilst developing this application.
							</asp:TableCell>
						</asp:TableRow>
						</asp:Table>
					</asp:TableCell>
					<asp:TableCell>&nbsp;</asp:TableCell>
				</asp:TableRow>
				</asp:Table>
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
		<asp:TableRow>
			<asp:TableCell CssClass="FormCenter" ColumnSpan="2">
				<asp:Table ID="Table2" runat="server" Width="777px">
				<asp:TableHeaderRow>
					<asp:TableHeaderCell Width="10%">&nbsp;</asp:TableHeaderCell>
					<asp:TableHeaderCell CssClass="HeaderLeft">
						ZedChart
					</asp:TableHeaderCell>
					<asp:TableHeaderCell Width="10%">&nbsp;</asp:TableHeaderCell>
				</asp:TableHeaderRow>
				<asp:TableRow>
					<asp:TableCell>&nbsp;</asp:TableCell>
					<asp:TableCell CssClass="FormLeft">
						<asp:Table ID="Table3" runat="server">
						<asp:TableRow>
							<asp:TableCell CssClass="FormCenter">
								<asp:HyperLink
									runat="server"
									ID="HyperLink1"
									ImageUrl="~/Images/ZedGraph.gif"
									ToolTip="Vbcity.com"
									NavigateUrl="http://sourceforge.net/projects/zedgraph/"
									Target="_blank"
									BorderColor="black"
									BorderStyle="solid"
									BorderWidth="1"
								/>
							</asp:TableCell>
						</asp:TableRow>
						<asp:TableRow>
							<asp:TableCell CssClass="FormLeft">
								<asp:HyperLink ID="HyperLink2" runat="server" Text="ZedChart" NavigateUrl="http://sourceforge.net/projects/zedgraph/" Target="_blank" />
								is a class library, user control and web control for .net, written in C# for drawing
								2D line, bar and pie charts. It features full detailed customisation capabilities.
							</asp:TableCell>
						</asp:TableRow>
						</asp:Table>
					</asp:TableCell>
					<asp:TableCell>&nbsp;</asp:TableCell>
				</asp:TableRow>
				</asp:Table>
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
		<asp:TableRow>
			<asp:TableCell CssClass="FormCenter" ColumnSpan="2">
				<asp:Table ID="Table8" runat="server" Width="777px">
				<asp:TableHeaderRow>
					<asp:TableHeaderCell Width="10%">&nbsp;</asp:TableHeaderCell>
					<asp:TableHeaderCell CssClass="HeaderLeft">
						Rama Krishna Kolluri
					</asp:TableHeaderCell>
					<asp:TableHeaderCell Width="10%">&nbsp;</asp:TableHeaderCell>
				</asp:TableHeaderRow>
				<asp:TableRow>
					<asp:TableCell>&nbsp;</asp:TableCell>
					<asp:TableCell CssClass="FormLeft">
						<asp:Table ID="Table9" runat="server">
						<asp:TableRow>
							<asp:TableCell CssClass="FormCenter">
								<asp:HyperLink
									runat="server"
									ID="HyperLink9"
									ImageUrl="~/Images/CodeProject.gif"
									ToolTip="Rama Krishna Kolluri"
									NavigateUrl="http://www.codeproject.com/aspnet/ExportClassLibrary.asp"
									Target="_blank"
									BorderColor="black"
									BorderStyle="solid"
									BorderWidth="1"
								/>
							</asp:TableCell>
						</asp:TableRow>
						<asp:TableRow>
							<asp:TableCell CssClass="FormLeft">
								<asp:HyperLink ID="HyperLink10" runat="server" Text="Rama Krishna Kolluri" NavigateUrl="http://www.codeproject.com/aspnet/ExportClassLibrary.asp" Target="_blank" />
								is the author of the RKLib.ExportData.dll component which is used for exporting
								data to Microsoft Excel or CSV (comma separated variable) files, via the reports
								page. Full details of how to use this library are provided at
								<asp:HyperLink ID="HyperLink11" runat="server" Text="The Code Project" NavigateUrl="http://www.codeproject.com/aspnet/ExportClassLibrary.asp" Target="_blank" />.
							</asp:TableCell>
						</asp:TableRow>
						</asp:Table>
					</asp:TableCell>
					<asp:TableCell>&nbsp;</asp:TableCell>
				</asp:TableRow>
				</asp:Table>
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
		<asp:TableRow>
			<asp:TableCell CssClass="FormCenter" ColumnSpan="2">
				<asp:Label runat="server" ID="LblVersion" Text="LblVersion" />
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
		<asp:TableRow>
			<asp:TableCell ColumnSpan="2">
				<asp:Button ID="BtnMainMenu" runat="server" CssClass="Button" OnClick="BtnMainMenu_Click" Text="Return" />
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
	</asp:Table>
<!-- $Filename: D:\Inetpub\wwwroot\TimeRep\About.aspx $   $Revision: 1.5 $ -->
</asp:Content>
