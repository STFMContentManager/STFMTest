<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FoundationDonate1.aspx.cs" Inherits="STFMFoundationDonor.STFMAcct1"%>

<asp:Content runat="server" ID="Foundation1" ContentPlaceHolderID="MainContent">

<h2>Donate to the STFM Foundation - Step 1</h2>

    <p>Please complete the form below to donate to the STFM Foundation</p>

    <p  style="width:875px">Information marked with a red * is required. After completing the form click on the Verify Data button below.</p>

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
        
            <asp:TableCell CssClass="celllblrow">What is your academic emphasis?<br />(Check all that apply)</asp:TableCell>
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

    
    <asp:LinkButton runat="server" ID="clickback" Text="Back" OnClick="clkbackbtn"></asp:LinkButton>
    
    <asp:LinkButton runat="server" ID="clicknext" Text="Next" OnClick="clknextbtn"></asp:LinkButton>

    </asp:Content>