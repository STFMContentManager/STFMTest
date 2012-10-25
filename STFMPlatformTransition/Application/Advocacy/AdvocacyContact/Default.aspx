<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="STFMAdvocacy.WebForm1" %>
<%@ Register TagName="ThreeColumnTemplate" TagPrefix="UC" Src="~/Controls/ThreeColumnTemplate.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div class="App_Body">
<h2>Tell Us About Your Advocacy Efforts</h2>
    
<p>We're excited to learn you have contacted your legislator. Please fill out the form below so we may learn about your contact.
Information marked with a red * is required. After completing the form click on the Submit Contact button below.</p>
    
    <asp:Table runat="server" ID="Advocacytable">
    
        <asp:TableRow>
        
            <asp:TableCell CssClass="lblrow">Title<span class="req">*</span>:</asp:TableCell>
            <asp:TableCell Width="250px"><asp:DropDownList runat="server" id="ddltitle">
                            <asp:ListItem Selected="True" Text="Select One" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Dr." Value="1"></asp:ListItem>
                            <asp:ListItem Text="Mr." Value="2"></asp:ListItem>
                            <asp:ListItem Text="Mrs." Value="3"></asp:ListItem>
                            <asp:ListItem Text="Ms." Value="4"></asp:ListItem>
                            <asp:ListItem Text="Miss" Value="5"></asp:ListItem>
            
            </asp:DropDownList></asp:TableCell>
        
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell CssClass="lblrow">First Name<span class="req">*</span>:</asp:TableCell>
            <asp:TableCell><asp:TextBox runat="server" ID="tbfname" CssClass="textboxes"></asp:TextBox></asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell CssClass="lblrow">Middle Initial</asp:TableCell>
            <asp:TableCell><asp:TextBox runat="server" ID="tbmname" CssClass="textboxes"></asp:TextBox></asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell CssClass="lblrow">Last Name<span class="req">*</span>:</asp:TableCell>
            <asp:TableCell><asp:TextBox runat="server" ID="tblname" CssClass="textboxes"></asp:TextBox></asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell CssClass="lblrow">Address<span class="req">*</span>:</asp:TableCell>
            <asp:TableCell><asp:TextBox runat="server" ID="tbaddr1" CssClass="textboxes"></asp:TextBox></asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell CssClass="lblrow">Address:</asp:TableCell>
            <asp:TableCell><asp:TextBox runat="server" ID="tbaddr2" CssClass="textboxes"></asp:TextBox></asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell CssClass="lblrow">City<span class="req">*</span>:</asp:TableCell>
            <asp:TableCell><asp:TextBox runat="server" ID="tbaddrcity" CssClass="textboxes"></asp:TextBox></asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell CssClass="lblrow">State<span class="req">*</span>:</asp:TableCell>
            <asp:TableCell>
                           <asp:DropDownList runat="server" ID="ddladdrstate">
                                <asp:ListItem Text="Non-US" Value="0"></asp:ListItem>
                                <asp:ListItem Text="AK" Value="1"></asp:ListItem>
                                <asp:ListItem Text="AL" Value="2"></asp:ListItem>
                                <asp:ListItem Text="AR" Value="3"></asp:ListItem>
                                <asp:ListItem Text="AZ" Value="4"></asp:ListItem>
                                <asp:ListItem Text="So On..." Value="5"></asp:ListItem>
                           </asp:DropDownList>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell CssClass="lblrow">Zip<span class="req">*</span>:</asp:TableCell>
            <asp:TableCell><asp:TextBox runat="server" ID="tbaddrzip" CssClass="textboxes"></asp:TextBox></asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell CssClass="lblrow">Email Address<span class="req">*</span>:</asp:TableCell>
            <asp:TableCell><asp:TextBox runat="server" ID="tbemail" CssClass="textboxes"></asp:TextBox></asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell CssClass="lblrow">Legislator Name<span class="req">*</span>:</asp:TableCell>
            <asp:TableCell><asp:TextBox runat="server" ID="tblegislatorname" CssClass="textboxes"></asp:TextBox></asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell CssClass="lblrow">How Contacted<span class="req">*</span>:</asp:TableCell>
            <asp:TableCell>
                <asp:DropDownList runat="server" ID="ddlcontact">
                    <asp:ListItem Text="Select One" Value="0"></asp:ListItem>
                    <asp:ListItem Text="In Person" Value="1"></asp:ListItem>
                    <asp:ListItem Text="By Phone" Value="2"></asp:ListItem>
                    <asp:ListItem Text="Email" Value="3"></asp:ListItem>
                    <asp:ListItem Text="Mail" Value="4"></asp:ListItem>
                </asp:DropDownList>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell CssClass="lblrow">Date Contacted<span class="req">*</span>:</asp:TableCell>
            <asp:TableCell><asp:TextBox runat="server" ID="tbcontactdate" CssClass="textboxes"></asp:TextBox></asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell CssClass="lblrow">Issue Discussed<span class="req">*</span>:</asp:TableCell>
            <asp:TableCell><asp:TextBox runat="server" Rows="5" TextMode="MultiLine"  ID="tbdiscuss" CssClass="textboxes"></asp:TextBox></asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell CssClass="lblrow">Did the legislator request follow-up?<span class="req">*</span>:</asp:TableCell>
            <asp:TableCell>
                <asp:DropDownList runat="server" ID="ddlfollowup">
                    <asp:ListItem Text="Select One" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                    <asp:ListItem Text="No" Value="2"></asp:ListItem>
                </asp:DropDownList>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell CssClass="lblrow">If yes, please describe:</asp:TableCell>
            <asp:TableCell><asp:TextBox runat="server" Rows="5"  TextMode= "MultiLine" ID="tbdescribe" CssClass="textboxes"></asp:TextBox></asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell>
            <textarea runat="server" ID="Notes_TextBox" rows="25" cols="25" ></textarea>
            </asp:TableCell>
        </asp:TableRow>
    
    </asp:Table>

    <br />

    <!--What happens when the submit button is clicked?-->
    <asp:LinkButton runat="server" ID="btnsubmit" Text="Submit" OnClick="SubmitForm"></asp:LinkButton>
    
    </div>

</asp:Content>
