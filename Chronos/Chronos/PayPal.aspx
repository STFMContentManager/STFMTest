<%@ Page Language="C#" MasterPageFile="~/PayPal.master" AutoEventWireup="true" CodeFile="PayPal.aspx.cs" Inherits="PayPal" Title="Untitled Page" %>
<asp:Content ID="Content1" runat="Server" ContentPlaceHolderID="ContentPlaceHolder1">
	<asp:Table ID="MainPage" runat="server" Width="777px">
	<asp:TableRow>
		<asp:TableCell ColumnSpan="2" CssClass="PageHeader">
			<asp:Label ID="LblPageTitle" runat="server" Text="LblPageTitle"></asp:Label>
		</asp:TableCell>
	</asp:TableRow>
	<asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
	<asp:TableRow>
		<asp:TableCell CssClass="FormCenter" Width="50%">
			<input type="hidden" name="cmd" value="_s-xclick" />
			<input type="image" src="https://www.paypal.com/en_US/i/btn/x-click-but6.gif" border="0" name="submit" alt="Make payments with PayPal - it's fast, free and secure!" />
			<img alt="" border="0" src="https://www.paypal.com/en_GB/i/scr/pixel.gif" width="1" height="1" />
			<input type="hidden" name="encrypted" value="-----BEGIN PKCS7-----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-----END PKCS7-----" />
		</asp:TableCell>
		<asp:TableCell CssClass="FormCenter" Width="50%">
			<a href="http://www.gnu.org/copyleft/gpl.html" target="_blank"><img style="border-color:White;" src="Images/GNU.png" alt="GNU - Free Software Foundation" /></a><br />GNU
		</asp:TableCell>
	</asp:TableRow>
	<asp:TableRow>
		<asp:TableCell ColumnSpan="2" CssClass="FormLeft">
			The TimeRep web application is released under the <a href="http://www.gnu.org/copyleft/gpl.html">GNU
			General Public License</a>, and is provided free of charge and may be used without obligation.
			<p>
			However, if I am to be encouraged to continue working on TimeRep then vountary contributions from
			users will help to ensure that I continue to enhance and support this application. Like all
			development effort, there are costs involved which I have to meet and I could just as easily spend
			my time (and money!) elsewhere.
			</p>
			<p>
			Click on the button above to access the PayPal system where you can make a voluntary contribution.
			There is no set fee. You do not need a PayPal account to make a donation - please see the instructions
			given on the PayPal web site.
			</p>
		</asp:TableCell>
	</asp:TableRow>
	<asp:TableRow>
		<asp:TableHeaderCell ColumnSpan="2" CssClass="ParagraphHeader">
			Value Added Tax (VAT)
		</asp:TableHeaderCell>
	</asp:TableRow>
	<asp:TableRow>
		<asp:TableCell ColumnSpan="2" CssClass="FormLeft">
			KazMax Ltd are registered for the collection of VAT (reg no GB689475070) which is charged at the
			prevailing rate as determined by the UK government. <b>All</b> contributions made via PayPal (or any
			other means) will be subject to VAT being applied as per my standard accounting procedures.
			<p>
			You do not need to do anything with respect to VAT being applied, I simply take the amount contributed
			and apply the necessary calculation to ensure that I pay the right amount of VAT to the authorities.
			As an example, if the VAT rate was 17.5% and you paid $100 then the VAT which was passed on to
			government would be calculated as 100 - (100 / 1.175) = $14.89. In other words, for the $100 you paid
			I get $85.10 and government get $14.89. <i>Figures shown are indicative only!</i>
			</p>
			<p>
			If you require a VAT invoice please let me know and I will provide. To save cost I won't send these
			invoices automatically.
			</p>
		</asp:TableCell>
	</asp:TableRow>
	<asp:TableRow>
		<asp:TableHeaderCell ColumnSpan="2" CssClass="ParagraphHeader">
			VAT Exclusion
		</asp:TableHeaderCell>
	</asp:TableRow>
	<asp:TableRow>
		<asp:TableCell ColumnSpan="2" CssClass="FormLeft">
			If you are a VAT registered company or otherwise permitted to purchase goods which have no VAT
			applied <a href="Contact.aspx">please let me know</a>. You will most probably want to be provided
			with an invoice which shows that no VAT was applied.
			<p>
			However please don't request a VAT-free payment unless you are permitted to do so under VAT rules.
			I can't (aka "I won't") bend the VAT rules under any circumstance whatsoever. If you aren't sure
			about this topic please refer to your accountant for advice - I cannot provide you with advice
			relating to VAT matters.
			</p>
		</asp:TableCell>
	</asp:TableRow>
	<asp:TableRow>
		<asp:TableHeaderCell ColumnSpan="2" CssClass="ParagraphHeader">
			Hosting Of TimeRep
		</asp:TableHeaderCell>
	</asp:TableRow>
	<asp:TableRow>
		<asp:TableCell ColumnSpan="2" CssClass="FormLeft">
			If you want I can arrange to host the TimeRep application for your company on an Internet web
			site. Charges will apply for this service being provided, and those charges have no relationship
			to any voluntary contribution you might make.
			<p>
			I cannot give you a standard figure for hosting TimeRep for you as there are many variables which
			have to be taken into consideration. I will provide a non-obligatory quotation for this service if
			you <a href="Contact.aspx">contact me</a>.
			</p>
		</asp:TableCell>
	</asp:TableRow>
	<asp:TableRow>
		<asp:TableCell ColumnSpan="2" CssClass="FormCenter">
			<a href="Default.aspx">Click Here To Return To The TimeRep Web Site</a>
		</asp:TableCell>
	</asp:TableRow>
	</asp:Table>
<!-- $Filename: $ -->
</asp:Content>
