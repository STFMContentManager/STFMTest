<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FullInventoryReport.ascx.cs" Inherits="ISIS.Controls.FullInventoryReport" %>

<asp:Repeater ID="repReports" runat="server">
     <ItemTemplate>
     
      <asp:Table ID="tabPreviousYear" runat="server">
       <asp:TableRow>
        <asp:TableCell>
         <asp:Label runat="server" Font-Bold="true" ID="lblProjActNames" Text="Project Name:" />
        </asp:TableCell>
        <asp:TableCell>
         &nbsp;<asp:Label runat="server" ForeColor="Crimson" ID="lblProjectName" Text=<%# DataBinder.Eval (Container.DataItem, "ProjectName") %> />
        </asp:TableCell>
        <asp:TableCell>
         &nbsp;&nbsp;<asp:Label runat="server" Font-Bold="true" ID="lblStaffTimeTitle" Text="Staff Time:" />
        </asp:TableCell>
       <asp:TableCell>
        &nbsp;<asp:Label  runat="server" ID="lblStaffTime" Text=<%# DataBinder.Eval (Container.DataItem, "StaffTimeDisplay") %> />
       </asp:TableCell>
      </asp:TableRow>
      </asp:Table>
      
      <asp:Table ID="Table1" runat="server">
       <asp:TableRow>
        <asp:TableCell ColumnSpan="2">


         <asp:Table ID="tabNumPartsPrevious" Width="500px" runat="server" CellPadding="4" BorderColor="#000000" BorderWidth="1">
          <asp:TableRow>
           <asp:TableCell>
         &nbsp;&nbsp;<asp:Label ID="lblYearPrevious" CssClass="lblYear" runat="server" Text=<%# DataBinder.Eval (Container.DataItem, "PreviousYear") %> />
           </asp:TableCell>
           <asp:TableCell>
           </asp:TableCell>
           <asp:TableCell Width="90px">
           </asp:TableCell>
           <asp:TableCell CssClass="lblQPadding" HorizontalAlign="Center">
            <asp:Label CssClass="lblQFont" ID="lblNetProfitPreviousQ1Title" Text="Q1" runat="server" />
           </asp:TableCell>
           <asp:TableCell CssClass="lblQPadding" HorizontalAlign="Center">
            <asp:Label CssClass="lblQFont" ID="lblNetProfitPreviousQ2Title" Text="Q2" runat="server" />
           </asp:TableCell>
           <asp:TableCell CssClass="lblQPadding" HorizontalAlign="Center">
            <asp:Label CssClass="lblQFont" ID="lblNetProfitPreviousQ3Title" Text="Q3" runat="server" />
           </asp:TableCell>
           <asp:TableCell CssClass="lblQPadding" HorizontalAlign="Center">
            <asp:Label CssClass="lblQFont" ID="lblNetProfitPreviousQ4Title" Text="Q4" runat="server" />
           </asp:TableCell>
          </asp:TableRow>
          <asp:TableRow>
           <asp:TableCell>
            <asp:Label runat="server" ID="lblNumPartsPreviousTitle" Font-Bold="true" Text="# Participants: " />
           </asp:TableCell>
           <asp:TableCell HorizontalAlign="Center">
            <asp:Label  runat="server" ID="lblNumPartsPrevious" Text=<%# DataBinder.Eval (Container.DataItem, "NumPartsPrevious") %> />
           </asp:TableCell>
           <asp:TableCell HorizontalAlign="Right">
            <asp:Label runat="server" ID="lblNetProfitPrevious" Font-Bold="true" Text="Net Profit: " />
           </asp:TableCell>
           <asp:TableCell HorizontalAlign="Center">
            <asp:Label  ID="lblNetProfitPreviousQ1" runat="server" Text=<%# String.Format("{0:C}", DataBinder.Eval (Container.DataItem, "NetProfitPreviousQ1")) %> />
           </asp:TableCell>
           <asp:TableCell HorizontalAlign="Center">
            <asp:Label  ID="lblNetProfitPreviousQ2" runat="server" Text=<%# String.Format("{0:C}", DataBinder.Eval (Container.DataItem, "NetProfitPreviousQ2")) %> />
           </asp:TableCell>
           <asp:TableCell HorizontalAlign="Center">
            <asp:Label  ID="lblNetProfitPreviousQ3" runat="server" Text=<%# String.Format("{0:C}", DataBinder.Eval (Container.DataItem, "NetProfitPreviousQ3")) %> />
           </asp:TableCell>
           <asp:TableCell HorizontalAlign="Center">
            <asp:Label  ID="lblNetProfitPreviousQ4" runat="server" Text=<%# String.Format("{0:C}", DataBinder.Eval (Container.DataItem, "NetProfitPreviousQ4")) %> />
           </asp:TableCell>
          </asp:TableRow>
         </asp:Table>

       </asp:TableCell>
        <asp:TableCell ColumnSpan="2">

         <asp:Table ID="tabNumPartsCurrent" Width="500px" runat="server" CellPadding="4" BorderColor="#000000" BorderWidth="1">
          <asp:TableRow>
          <asp:TableCell>
         &nbsp;&nbsp;<asp:Label ID="lblYearCurrent" CssClass="lblYear" runat="server" Text=<%# DataBinder.Eval (Container.DataItem, "CurrentYear") %> />
          </asp:TableCell>
          <asp:TableCell>
          </asp:TableCell>
          <asp:TableCell Width="90px">
          </asp:TableCell>
          <asp:TableCell CssClass="lblQPadding" HorizontalAlign="Center">
           <asp:Label CssClass="lblQFont" ID="lblNetProfitCurrentQ1Title" Text="Q1" runat="server" />
          </asp:TableCell>
          <asp:TableCell CssClass="lblQPadding" HorizontalAlign="Center">
           <asp:Label CssClass="lblQFont" ID="lblNetProfitCurrentQ2Title" Text="Q2" runat="server" />
          </asp:TableCell>
          <asp:TableCell CssClass="lblQPadding" HorizontalAlign="Center">
           <asp:Label CssClass="lblQFont" ID="lblNetProfitCurrentQ3Title" Text="Q3" runat="server" />
          </asp:TableCell>
          <asp:TableCell CssClass="lblQPadding" HorizontalAlign="Center">
           <asp:Label CssClass="lblQFont" ID="lblNetProfitCurrentQ4Title" Text="Q4" runat="server" />
          </asp:TableCell>
          </asp:TableRow>
         <asp:TableRow>
           <asp:TableCell>
            <asp:Label runat="server" ID="lblNumPartsCurrentTitle" Font-Bold="true" Text="# Participants: " />
           </asp:TableCell>
           <asp:TableCell HorizontalAlign="Center">
            <asp:Label  runat="server" ID="lblNumPartsCurrent" Text=<%# DataBinder.Eval (Container.DataItem, "NumPartsCurrent") %> />
           </asp:TableCell>
          <asp:TableCell HorizontalAlign="Right">
           <asp:Label runat="server" ID="lblNetProfitCurrent" Font-Bold="true" Text="Net Profit: " />
          </asp:TableCell>
          <asp:TableCell HorizontalAlign="Center">
           <asp:Label  ID="lblNetProfitCurrentQ1" runat="server" Text=<%# String.Format("{0:C}", DataBinder.Eval (Container.DataItem, "NetProfitCurrentQ1")) %> />
          </asp:TableCell>
          <asp:TableCell HorizontalAlign="Center">
           <asp:Label  ID="lblNetProfitCurrentQ2" runat="server" Text=<%# String.Format("{0:C}", DataBinder.Eval (Container.DataItem, "NetProfitCurrentQ2")) %> />
          </asp:TableCell>
          <asp:TableCell HorizontalAlign="Center">
           <asp:Label  ID="lblNetProfitCurrentQ3" runat="server" Text=<%# String.Format("{0:C}", DataBinder.Eval (Container.DataItem, "NetProfitCurrentQ3")) %> />
          </asp:TableCell>
          <asp:TableCell HorizontalAlign="Center">
           <asp:Label  ID="lblNetProfitCurrentQ4" runat="server" Text=<%# String.Format("{0:C}", DataBinder.Eval (Container.DataItem, "NetProfitCurrentQ4")) %> />
          </asp:TableCell>
         </asp:TableRow>
        </asp:Table>

        </asp:TableCell>
        <asp:TableCell ColumnSpan="2">

         <asp:Table ID="tabNumPartsNext" Width="500px" runat="server" CellPadding="4" BorderColor="#000000" BorderWidth="1">
          <asp:TableRow>
          <asp:TableCell>
         &nbsp;&nbsp;<asp:Label ID="lblYearNext" CssClass="lblYear" runat="server" Text=<%# DataBinder.Eval (Container.DataItem, "NextYear") %> />
          </asp:TableCell>
          <asp:TableCell>
          </asp:TableCell>
          <asp:TableCell Width="90px">
          </asp:TableCell>
          <asp:TableCell CssClass="lblQPadding" HorizontalAlign="Center">
           <asp:Label CssClass="lblQFont" ID="lblNetProfitNextQ1Title" Text="Q1" runat="server" />
          </asp:TableCell>
          <asp:TableCell CssClass="lblQPadding" HorizontalAlign="Center">
           <asp:Label CssClass="lblQFont" ID="lblNetProfitNextQ2Title" Text="Q2" runat="server" />
          </asp:TableCell>
          <asp:TableCell CssClass="lblQPadding" HorizontalAlign="Center">
           <asp:Label CssClass="lblQFont" ID="lblNetProfitNextQ3Title" Text="Q3" runat="server" />
          </asp:TableCell>
          <asp:TableCell CssClass="lblQPadding" HorizontalAlign="Center">
           <asp:Label CssClass="lblQFont" ID="lblNetProfitNextQ4Title" Text="Q4" runat="server" />
          </asp:TableCell>
          </asp:TableRow>
         <asp:TableRow>
           <asp:TableCell>
            <asp:Label runat="server" ID="lblNumPartsNextTitle" Font-Bold="true" Text="# Participants: " />
           </asp:TableCell>
           <asp:TableCell HorizontalAlign="Center">
            <asp:Label  runat="server" ID="lblNumPartsNext" Text=<%# DataBinder.Eval (Container.DataItem, "NumPartsNext") %> />
           </asp:TableCell>
          <asp:TableCell HorizontalAlign="Right">
           <asp:Label runat="server" ID="lblNetProfitNext" Font-Bold="true" Text="Net Profit: " />
          </asp:TableCell>
          <asp:TableCell HorizontalAlign="Center">
           <asp:Label  ID="lblNetProfitNextQ1" runat="server" Text=<%# String.Format("{0:C}", DataBinder.Eval (Container.DataItem, "NetProfitNextQ1")) %> />
          </asp:TableCell>
          <asp:TableCell HorizontalAlign="Center">
           <asp:Label  ID="lblNetProfitNextQ2" runat="server" Text=<%# String.Format("{0:C}", DataBinder.Eval (Container.DataItem, "NetProfitNextQ2")) %> />
          </asp:TableCell>
          <asp:TableCell HorizontalAlign="Center">
           <asp:Label  ID="lblNetProfitNextQ3" runat="server" Text=<%# String.Format("{0:C}", DataBinder.Eval (Container.DataItem, "NetProfitNextQ3")) %> />
          </asp:TableCell>
          <asp:TableCell HorizontalAlign="Center">
           <asp:Label  ID="lblNetProfitNextQ4" runat="server" Text=<%# String.Format("{0:C}", DataBinder.Eval (Container.DataItem, "NetProfitNextQ4")) %> />
          </asp:TableCell>
         </asp:TableRow>
        </asp:Table>

        </asp:TableCell>
      </asp:TableRow>
       <asp:TableRow>
        <asp:TableCell ColumnSpan="2">
         <asp:Label runat="server" ID="lblImpactTitle" Text="Impact" />
        </asp:TableCell>
       </asp:TableRow>
       <asp:TableRow>
        <asp:TableCell ColumnSpan="2">
        <asp:Label id="lblImpact" runat="server" />
        </asp:TableCell>
       </asp:TableRow>
       <asp:TableRow>
        <asp:TableCell ColumnSpan="2">
         <asp:Label runat="server" ID="lblCommentsTitle" Text="Significant Activities/Comments" />
        </asp:TableCell>
       </asp:TableRow>
       <asp:TableRow>
       <asp:TableCell ColumnSpan="2">
        <asp:Label id="lblComments" runat="server" />
       </asp:TableCell>
       </asp:TableRow>
      </asp:Table>

      <br /><hr /><br />

     </ItemTemplate>    
    </asp:Repeater>
