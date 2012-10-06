<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FoundationDonate4.aspx.cs" Inherits="STFMFoundationDonor.STFMAcct3" %>

<asp:Content runat="server" ID="Foundation4" ContentPlaceHolderID="MainContent">

<div class="App_Body>

<h2>Donate to the STFM Foundation</h2>
    
    <p>Please check your information below for accurracy.  You may make changes to your entries by clicking the "edit" links.  To complete your transaction, click "Checkout" at the bottom of the page.</p>

    <asp:Table ID="taddrhead" runat="server">
    
        <asp:TableHeaderRow>
            <asp:TableHeaderCell ColumnSpan="2" HorizontalAlign="Left"><h3 class="EditHeader">Personal and Contact Information </h3><asp:LinkButton runat="server" OnClick="ConfirmEdit" ID="PersonalInfoEdit">(Edit)</asp:LinkButton></asp:TableHeaderCell>

        </asp:TableHeaderRow>

        <asp:TableRow>

            <asp:TableCell runat = "server" ColumnSpan="2" HorizontalAlign="Left">
                          
            </asp:TableCell>

        </asp:TableRow>

        <asp:TableRow>
        
            <asp:TableCell CssClass="lblrow">Name:</asp:TableCell>
            <asp:TableCell><asp:Label runat="server" ID="lblconfname"></asp:Label></asp:TableCell>
        
        </asp:TableRow>

        <asp:TableRow>
        
            <asp:TableCell CssClass="lblrow">Email Address:</asp:TableCell>
            <asp:TableCell><asp:Label runat="server" ID="lblconfemail"></asp:Label></asp:TableCell>
        
        </asp:TableRow>

        <asp:TableRow>
        
            <asp:TableCell CssClass="lblrow">Birthdate:</asp:TableCell>
            <asp:TableCell><asp:Label runat="server" ID="lblbday"></asp:Label></asp:TableCell>
        
        </asp:TableRow>

        </asp:Table>

        <br />

        <asp:Table runat="server" ID="DonationInfo">
        
            <asp:TableHeaderRow>
                <asp:TableHeaderCell ColumnSpan="2" HorizontalAlign="Left"><h3 Class="EditHeader">STFM Foundation Donation </h3><asp:LinkButton runat="server" OnClick="ConfirmEdit" ID="PurchaseEdit">(Edit)</asp:LinkButton></asp:TableHeaderCell>
            </asp:TableHeaderRow>
            
            <asp:TableRow>
                <asp:TableCell CssClass="lblrow">Donation Level:</asp:TableCell>
                <asp:TableCell><asp:Label runat="server" ID="lblDNRAmt"></asp:Label></asp:TableCell>
            </asp:TableRow>
            
            <asp:TableRow runat="server" ID="trFDNDesignate">
                <asp:TableCell CssClass="lblrow">The donation is designated for:</asp:TableCell>
                <asp:TableCell><asp:Label runat="server" ID="lblDNRDesignate"></asp:Label></asp:TableCell>
            </asp:TableRow> 

            <asp:TableRow ID="trFDNHonor" runat="server">
                <asp:TableCell CssClass="lblrow">This gift is made in</asp:TableCell>
                <asp:TableCell><asp:Label runat="server" ID="lblDNRHonor"></asp:Label></asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell ColumnSpan="2">Payment Information</asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell CssClass="lblrow">Credit Card Type:</asp:TableCell>
                <asp:TableCell><asp:Label runat="server" ID="lblDNRCCType"></asp:Label></asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell CssClass="lblrow">Credit Card Number:</asp:TableCell>            
                <asp:TableCell><asp:Label runat="server" ID="lblDNRCCNum"></asp:Label></asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell CssClass="lblrow">Cardholder Name:</asp:TableCell>
                <asp:TableCell><asp:Label runat="server" ID="lblDNRCCname"></asp:Label></asp:TableCell>
            </asp:TableRow>
        
        </asp:Table>

        <br />

        <asp:Table ID="taddr1" runat="server">

        <asp:TableHeaderRow>
            <asp:TableHeaderCell ID="TableHeaderCell1" runat="server" HorizontalAlign="Left">
                <h3 class="EditHeader"><asp:Label runat="server" ID="lbladdrheader">Business Address </asp:Label></h3><asp:LinkButton runat="server" OnClick="ConfirmEdit" ID="Addr1Edit">(Edit)</asp:LinkButton>
            </asp:TableHeaderCell>
        </asp:TableHeaderRow>

        <asp:TableRow>

             <asp:TableCell runat = "server" ColumnSpan="2" HorizontalAlign="Left">
            
                

            </asp:TableCell>

        </asp:TableRow>

        <asp:TableRow>
        
            <asp:TableCell><asp:Label runat="server" ID="lbladdr1name"></asp:Label></asp:TableCell>
        
        </asp:TableRow>

        <asp:TableRow runat="server" ID="traddr1company">
        
            <asp:TableCell><asp:Label runat="server" ID="lbladdr1company"></asp:Label></asp:TableCell>
        
        </asp:TableRow>

        <asp:TableRow>
        
            <asp:TableCell><asp:Label runat="server" ID="lbladdr1line1"></asp:Label></asp:TableCell>
        
        </asp:TableRow>

        <asp:TableRow runat="server" ID="traddr1line2">
        
            <asp:TableCell><asp:Label runat="server" ID="lbladdr1line2"></asp:Label></asp:TableCell>
        
        </asp:TableRow>

        <asp:TableRow runat="server" ID="traddr1line3">
        
            <asp:TableCell><asp:Label runat="server" ID="lbladdr1line3"></asp:Label></asp:TableCell>
        
        </asp:TableRow>

        <asp:TableRow>
        
            <asp:TableCell><asp:Label runat="server" ID="lbladdr1city"></asp:Label></asp:TableCell>
        
        </asp:TableRow>

        <asp:TableRow>
        
            <asp:TableCell><asp:Label runat="server" ID="lbladdr1country"></asp:Label></asp:TableCell>
        
        </asp:TableRow>

        <asp:TableRow>
        
            <asp:TableCell><asp:Label runat="server" ID="lbladdr1phone"></asp:Label></asp:TableCell>
        
        </asp:TableRow>

        <asp:TableRow>
        
            <asp:TableCell><asp:Label runat="server" ID="lbladdr1fax"></asp:Label></asp:TableCell>
        
        </asp:TableRow>

        <asp:TableRow>
        
            <asp:TableCell>Is this your billing address or mailing address?</asp:TableCell>

        </asp:TableRow>

        <asp:TableRow>
        
            <asp:TableCell>
                <asp:DropDownList runat="server" ID="ddladdr1typeselect" AppendDataBoundItems="true" AutoPostBack="true">
                </asp:DropDownList>            
            </asp:TableCell>
        
        </asp:TableRow>

    </asp:Table>

    <br />

    <asp:Table runat="server" ID="taddr2">

        <asp:TableHeaderRow>
            <asp:TableHeaderCell runat="server" ID="TableHeaderCell2" HorizontalAlign="Left">
                <h3 class="EditHeader">Home Address </h3><asp:LinkButton runat="server" OnClick="ConfirmEdit" ID="Addr2Edit">(Edit)</asp:LinkButton>
            </asp:TableHeaderCell>
        </asp:TableHeaderRow>

        <asp:TableRow>

             <asp:TableCell ID="TableCell1" runat = "server" ColumnSpan="2" HorizontalAlign="Left">
            
                

            </asp:TableCell>

        </asp:TableRow>
    
        <asp:TableRow>
        
            <asp:TableCell><asp:Label runat="server" ID="lbladdr2name"></asp:Label></asp:TableCell>
        
        </asp:TableRow>

        <asp:TableRow runat="server" ID="traddr2company">
        
            <asp:TableCell><asp:Label runat="server" ID="lbladdr2company"></asp:Label></asp:TableCell>
        
        </asp:TableRow>

        <asp:TableRow>
        
            <asp:TableCell><asp:Label runat="server" ID="lbladdr2line1"></asp:Label></asp:TableCell>
        
        </asp:TableRow>

        <asp:TableRow runat="server" ID="traddr2line2">
        
            <asp:TableCell><asp:Label runat="server" ID="lbladdr2line2"></asp:Label></asp:TableCell>
        
        </asp:TableRow>

        <asp:TableRow runat="server" ID="traddr2line3">
        
            <asp:TableCell><asp:Label runat="server" ID="lbladdr2line3"></asp:Label></asp:TableCell>
        
        </asp:TableRow>

        <asp:TableRow>
        
            <asp:TableCell><asp:Label runat="server" ID="lbladdr2city"></asp:Label></asp:TableCell>
        
        </asp:TableRow>

        <asp:TableRow>
        
            <asp:TableCell><asp:Label runat="server" ID="lbladdr2state"></asp:Label></asp:TableCell>
        
        </asp:TableRow>

        <asp:TableRow>
        
            <asp:TableCell><asp:Label runat="server" ID="lbladdr2zip"></asp:Label></asp:TableCell>
        
        </asp:TableRow>

        <asp:TableRow>
        
            <asp:TableCell><asp:Label runat="server" ID="lbladdr2country"></asp:Label></asp:TableCell>
        
        </asp:TableRow>

        <asp:TableRow>
        
            <asp:TableCell><asp:Label runat="server" ID="lbladdr2phone"></asp:Label></asp:TableCell>
        
        </asp:TableRow>

        <asp:TableRow>
        
            <asp:TableCell><asp:Label runat="server" ID="lbladdr2fax"></asp:Label></asp:TableCell>
        
        </asp:TableRow>

        <asp:TableRow>
        
            <asp:TableCell>Is this your billing address or mailing address?</asp:TableCell>

        </asp:TableRow>

        <asp:TableRow>
        
            <asp:TableCell>
                <asp:DropDownList runat="server" ID="ddladdr2typeselect" AppendDataBoundItems="true" AutoPostBack = "true">
                </asp:DropDownList>            
            </asp:TableCell>
        
        </asp:TableRow>

    </asp:Table>

    <asp:LinkButton runat="server" ID="clickbackbutton" Text="Back" OnClick="clkbackbtn"/>
    
    <asp:LinkButton runat="server" ID="clicknextbutton" Text="Next" OnClick="clknextbtn"/>

</div>

</asp:Content> 
