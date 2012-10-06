<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="STFMJoin1.aspx.cs" Inherits="STFM_Account_Manager_3.WebForm2" %>

<asp:Content ID="ContentJoin1" runat="server" ContentPlaceHolderID="MainContent">

<asp:Table ID="Table3" runat="server" CssClass="App_Body" HorizontalAlign="Center">
 <asp:TableRow>
  <asp:TableCell>

<h2>STFM Member Application - Step 1</h2>

    <p>Please select the membership type and complete the additional membership information.  Required items are marked with an asterisk *.</p>
   
    <h2><span class="reqinfo">*</span>Select one of the following memership categories:</h2>
    <p><a href="http://stfm.org/join.cfm" target="_blank">Click here for details</a></p>

    <asp:RadioButtonList ID="rblmemtype1" runat="server" CssClass="radbuttonlist" OnSelectedIndexChanged="SetMemList" AutoPostBack="true">    
        <asp:ListItem Text="Active Physician Member - $310" Value="1"></asp:ListItem>
        <asp:ListItem Text="Active Nonphysician Member - $220" Value="2"></asp:ListItem>
        <asp:ListItem Text="Associate Member - $145" Value="3"></asp:ListItem>
        <asp:ListItem Text="International Member (Not Canada) - $140" Value="4"></asp:ListItem>        
    </asp:RadioButtonList>

    <p>Lifetime:<br /><i>(Current STFM member that is age 60+ by January 1, 2013)</i></p>
    <asp:RadioButtonList ID="rblmemtype2" runat="server" CssClass="radbuttonlist" OnSelectedIndexChanged="SetMemList" AutoPostBack="true">
        <asp:ListItem Text="Lifetime Physician Member - $1,000" Value="5"></asp:ListItem>
        <asp:ListItem Text="Lifetime Nonphysician Member - $750" Value="6"></asp:ListItem>
    </asp:RadioButtonList>

    <p>Affiliate Member</p>
    <asp:RadioButtonList ID="rblmemtype3" runat="server" CssClass="radbuttonlist" OnSelectedIndexChanged="SetMemList" AutoPostBack="true">
        <asp:ListItem Text = "Fellow-in-Training - $110" Value="7"></asp:ListItem>
        <asp:ListItem Text = "Resident - $75" Value="8"></asp:ListItem>
        <asp:ListItem Text = "Student - 25" Value="9"></asp:ListItem>
    </asp:RadioButtonList>
    <br />

<div id="memtext">

    <h2>Additional Membership Information</h2>

    <asp:Table runat="server" ID="tposition">
    
    <asp:TableRow>
        <asp:TableCell><span class="reqinfo">*</span>Primary Position:</asp:TableCell>
        <asp:TableCell><asp:DropDownList ID="ddlPosition" runat="server">

            <asp:ListItem Text="Select One" Value="0" Enabled="true"></asp:ListItem>
            <asp:ListItem Text="Position 1" Value="1"></asp:ListItem>
            <asp:ListItem Text="Position 2" Value="2"></asp:ListItem>
            <asp:ListItem Text="Position 3" Value="3"></asp:ListItem>
            <asp:ListItem Text="Position 4" Value="4"></asp:ListItem>

        </asp:DropDownList></asp:TableCell>
    </asp:TableRow>
    
    <asp:TableRow>
        <asp:TableCell><span class="reqinfo">*</span>Primary Rank:</asp:TableCell>
        <asp:TableCell><asp:DropDownList ID="ddlrank" runat="server">
            <asp:ListItem Text="Select One" Value="0" Enabled="true"></asp:ListItem>
            <asp:ListItem Text="Rank 1" Value="1"></asp:ListItem>
            <asp:ListItem Text="Rank 2" Value="2"></asp:ListItem>
            <asp:ListItem Text="Rank 3" Value="3"></asp:ListItem>
            <asp:ListItem Text="Rank 4" Value="4"></asp:ListItem>
        </asp:DropDownList></asp:TableCell>
    </asp:TableRow>

    <asp:TableRow>
        <asp:TableCell><span class="reqinfo">*</span>Discipline:</asp:TableCell>
        <asp:TableCell><asp:DropDownList ID="ddldiscipline" runat="server">
            <asp:ListItem Text="Select One" Value="0" Enabled="true"></asp:ListItem>
            <asp:ListItem Text="Discipline 1" Value="1"></asp:ListItem>
            <asp:ListItem Text="Discipline 2" Value="2"></asp:ListItem>
            <asp:ListItem Text="Discipline 3" Value="3"></asp:ListItem>
            <asp:ListItem Text="Discipline 4" Value="4"></asp:ListItem>
        </asp:DropDownList></asp:TableCell>
    </asp:TableRow>

    </asp:Table>
       
    </div>

    <p><strong>Optional Data:</strong></p>
    <p>STFM Members occasionally request the following demographic data for networking purposes.  May we release this information for networking putposes only?</p>
    
    <asp:RadioButtonList runat="server" ID="rblethnicity">
        
        <asp:ListItem Text = "Yes" Value="1"></asp:ListItem><asp:ListItem Text = "No" Value="2"></asp:ListItem>
        
    </asp:RadioButtonList>

    <p><strong>Ethnicity:</strong> <asp:DropDownList ID="ddlethnicity" runat="server">

        <asp:ListItem Text="Select One" Selected="True" Value="0"></asp:ListItem>
        <asp:ListItem Text="Value1" Value="1"></asp:ListItem>
        <asp:ListItem Text="Value2" Value="2"></asp:ListItem>
        <asp:ListItem Text="Value3" Value="3"></asp:ListItem>

        </asp:DropDownList> </p>

    <asp:LinkButton runat="server" ID="linkbackbutton" Text="Back" OnClick="clkbackbtn"/>    
    <asp:LinkButton runat="server" ID="linknextbutton" Text="Next" OnClick="clknextbtn"/>
  </asp:TableCell>
 </asp:TableRow>
</asp:Table>
</asp:Content>
