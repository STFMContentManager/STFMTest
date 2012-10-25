<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageProjects.aspx.cs" Inherits="ISIS.ManageProjects" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

      <asp:Table runat="server" Width="100%" ID="tabHeader">
       <asp:TableRow>
        <asp:TableCell Width="45%" style="font-size:30px; color:#000000; border-bottom: solid .1ex #0000aa">
         Society of Teachers of Family Medicine Project Inventory <font color="red">Manage Projects</font>
        </asp:TableCell>
       </asp:TableRow>
      </asp:Table>
      
      <br />

      <asp:Table ID="tabMenu" Width="25%" runat="server">
      <asp:TableRow>
       <asp:TableCell>
       <asp:Image runat="server" ID="imgHomeIcon" ImageUrl="~/Images/Edit_Report_Icon.gif" />&nbsp;<asp:LinkButton runat="server" ID="LinkButton6" Text="Edit Projects" OnClick="GoHome"></asp:LinkButton>
       </asp:TableCell>
       <asp:TableCell>
       &nbsp;<asp:Image runat="server" ID="imgReportIcon" Width="26" Height="26" ImageUrl="~/Images/Report_Icon.gif" />&nbsp;<asp:LinkButton runat="server" ID="LinkButton1" Text="View Inventory Report" OnClick="ViewInventoryReport"></asp:LinkButton>
       </asp:TableCell>
      </asp:TableRow>
    </asp:Table>

    <br /><br />
    
    <asp:Table runat="server" ID="tabProjectCreate">
     <asp:TableRow>
      <asp:TableCell>
       <asp:Label runat="server" ID="lblCreateProjectName" Text="New Project Name:" />
      </asp:TableCell>
      <asp:TableCell>
       <asp:TextBox runat="server" ID="txtCreateProjectName" />
      </asp:TableCell>
     </asp:TableRow>
     <asp:TableRow>
      <asp:TableCell>
       <asp:Button runat="server" Text="Create Project" OnClick="CreateProject" />
      </asp:TableCell>
     </asp:TableRow>
    </asp:Table>

    <br /><br />

    <asp:Table runat="server" ID="tabProjectRename">
     <asp:TableRow>
      <asp:TableCell>
       <asp:Label runat="server" Text="Project to Rename:" ID="lblRenameProjectName"></asp:Label>
      </asp:TableCell>
      <asp:TableCell>
       <asp:DropDownList DataTextField="ProjectName" DataValueField="Id" runat="server" ID="ddlRenameProjectNames" />
      </asp:TableCell>
     </asp:TableRow>
     <asp:TableRow>
      <asp:TableCell>
       <asp:Label runat="server" Text="Project New Name:" ID="lblRenameProjectNewName"></asp:Label>
      </asp:TableCell>
      <asp:TableCell>
       <asp:TextBox runat="server" ID="txtRenameProjectNewName"></asp:TextBox>
      </asp:TableCell>
     </asp:TableRow>
     <asp:TableRow>
      <asp:TableCell>
       <asp:Button ID="Button2" runat="server" Text="Rename Project" OnClick="RenameProject" />
      </asp:TableCell>
     </asp:TableRow>
    </asp:Table>
    
    <br /><br />

    <asp:Table runat="server" ID="tabProjectRemove">
     <asp:TableRow>
      <asp:TableCell>
       <asp:Label runat="server" Text="Project to Remove:" ID="lblRemoveProjectName"></asp:Label>
      </asp:TableCell>
      <asp:TableCell>
       <asp:DropDownList DataTextField="ProjectName" DataValueField="Id" runat="server" ID="ddlRemoveProjectNames" />
      </asp:TableCell>
     </asp:TableRow>
     <asp:TableRow>
      <asp:TableCell>
       <asp:Button ID="Button4" runat="server" Text="Remove Project" OnClick="RemoveProject" />
      </asp:TableCell>
     </asp:TableRow>
    </asp:Table>
    
    <br /><br />

    <asp:Table ID="tabMessage" HorizontalAlign="Center" runat="server" Visible="false">
     <asp:TableRow>
      <asp:TableCell HorizontalAlign="Center">
       <asp:Label runat="server" ID="lblMessage"></asp:Label>
      </asp:TableCell>
     </asp:TableRow>
     <asp:TableRow>
      <asp:TableCell HorizontalAlign="Center">
       <asp:Button runat="server" ID="btnMessage" Text="Manage Projects" OnClick="GoManageProjects"></asp:Button>
      </asp:TableCell>
     </asp:TableRow>
    </asp:Table>

    </div>
    </form>
</body>
</html>
