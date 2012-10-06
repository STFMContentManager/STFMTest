<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="JoinPage3.aspx.cs" Inherits="STFMPlatformTransition.STFMAccts.JoinPage3" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server" ID="JoinContent3">

    <asp:Panel runat="server" Width="875" ID="bodypanel">
    
        <h2>STFM Membership Application - Step 3</h2>

        <p style="font-weight:bold; font-size:medium;">STFM Membership Fee Total: <asp:Label runat="server" ID="lblfeetotal"></asp:Label></p>

        <p>STFM dues are not deductible as a charitable contribution.  However, dues payments may 
        be partially deductible as a business expense.  Because STFM promotes the interests of 
        famil medicine educators on legislative matters, STFM estimates that 10% of the portion of 
        dues paid by individual members will not be deductible for this year.</p>
        <div style="text-align:center;">
        <p style="font-weight:bold; h">Please enter your payment information and <br />then click once on the "Submit Payment" button.</p>

        <asp:Table runat="server" ID="tpayment">
        
            <asp:TableHeaderRow>
                <asp:TableHeaderCell ColumnSpan="2" HorizontalAlign="Center"><p style="font-weight:bold;">Payment Information</p></asp:TableHeaderCell>
            </asp:TableHeaderRow>

            <asp:TableRow Height="45px" VerticalAlign="Bottom">
                <asp:TableCell>Credit Card Type:</asp:TableCell>
                <asp:TableCell><asp:DropDownList runat="server" ID="ddlpayment">
                    <asp:ListItem Text="Select One" Value="0"></asp:ListItem>
                    <asp:ListItem Text="MasterCard" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Visa" Value="2"></asp:ListItem>
                    <asp:ListItem Text="American Express" Value="3"></asp:ListItem></asp:DropDownList></asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell>Card Number:</asp:TableCell>
                <asp:TableCell><asp:TextBox runat="server" ID="tbcardnum"></asp:TextBox></asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell>Cardholder Name:</asp:TableCell>
                <asp:TableCell><asp:TextBox runat="server" ID="tbcardholder"></asp:TextBox></asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell>Exipiration Date:</asp:TableCell>
                <asp:TableCell><asp:TextBox runat="server" ID="tbexpmonth" Columns="2"></asp:TextBox> / <asp:TextBox runat="server" ID="tbexpyear" Columns="4"></asp:TextBox></asp:TableCell>
            </asp:TableRow>
        
        </asp:Table><br />
        <asp:LinkButton ID="btnSubmit" runat="server" Text="Submit Payment"></asp:LinkButton>
        </div>
    </asp:Panel>

</asp:Content>
