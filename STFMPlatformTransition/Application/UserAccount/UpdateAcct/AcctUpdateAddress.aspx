<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AcctUpdateAddress.aspx.cs" Inherits="STFMAcctUpdate.STFMAcct2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link rel=Stylesheet href=/Styles/AcctCreate.css type="text/css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <h2>STFM.org account creation system - Step 2 of 4 address information</h2>

    <p>Please input your business and/or home addess information below.</p>  

    <asp:Table ID="Table1" runat="server">

    <asp:TableRow>
        <asp:TableCell ColumnSpan = 2 runat="server" ID="BillAddrError" Width = "365px" ForeColor="Red"></asp:TableCell>
    </asp:TableRow>
    
    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Left" ColumnSpan= 2><h3>Business Address:</h3></asp:TableCell>
    </asp:TableRow>
    
    <asp:TableRow ID="addr1company">

        <asp:TableCell Text="Company/Institution:" CssClass="lblrow"></asp:TableCell>
        <asp:TableCell>
        <asp:DropDownList ID="ddladdr1company" runat="server" Width="200px" 
            >
            </asp:DropDownList>
        </asp:TableCell>

    </asp:TableRow>

    <asp:TableRow>

        <asp:TableCell CssClass="lblrow">Address Line 1<span class="req">*</span>:</asp:TableCell>
        <asp:TableCell><asp:TextBox runat="server" ID="tbaddr1line1" CssClass="textboxes"></asp:TextBox></asp:TableCell>

    </asp:TableRow>

    <asp:TableRow>

        <asp:TableCell Text="Address Line 2:" CssClass="lblrow"></asp:TableCell>
        <asp:TableCell><asp:TextBox runat="server" ID="tbaddr1line2" CssClass="textboxes"></asp:TextBox></asp:TableCell>

    </asp:TableRow>

    <asp:TableRow>

        <asp:TableCell Text="Address Line 3:" CssClass="lblrow"></asp:TableCell>
        <asp:TableCell><asp:TextBox runat="server" ID="tbaddr1line3" CssClass="textboxes"></asp:TextBox></asp:TableCell>

    </asp:TableRow>

    <asp:TableRow>

        <asp:TableCell CssClass="lblrow">City<span class="req">*</span>:</asp:TableCell>
        <asp:TableCell><asp:TextBox runat="server" ID="tbaddr1city" CssClass="textboxes"></asp:TextBox></asp:TableCell>

    </asp:TableRow>

    <asp:TableRow>

        <asp:TableCell CssClass="lblrow">State<span class="req">*</span>:</asp:TableCell>
        <asp:TableCell><asp:DropDownList runat="server" Width = "200px" ID="ddladdr1state" 
            AppendDataBoundItems="true" OnSelectedIndexChanged="ddlState_Change" AutoPostBack="true">
            </asp:DropDownList></asp:TableCell>

    </asp:TableRow>

    <asp:TableRow>

        <asp:TableCell CssClass="lblrow">Zip/Postal Code<span class="req">*</span>:</asp:TableCell>
        <asp:TableCell><asp:TextBox runat="server" ID="tbaddr1zip" CssClass="textboxes"></asp:TextBox></asp:TableCell>

    </asp:TableRow>

        <asp:TableRow>

        <asp:TableCell CssClass="lblrow">Country<span class="req">*</span>:</asp:TableCell>
        <asp:TableCell>
        <asp:DropDownList runat="server" ID="ddladdr1country" Width = "200px" AutoPostBack="true" OnSelectedIndexChanged="ddlCountry_addr1Change"> <%--DataSourceID="SqlSTFMCountries" 
            DataTextField="countryname" DataValueField="countryid" AppendDataBoundItems=true Width="200px">
            <asp:ListItem Text = "Select One" Value = "0"></asp:ListItem>--%>
            </asp:DropDownList></asp:TableCell>

    </asp:TableRow>

    <asp:TableRow>

        <asp:TableCell CssClass="lblrow">Telephone Number<span class="req">*</span>:</asp:TableCell>
        <asp:TableCell><asp:TextBox runat="server" ID="tbaddr1telephone" CssClass="textboxes"></asp:TextBox></asp:TableCell>

    </asp:TableRow>

    <asp:TableRow>

        <asp:TableCell Text="Fax Number:" CssClass="lblrow"></asp:TableCell>
        <asp:TableCell><asp:TextBox runat="server" ID="tbaddr1fax" CssClass="textboxes"></asp:TextBox></asp:TableCell>

    </asp:TableRow>
    
    </asp:Table>
    
<asp:Table ID="tbaddr2" runat="server">

    <asp:TableHeaderRow>
        <asp:TableHeaderCell HorizontalAlign="Left"><h3>Home Address:</h3></asp:TableHeaderCell>
    </asp:TableHeaderRow>
    
    <asp:TableRow>

        <asp:TableCell CssClass="lblrow">Address Line 1<span class="req">*</span></asp:TableCell>
        <asp:TableCell><asp:TextBox runat="server" ID="tbaddr2line1" CssClass="textboxes"></asp:TextBox></asp:TableCell>

    </asp:TableRow>

    <asp:TableRow>

        <asp:TableCell Text="Address Line 2:" CssClass="lblrow"></asp:TableCell>
        <asp:TableCell><asp:TextBox runat="server" ID="tbaddr2line2" CssClass="textboxes"></asp:TextBox></asp:TableCell>

    </asp:TableRow>

    <asp:TableRow>

        <asp:TableCell Text="Address Line 3:" CssClass="lblrow"></asp:TableCell>
        <asp:TableCell><asp:TextBox runat="server" ID="tbaddr2line3" CssClass="textboxes"></asp:TextBox></asp:TableCell>

    </asp:TableRow>

    <asp:TableRow>

        <asp:TableCell CssClass="lblrow">City<span class="req">*</span>:</asp:TableCell>
        <asp:TableCell><asp:TextBox runat="server" ID="tbaddr2city" CssClass="textboxes"></asp:TextBox></asp:TableCell>

    </asp:TableRow>

    <asp:TableRow>

        <asp:TableCell CssClass="lblrow">State<span class="req">*</span>:</asp:TableCell>
        <asp:TableCell><asp:DropDownList runat="server" Width = "200px" ID="ddladdr2state"></asp:DropDownList> 
            <%--DataSourceID="SqlSTFMStates" DataTextField="nametext" DataValueField="stateid" AppendDataBoundItems="true">
        <asp:ListItem Text="Select One" Value="0"></asp:ListItem></asp:DropDownList>--%></asp:TableCell>

    </asp:TableRow>

    <asp:TableRow>

        <asp:TableCell CssClass="lblrow">Zip/Postal Code<span class="req">*</span>:</asp:TableCell>
        <asp:TableCell><asp:TextBox runat="server" ID="tbaddr2zip" CssClass="textboxes"></asp:TextBox></asp:TableCell>

    </asp:TableRow>

        <asp:TableRow>

        <asp:TableCell CssClass="lblrow">Country<span class="req">*</span>:</asp:TableCell>
        <asp:TableCell>
        <asp:DropDownList runat="server" ID="ddladdr2country" Width = "200px" AutoPostBack="true" OnSelectedIndexChanged="ddlCountry_addr2Change"> <%--DataSourceID="SqlSTFMCountries" 
            DataTextField="countryname" DataValueField="countryid" AppendDataBoundItems="true" Width="200px">
            <asp:ListItem Text="Select One" Value="0"></asp:ListItem>--%>
            </asp:DropDownList></asp:TableCell>

    </asp:TableRow>

    <asp:TableRow>

        <asp:TableCell CssClass="lblrow">Telephone Number<span class="req">*</span>:</asp:TableCell>
        <asp:TableCell><asp:TextBox runat="server" ID="tbaddr2telephone" CssClass="textboxes"></asp:TextBox></asp:TableCell>

    </asp:TableRow>

    <asp:TableRow>

        <asp:TableCell Text="Fax Number:" CssClass="lblrow"></asp:TableCell>
        <asp:TableCell><asp:TextBox runat="server" ID="tbaddr2fax" CssClass="textboxes"></asp:TextBox></asp:TableCell>

    </asp:TableRow>
    
    </asp:Table>

    <asp:Button runat="server" ID="backbutton" Text="Back" OnClick="clkbackbtn"/>
    
    <asp:Button runat="server" ID="nextbutton" Text="Next" OnClick="clknextbtn"/>
    </form>
</body>
</html>
