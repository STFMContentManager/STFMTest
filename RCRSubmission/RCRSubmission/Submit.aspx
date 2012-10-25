<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Submit.aspx.cs" Inherits="RCRSubmission.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body style="margin:0">
    <form id="form1" runat="server">
    <div>
     <asp:Table HorizontalAlign="Center" Width="875px" CellPadding="0" CellSpacing="0" runat="server" ID="tabMain">
      <asp:TableRow>
       <asp:TableCell HorizontalAlign="Center">
        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Header.jpg" />
       </asp:TableCell>
      </asp:TableRow>
      <asp:TableRow>
       <asp:TableCell>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Instructions.aspx" Target="_blank" Text="Click Here to View Instructions"></asp:HyperLink>
       </asp:TableCell>
      </asp:TableRow>
      <asp:TableRow>
       <asp:TableCell>
<p>
 <b>
  Residency Curriculum Resource Curriculum Proposal
 </b>
</p>
<p>
<asp:Table ID="tabApplication" runat="server">
 <asp:TableRow>
  <asp:TableCell>
   Lead author’s name
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell>
   <asp:Label ID="lblFirstName" runat="server" Text="First Name:"></asp:Label>
  </asp:TableCell>
  <asp:TableCell>
   <asp:Label ID="lblMiddleName" runat="server" Text="Middle Name:"></asp:Label>
  </asp:TableCell>
  <asp:TableCell>
   <asp:Label ID="lblLastName" runat="server" Text="Last Name:"></asp:Label>
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell>
   <asp:TextBox runat="server" ID="txtFirstName"></asp:TextBox>
  </asp:TableCell>
  <asp:TableCell>
   <asp:TextBox runat="server" ID="txtMiddleName"></asp:TextBox>
  </asp:TableCell>
  <asp:TableCell>
   <asp:TextBox runat="server" ID="txtLastName"></asp:TextBox>
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell>
   <asp:Label ID="lblTitle" runat="server" Text="Title:"></asp:Label>
  </asp:TableCell>
  <asp:TableCell>
   <asp:Label ID="lblDegrees" runat="server" Text="Degree(s):"></asp:Label>
  </asp:TableCell>
  <asp:TableCell>
   <asp:Label ID="lblMembership" runat="server" Text="Membership (check all that apply):"></asp:Label>
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell>
   <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
  </asp:TableCell>
  <asp:TableCell>
   <asp:DropDownList runat="server" ID="ddlDegrees"></asp:DropDownList>
  </asp:TableCell>
  <asp:TableCell>
   <asp:CheckBoxList runat="server" ID="cblMembership"><asp:ListItem Value="1">AFMRD</asp:ListItem><asp:ListItem Value="2">STFM</asp:ListItem></asp:CheckBoxList>
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell ColumnSpan="3">
   <asp:Label ID="lblAffiliation" runat="server" Text="Residency program/medical school affiliation:"></asp:Label><asp:TextBox ID="txtAffiliation" runat="server"></asp:TextBox>
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell>
   <asp:Label ID="lblAddress1" runat="server" Text="Address 1:"></asp:Label>
  </asp:TableCell>
  <asp:TableCell>
   <asp:Label ID="lblAddress2" runat="server" Text="Address 2:"></asp:Label>
  </asp:TableCell>
  <asp:TableCell>
   <asp:Label ID="lblAddress3" runat="server" Text="Address 3:"></asp:Label>
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell>
   <asp:TextBox runat="server" ID="txtAddress1"></asp:TextBox>
  </asp:TableCell>
  <asp:TableCell>
   <asp:TextBox runat="server" ID="txtAddress2"></asp:TextBox>
  </asp:TableCell>
  <asp:TableCell>
   <asp:TextBox runat="server" ID="txtAddress3"></asp:TextBox>
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell>
   <asp:Label ID="lblCity" runat="server" Text="City:"></asp:Label>
  </asp:TableCell>
  <asp:TableCell>
   <asp:Label ID="lblState" runat="server" Text="State:"></asp:Label>
  </asp:TableCell>
  <asp:TableCell>
   <asp:Label ID="lblZip" runat="server" Text="Zip:"></asp:Label>
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell>
   <asp:TextBox runat="server" ID="txtCity"></asp:TextBox>
  </asp:TableCell>
  <asp:TableCell>
   <asp:DropDownList runat="server" ID="ddlStates"></asp:DropDownList>
  </asp:TableCell>
  <asp:TableCell>
   <asp:TextBox runat="server" ID="txtZip"></asp:TextBox>
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell>
   <asp:Label ID="lblEmailAddress" runat="server" Text="Email address:"></asp:Label>
  </asp:TableCell>
  <asp:TableCell ColumnSpan="2">
   <asp:Label ID="lblPhoneNumber" runat="server" Text="Phone number:"></asp:Label>
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell>
   <asp:TextBox runat="server" ID="txtEmailAddress"></asp:TextBox>
  </asp:TableCell>
  <asp:TableCell ColumnSpan="2">
   <asp:TextBox runat="server" ID="txtPhoneNumber"></asp:TextBox>
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell ColumnSpan="3">
   Co-authors (if any):
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell>
   <asp:Label ID="lblCA1FirstName" runat="server" Text="First Name:"></asp:Label>
  </asp:TableCell>
  <asp:TableCell>
   <asp:Label ID="lblCA1MiddleName" runat="server" Text="Middle Name:"></asp:Label>
  </asp:TableCell>
  <asp:TableCell>
   <asp:Label ID="lblCA1LastName" runat="server" Text="Last Name:"></asp:Label>
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell>
   <asp:TextBox runat="server" ID="txtCA1FirstName"></asp:TextBox>
  </asp:TableCell>
  <asp:TableCell>
   <asp:TextBox runat="server" ID="txtCA1MiddleName"></asp:TextBox>
  </asp:TableCell>
  <asp:TableCell>
   <asp:TextBox runat="server" ID="txtCA1LastName"></asp:TextBox>
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell>
   <asp:Label ID="lblCA1Degrees" runat="server" Text="Degree(s):"></asp:Label><asp:DropDownList runat="server" ID="ddlCA1Degrees"><asp:ListItem Text="Degree 1"></asp:ListItem><asp:ListItem Text="Degree 2"></asp:ListItem><asp:ListItem Text="Degree 3"></asp:ListItem></asp:DropDownList>
  </asp:TableCell>
  <asp:TableCell ColumnSpan="2">
   <asp:Label ID="lblCA1Affiliation" runat="server" Text="Program affiliation: "></asp:Label><asp:DropDownList ID="ddlCA1Affiliation" runat="server"><asp:ListItem Text="Program 1"></asp:ListItem><asp:ListItem Text="Program 2"></asp:ListItem><asp:ListItem Text="Program 3"></asp:ListItem></asp:DropDownList>
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell>
   <asp:Label ID="lblCA2FirstName" runat="server" Text="First Name:"></asp:Label>
  </asp:TableCell>
  <asp:TableCell>
   <asp:Label ID="lblCA2MiddleName" runat="server" Text="Middle Name:"></asp:Label>
  </asp:TableCell>
  <asp:TableCell>
   <asp:Label ID="lblCA2LastName" runat="server" Text="Last Name:"></asp:Label>
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell>
   <asp:TextBox runat="server" ID="txtCA2FirstName"></asp:TextBox>
  </asp:TableCell>
  <asp:TableCell>
   <asp:TextBox runat="server" ID="txtCA2MiddleName"></asp:TextBox>
  </asp:TableCell>
  <asp:TableCell>
   <asp:TextBox runat="server" ID="txtCA2LastName"></asp:TextBox>
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell>
   <asp:Label ID="lblCA2Degrees" runat="server" Text="Degree(s):"></asp:Label><asp:DropDownList runat="server" ID="ddlCA2Degrees"><asp:ListItem Text="Degree 1"></asp:ListItem><asp:ListItem Text="Degree 2"></asp:ListItem><asp:ListItem Text="Degree 3"></asp:ListItem></asp:DropDownList>
  </asp:TableCell>
  <asp:TableCell ColumnSpan="2">
   <asp:Label ID="lblCA2Affiliation" runat="server" Text="Program affiliation: "></asp:Label><asp:DropDownList ID="ddlCA2Affiliation" runat="server"><asp:ListItem Text="Program 1"></asp:ListItem><asp:ListItem Text="Program 2"></asp:ListItem><asp:ListItem Text="Program 3"></asp:ListItem></asp:DropDownList>
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell ColumnSpan="3">
   <asp:Label ID="lblDisclosures" runat="server" Text="Disclosures"></asp:Label>
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell ColumnSpan="3">
   <asp:Label ID="lblAuthorsInterest" runat="server" Text="Please note all authors’ financial arrangement or affiliation with organizations that may have a direct interest in the subject matter."></asp:Label>
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell ColumnSpan="3">
   <asp:TextBox ID="txtAuthorsInterest" runat="server"></asp:TextBox>
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell ColumnSpan="3">
   <asp:Label ID="lblTopics" runat="server" Text="Topic you’d like to author (selected from topic list):"></asp:Label><asp:DropDownList runat="server" ID="ddlTopics"><asp:ListItem Text="Topic 1"></asp:ListItem><asp:ListItem Text="Topic 2"></asp:ListItem><asp:ListItem Text="Topic 3"></asp:ListItem></asp:DropDownList>
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell ColumnSpan="3">
   <asp:Label ID="lblBiosketch" runat="server" Text="Primary author biosketch (125 word maximum):"></asp:Label>
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell ColumnSpan="3">
   <textarea rows="5" cols="25" id="taBiosketch"></textarea>
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell ColumnSpan="3">
   <asp:Label ID="lblLearningObjectives" runat="server" Text="Proposed learning objectives:"></asp:Label>
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell ColumnSpan="3">
   <asp:Label ID="lblCurrDesc" runat="server" Text="Curriculum description: describe how you would teach the session and how the session would flow. (400 word maximum):"></asp:Label>
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell ColumnSpan="3">
   <textarea rows="10" cols="40" id="taCurrDesc"></textarea>
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell ColumnSpan="3">
   <asp:Label ID="lblSessionType" runat="server" Text="Type of Session:"></asp:Label><asp:RadioButtonList ID="rblSessionType" runat="server"><asp:ListItem Value="1" Text="Mini-session"></asp:ListItem><asp:ListItem Value="2" Text="Hour session"></asp:ListItem><asp:ListItem Value="3" Text="Workshop"></asp:ListItem><asp:ListItem Value="4" Text="Self-learning module"></asp:ListItem><asp:ListItem Value="5" Text="Other"></asp:ListItem></asp:RadioButtonList>
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell ColumnSpan="3">
   <asp:TextBox ID="txtSessionTypeOther" runat="server"></asp:TextBox>
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell ColumnSpan="3">
   <asp:Label ID="lblCurrFormat" runat="server" Text="Curriculum format (for example PowerPoint, Keystone, video, interactive module):"></asp:Label>
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell ColumnSpan="3">
   <asp:TextBox ID="txtCurrFormat" runat="server"></asp:TextBox>
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell ColumnSpan="3">
   <asp:Label ID="lblProvidedText" runat="server" Text="Authors will be provided PowerPoint templates, Word templates, and style guidelines."></asp:Label>
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell ColumnSpan="3">
   <asp:Label ID="lblTeachingTools" runat="server" Text="Describe teaching tools (illustrations, video,  case studies) you plan to use:"></asp:Label>
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell ColumnSpan="3">
   <textarea rows="2" cols="40" id="taTeachingTools"></textarea>
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell ColumnSpan="3">
   <asp:Label ID="lblTopicAssigned" runat="server" Text="If your desired topic has already been assigned, would you be willing to be assigned a related topic in the same curricular area?"></asp:Label><asp:RadioButtonList ID="rblTopicAssigned" runat="server"><asp:ListItem Value="1" Text="Yes"></asp:ListItem><asp:ListItem Value="0" Text="No"></asp:ListItem></asp:RadioButtonList>
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell ColumnSpan="3">
   <asp:CheckBox ID="chkUnderstand1" runat="server" /><asp:Label ID="lblUnderstand1" runat="server" Text="I understand that in addition to the “presentation,” I am required to create a quiz and teaching guide."></asp:Label>
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell ColumnSpan="3">
   <asp:CheckBox ID="chkUnderstand2" runat="server" /><asp:Label ID="lblUnderstand2" runat="server" Text="I understand that I will be required to update my curriculum on a periodic basis."></asp:Label>
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell ColumnSpan="3">
   <asp:CheckBox ID="chkUnderstand3" runat="server" /><asp:Label ID="lblUnderstand3" runat="server" Text="I understand that I must own or have written permission to use any graphs, charts, photos, videos, etc. that I include in my curriculum."></asp:Label>
  </asp:TableCell>
 </asp:TableRow>
</asp:Table>

       </asp:TableCell>
      </asp:TableRow>
      <asp:TableRow>
       <asp:TableCell>
        <asp:HyperLink ID="HyperLink2" NavigateUrl="~/Submit.aspx" runat="server">Click Here to Verify</asp:HyperLink>
       </asp:TableCell>
      </asp:TableRow>
     </asp:Table>
    </div>
    </form>
</body>
</html>
