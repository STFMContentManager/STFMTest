<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FMHubAdminMain.ascx.cs" Inherits="STFMPlatformTransition.Controls.FMHubAdminMain" %>

<asp:Table runat="server" Width="875px" HorizontalAlign="Center" BorderWidth="0px">
<asp:TableRow>
<asp:TableCell>
<h3>Recently Published Issues</h3>


<asp:Repeater runat="server" ID="FM_Published">
    <ItemTemplate runat="server">       

        <asp:Label ID="FM_PubTitle" runat="server" Text='<%# Eval("Title").ToString() %>'></asp:Label>
        <asp:Label ID="FM_PubMonth" runat="server" Text='<%# Eval("PublishDate").ToString() %>'></asp:Label>
        <asp:LinkButton runat="server" CssClass='<%# Eval("ID").ToString() %>'  Text="Delete Issue" OnClick="Delete_FM"></asp:LinkButton>
        <br />
    </ItemTemplate>    
</asp:Repeater>



<h3>Issues Not Yet Published</h3>

<asp:Repeater runat="server" ID="FM_Unpublished">

    <ItemTemplate runat="server">
        
        <asp:Label ID="FM_PubTitle" runat="server" Text='<%# Eval("Title").ToString() %>'></asp:Label>
        <asp:Label ID="FM_PubMonth" runat="server" Text='<%# Eval("PublishDate").ToString() %>'></asp:Label>        
        <br />
            
    </ItemTemplate>

</asp:Repeater>

<a href="../FMHub/FMHubAdmin.aspx">Enter a new issue</a>

</asp:TableCell>
</asp:TableRow>
</asp:Table>
