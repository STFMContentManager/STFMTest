<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AcctUpdatePersonal.aspx.cs" Inherits="STFMAcctUpdate.AccountUpdate1"%>

<asp:Content ID="AcctUpdate" runat="server" ContentPlaceHolderID="MainContent">

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


        <asp:TableRow Width="220px" VerticalAlign="Middle">
            <asp:TableCell CssClass="lblrow">Please select your country of residence<span class="req">*</span>:</asp:TableCell>
            <asp:TableCell CssClass="textboxrowpinfo"><asp:DropDownList runat="server" ID="ddlMainCountry" Width="180px" OnSelectedIndexChanged="MainCountryChange" AutoPostBack="true"
                ></asp:DropDownList></asp:TableCell>
        </asp:TableRow>

        <asp:TableRow Width="220px" VerticalAlign="Middle">
            <asp:TableCell CssClass="lblrow">Please select the state in which you work<span class="req">*</span>:</asp:TableCell>
            <asp:TableCell CssClass="textboxrowpinfo"><asp:DropDownList runat="server" ID="ddlworkstate" Width="180px" ></asp:DropDownList></asp:TableCell>
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

    <asp:Table runat="server">

        <asp:TableRow>
        
            <asp:TableCell CssClass="lblrow">What is your academic emphasis?<br />(Check all that apply)</asp:TableCell>
            <asp:TableCell>
            
                <asp:CheckBoxList runat="server" ID="cblAcademic">
                    <asp:ListItem Text="Residency Education" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Medical Student Education" Value="1"></asp:ListItem>
                    <asp:ListItem Text="I am not involved in the education of residents or students" Value="2"></asp:ListItem>
                </asp:CheckBoxList>
            
            </asp:TableCell>
        
        </asp:TableRow>

        <asp:TableRow Height="35px" runat="server"></asp:TableRow>
    
        <asp:TableRow>
            
            <asp:TableCell CssClass="lblrow">Birthdate<span class="req">*</span>:</asp:TableCell>
            <asp:TableCell>Month: <asp:DropDownList runat="server" AppendDataBoundItems="true" ID="ddlMonth"></asp:DropDownList>
            Day: <asp:DropDownList runat="server" AppendDataBoundItems="true" ID="ddlDay"></asp:DropDownList>
            Year: <asp:DropDownList runat="server" AppendDataBoundItems="true" ID="ddlYear"></asp:DropDownList></asp:TableCell>
        
        </asp:TableRow>

    </asp:Table>

    <br />

    <asp:LinkButton runat="server" ID="lbackbutton" Text="Back" OnClick="clkbackbtn"/>
    
    <asp:LinkButton runat="server" ID="lnextbutton" Text="Next" OnClick="clknextbtn"/>
</asp:Content>
