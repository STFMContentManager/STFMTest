<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="AcctUpdateStart.aspx.cs" Inherits="STFMAcctUpdate.STFMAcct3" %>

<asp:Content ID="content3" runat="server" ContentPlaceHolderID="MainContent">

<div class="App_Body>

<h2>Update Your STFM.org Account Information</h2>
    
    <p>Please check the information you submitted below for completeness and accuracy.  If you would 
    like to make any changes, please click the "Back" button to return to the previous screens. 
    Click "Next" to continue.</p>

    <asp:Table ID="taddrhead" runat="server">
    
        <asp:TableHeaderRow>
            <asp:TableHeaderCell ColumnSpan="2" HorizontalAlign="Left"><h4 class="EditHeader">Personal and Contact Information </h4><asp:LinkButton runat="server" OnClick="ConfirmEdit" ID="PersonalInfoEdit">(Edit)</asp:LinkButton></asp:TableHeaderCell>

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
        
            <asp:TableCell CssClass="lblrow">Wants text updates from STFM:</asp:TableCell>
            <asp:TableCell><asp:Label runat="server" ID="lblconftxt"></asp:Label></asp:TableCell>
        
        </asp:TableRow>

        </asp:Table>

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
                <asp:DropDownList runat="server" ID="ddladdr1typeselect" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="ddladdr1typechange">
                </asp:DropDownList>            
            </asp:TableCell>
        
        </asp:TableRow>

    </asp:Table>

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
                <asp:DropDownList runat="server" ID="ddladdr2typeselect" AppendDataBoundItems="true" AutoPostBack = "true" OnSelectedIndexChanged="ddladdr2typechange">
                </asp:DropDownList>            
            </asp:TableCell>
        
        </asp:TableRow>

    </asp:Table>
    
    <asp:LinkButton runat="server" ID="linknextbutton" Text="Confirm" OnClick="clknextbtn"/>

    </div>

    </asp:Content>