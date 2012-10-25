<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="NewCreateAccount.aspx.cs" Inherits="AcctSys.AcctCreate" MaintainScrollPositionOnPostback="true"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html id="Html1" xmlns="http://www.w3.org/1999/xhtml" runat="server">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

    

    <%-- HERE BE SQL SERVER STUFFS --%>

  <asp:SqlDataSource ID="SqlSTFMStates" runat="server" 
  ConnectionString="<%$ ConnectionStrings:STFMAcctCreate %>" SelectCommand="SELECT (abbrev + ' - ' + name) as nametext, stateid
  FROM [sampletrakdata].[dbo].[JPteststates]"></asp:SqlDataSource>

  <asp:SqlDataSource ID="SqlSTFMCountries" runat="server" 
  ConnectionString="<%$ ConnectionStrings:STFMAcctCreate %>" SelectCommand="USE sampletrakdata
  SELECT [Country ID] as countryid, [Country Name] as countryname FROM tblcountries">
  </asp:SqlDataSource>

  <asp:SqlDataSource ID="SqlSTFMCompanies" runat="server" 
  ConnectionString="<%$ ConnectionStrings:STFMAcctCreate %>" SelectCommand="Use sampletrakdata
  Select [Company ID] as compid, [Company Name] as name FROM tblcompanies ORDER BY name">
  </asp:SqlDataSource>
    
    <asp:Label runat="server" ID="lmainerror"></asp:Label>    

    <asp:Panel runat="server" ID="AcctCreate1">
    
    <h2>STFM.org account creation system - Step 1 of 4 personal and contact information</h2>

    <p>To use some of the features provided by our website (such as conference registration or to become an 
    STFM member) you must have an account with STFM. After creating an account, non-members are 
    welcome to register for STFM conferences and to submit presentations. After creating an account you 
    may then join STFM.</p>

    <p>Information marked with a red * is required. After completing the form click on the Verify Data button below.

    <p style="color:Red"> NOTE if you were or are an STFM or NAPCRG member then you already 
    have an account with STFM. Do not create a new account. Please try using 
    our recover password feature or call (800-274-7928 ext. 5407) or email (rtheobald@stfm.org) us for assistance.</p>

    <asp:Table ID="Table1" runat="server">
        <asp:TableRow runat = "server" ID="trowerror">
        
            <asp:TableCell ColumnSpan="2" ID="cellerror" ForeColor="Red" Width="300px"></asp:TableCell>

        </asp:TableRow>
        <asp:TableRow>
        
            <asp:TableCell CssClass="lblrow">Title<span class="req">*</span>:</asp:TableCell>
            <asp:TableCell CssClass="textboxrowpinfo">
                <asp:DropDownList runat="server" ID="ddltitle">
                    <asp:ListItem Text="Select One" Value="0" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="Dr." Value="1"></asp:ListItem>
                    <asp:ListItem Text="Mr." Value="2"></asp:ListItem>
                    <asp:ListItem Text="Mrs." Value="3"></asp:ListItem>
                    <asp:ListItem Text="Ms." Value="4"></asp:ListItem>
                </asp:DropDownList>
            </asp:TableCell>
        
        </asp:TableRow>

        <asp:TableRow>
            
            <asp:TableCell CssClass="lblrow">First Name<span class="req">*</span>:</asp:TableCell>
            <asp:TableCell CssClass="textboxrowpinfo"><asp:TextBox runat="server" ID="tbfname" CssClass="textboxes"></asp:TextBox></asp:TableCell>
        
        </asp:TableRow>

        <asp:TableRow>
            
            <asp:TableCell CssClass="lblrow">Middle Name:</asp:TableCell>
            <asp:TableCell CssClass="textboxrowpinfo"><asp:TextBox runat="server" ID="tbmname" CssClass="textboxes"></asp:TextBox></asp:TableCell>
        
        </asp:TableRow>

        <asp:TableRow>
            
            <asp:TableCell CssClass="lblrow">Last Name<span class="req">*</span>:</asp:TableCell>
            <asp:TableCell CssClass="textboxrowpinfo"><asp:TextBox runat="server" ID="tblname" CssClass="textboxes"></asp:TextBox></asp:TableCell>
        
        </asp:TableRow>

        <asp:TableRow>
            
            <asp:TableCell CssClass="lblrow">Suffix:</asp:TableCell>
            <asp:TableCell CssClass="textboxrowpinfo"><asp:TextBox runat="server" ID="tbsuffix" CssClass="textboxes"></asp:TextBox></asp:TableCell>
        
        </asp:TableRow>

        <asp:TableRow>
            
            <asp:TableCell CssClass="lblrow">Degree:</asp:TableCell>
            <asp:TableCell CssClass="textboxrowpinfo"><asp:TextBox runat="server" ID="tbdegree" CssClass="textboxes"></asp:TextBox></asp:TableCell>
        
        </asp:TableRow>

        <asp:TableRow>
            
            <asp:TableCell CssClass="lblrow">Email Address<span class="req">*</span>:</asp:TableCell>
            <asp:TableCell CssClass="textboxrowpinfo"><asp:TextBox runat="server" ID="tbemail" CssClass="textboxes"></asp:TextBox></asp:TableCell>
        
        </asp:TableRow>
        <asp:TableRow>
            
            <asp:TableCell CssClass="lblrow">Birthdate<span class="req">*</span>:</asp:TableCell>
            <asp:TableCell CssClass="textboxrowpinfo"><asp:TextBox runat="server" ID="tbbirthdate" CssClass="textboxes"></asp:TextBox></asp:TableCell>
        
        </asp:TableRow>

        <asp:TableRow>
            
            <asp:TableCell CssClass="lblrow">Cell Phone Number:</asp:TableCell>
            <asp:TableCell CssClass="textboxrowpinfo"><asp:TextBox runat="server" ID="tbcellphone" CssClass="textboxes"></asp:TextBox></asp:TableCell>
        
        </asp:TableRow>

    </asp:Table>

    <asp:Table ID="Table2" runat="server">

        <asp:TableRow>
            
            <asp:TableCell CssClass="celllblrow">Would you like to receive occasional STFM news updates via text message?  
                Click here for more details</asp:TableCell>
            <asp:TableCell>
                <asp:RadioButtonList runat="server" ID="rbltextmsg">
                    <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                    <asp:ListItem Text="No" Value="2"></asp:ListItem>
                </asp:RadioButtonList>
            </asp:TableCell>
        
        </asp:TableRow>
    
    </asp:Table>
    
    </asp:Panel>

<%-- /////////////////////////////////////////////
//////////////////////////////////////////////////
//////HERE IS WHERE THE ADDRESS STUFF BEGINS//////
//////////////////////////////////////////////////
///////////////////////////////////////////// --%>

    <asp:Panel runat="server" ID="AcctCreate2">
    
    <h2>STFM.org account creation system - Step 2 of 4 address information</h2>

    <p>Please input your billing and mailing address information below.  Your billing address will be used 
    to send you your annual STFM renewal notices.  The mailing address is the address we will send STFM materials, 
    such as your issues of <em>Family Medicine</em></p>

    <asp:Table ID="Table3" runat="server">

    <asp:TableRow>
        <asp:TableCell ColumnSpan = 2 runat="server" ID="BillAddrError" Width = "365px" ForeColor="Red"></asp:TableCell>
    </asp:TableRow>
    
    <asp:TableHeaderRow>
        <asp:TableHeaderCell HorizontalAlign="Left"><h3>Billing Address:</h3></asp:TableHeaderCell>
    </asp:TableHeaderRow>
    
    <asp:TableRow>
    
    <asp:TableCell CssClass="lblrow">What type of address is this?:</asp:TableCell>
    
    <asp:TableCell>
    <asp:RadioButtonList runat="server" AutoPostBack='true' ID="rbladdr1type" OnSelectedIndexChanged="addr1typechange" >
        <asp:ListItem Value = "0" Text="Home"></asp:ListItem>
        <asp:ListItem Value = "1" Text="Business"></asp:ListItem>
    </asp:RadioButtonList>
    </asp:TableCell>

    </asp:TableRow>

    <asp:TableRow ID="addr1company">

        <asp:TableCell Text="Company/Institution:" CssClass="lblrow"></asp:TableCell>
        <asp:TableCell>
        <asp:DropDownList ID="ddladdr1company" runat="server" Width="200px" 
            DataSourceID="SqlSTFMCompanies" DataTextField="name" DataValueField="compid" AppendDataBoundItems=true>
            <asp:ListItem Text="Select One" Value="0"></asp:ListItem></asp:DropDownList>
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

        <asp:TableCell CssClass="lblrow">City<span class="req">*</span>:</asp:TableCell>
        <asp:TableCell><asp:TextBox runat="server" ID="tbaddr1city" CssClass="textboxes"></asp:TextBox></asp:TableCell>

    </asp:TableRow>

    <asp:TableRow>

        <asp:TableCell CssClass="lblrow">State<span class="req">*</span>:</asp:TableCell>
        <asp:TableCell><asp:DropDownList runat="server" Width = "200px" ID="ddladdr1state" 
            DataSourceID="SqlSTFMStates" DataTextField="nametext" DataValueField="stateid" AppendDataBoundItems="true">
            <asp:ListItem Text="Select One" Value = "0"></asp:ListItem></asp:DropDownList></asp:TableCell>

    </asp:TableRow>

    <asp:TableRow>

        <asp:TableCell CssClass="lblrow">Zip/Postal Code<span class="req">*</span>:</asp:TableCell>
        <asp:TableCell><asp:TextBox runat="server" ID="tbaddr1zip" CssClass="textboxes"></asp:TextBox></asp:TableCell>

    </asp:TableRow>

        <asp:TableRow>

        <asp:TableCell CssClass="lblrow">Country<span class="req">*</span>:</asp:TableCell>
        <asp:TableCell>
        <asp:DropDownList runat="server" ID="ddladdr1country" DataSourceID="SqlSTFMCountries" 
            DataTextField="countryname" DataValueField="countryid" AppendDataBoundItems=true Width="200px">
            <asp:ListItem Text = "Select One" Value = "0"></asp:ListItem>
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
    
    <p>Is your mailing address the same as your billing address?<span class="req">*</span></p>
    <asp:Label runat="server" ID="lmailerror" ForeColor="Red"></asp:Label>
    <asp:RadioButtonList runat="server" ID="rbladdr2" OnSelectedIndexChanged="rbladdrselect" AutoPostBack="true">
        <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
        <asp:ListItem Text="No" Value="2"></asp:ListItem>
    </asp:RadioButtonList>



<asp:Table ID="tbaddr2" runat="server">

    <asp:TableHeaderRow>
        <asp:TableHeaderCell HorizontalAlign="Left"><h3>Mailing Address:</h3></asp:TableHeaderCell>
    </asp:TableHeaderRow>
    
    <asp:TableRow>
    
    <asp:TableCell CssClass="lblrow">What type of address is this?:</asp:TableCell>
    
    <asp:TableCell>
    <asp:RadioButtonList runat="server" AutoPostBack='true' ID="rbladdr2type" OnSelectedIndexChanged="addr2typechange">
        <asp:ListItem Value = "0" Text="Home"></asp:ListItem>
        <asp:ListItem Value = "1" Text="Business"></asp:ListItem>
    </asp:RadioButtonList>
    </asp:TableCell>

    </asp:TableRow>

    <asp:TableRow ID="addr2company">

        <asp:TableCell Text="Company/Institution:" CssClass="lblrow"></asp:TableCell>
        <asp:TableCell>
        <asp:DropDownList ID="ddladdr2company" runat="server" Width="200px" 
            DataSourceID="SqlSTFMCompanies" DataTextField="name" DataValueField="compid" AppendDataBoundItems="true">
            <asp:ListItem Text="Select One" Value="0"></asp:ListItem></asp:DropDownList>
        </asp:TableCell>

    </asp:TableRow>

    <asp:TableRow>

        <asp:TableCell CssClass="lblrow">Address Line 1<span class="req">*</span></asp:TableCell>
        <asp:TableCell><asp:TextBox runat="server" ID="tbaddr2line1" CssClass="textboxes"></asp:TextBox></asp:TableCell>

    </asp:TableRow>

    <asp:TableRow>

        <asp:TableCell Text="Address Line 2:" CssClass="lblrow"></asp:TableCell>
        <asp:TableCell><asp:TextBox runat="server" ID="tbaddr2line2" CssClass="textboxes"></asp:TextBox></asp:TableCell>

    </asp:TableRow>

    <asp:TableRow>

        <asp:TableCell CssClass="lblrow">City<span class="req">*</span>:</asp:TableCell>
        <asp:TableCell><asp:TextBox runat="server" ID="tbaddr2city" CssClass="textboxes"></asp:TextBox></asp:TableCell>

    </asp:TableRow>

    <asp:TableRow>

        <asp:TableCell CssClass="lblrow">State<span class="req">*</span>:</asp:TableCell>
        <asp:TableCell><asp:DropDownList runat="server" Width = "200px" ID="ddladdr2state" 
            DataSourceID="SqlSTFMStates" DataTextField="nametext" DataValueField="stateid" AppendDataBoundItems="true">
        <asp:ListItem Text="Select One" Value="0"></asp:ListItem></asp:DropDownList></asp:TableCell>

    </asp:TableRow>

    <asp:TableRow>

        <asp:TableCell CssClass="lblrow">Zip/Postal Code<span class="req">*</span>:</asp:TableCell>
        <asp:TableCell><asp:TextBox runat="server" ID="tbaddr2zip" CssClass="textboxes"></asp:TextBox></asp:TableCell>

    </asp:TableRow>

        <asp:TableRow>

        <asp:TableCell CssClass="lblrow">Country<span class="req">*</span>:</asp:TableCell>
        <asp:TableCell>
        <asp:DropDownList runat="server" ID="ddladdr2country" DataSourceID="SqlSTFMCountries" 
            DataTextField="countryname" DataValueField="countryid" AppendDataBoundItems="true" Width="200px">
            <asp:ListItem Text="Select One" Value="0"></asp:ListItem>
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

    </asp:Panel>

    <asp:Panel runat="server" ID="AcctCreate3">
    
    <h2>STFM.org account creation system - Step 3 of 4 confirm information</h2>
    
    <p>Please check the information you submitted below for completeness and accuracy.  If you would 
    like to make any changes, please click the "Back" button to return to the previous screens. 
    Click "Next" to continue.</p>

    <asp:Table ID="Table4" runat="server">
    
        <asp:TableHeaderRow>
            <asp:TableHeaderCell ColumnSpan="2" HorizontalAlign="Left"><h3>Personal and Contact Information</h3></asp:TableHeaderCell>
        </asp:TableHeaderRow>

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

        <asp:TableHeaderRow>
            <asp:TableHeaderCell ColumnSpan="2" runat="server" ID="taddrhdr" HorizontalAlign="Left">
                <h3>Billing Address</h3>
            </asp:TableHeaderCell>
        </asp:TableHeaderRow>

        <asp:TableRow>
        
            <asp:TableCell CssClass="lblrow">Name:</asp:TableCell>
            <asp:TableCell><asp:Label runat="server" ID="lbladdr1name"></asp:Label></asp:TableCell>
        
        </asp:TableRow>

        <asp:TableRow runat="server" ID="traddr1company">
        
            <asp:TableCell CssClass="lblrow">Company:</asp:TableCell>
            <asp:TableCell><asp:Label runat="server" ID="lbladdr1company"></asp:Label></asp:TableCell>
        
        </asp:TableRow>

        <asp:TableRow>
        
            <asp:TableCell CssClass="lblrow">Address 1:</asp:TableCell>
            <asp:TableCell><asp:Label runat="server" ID="lbladdr1line1"></asp:Label></asp:TableCell>
        
        </asp:TableRow>

        <asp:TableRow>
        
            <asp:TableCell CssClass="lblrow">Address 2:</asp:TableCell>
            <asp:TableCell><asp:Label runat="server" ID="lbladdr1line2"></asp:Label></asp:TableCell>
        
        </asp:TableRow>

        <asp:TableRow>
        
            <asp:TableCell CssClass="lblrow">City:</asp:TableCell>
            <asp:TableCell><asp:Label runat="server" ID="lbladdr1city"></asp:Label></asp:TableCell>
        
        </asp:TableRow>

        <asp:TableRow>
        
            <asp:TableCell CssClass="lblrow">State:</asp:TableCell>
            <asp:TableCell><asp:Label runat="server" ID="lbladdr1state"></asp:Label></asp:TableCell>
        
        </asp:TableRow>

        <asp:TableRow>
        
            <asp:TableCell CssClass="lblrow">Zip/Postal Code:</asp:TableCell>
            <asp:TableCell><asp:Label runat="server" ID="lbladdr1zip"></asp:Label></asp:TableCell>
        
        </asp:TableRow>

        <asp:TableRow>
        
            <asp:TableCell CssClass="lblrow">Country:</asp:TableCell>
            <asp:TableCell><asp:Label runat="server" ID="lbladdr1country"></asp:Label></asp:TableCell>
        
        </asp:TableRow>

        <asp:TableRow>
        
            <asp:TableCell CssClass="lblrow">Phone Number:</asp:TableCell>
            <asp:TableCell><asp:Label runat="server" ID="lbladdr1phone"></asp:Label></asp:TableCell>
        
        </asp:TableRow>

        <asp:TableRow>
        
            <asp:TableCell CssClass="lblrow">Fax Number:</asp:TableCell>
            <asp:TableCell><asp:Label runat="server" ID="lbladdr1fax"></asp:Label></asp:TableCell>
        
        </asp:TableRow>

    </asp:Table>

    <asp:Table runat="server" ID="taddr2">

        <asp:TableHeaderRow>
            <asp:TableHeaderCell ColumnSpan="2" runat="server" ID="TableHeaderCell1" HorizontalAlign="Left">
                <h3>Mailing Address</h3>
            </asp:TableHeaderCell>
        </asp:TableHeaderRow>
    
        <asp:TableRow>
        
            <asp:TableCell CssClass="lblrow">Name:</asp:TableCell>
            <asp:TableCell><asp:Label runat="server" ID="lbladdr2name"></asp:Label></asp:TableCell>
        
        </asp:TableRow>

        <asp:TableRow runat="server" ID="traddr2company">
        
            <asp:TableCell CssClass="lblrow">Company:</asp:TableCell>
            <asp:TableCell><asp:Label runat="server" ID="lbladdr2company"></asp:Label></asp:TableCell>
        
        </asp:TableRow>

        <asp:TableRow>
        
            <asp:TableCell CssClass="lblrow">Address 1:</asp:TableCell>
            <asp:TableCell><asp:Label runat="server" ID="lbladdr2line1"></asp:Label></asp:TableCell>
        
        </asp:TableRow>

        <asp:TableRow>
        
            <asp:TableCell CssClass="lblrow">Address 2:</asp:TableCell>
            <asp:TableCell><asp:Label runat="server" ID="lbladdr2line2"></asp:Label></asp:TableCell>
        
        </asp:TableRow>

        <asp:TableRow>
        
            <asp:TableCell CssClass="lblrow">City:</asp:TableCell>
            <asp:TableCell><asp:Label runat="server" ID="lbladdr2city"></asp:Label></asp:TableCell>
        
        </asp:TableRow>

        <asp:TableRow>
        
            <asp:TableCell CssClass="lblrow">State:</asp:TableCell>
            <asp:TableCell><asp:Label runat="server" ID="lbladdr2state"></asp:Label></asp:TableCell>
        
        </asp:TableRow>

        <asp:TableRow>
        
            <asp:TableCell CssClass="lblrow">Zip/Postal Code:</asp:TableCell>
            <asp:TableCell><asp:Label runat="server" ID="lbladdr2zip"></asp:Label></asp:TableCell>
        
        </asp:TableRow>

        <asp:TableRow>
        
            <asp:TableCell CssClass="lblrow">Country:</asp:TableCell>
            <asp:TableCell><asp:Label runat="server" ID="lbladdr2country"></asp:Label></asp:TableCell>
        
        </asp:TableRow>

        <asp:TableRow>
        
            <asp:TableCell CssClass="lblrow">Phone Number:</asp:TableCell>
            <asp:TableCell><asp:Label runat="server" ID="lbladdr2phone"></asp:Label></asp:TableCell>
        
        </asp:TableRow>

        <asp:TableRow>
        
            <asp:TableCell CssClass="lblrow">Fax Number:</asp:TableCell>
            <asp:TableCell><asp:Label runat="server" ID="lbladdr2fax"></asp:Label></asp:TableCell>
        
        </asp:TableRow>

    </asp:Table>
    
</asp:Panel>

<asp:Panel runat="server" ID="AcctCreate4">

<h2>STFM.org account creation system - Step 4 of 4 create username and password</h2>

<p>Please set your username and password below.  Click "Submit" to finish creating your STFM.org account</p>

<asp:Table ID="Table5" runat="server">
    <asp:TableRow>
        <asp:TableCell ColumnSpan = 2 runat="server" ID="PWerror" Visible="false" ForeColor="Red"></asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell CssClass="lblrow">Username:</asp:TableCell>
        <asp:TableCell><asp:TextBox runat="server" ID="tbusername"></asp:TextBox></asp:TableCell>
    </asp:TableRow>

    <asp:TableRow>
        <asp:TableCell CssClass="lblrow">Password:</asp:TableCell>
        <asp:TableCell><asp:TextBox runat="server" ID="tbpassword" TextMode="Password"></asp:TextBox></asp:TableCell>
    </asp:TableRow>

    <asp:TableRow>
        <asp:TableCell CssClass="lblrow">Confirm Password:</asp:TableCell>
        <asp:TableCell><asp:TextBox runat="server" ID="tbpasswordconf" TextMode="Password"></asp:TextBox></asp:TableCell>
    </asp:TableRow>

</asp:Table>

</asp:Panel>
    
<br />

    <asp:Button runat="server" ID="backbutton" Text="Back" OnClick="clkbackbtn"/>
    <asp:Button runat="server" ID="nextbutton" Text="Next" OnClick="clknextbtn"/>

    </form>
</body>
</html>