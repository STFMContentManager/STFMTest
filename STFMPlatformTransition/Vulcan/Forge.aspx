<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Forge.aspx.cs" Inherits="STFMPlatformTransition.ControlPanel" MaintainScrollPositionOnPostback="true" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

     <asp:Table runat="server" Width="875px" ID="tabForge" HorizontalAlign="Center" Visible="true">
      <asp:TableRow>
       <asp:TableCell ColumnSpan="3">

        <asp:Table HorizontalAlign="Left" Width="100%" CellPadding="0" CellSpacing="0" runat="server">
         <asp:TableRow>
          <asp:TableCell Width="100px">
           <img alt="" src="../Images/HephaestusForge.jpg" style="border:3px solid black" />
          </asp:TableCell>
          <asp:TableCell HorizontalAlign="Left" ColumnSpan="2" Font-Size="35px" ForeColor="DarkOrange">

           <asp:Table runat="server" Width="100%">
            <asp:TableRow>
             <asp:TableCell BackColor="#e9e9cf" style="border-top:.1ex solid #000000; border-bottom:.1ex solid #000000">
              &nbsp;The Forge
             </asp:TableCell>
            </asp:TableRow>
           </asp:Table>
          
          </asp:TableCell>
         </asp:TableRow>
        </asp:Table>

       <asp:Table ID="tabView" Width="100%" HorizontalAlign="Left" runat="server">
        <asp:TableRow>
        <asp:TableCell Width="50%">

       <br />
       <asp:Label ID="lblMessage" Font-Size="18px" ForeColor="Blue" runat="server" />
       <br /><asp:LinkButton runat="server" ID="lbForgeLogOut" OnClick="Logout" Text="Log out of Vulcan" /><br /><br />


        <asp:Table ID="tabSearch" BackColor="#ddffdd" Width="100%" runat="server">
        <asp:TableRow>
         <asp:TableCell ForeColor="Red" Font-Size="18px" ColumnSpan="4" style="border-bottom:solid .1ex #000000">
         Search
         </asp:TableCell>
        </asp:TableRow>
       <asp:TableRow>
        <asp:TableCell Width="90px" HorizontalAlign="Left">
        Search Filter:
        </asp:TableCell>
        <asp:TableCell ColumnSpan="2">
        <asp:RadioButtonList ID="rblSearchOptions" RepeatDirection="Horizontal" runat="server" ForeColor="Blue"><asp:ListItem Value="Section" Text="Section" /><asp:ListItem Value="Page" Text="Page" /><asp:ListItem Value="Content" Text="Content" /><asp:ListItem Value="DateCreated" Text="Date Created" /><asp:ListItem Value="CreatedBy" Text="Created By" /></asp:RadioButtonList>
        </asp:TableCell>
       </asp:TableRow>
         <asp:TableRow>
        <asp:TableCell Width="90px" HorizontalAlign="Left">
         Search Text:
        </asp:TableCell>
        <asp:TableCell Width="10%">
         &nbsp;&nbsp;<asp:TextBox ID="txtSearch" BorderStyle="solid" BorderColor="#000000" BorderWidth=".1ex" BackColor="#e8e8e8" runat="server"></asp:TextBox>
        </asp:TableCell>
        <asp:TableCell>
        <asp:LinkButton ID="lbSearch" OnClick="FindPage" Font-Size="12px" runat="server">Click Here to Search</asp:LinkButton>
        </asp:TableCell>
       </asp:TableRow>
       <asp:TableRow>
        <asp:TableCell ColumnSpan="4">
          <asp:Label runat="server" ID="lblSearchMessage" />
          </asp:TableCell>
         </asp:TableRow>
        </asp:Table>

        </asp:TableCell>
        </asp:TableRow>
        </asp:Table>


       <br /><hr /><br />

       <asp:Table Width="100%" BackColor="#ffffcc" CellPadding="6" runat="server">
        <asp:TableRow>
         <asp:TableCell>



        <asp:Table ID="tabPageDropDowns" Width="100%" runat="server">
         <asp:TableRow>
          <asp:TableCell ForeColor="Red" Font-Size="18px" ColumnSpan="3" style="border-bottom:solid .1ex #000000">View Published Pages</asp:TableCell>
         </asp:TableRow>
         <asp:TableRow>
          <asp:TableCell Width="22%" VerticalAlign="Top">
           Choose a page to view:
          </asp:TableCell>
          <asp:TableCell HorizontalAlign="Left" VerticalAlign="Top">
           <asp:DropDownList AutoPostBack="true" OnSelectedIndexChanged="ViewPage" runat="server" ID="ddlPagesPublished"></asp:DropDownList>
          </asp:TableCell>
            <asp:TableCell VerticalAlign="Top">
             Filter by section:
            </asp:TableCell>
            <asp:TableCell>
             <asp:RadioButtonList RepeatDirection="Vertical" ID="rblSectionFilter" AutoPostBack="true" OnSelectedIndexChanged="FilterPublishedPages" runat="server"><asp:ListItem Value="About Us" Text="About Us"></asp:ListItem><asp:ListItem Value="NewsJournals" Text="News & Journals"></asp:ListItem><asp:ListItem Value="Conferences" Text="Conferences"></asp:ListItem><asp:ListItem Value="Faculty Resources" Text="Faculty Resources"></asp:ListItem><asp:ListItem Value="Professional Development" Text="Professional Development"></asp:ListItem><asp:ListItem Value="Advocacy" Text="Advocacy"></asp:ListItem><asp:ListItem Value="Research" Text="Research"></asp:ListItem><asp:ListItem Value="Groups" Text="Groups"></asp:ListItem><asp:ListItem Value="Foundation" Text="Foundation"></asp:ListItem></asp:RadioButtonList>
            </asp:TableCell>
         </asp:TableRow>
        </asp:Table>

       
       </asp:TableCell>
       </asp:TableRow>
       <asp:TableRow>
       <asp:TableCell>


        <asp:Table ID="tabPagesNotPublished" Width="100%" runat="server">
         <asp:TableRow>
          <asp:TableCell ForeColor="Red" Font-Size="18px" ColumnSpan="3" style="border-bottom:solid .1ex #000000">View Pages Not Published</asp:TableCell>
         </asp:TableRow>
         <asp:TableRow>
          <asp:TableCell Width="22%">
           Choose a page to view:
          </asp:TableCell>
          <asp:TableCell HorizontalAlign="Left">
           <asp:DropDownList AutoPostBack="true" OnSelectedIndexChanged="ViewPage" runat="server" ID="ddlPagesNotPublished"></asp:DropDownList>
          </asp:TableCell>
         </asp:TableRow>
        </asp:Table>

       
       </asp:TableCell>
       </asp:TableRow>
       <asp:TableRow>
       <asp:TableCell>


        <asp:Table ID="Table3" Width="100%" runat="server">
         <asp:TableRow>
          <asp:TableCell ForeColor="Red" Font-Size="18px" ColumnSpan="3" style="border-bottom:solid .1ex #000000">View Page Templates</asp:TableCell>
         </asp:TableRow>
         <asp:TableRow>
          <asp:TableCell Width="22%">
           Choose a template to view:
          </asp:TableCell>
          <asp:TableCell HorizontalAlign="Left">
           <asp:DropDownList AutoPostBack="true" OnSelectedIndexChanged="ViewTemplate" runat="server" ID="ddlTemplates">
            <asp:ListItem Value=""></asp:ListItem>
            <asp:ListItem Value="HomepageTemplate">Homepage</asp:ListItem>
            <asp:ListItem Value="OneColumnTemplate">One Column (Middle)</asp:ListItem>
            <asp:ListItem Value="TwoColumnTemplate">Two Columns (Left)</asp:ListItem>
            <asp:ListItem Value="TwoColumnTemplate">Two Columns (Right)</asp:ListItem>
            <asp:ListItem Value="ThreeColumnTemplate">Three Columns</asp:ListItem>
           </asp:DropDownList>
          </asp:TableCell>
         </asp:TableRow>
        </asp:Table>

       
        </asp:TableCell>
       </asp:TableRow>
      </asp:Table>


       <br /><hr /><br />

        <asp:Table BackColor="#ddddff" Width="100%" CellPadding="6" runat="server">
         <asp:TableRow>
          <asp:TableCell Width="40%" VerticalAlign="Top">


       <asp:Table ID="tabPage" Width="100%" runat="server">
        <asp:TableRow>
         <asp:TableCell ForeColor="Red" Font-Size="18px" ColumnSpan="2">
          Add a page
         </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
         <asp:TableCell Width="22%">
       
        Choose a template to use:
         
         </asp:TableCell>
         <asp:TableCell>
       
        &nbsp;<asp:DropDownList AutoPostBack="true" runat="server" ID="ddlAddPageTemplate">
         <asp:ListItem Value=""></asp:ListItem>
         <asp:ListItem Value="HomepageTemplate">Homepage</asp:ListItem>
         <asp:ListItem Value="OneColumnTemplate">One Column (Middle)</asp:ListItem>
         <asp:ListItem Value="TwoColumnTemplate">Two Columns (Left)</asp:ListItem>
         <asp:ListItem Value="TwoColumnTemplate">Two Columns (Right)</asp:ListItem>
         <asp:ListItem Value="ThreeColumnTemplate">Three Columns</asp:ListItem>
        </asp:DropDownList>
        
         </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
         <asp:TableCell Width="22%">
        
          Page Name (no extension):
         
         </asp:TableCell>
         <asp:TableCell>
        
          &nbsp;<asp:TextBox ID="txtPageName" BorderStyle="solid" BorderColor="#000000" BorderWidth=".1ex" BackColor="#e8e8e8" runat="server"></asp:TextBox>&nbsp;.aspx
         
         </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
         <asp:TableCell Width="22%">
        
          Page Title:
         
         </asp:TableCell>
         <asp:TableCell>
        
          &nbsp;<asp:TextBox ID="txtPageTitle" BorderStyle="solid" BorderColor="#000000" BorderWidth=".1ex" BackColor="#e8e8e8" runat="server"></asp:TextBox>
         
         </asp:TableCell>
        </asp:TableRow>
       </asp:Table>

        
        </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
        <asp:TableCell VerticalAlign="Top">


          <asp:Table ID="Table1" runat="server">
           <asp:TableRow>
            <asp:TableCell ForeColor="Red" Font-Size="18px" ColumnSpan="2">
             Assign a Section
            </asp:TableCell>
           </asp:TableRow>
           <asp:TableRow>
            <asp:TableCell VerticalAlign="Top">
             Select a section(s):
            </asp:TableCell>
            <asp:TableCell>
             <asp:RadioButtonList RepeatDirection="Vertical" ID="rblSection" runat="server"><asp:ListItem Value="About Us" Text="About Us"></asp:ListItem><asp:ListItem Value="NewsJournals" Text="News & Journals"></asp:ListItem><asp:ListItem Value="Conferences" Text="Conferences"></asp:ListItem><asp:ListItem Value="Faculty Resources" Text="Faculty Resources"></asp:ListItem><asp:ListItem Value="Professional Development" Text="Professional Development"></asp:ListItem><asp:ListItem Value="Advocacy" Text="Advocacy"></asp:ListItem><asp:ListItem Value="Research" Text="Research"></asp:ListItem><asp:ListItem Value="Groups" Text="Groups"></asp:ListItem><asp:ListItem Value="Foundation" Text="Foundation"></asp:ListItem></asp:RadioButtonList>
            </asp:TableCell>
           </asp:TableRow>
          </asp:Table>

        
        </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
        <asp:TableCell ColumnSpan="2" VerticalAlign="Top">

       <asp:Table ID="Table2" Width="100%" runat="server">
        <asp:TableRow>
         <asp:TableCell ForeColor="Red" Font-Size="18px" ColumnSpan="2">
          Set Page Availability
         </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
         <asp:TableCell Width="25%">
          Start Date:
         </asp:TableCell>
         <asp:TableCell>&nbsp;</asp:TableCell>
         <asp:TableCell>
          End Date:
         </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
         <asp:TableCell>
         <asp:Calendar ID="calContentStartDate" BackColor="#ffffff" runat="server" />
         </asp:TableCell>
         <asp:TableCell>&nbsp;</asp:TableCell>
         <asp:TableCell>
         <asp:Calendar ID="calContentEndDate" BackColor="#ffffff" ShowNextPrevMonth="true" runat="server" />
         </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
         <asp:TableCell ColumnSpan="3">
          * leaving the start date blank will cause the page to show up as soon as it's published<br />
          * leaving the end date blank will cause the page to never be unavailable<br />
          * leaving both the start and end date blank will cause the page to show up as soon as it's published and never be unavailable <br />
         </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
         <asp:TableCell VerticalAlign="Bottom" Height="30px">
          <asp:LinkButton ID="lbAddPage" OnClick="AddPage" runat="server" Font-Size="12px">Click to add page</asp:LinkButton>
         </asp:TableCell>
        </asp:TableRow>
       </asp:Table>


       </asp:TableCell>
      </asp:TableRow>
     </asp:Table>


       <br /><hr /><br />

        <asp:Table ID="Table4" BackColor="#ffdddd" Width="100%" CellPadding="6" runat="server">
         <asp:TableRow>
          <asp:TableCell Width="40%" VerticalAlign="Top">


       <asp:Table ID="Table5" Width="100%" runat="server">
        <asp:TableRow>
         <asp:TableCell ForeColor="Red" Font-Size="18px" ColumnSpan="2">
          Change Page Availability
         </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
         <asp:TableCell Width="22%">
       
        Choose a page:
         
         </asp:TableCell>
         <asp:TableCell>
       
        &nbsp;<asp:DropDownList runat="server" ID="ddlContentPagesWithDateConstraint" />
        
         </asp:TableCell>
        </asp:TableRow>
       </asp:Table>

        
        </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
        <asp:TableCell ColumnSpan="2" VerticalAlign="Top">

       <asp:Table ID="Table7" Width="100%" runat="server">
        <asp:TableRow>
         <asp:TableCell ForeColor="Red" Font-Size="18px" ColumnSpan="2">
          Set Page Start and End Dates
         </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
         <asp:TableCell Width="25%">
          Start Date:
         </asp:TableCell>
         <asp:TableCell>&nbsp;</asp:TableCell>
         <asp:TableCell>
          End Date:
         </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
         <asp:TableCell>
         <asp:Calendar ID="calChangePageStartDate" BackColor="#ffffff" runat="server" />
         </asp:TableCell>
         <asp:TableCell>&nbsp;</asp:TableCell>
         <asp:TableCell>
         <asp:Calendar ID="calChangePageEndDate" BackColor="#ffffff" ShowNextPrevMonth="true" runat="server" />
         </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
         <asp:TableCell ColumnSpan="3">
          * leaving the start date blank will cause the page to show up as soon as it's published<br />
          * leaving the end date blank will cause the page to never be unavailable<br />
          * leaving both the start and end date blank will cause the page to show up as soon as it's published and never be unavailable <br />
         </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
         <asp:TableCell VerticalAlign="Bottom" Height="30px">
          <asp:LinkButton ID="lbChangePageAvailability" OnClick="ChangePageAvailability" runat="server" Font-Size="12px">Click to change page availability</asp:LinkButton>
         </asp:TableCell>
        </asp:TableRow>
       </asp:Table>


       </asp:TableCell>
      </asp:TableRow>
     </asp:Table>


       <br /><hr /><br />

       </asp:TableCell>
      </asp:TableRow>
     </asp:Table>

    </div>
    </form>
</body>
</html>

