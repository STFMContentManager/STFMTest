<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ISIS.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .txtBox { border: solid .1ex #bbbbbb }
        .lblYear { color: Blue }     
        .lblQFont { font-size: 12px }
        .lblQPadding { padding-left: 8px }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>

      <asp:Table runat="server" Width="100%" ID="tabHeader">
       <asp:TableRow>
        <asp:TableCell Width="45%" style="font-size:30px; color:#000000; border-bottom: solid .1ex #0000aa">
         Society of Teachers of Family Medicine Project Inventory <font color="red">Edit Projects</font>
        </asp:TableCell>
       </asp:TableRow>
      </asp:Table>
      
      <br />

      <asp:Table ID="tabMenu" Width="25%" runat="server">
      <asp:TableRow>
       <asp:TableCell>
       <asp:Image runat="server" ID="imgAdminIcon" ImageUrl="~/Images/Admin_Icon.gif" />&nbsp;<asp:LinkButton runat="server" ID="lbManageProjects" OnClick="ManageProjects" Text="Manage Projects" />
       </asp:TableCell>
       <asp:TableCell>
       &nbsp;<asp:Image runat="server" ID="imgReportIcon" Width="26" Height="26" ImageUrl="~/Images/Report_Icon.gif" />&nbsp;<asp:LinkButton runat="server" ID="LinkButton1" Text="View Inventory Report" OnClick="ViewInventoryReport"></asp:LinkButton>
       </asp:TableCell>
      </asp:TableRow>
    </asp:Table>

    <br /><br />
    
    <asp:Table runat="server" ID="tabPreviousYear">
       <asp:TableRow>
        <asp:TableCell>
         <asp:Label runat="server" ID="lblProjActNames" Text="Project Name" />
        </asp:TableCell>
        <asp:TableCell>
         <asp:DropDownList DataTextField="ProjectName" DataValueField="Id" AutoPostBack="true" OnSelectedIndexChanged="GetProject" runat="server" ID="ddlProjectActNames" />
        </asp:TableCell>
       </asp:TableRow>
       <asp:TableRow>
        <asp:TableCell>&nbsp;</asp:TableCell>
       </asp:TableRow>
       <asp:TableRow>
        <asp:TableCell VerticalAlign="Top">
         <asp:Label runat="server" ID="lblStaffTime" Text="Staff Time" />
        </asp:TableCell>
       <asp:TableCell>
        <asp:RadioButtonList runat="server" ID="rblStaffTime">
         <asp:ListItem Value="1" Text="Low"></asp:ListItem>
         <asp:ListItem Value="2" Text="Mod"></asp:ListItem>
         <asp:ListItem Value="3" Text="High"></asp:ListItem>
        </asp:RadioButtonList>
       </asp:TableCell>
      </asp:TableRow>
      </asp:Table>
      
      <br /><br />

      <asp:Table runat="server">
       <asp:TableRow>
        <asp:TableCell ColumnSpan="2">
         <asp:Label ID="lblYearPrevious" CssClass="lblYear" runat="server" />
        </asp:TableCell>
       </asp:TableRow>
       <asp:TableRow>
        <asp:TableCell ColumnSpan="2">

        <br />

         <asp:Table ID="tabNumPartsPrevious" runat="server">
          <asp:TableRow>
           <asp:TableCell>
            <asp:Label runat="server" ID="lblNumPartsPrevious" Text="# Participants" />
           </asp:TableCell>
           <asp:TableCell>
            <asp:TextBox CssClass="txtBox" runat="server" ID="txtNumPartsPrevious" />
           </asp:TableCell>
          </asp:TableRow>
         </asp:Table>

        <br />

       </asp:TableCell>
       </asp:TableRow>
       <asp:TableRow>
        <asp:TableCell>

        <asp:Table ID="tabNetProfitPrevious" runat="server">
         <asp:TableRow>
          <asp:TableCell Width="90px">
          </asp:TableCell>
          <asp:TableCell CssClass="lblQPadding">
           <asp:Label CssClass="lblQFont" ID="lblNetProfitPreviousQ1" Text="Q1" runat="server" />
          </asp:TableCell>
          <asp:TableCell CssClass="lblQPadding">
           <asp:Label CssClass="lblQFont" ID="lblNetProfitPreviousQ2" Text="Q2" runat="server" />
          </asp:TableCell>
          <asp:TableCell CssClass="lblQPadding">
           <asp:Label CssClass="lblQFont" ID="lblNetProfitPreviousQ3" Text="Q3" runat="server" />
          </asp:TableCell>
          <asp:TableCell CssClass="lblQPadding">
           <asp:Label CssClass="lblQFont" ID="lblNetProfitPreviousQ4" Text="Q4" runat="server" />
          </asp:TableCell>
         </asp:TableRow>
         <asp:TableRow>
          <asp:TableCell HorizontalAlign="Right">
           <asp:Label runat="server" ID="lblNetProfitPrevious" Text="Net Profit" />
          </asp:TableCell>
          <asp:TableCell>
           <asp:TextBox CssClass="txtBox" ID="txtNetProfitPreviousQ1" runat="server" />
          </asp:TableCell>
          <asp:TableCell>
           <asp:TextBox CssClass="txtBox" ID="txtNetProfitPreviousQ2" runat="server" />
          </asp:TableCell>
          <asp:TableCell>
           <asp:TextBox CssClass="txtBox" ID="txtNetProfitPreviousQ3" runat="server" />
          </asp:TableCell>
          <asp:TableCell>
           <asp:TextBox CssClass="txtBox" ID="txtNetProfitPreviousQ4" runat="server" />
          </asp:TableCell>
         </asp:TableRow>
        </asp:Table>

        </asp:TableCell>
       </asp:TableRow>
     </asp:Table>    

      <br /><br />

      <asp:Table ID="Table1" runat="server">
       <asp:TableRow>
        <asp:TableCell ColumnSpan="2">
         <asp:Label ID="lblYearCurrent" CssClass="lblYear" runat="server" />
        </asp:TableCell>
       </asp:TableRow>
       <asp:TableRow>
        <asp:TableCell ColumnSpan="2">

        <br />

         <asp:Table ID="tabNumPartsCurrent" runat="server">
          <asp:TableRow>
           <asp:TableCell>
            <asp:Label runat="server" ID="lblNumPartsCurrent" Text="# Participants" />
           </asp:TableCell>
           <asp:TableCell>
            <asp:TextBox CssClass="txtBox" runat="server" ID="txtNumPartsCurrent" />
           </asp:TableCell>
          </asp:TableRow>
         </asp:Table>

        <br />

       </asp:TableCell>
       </asp:TableRow>
       <asp:TableRow>
        <asp:TableCell>

        <asp:Table ID="tabNetProfitCurrent" runat="server">
         <asp:TableRow>
          <asp:TableCell Width="90px">
          </asp:TableCell>
          <asp:TableCell CssClass="lblQPadding">
           <asp:Label CssClass="lblQFont" ID="lblNetProfitCurrentQ1" Text="Q1" runat="server" />
          </asp:TableCell>
          <asp:TableCell CssClass="lblQPadding">
           <asp:Label CssClass="lblQFont" ID="lblNetProfitCurrentQ2" Text="Q2" runat="server" />
          </asp:TableCell>
          <asp:TableCell CssClass="lblQPadding">
           <asp:Label CssClass="lblQFont" ID="lblNetProfitCurrentQ3" Text="Q3" runat="server" />
          </asp:TableCell>
          <asp:TableCell CssClass="lblQPadding">
           <asp:Label CssClass="lblQFont" ID="lblNetProfitCurrentQ4" Text="Q4" runat="server" />
          </asp:TableCell>
         </asp:TableRow>
         <asp:TableRow>
          <asp:TableCell HorizontalAlign="Right">
           <asp:Label runat="server" ID="lblNetProfitCurrent" Text="Net Profit" />
          </asp:TableCell>
          <asp:TableCell>
           <asp:TextBox CssClass="txtBox" ID="txtNetProfitCurrentQ1" runat="server" />
          </asp:TableCell>
          <asp:TableCell>
           <asp:TextBox CssClass="txtBox" ID="txtNetProfitCurrentQ2" runat="server" />
          </asp:TableCell>
          <asp:TableCell>
           <asp:TextBox CssClass="txtBox" ID="txtNetProfitCurrentQ3" runat="server" />
          </asp:TableCell>
          <asp:TableCell>
           <asp:TextBox CssClass="txtBox" ID="txtNetProfitCurrentQ4" runat="server" />
          </asp:TableCell>
         </asp:TableRow>
        </asp:Table>

        </asp:TableCell>
       </asp:TableRow>
     </asp:Table>    

      <br /><br />

      <asp:Table ID="Table4" runat="server">
       <asp:TableRow>
        <asp:TableCell ColumnSpan="2">
         <asp:Label ID="lblYearNext" CssClass="lblYear" runat="server" />
        </asp:TableCell>
       </asp:TableRow>
       <asp:TableRow>
        <asp:TableCell ColumnSpan="2">

        <br />

         <asp:Table ID="tabNumPartsNext" runat="server">
          <asp:TableRow>
           <asp:TableCell>
            <asp:Label runat="server" ID="lblNumPartsNext" Text="# Participants" />
           </asp:TableCell>
           <asp:TableCell>
            <asp:TextBox CssClass="txtBox" runat="server" ID="txtNumPartsNext" />
           </asp:TableCell>
          </asp:TableRow>
         </asp:Table>

        <br />

       </asp:TableCell>
       </asp:TableRow>
       <asp:TableRow>
        <asp:TableCell>

        <asp:Table ID="Table6" runat="server">
         <asp:TableRow>
          <asp:TableCell Width="90px">
          </asp:TableCell>
          <asp:TableCell CssClass="lblQPadding">
           <asp:Label CssClass="lblQFont" ID="lblNetProfitNextQ1" Text="Q1" runat="server" />
          </asp:TableCell>
          <asp:TableCell CssClass="lblQPadding">
           <asp:Label CssClass="lblQFont" ID="lblNetProfitNextQ2" Text="Q2" runat="server" />
          </asp:TableCell>
          <asp:TableCell CssClass="lblQPadding">
           <asp:Label CssClass="lblQFont" ID="lblNetProfitNextQ3" Text="Q3" runat="server" />
          </asp:TableCell>
          <asp:TableCell CssClass="lblQPadding">
           <asp:Label CssClass="lblQFont" ID="lblNetProfitNextQ4" Text="Q4" runat="server" />
          </asp:TableCell>
         </asp:TableRow>
         <asp:TableRow>
          <asp:TableCell HorizontalAlign="Right">
           <asp:Label runat="server" ID="lblNetProfitNext" Text="Net Profit" />
          </asp:TableCell>
          <asp:TableCell>
           <asp:TextBox CssClass="txtBox" ID="txtNetProfitNextQ1" runat="server" />
          </asp:TableCell>
          <asp:TableCell>
           <asp:TextBox CssClass="txtBox" ID="txtNetProfitNextQ2" runat="server" />
          </asp:TableCell>
          <asp:TableCell>
           <asp:TextBox CssClass="txtBox" ID="txtNetProfitNextQ3" runat="server" />
          </asp:TableCell>
          <asp:TableCell>
           <asp:TextBox CssClass="txtBox" ID="txtNetProfitNextQ4" runat="server" />
          </asp:TableCell>
         </asp:TableRow>
        </asp:Table>

        </asp:TableCell>
       </asp:TableRow>
     </asp:Table>
     
     <br />

     <asp:Table ID="tabImpactComments" runat="server">
       <asp:TableRow>
        <asp:TableCell>
         <asp:Label runat="server" ID="lblImpact" Text="Impact" />
        </asp:TableCell>
       </asp:TableRow>
       <asp:TableRow>
        <asp:TableCell>
        <textarea rows="4" cols="100" id="taImpact" runat="server"></textarea>
        </asp:TableCell>
       </asp:TableRow>
       <asp:TableRow>
        <asp:TableCell ColumnSpan="2">
         <asp:Label runat="server" ID="lblComments" Text="Significant Activities/Comments" />
        </asp:TableCell>
       </asp:TableRow>
       <asp:TableRow>
       <asp:TableCell ColumnSpan="2">
        <textarea rows="4" cols="100" id="taComments" runat="server"></textarea>
       </asp:TableCell>
       </asp:TableRow>
      </asp:Table>

    <br /><br />

    <asp:Button runat="server" ID="btnSave" Text="Save Changes" OnClick="SaveChanges" />
    
    <br /><br /><br />

    </div>
    </form>
</body>
</html>
