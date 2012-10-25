<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FacultyScholarshipApplication.aspx.cs" Inherits="STFMPlatformTransition.FacultyScholarshipApplication" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<link rel="Stylesheet" href="/Styles/STFMStamps.css" />
</head>
<body style="font-family:Verdana; font-size:12px">
    <form id="form1" runat="server">
    <div>
<asp:Table ID="tabDirections" runat="server">
 <asp:TableRow>
  <asp:TableCell HorizontalAlign="Center">
   <h2>STFM New Faculty FMCC Scholarship Application</h2>
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell HorizontalAlign="Center">
   <font color="#000000"><strong>Award for New Faculty (5 years or less) to attend the Family Medicine Congressional Conference</strong></font>
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell HorizontalAlign="Center">
   <font color="#000000">Washington, DC</font>
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell HorizontalAlign="Center">
   <font color="#000000">May 14-15, 2013</font>
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell HorizontalAlign="Center" ForeColor="Red">
   The deadline to submit applications is Wednesday, October 3, 2012
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell Font-Bold="true">
   <h3>Scholarship Eligibility Requirements:</h3>
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell style="padding-left:20px">
   <ul>
    <li><img src="Images/BlueDot.gif" width="10" height="10" />Current faculty at a family medicine department or residency.</li>
    <li><img src="Images/BlueDot.gif" width="10" height="10" />STFM Member</li>
    <li><img src="Images/BlueDot.gif" width="10" height="10" />Member of the CAN Network (may sign up in order to be eligible)</li>
    <li><img src="Images/BlueDot.gif" width="10" height="10" />Completed the Online Advocacy Module at <a href="http://www.stfm.org/advocacy/course.cfm" target="_blank">www.stfm.org/advocacy/course.cfm</a></li>
    <li><img src="Images/BlueDot.gif" width="10" height="10" />Able to attend FMCC May 14-15, 2013</li>
    <li><img src="Images/BlueDot.gif" width="10" height="10" />Will write a report following attendance at FMCC on one of the following topics: Process of Advocacy, Content (Issue areas of advocacy or lessons from the speakers), Translation of skills learned at FMCC to role as faculty member</li>
   </ul>
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell Font-Bold="true">
   <br /><h3>To submit your application:</h3>
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell>
    1. Complete all fields on the application. Fields marked with an * are required.
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell>
    2. Upload the following documents where indicated in the .doc, .docx, or .pdf file formats.
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell style="padding-left:20px">
   <ul>
    <li><img src="Images/BlueDot.gif" width="10" height="10" />Letter of Recommendation from your current Chair or Program Director</li>
    <li><img src="Images/BlueDot.gif" width="10" height="10" />Current Curriculum Vitae</li>
    <li><img src="Images/BlueDot.gif" width="10" height="10" />Essay (max. 400 words) on why you wish to come to FMCC</li>
    <li>
     <img src="Images/BlueDot.gif" width="10" height="10" />Description (max. 400 words) detailing your prior advocacy experience
     <br />
     &nbsp&nbsp;<b><font style="font-size:10px">(You are still eligible for the award if you do not have prior advocacy experience.)</font></b>
    </li>
   </ul>
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell>
   3. Click submit at the bottom of the application.
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell>
   4. You will receive a confirmation email.
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell Height="30px">&nbsp;
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell>
   <b>Questions about the scholarship?</b> Email Hope at <a href="mailto:HWittenberg@stfm.org">HWittenberg@stfm.org</a>
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell>
   <b>Questions about the application process?</b> Email Emily Wong at  <a href="mailto:ewong@stfm.org">ewong@stfm.org</a> 
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell>
   Or <b>Call our Washington Office</b> at 202-986-3309
  </asp:TableCell>
 </asp:TableRow>
</asp:Table>
<br /><br />
<asp:Table runat="server" ID="tabContactInformation">
 <asp:TableRow>
  <asp:TableCell Font-Bold="true">
   <h3>Contact Information:</h3>
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell Width="20%" HorizontalAlign="Right">
First Name:
  </asp:TableCell>
  <asp:TableCell>
 <asp:TextBox ID="txtFirstName" runat="server" />
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell Width="20%" HorizontalAlign="Right">
Last Name:
  </asp:TableCell>
  <asp:TableCell>
 <asp:TextBox ID="txtLastName" runat="server" />
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell Width="20%" HorizontalAlign="Right">
Email:
  </asp:TableCell>
  <asp:TableCell>
 <asp:TextBox ID="txtEmail" runat="server" /><asp:RegularExpressionValidator runat="server" ControlToValidate="txtEmail" ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$" ID="revEmail" ErrorMessage="Email is not in the correct format" ForeColor="Red"></asp:RegularExpressionValidator>
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell Width="20%" HorizontalAlign="Right">
Phone:
  </asp:TableCell>
  <asp:TableCell>
 <asp:TextBox ID="txtPhone" runat="server" /><asp:RegularExpressionValidator runat="server" ControlToValidate="txtPhone" ValidationExpression="^[0-9]+(-[0-9]+)*$" ID="revPhone" ErrorMessage="Phone number is not in the correct format" ForeColor="Red"></asp:RegularExpressionValidator>
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell Width="20%" HorizontalAlign="Right">
Institution:
  </asp:TableCell>
  <asp:TableCell>
 <asp:TextBox ID="txtInstitution" runat="server" />
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell Width="20%" HorizontalAlign="Right">
City:
  </asp:TableCell>
  <asp:TableCell>
 <asp:TextBox ID="txtCity" runat="server" />
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell Width="20%" HorizontalAlign="Right">
State:
  </asp:TableCell>
  <asp:TableCell>
 <asp:DropDownList runat="server" ID="ddlStates" />
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell Width="20%" HorizontalAlign="Right">
Zip:
  </asp:TableCell>
  <asp:TableCell>
 <asp:TextBox ID="txtZip" runat="server" /><asp:RegularExpressionValidator runat="server" ControlToValidate="txtZip" ValidationExpression="^(\d{5}-\d{4}|\d{5}|\d{9})$|^([a-zA-Z]\d[a-zA-Z] \d[a-zA-Z]\d)$" ID="revZip" ErrorMessage="Zip code is not in the correct format" ForeColor="Red"></asp:RegularExpressionValidator>
  </asp:TableCell>
 </asp:TableRow>
</asp:Table>
<asp:Table runat="server" ID="tabDocumentUploads">
 <asp:TableRow>
  <asp:TableCell>
Will you attend the May 14-15, 2013 conference in Washington, DC?
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell>
<asp:RadioButtonList RepeatDirection="Horizontal" ID="rblAttendConference" runat="server"><asp:ListItem Text="Yes" Value="1" /><asp:ListItem Text="No" Value="0"></asp:ListItem></asp:RadioButtonList>
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell>
Have you completed the online advocacy course?
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell>
<asp:RadioButtonList RepeatDirection="Horizontal" ID="rblCompletedAdvocacyCourse" runat="server"><asp:ListItem Text="Yes" Value="1" /><asp:ListItem Text="No" Value="0"></asp:ListItem></asp:RadioButtonList>
  </asp:TableCell>
 </asp:TableRow>
</asp:Table>
<br /><br />
<asp:Table runat="server" ID="tabUploads">
 <asp:TableRow>
  <asp:TableCell Font-Bold="true">
Upload Documents below:
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell>
CV
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell>
   <input id="inptCVDocument" type="file" runat="server" />
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell>
Why I want to attend FMCC
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell>
   <input id="inptWhyAttendDocument" type="file" runat="server" />
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell>
Chair or Program Director Letter of Recommendation
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell>
   <input id="inptDirLORDocument" type="file" runat="server" />
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell>
Prior Advocacy Experience
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell>
   <input id="inptAdvExpDocument" type="file" runat="server" />
  </asp:TableCell>
 </asp:TableRow>
</asp:Table>
<br /><br />
<asp:LinkButton ID="lbSubmit" runat="server" Text="Submit This Application" OnClick = "SubmitApplication"></asp:LinkButton>
    </div>
    </form>

    <asp:Label runat="server" ForeColor="Blue" Font-Size="24px" Text="Thank you - your application has been successfully submitted." ID="lblThankYouMessage" />
    </body>
</html>
