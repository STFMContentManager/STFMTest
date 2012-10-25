<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FoundationDonate3.aspx.cs" Inherits="STFMFoundationDonor.Default" %>
  
 <asp:Content runat="server" ID="foundation3" ContentPlaceHolderID="MainContent">
    <h2>Donate to the STFM Foundation - Step 3</h2>
    Select Amount and Provide Credit Card Information<br />
    Please enter your payment information and then click once on the "Make Donation" button:
    <h3>Payment Information</h3>
    
    <asp:Table runat="server" CssClass="FDN_table">
        <asp:TableRow CssClass="FDN_headrow">
            <asp:TableCell RowSpan="5" CssClass=FDN_labelcoltb1>Please select an amount:</asp:TableCell>

            <asp:TableCell><asp:RadioButton CssClass="FDN_MidColumn" runat="server" ID="rbpresident"  GroupName="DnrAmt"/></asp:TableCell>
            <asp:TableCell CssClass="FDN_controlcoltb1">President's Club - $1,000</asp:TableCell>            

        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell><asp:RadioButton runat="server" ID="rbtrustee" CssClass="FDN_MidColumn" GroupName="DnrAmt"/></asp:TableCell>
            <asp:TableCell CssClass="FDN_controlcoltb1">Trustee's Club - $500</asp:TableCell>
        </asp:TableRow>
        
        <asp:TableRow>
            <asp:TableCell><asp:RadioButton runat="server" ID="rbdirectors" CssClass="FDN_MidColumn" GroupName="DnrAmt"/></asp:TableCell>
            <asp:TableCell CssClass="FDN_controlcoltb1">Director's Club - $250</asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell><asp:RadioButton runat="server" ID="rbmentor" CssClass="FDN_MidColumn" GroupName="DnrAmt"/></asp:TableCell>
            <asp:TableCell CssClass="FDN_controlcoltb1">Mentor's Club - $100</asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell><asp:RadioButton runat="server" ID="rbother" CssClass="FDN_MidColumn" GroupName="DnrAmt"/></asp:TableCell>
            <asp:TableCell VerticalAlign="Bottom" CssClass="FDN_controlcoltb1">Other <asp:TextBox runat="server" ID="tbAMTother" ></asp:TextBox></asp:TableCell>
        </asp:TableRow>

    </asp:Table>

    <asp:Table runat = "server" CssClass="FDN_table">
        <asp:TableRow>
            <asp:TableCell RowSpan="5" CssClass="FDN_labelcoltb1">I would like to designate my gift to the:</asp:TableCell>

            <asp:TableCell CssClass="FDN_controlcoltb2">
                <asp:RadioButtonList runat="server" ID="rbldesignate">

                                <asp:ListItem Text="Please use my gift where needed" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Bishop Fellowship Program" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Faculty Enhancement Program" Value="2"></asp:ListItem>
                                <asp:ListItem Text="New Facult Scholars Award Program" Value="3"></asp:ListItem>
                                <asp:ListItem Text="International Scholarships" Value="4"></asp:ListItem>

                </asp:RadioButtonList>
             </asp:TableCell>
        </asp:TableRow>
    </asp:Table>

    <asp:Table runat="server" CssClass="FDN_table">
    
        <asp:TableRow>
        
            <asp:TableCell CssClass="FDN_labelcoltb1">This gift is made in:</asp:TableCell>
            <asp:TableCell CssClass="FDN_controlcoltb2">
                <asp:RadioButtonList runat="server" ID="rblmemoryof">
                    <asp:ListItem Text="memory of" Value="0"></asp:ListItem>
                    <asp:ListItem Text="honor of" Value="1"></asp:ListItem>
                    <asp:ListItem Text="not applicable" Value="2"></asp:ListItem>
                </asp:RadioButtonList>
            </asp:TableCell>

        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell CssClass="FDN_labelcoltb1">First Name:</asp:TableCell>
            <asp:TableCell CssClass="FDN_controlcoltb2"><asp:TextBox runat="server" ID="tbfname"></asp:TextBox></asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell CssClass="FDN_labelcoltb1">Last Name:</asp:TableCell>
            <asp:TableCell CssClass="FDN_controlcoltb2"><asp:TextBox runat="server" ID="tblname"></asp:TextBox></asp:TableCell>
        </asp:TableRow>
    
    </asp:Table>

    <asp:Table runat="server" CssClass="FDN_table">
        
        <asp:TableRow>
            <asp:TableCell CssClass="FDN_labelcoltb1">Credit Card Type:</asp:TableCell>
            <asp:TableCell CssClass="FDN_controlcoltb2">
                <asp:DropDownList runat="server" ID="ddlpaymenttype">
                    <asp:ListItem Text="Visa" Value="0"></asp:ListItem>
                    <asp:ListItem Text="MasterCard" Value="1"></asp:ListItem>
                    <asp:ListItem Text="American Express" Value="2"></asp:ListItem>
                </asp:DropDownList>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell CssClass="FDN_labelcoltb1">Credit Card Number:</asp:TableCell>
            <asp:TableCell CssClass="FDN_controlcoltb2"><asp:TextBox runat="server" ID="tbccNumber"></asp:TextBox></asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell CssClass="FDN_labelcoltb1">Name on Card:</asp:TableCell>
            <asp:TableCell CssClass="FDN_controlcoltb2"><asp:TextBox runat="server" ID="tbccName"></asp:TextBox></asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell CssClass="FDN_labelcoltb1">Exipration Date:</asp:TableCell>
            <asp:TableCell CssClass="FDN_controlcoltb2">
                <asp:DropDownList runat="server" ID="ddlexpmonth">
                    <asp:ListItem Text="1" Value="1"></asp:ListItem>
                    <asp:ListItem Text="2" Value="2"></asp:ListItem>
                    <asp:ListItem Text="3" Value="3"></asp:ListItem>
                    <asp:ListItem Text="4" Value="4"></asp:ListItem>
                    <asp:ListItem Text="5" Value="5"></asp:ListItem>
                    <asp:ListItem Text="6" Value="6"></asp:ListItem>
                    <asp:ListItem Text="7" Value="7"></asp:ListItem>
                    <asp:ListItem Text="8" Value="8"></asp:ListItem>
                    <asp:ListItem Text="9" Value="9"></asp:ListItem>
                    <asp:ListItem Text="10" Value="10"></asp:ListItem>
                    <asp:ListItem Text="11" Value="11"></asp:ListItem>
                    <asp:ListItem Text="12" Value="12"></asp:ListItem>
                </asp:DropDownList>

                &nbsp;/&nbsp;
                
                <asp:DropDownList runat="server" ID="ddlexpyear">
                    <asp:ListItem Text="2012" Value="2012"></asp:ListItem>
                    <asp:ListItem Text="2013" Value="2013"></asp:ListItem>
                    <asp:ListItem Text="2014" Value="2014"></asp:ListItem>
                    <asp:ListItem Text="2015" Value="2015"></asp:ListItem>
                </asp:DropDownList>

            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
        
            <asp:TableCell ColumnSpan="2" HorizontalAlign="Center"><asp:RadioButton runat="server" ID="rbChargeAboveAmt" GroupName="paytype"/>Charge the amount above now.</asp:TableCell>
        
        </asp:TableRow>

        <asp:TableRow>
        
            <asp:TableCell ColumnSpan="2" HorizontalAlign="Center"><asp:RadioButton runat="server" GroupName="paytype" ID="rbChargeMonthly"/>Charge my credit card $&nbsp;<asp:TextBox runat="server" ID="tbMonthlyAmt" Columns="6">
                </asp:TextBox>&nbsp;a month for&nbsp;<asp:TextBox runat="server" ID="tbMontlyTime" Columns="2"></asp:TextBox>&nbsp;months</asp:TableCell>

        </asp:TableRow>
    
    </asp:Table>
    <br />
    <asp:LinkButton Text="Make Donation" ID="btndonate" runat="server" OnClick="clicknextbutton"></asp:LinkButton> 
</asp:Content>   
