<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RCRSubmission.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="margin:0">
    <form id="form1" runat="server">
    <div>
     <asp:Table HorizontalAlign="Center" Width="875px" CellPadding="0" CellSpacing="0" runat="server" ID="tabMain">
      <asp:TableRow>
       <asp:TableCell HorizontalAlign="Center">
        <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Default.aspx"><asp:Image ID="Image1" BorderStyle="None" runat="server" ImageUrl="~/Images/Header.jpg" /></asp:HyperLink>
       </asp:TableCell>
      </asp:TableRow>
      <asp:TableRow>
       <asp:TableCell>
<p>
 <b>Call for Proposals</b>
</p>
<p>
The Association of Family Medicine Residency Directors (AFMRD) and the Society of Teachers of Family Medicine (STFM) are now accepting proposals for curricula for a new, peer-reviewed Residency Curriculum Resource.
</p>
<p>
The curricula will be combined into a Web-based repository that provides materials to family medicine residency programs that can be used to teach the core content of family medicine. The Family Medicine Residency Curriculm Resource will be available on a subscription basis. 
</p>
<p>
Selected authors will develop case-based presentations, quizzes and teaching guides. Interactive modules and presentations with pictures, video, and other learning aids are encouraged. 
</p>
<p>
Proposals will be accepted on an ongoing basis, but only one author/authoring group will be selected for each topic. As authors are assigned, topics will be removed from the topic list. Authors will be credited for their work.  Submissions will be peer reviewed and will meet the RC-FM guidelines for scholarly activities.
</p>
<p>
 <ul>
  <li><asp:HyperLink ID="HyperLink1" NavigateUrl="~/Submission.aspx" runat="server">Proposal application</asp:HyperLink></li>
  <li><asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/Topics/PGY1 Author Topic List.pdf" Text="List of available topics" Target="_blank"></asp:HyperLink></li>
  <li><asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/SampleCurriculum.aspx" Text="Sample curriculum"></asp:HyperLink></li>
  <li><asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Instructions.aspx" Target="_blank" Text="Click Here to View Instructions">Instructions for  authors</asp:HyperLink></li>
  <li><asp:HyperLink runat="server" Target="_blank" NavigateUrl="~/Guidelines/DRAFT RCR Selection Guidelines .pdf">Evaluation criteria</asp:HyperLink></li>
  <li><asp:HyperLink runat="server" Target="_blank" NavigateUrl="http://www.stfm.org/about/newsreleases_4_5_2012.cfm">More about the Residency Curriculum Resource</asp:HyperLink></li>
 </ul>
</p>
       </asp:TableCell>
      </asp:TableRow>
     </asp:Table>
    </div>
    </form>
</body>
</html>
