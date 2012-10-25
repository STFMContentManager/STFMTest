<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Submission.aspx.cs" Inherits="RCRSubmission.Submission" MaintainScrollPositionOnPostback="true" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" language="javascript">
        function checkmaxlength(currentlen, maxlen) {
            if (currentlen >= maxlen) {
                return false;
            }
            else {
                return true;
            }
        }
        function biosketchcnt(x) {
            //alert(x);
            var r = 0;
            a = x.replace(/\s/g, ' ');
            a = x.split(' ');
            for (z = 0; z < a.length; z++) { if (a[z].length > 0) r++; }
            //alert(r);
            var c = document.getElementById("c");
            if (r > 125) {
                alert('Maximum number of words reached');
            }
            else {
                c.value = r;
            }
        }
        function currdesccnt(x) {
            //alert(x);
            var r = 0;
            a = x.replace(/\s/g, ' ');
            a = x.split(' ');
            for (z = 0; z < a.length; z++) { if (a[z].length > 0) r++; }
            //alert(r);
            var c = document.getElementById("c2");
            if (r > 400) {
                alert('Maximum number of words reached');
            }
            else {
                c.value = r;
            }
        } 
    </script>
</head>
<body style="margin:0">
    <form id="form1" runat="server">
    <div>
     <asp:Table HorizontalAlign="Center" Width="875px" CellPadding="0" CellSpacing="0" runat="server" ID="tabMain">
      <asp:TableRow>
       <asp:TableCell HorizontalAlign="Center">
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx"><asp:Image ID="Image1" BorderStyle="None" runat="server" ImageUrl="~/Images/Header.jpg" /></asp:HyperLink>
       </asp:TableCell>
      </asp:TableRow>
      <asp:TableRow>
       <asp:TableCell>
        <p style="padding-top:10px">
         <b>
          Residency Curriculum Resource Curriculum Proposal
         </b>
        </p>
        <asp:HyperLink runat="server" NavigateUrl="~/Instructions.aspx" Target="_blank" Text="Click Here to View Instructions"></asp:HyperLink>
       </asp:TableCell>
      </asp:TableRow>
      <asp:TableRow>
       <asp:TableCell style="padding-top:10px">
<asp:Label runat="server" ID="lblMessage" Width="100%" ForeColor="Red"></asp:Label>
<asp:Table ID="tabApplication" runat="server">
 <asp:TableRow>
  <asp:TableCell Font-Size="14px" Font-Bold="true" style="padding-top:10px">
   Lead author’s name
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell Height="5px">
   &nbsp;
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
   &nbsp;
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell>
   <asp:Label ID="lblTitle" runat="server" Text="Title:"></asp:Label>
  </asp:TableCell>
  <asp:TableCell>
   <asp:Label ID="lblDegrees" runat="server" Text="Degree:"></asp:Label>
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
  <asp:TableCell>
   &nbsp;
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell ColumnSpan="3">
   <asp:Label ID="lblAffiliation" runat="server" Text="Residency program/medical school affiliation:"></asp:Label><asp:DropDownList ID="ddlAffiliation" runat="server"></asp:DropDownList>
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell>
   &nbsp;
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell>
   <asp:Label ID="lblAddress1" runat="server" Text="Mailing Address 1:"></asp:Label>
  </asp:TableCell>
  <asp:TableCell>
   <asp:Label ID="lblAddress2" runat="server" Text="Mailing Address 2:"></asp:Label>
  </asp:TableCell>
  <asp:TableCell>
   <asp:Label ID="lblAddress3" runat="server" Text="Mailing Address 3:"></asp:Label>
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
   &nbsp;
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
   <asp:Label ID="lblZipCode" runat="server" Text="Zip:"></asp:Label>
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
   <asp:TextBox runat="server" ID="txtZipCode"></asp:TextBox>
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell>
   &nbsp;
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
  <asp:TableCell>
   &nbsp;
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell Font-Size="14px" Font-Bold="true" ColumnSpan="3" style="padding-top:10px">
   Co-authors (if any):
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell>
   &nbsp;
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
   &nbsp;
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell>
   <asp:Label ID="lblCA1Degrees" runat="server" Text="Degree:"></asp:Label><asp:DropDownList runat="server" ID="ddlCA1Degrees"><asp:ListItem Text="Degree 1"></asp:ListItem><asp:ListItem Text="Degree 2"></asp:ListItem><asp:ListItem Text="Degree 3"></asp:ListItem></asp:DropDownList>
  </asp:TableCell>
  <asp:TableCell ColumnSpan="2">
   <asp:Label ID="lblCA1Affiliation" runat="server" Text="Program affiliation: "></asp:Label><asp:DropDownList ID="ddlCA1Affiliation" runat="server"><asp:ListItem Text="Program 1"></asp:ListItem><asp:ListItem Text="Program 2"></asp:ListItem><asp:ListItem Text="Program 3"></asp:ListItem></asp:DropDownList>
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell>
   &nbsp;
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
   &nbsp;
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell>
   <asp:Label ID="lblCA2Degrees" runat="server" Text="Degree:"></asp:Label><asp:DropDownList runat="server" ID="ddlCA2Degrees"><asp:ListItem Text="Degree 1"></asp:ListItem><asp:ListItem Text="Degree 2"></asp:ListItem><asp:ListItem Text="Degree 3"></asp:ListItem></asp:DropDownList>
  </asp:TableCell>
  <asp:TableCell ColumnSpan="2">
   <asp:Label ID="lblCA2Affiliation" runat="server" Text="Program affiliation: "></asp:Label><asp:DropDownList ID="ddlCA2Affiliation" runat="server"><asp:ListItem Text="Program 1"></asp:ListItem><asp:ListItem Text="Program 2"></asp:ListItem><asp:ListItem Text="Program 3"></asp:ListItem></asp:DropDownList>
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell>
   &nbsp;
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell ColumnSpan="3" style="padding-top:10px; padding-bottom:10px">
   <asp:Label ID="lblDisclosures" runat="server" Text="Disclosures" Font-Size="14px" Font-Bold="true"></asp:Label>
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell ColumnSpan="3">
   <asp:Label ID="lblAuthorsInterest" runat="server" Text="Please note all authors’ financial arrangement or affiliation with organizations that may have a direct interest in the subject matter."></asp:Label>
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell ColumnSpan="3">
   <asp:TextBox runat="server" Rows="2" Columns="75" TextMode="MultiLine" id="taAuthorsInterest"></asp:TextBox>
    <%--onkeypress="return checkmaxlength(this.value.length, 150);"--%>
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell>
   &nbsp;
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell ColumnSpan="3">
   <asp:Label ID="lblTopics" runat="server" Text="Topic you’d like to author:"></asp:Label>
   <br /><br />
   First Choose a Core Topic:&nbsp;<asp:DropDownList runat="server" ID="ddlCoreTopics" AutoPostBack="true" OnSelectedIndexChanged="FillTopicsDropDownList"></asp:DropDownList>
   <br /><br />
   Next Choose a Topic to Author:&nbsp;<asp:DropDownList runat="server" Enabled="false" ID="ddlTopics"></asp:DropDownList>
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell>
   &nbsp;
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell ColumnSpan="3">
   <asp:Label ID="lblBiosketch" runat="server" Text="Primary author biosketch (125 word maximum):"></asp:Label>
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell ColumnSpan="3">
   <asp:TextBox runat="server" Rows="11" Columns="75" TextMode="MultiLine" onkeyup="biosketchcnt(this.value)" id="taBiosketch"></asp:TextBox>
   <br />Word Count: <input type="text" id="c" value="0" size="5" />
 <%--onkeypress="return checkmaxlength(this.value.length, 750);"--%>
   </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell>
   &nbsp;
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell ColumnSpan="3">
   <asp:Label ID="lblLearningObjectives" runat="server" Text="Proposed learning objectives:"></asp:Label>
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell ColumnSpan="3">
   <asp:TextBox runat="server" Rows="11" Columns="75" TextMode="MultiLine" id="taLearningObjectives"></asp:TextBox>
 <%--onkeypress="return checkmaxlength(this.value.length, 750);"--%>
   </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell ColumnSpan="3">
   <asp:Label ID="lblCurrDesc" runat="server" Text="Curriculum description: describe how you would teach the session and how the session would flow. (400 word maximum):"></asp:Label>
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell ColumnSpan="3">
   <asp:TextBox runat="server" Rows="37" Columns="75" TextMode="MultiLine" onkeyup="currdesccnt(this.value)" id="taCurrDesc"></asp:TextBox>
   <br />Word Count: <input type="text" id="c2" value="0" size="5" />
 <%--onkeypress="return checkmaxlength(this.value.length, 2600);"--%>
   </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell>
   &nbsp;
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell ColumnSpan="3">
   <asp:Label ID="lblSessionType" runat="server" Text="Type of Session:"></asp:Label><asp:RadioButtonList ID="rblSessionType" AutoPostBack="true" OnSelectedIndexChanged="CheckSessionType" runat="server"><asp:ListItem Value="1" Text="Mini-session"></asp:ListItem><asp:ListItem Value="2" Text="Hour session"></asp:ListItem><asp:ListItem Value="3" Text="Workshop"></asp:ListItem><asp:ListItem Value="4" Text="Self-learning module"></asp:ListItem><asp:ListItem Value="5" Text="Other"></asp:ListItem></asp:RadioButtonList>
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell ColumnSpan="3">
   <asp:TextBox ID="txtSessionTypeOther" Enabled="false" runat="server"></asp:TextBox>
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell>
   &nbsp;
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell ColumnSpan="3">
   <asp:Label ID="lblCurrFormat" runat="server" Text="Curriculum format (for example PowerPoint, Keystone, video, interactive module):"></asp:Label>
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell ColumnSpan="3">
   <asp:TextBox ID="txtCurrFormat" Width="500" runat="server"></asp:TextBox>
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell>
   &nbsp;
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell ColumnSpan="3">
   <asp:Label ID="lblProvidedText" runat="server" Text="Authors will be provided PowerPoint templates, Word templates, and style guidelines."></asp:Label>
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell>
   &nbsp;
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell ColumnSpan="3">
   <asp:Label ID="lblTeachingTools" runat="server" Text="Describe teaching tools (illustrations, video,  case studies) you plan to use:"></asp:Label>
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell>
   &nbsp;
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell ColumnSpan="3">
   <asp:TextBox runat="server" TextMode="MultiLine" Rows="2" Columns="75" ID="taTeachingTools"></asp:TextBox>
  <%--onkeypress="return checkmaxlength(this.value.length, 150);"--%>
    </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell>
   &nbsp;
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell ColumnSpan="3">
   <asp:Label ID="lblTopicAssigned" runat="server" Text="If your desired topic has already been assigned, would you be willing to be assigned a related topic in the same curricular area?"></asp:Label><asp:RadioButtonList ID="rblTopicAssigned" runat="server"><asp:ListItem Value="1" Text="Yes"></asp:ListItem><asp:ListItem Value="0" Text="No"></asp:ListItem></asp:RadioButtonList>
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell>
   &nbsp;
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell ColumnSpan="3">
   <asp:CheckBox ID="chkUnderstandAttestation1" runat="server" /><asp:Label ID="lblUnderstandAttestation1" runat="server" Text="I understand that in addition to the “presentation,” I am required to create a quiz and teaching guide."></asp:Label>
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell ColumnSpan="3">
   <asp:CheckBox ID="chkUnderstandAttestation2" runat="server" /><asp:Label ID="lblUnderstandAttestation2" runat="server" Text="I understand that I will be required to update my curriculum on a periodic basis."></asp:Label>
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell ColumnSpan="3">
   <asp:CheckBox ID="chkUnderstandAttestation3" runat="server" /><asp:Label ID="lblUnderstandAttestation3" runat="server" Text="I understand that I must own or have written permission to use any graphs, charts, photos, videos, etc. that I include in my curriculum."></asp:Label>
  </asp:TableCell>
 </asp:TableRow>
</asp:Table>

<br /><br />

       </asp:TableCell>
      </asp:TableRow>
      <asp:TableRow>
       <asp:TableCell>
        <asp:LinkButton ID="lbVerifyChanges" OnClick="VerifySubmission" runat="server">Click Here to Submit this Proposal</asp:LinkButton>
       </asp:TableCell>
      </asp:TableRow>
     </asp:Table>

<br /><br />

    </div>
    </form>
</body>
</html>
