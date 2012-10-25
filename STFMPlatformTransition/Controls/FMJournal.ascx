<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FMJournal.ascx.cs" Inherits="STFMPlatformTransition.Controls.FMJournal" %>

<style type="text/css">

.title
{
    font-weight:bold;
    display:inline;
    margin-left:10px;    
}
.author
{
    font-style:italic;
    margin-left:20px;
    margin-top:-.09em;
}
.articletype
{
    text-decoration:underline;
}
.IssueHead
{
    font-size:large;
    color:rgb(29,65,123);
    font-weight:bold;        
}

</style>

<script type="text/javascript" src="http://code.jquery.com/jquery-1.8.2.js"></script>
<script type="text/javascript">
    $(document).ready(function () {

        $('a').click(function (event) {
            var x = event.target.id;
            
            if (x.substring(0, 8) == 'Abstract') {
                x = '#' + x;
                var y = '#div-' + x.substring(10);
                
                $(y).slideToggle(function () {
                    $(x).text(
                      $(this).is(':visible') ? "Hide Abstract" : "Show Abstract"
                    );
                });
            }
        })
    });

</script>

<asp:Table Width="875px" runat="server" HorizontalAlign="Center">

<asp:TableRow>
<asp:TableCell><img src="http://deepcleansing.ionpg.com/deepcleansing/images/FM_Nameplate_Blackweb.jpg" /></asp:TableCell>
</asp:TableRow>

<asp:TableRow>
<asp:TableCell>
<asp:Label runat="server" ID="FM_TOC_Display"></asp:label><div style="display:none></div>
</asp:TableCell>
</asp:TableRow>
</asp:Table>

