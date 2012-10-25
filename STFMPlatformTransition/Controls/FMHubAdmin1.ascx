<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FMHubAdmin1.ascx.cs" Inherits="STFMPlatformTransition.Controls.FMHubAdmin" %>

<style type="text/css">
    
.labelcolwidth
{
    width:86px;
}

.labelcolwidth2
{
    width:125px;
}
</style>



<asp:Table ID="Table1" runat="server" Width="875px" HorizontalAlign="Center">
<asp:TableRow>
<asp:TableCell>

<h2>Update Family Medicine Hub and Generate PubMed File</h2>
<p>Enter the information below and then press the "Start Entering Articles" link</p>

<asp:Panel runat="server" ID="pnlIssueEntry" Visible="false">

<asp:Table runat="server">

    <asp:TableRow>
        <asp:TableCell CssClass="labelcolwidth"><asp:Label runat="server" Text="Volume"></asp:Label></asp:TableCell>
        <asp:TableCell><asp:TextBox runat="server" ID="tbvolume" Columns="5"></asp:TextBox></asp:TableCell>
    </asp:TableRow>

    <asp:TableRow>
        <asp:TableCell CssClass="labelcolwidth"><asp:Label ID="Label1" runat="server" Text="Issue"></asp:Label></asp:TableCell>
        <asp:TableCell><asp:TextBox runat="server" ID="tbissue" Columns="5"></asp:TextBox></asp:TableCell>
    </asp:TableRow>

    <asp:TableRow Height="50px" VerticalAlign="Bottom">
        <asp:TableCell CssClass="labelcolwidth"><asp:Label ID="Label3" runat="server" Text="Month"></asp:Label></asp:TableCell>
        <asp:TableCell>
                    <asp:DropDownList runat="server" ID="MonthDDL">
                            <asp:ListItem Text="Select One" Value="0"></asp:ListItem>
                            <asp:ListItem Text="January" Value="1"></asp:ListItem>
                            <asp:ListItem Text="February" Value="2"></asp:ListItem>
                            <asp:ListItem Text="March" Value="3"></asp:ListItem>
                            <asp:ListItem Text="April" Value="4"></asp:ListItem>
                            <asp:ListItem Text="May" Value="5"></asp:ListItem>
                            <asp:ListItem Text="June" Value="6"></asp:ListItem>
                            <asp:ListItem Text="July" Value="7"></asp:ListItem>
                            <asp:ListItem Text="August" Value="8"></asp:ListItem>
                            <asp:ListItem Text="September" Value="9"></asp:ListItem>
                            <asp:ListItem Text="October" Value="10"></asp:ListItem>
                            <asp:ListItem Text="November" Value="11"></asp:ListItem>
                            <asp:ListItem Text="December" Value="12"></asp:ListItem>
                       </asp:DropDownList>
        </asp:TableCell>
    </asp:TableRow>  

    <asp:TableRow>
        <asp:TableCell CssClass="labelcolwidth"><asp:Label ID="Label2" runat="server" Text="Year"></asp:Label></asp:TableCell>
        <asp:TableCell><asp:TextBox runat="server" ID="tbyear" Columns="5"></asp:TextBox></asp:TableCell>         
    </asp:TableRow>

</asp:Table>

</asp:Panel>

<asp:Panel runat="server" ID="pnlAddArticles" Visible="false">
<asp:Label runat="server" ID="lblArticleHead" Text="SET THIS WITH ISSUE DATA"></asp:Label><br />
<asp:LinkButton runat="server" ID="lbnAddArticle" Text="Add Article" OnClick="AddArticle"></asp:LinkButton><br /><br />

<asp:DataGrid runat="server" ID="dgArticleList" AutoGenerateColumns="false" BorderStyle="None">
    <Columns>
        <asp:BoundColumn DataField="Added Articles" HeaderText="Articles" ItemStyle-Width="500px"></asp:BoundColumn>
        <asp:HyperLinkColumn Text="Add Authors" DataNavigateUrlFormatString="../Application/FMHub/FMHubAdmin.aspx?Step=4&IssueID&ArticleID={0}" DataNavigateUrlField="ID"></asp:HyperLinkColumn>
    </Columns>
</asp:DataGrid>

<hr width="100%" />

</asp:Panel>

<asp:Panel runat="server" ID="pnlEditArticle" Visible="false">
    <asp:Table runat="server">
        <asp:TableRow>
            <asp:TableCell CssClass="labelcolwidth"><asp:Label runat="server" ID="lblartTitle" Text="Title"></asp:Label></asp:TableCell>
            <asp:TableCell><asp:TextBox ID="tbTitle" runat="server" Width="600px"></asp:TextBox></asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell CssClass="labelcolwidth"><asp:Label runat="server" ID="lblartSubject" Text="Subject"></asp:Label></asp:TableCell>
            <asp:TableCell><asp:TextBox ID="tbsubject" runat="server" Width="600px"></asp:TextBox></asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell CssClass="labelcolwidth"><asp:Label runat="server" ID="lblartStart" Text="Start Page"></asp:Label></asp:TableCell>
            <asp:TableCell><asp:TextBox ID="tbStart" runat="server" Width="50px"></asp:TextBox></asp:TableCell>
        </asp:TableRow>

        <asp:TableRow Height="50px" VerticalAlign="Top">
            <asp:TableCell CssClass="labelcolwidth"><asp:Label runat="server" ID="lblartEnd" Text="End Page"></asp:Label></asp:TableCell>
            <asp:TableCell><asp:TextBox ID="tbEnd" runat="server" Width="50px"></asp:TextBox></asp:TableCell>
        </asp:TableRow>
    </asp:Table>

<asp:Label runat="server" ID="lblartAbstract" Text="Abstract"></asp:Label><br />
<asp:TextBox runat="server" ID="tbAbstract" TextMode="MultiLine" Width="700px" Rows="30"></asp:TextBox><br /><br />

<asp:Label runat="server" Text="Upload Article PDF"></asp:Label><br />
<input id="inptArticle" type="file" runat="server" /><br /><br />

<asp:LinkButton runat="server" ID="lbnInsertArticle" Text="Save Article" OnClick="InsertAndClearArticle"></asp:LinkButton>
</asp:Panel>

<asp:Panel runat="server" ID="pnlAddAuthor" Visible="false">

    <asp:Label runat="server" ID="lblAuthorHeader" Font-Bold="true" Font-Size="Large"></asp:Label><br /><br />

    <asp:DataGrid runat="server" ID="dgAuthorList" AutoGenerateColumns="false" BorderStyle="None">
        <Columns>
            <asp:BoundColumn DataField="AuthorName" HeaderText="Authors" ItemStyle-BorderStyle="None" HeaderStyle-BorderStyle="None"></asp:BoundColumn>
        </Columns>
    </asp:DataGrid><br />

    <asp:Table runat="server">

        <asp:TableRow>
            <asp:TableCell CssClass="labelcolwidth2"><asp:Label runat="server" Text="First Name:"></asp:Label></asp:TableCell>
            <asp:TableCell><asp:TextBox runat="server" ID="tbfname" Width="225px"></asp:TextBox></asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell CssClass="labelcolwidth2"><asp:Label ID="Label4" runat="server" Text="Middle Name:"></asp:Label></asp:TableCell>
            <asp:TableCell><asp:TextBox runat="server" ID="tbmname" Width="225px"></asp:TextBox></asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell CssClass="labelcolwidth2"><asp:Label ID="Label5" runat="server" Text="Last Name:"></asp:Label></asp:TableCell>
            <asp:TableCell><asp:TextBox runat="server" ID="tblname" Width="225px"></asp:TextBox></asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell CssClass="labelcolwidth2"><asp:Label ID="Label6" runat="server" Text="Organization:"></asp:Label></asp:TableCell>
            <asp:TableCell><asp:TextBox runat="server" ID="tborganization" Width="225px"></asp:TextBox></asp:TableCell>
        </asp:TableRow>

    </asp:Table><br />

    <asp:LinkButton ID="lbnAddAuthor" Text="Add Author" runat="server" OnClick="InsertAndClearAuthor"></asp:LinkButton>

</asp:Panel>

<asp:LinkButton runat="server" ID="lbnNavigate" OnClick="FMHubNav"></asp:LinkButton>

</asp:TableCell>
</asp:TableRow>
</asp:Table>
