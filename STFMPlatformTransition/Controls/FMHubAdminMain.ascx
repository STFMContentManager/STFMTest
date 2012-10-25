﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FMHubAdminMain.ascx.cs" Inherits="STFMPlatformTransition.Controls.FMHubAdminMain" %>

<asp:Table runat="server" Width="875px" HorizontalAlign="Center" BorderWidth="0px">
<asp:TableRow>
<asp:TableCell>
<h3>Recently Published Issues</h3>


<asp:Repeater runat="server" ID="FM_Published">
    <ItemTemplate runat="server">       

        <asp:Label ID="FM_PubTitle" runat="server" Text='<%# Eval("Title").ToString() %>'></asp:Label>
        <asp:Label ID="FM_PubMonth" runat="server" Text='<%# Eval("PublishDate").ToString() %>'></asp:Label>
        <asp:LinkButton ID="LinkButton2" runat="server" CssClass='<%# Eval("ID").ToString() %>' Text = "View Issue" OnClick="View_FM"></asp:LinkButton>&nbsp;|&nbsp;
        <asp:LinkButton runat="server" CssClass='<%# Eval("ID").ToString() %>'  Text="Delete Issue" OnClick="Delete_FM"></asp:LinkButton>&nbsp;|&nbsp;
        <asp:LinkButton runat="server" CssClass='<%# Eval("ID").ToString() %>' Text="Edit Issue" OnClick="Edit_FM"></asp:LinkButton>
        
        <br />
    </ItemTemplate>    
</asp:Repeater>


<br />
<h3>Issues Not Yet Published</h3>

<asp:Repeater runat="server" ID="FM_Unpublished">

    <ItemTemplate runat="server">
        
        <asp:Label ID="FM_PubTitle" runat="server" Text='<%# Eval("Title").ToString() %>'></asp:Label>
        <asp:Label ID="FM_PubMonth" runat="server" Text='<%# Eval("PublishDate").ToString() %>'></asp:Label> 
        <asp:LinkButton ID="LinkButton1" runat="server" CssClass='<%# Eval("ID").ToString() %>'  Text="Delete Issue" OnClick="Delete_FM"></asp:LinkButton>&nbsp;|&nbsp;
        <asp:LinkButton ID="LinkButton3" runat="server" CssClass='<%# Eval("ID").ToString() %>' Text="Edit Issue" OnClick="Edit_FM"></asp:LinkButton>
               
        <br />
            
    </ItemTemplate>

</asp:Repeater><br />

<a href="../FMHub/FMHubAdmin.aspx">Enter a new issue</a>

</asp:TableCell>
</asp:TableRow>
</asp:Table>
