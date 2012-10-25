<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="STFMPlatformTransition.Vulcan" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <br /><br />
    <center><asp:Label runat="server" ForeColor="Red" Font-Size="18px" ID="lblMessage"></asp:Label><br /></center>
    <br /><br />
     <asp:Table ID="Table1" HorizontalAlign="Center" BackColor="#eeeeff" BorderColor="#000000" BorderWidth=".1ex" CellPadding="6" runat="server">
      <asp:TableRow>
       <asp:TableCell HorizontalAlign="Center">
        <img alt="" src="/Images/Hephaestus.jpg" width="320px" height="450px" style="filter:alpha(opacity=60);" />
       </asp:TableCell>
       <asp:TableCell>
       
        <asp:Table ID="Table2" HorizontalAlign="Center" runat="server">
         <asp:TableRow>
          <asp:TableCell>
           <p style="font-size:30px; text-align:center; color:DarkOrange">VULCAN</p>
          </asp:TableCell>
         </asp:TableRow>
         <asp:TableRow>
          <asp:TableCell>
           <asp:Label runat="server" ID="lblUserIDTitle">User ID</asp:Label>
          </asp:TableCell>
         </asp:TableRow>
         <asp:TableRow>
          <asp:TableCell>
           <asp:TextBox runat="server" ID="txtUserID"></asp:TextBox>
          </asp:TableCell>
         </asp:TableRow>
         <asp:TableRow>
          <asp:TableCell>
           <asp:Label runat="server" ID="lblUserPwdTitle">User Password</asp:Label>
          </asp:TableCell>
         </asp:TableRow>
         <asp:TableRow>
          <asp:TableCell>
           <asp:TextBox runat="server" ID="txtPassword" TextMode="Password"></asp:TextBox>
          </asp:TableCell>
         </asp:TableRow>
         <asp:TableRow>
          <asp:TableCell>
           <asp:LinkButton ID="LinkButton1" OnClick="CheckLoginCredentials" runat="server" Text="Login"></asp:LinkButton>
          </asp:TableCell>
         </asp:TableRow>
        </asp:Table>
       
       </asp:TableCell>
      </asp:TableRow>
     </asp:Table>

      </asp:TableCell>
     </asp:TableRow>
    </asp:Table>

    </div>
    </form>
</body>
</html>

