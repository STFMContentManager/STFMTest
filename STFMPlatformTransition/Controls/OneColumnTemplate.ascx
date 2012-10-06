<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OneColumnTemplate.ascx.cs" Inherits="STFMPlatformTransition.OneColumnTemplate1" %>
<%@ Register TagPrefix="FTB" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>

<asp:Table ID="tabDisplay" HorizontalAlign="Center" CellPadding="0" runat="server" Width="100%" Visible="true">
 <asp:TableRow>
  <asp:TableCell VerticalAlign="Top"><asp:Label runat="server" ID="lblMiddleColumn" Font-Size="12px" style="font-family:Vardana"></asp:Label></asp:TableCell>
 </asp:TableRow>
</asp:Table>

<asp:Table ID="tabCMSDisplay" HorizontalAlign="Center" runat="server" Width="100%" Visible="false">
 <asp:TableRow>
  <asp:TableCell ColumnSpan="3" VerticalAlign="Top">
     
   <asp:Table ID="Table3" Width="100%" runat="server">
    <asp:TableRow>
     <asp:TableCell width="100%">
      <asp:LinkButton runat="server" ID="lbSaveMiddleColumn" OnClick="SaveContent" Visible="true" ForeColor="Red" Font-Size="10px">[Save]</asp:LinkButton>&nbsp;&nbsp;<asp:LinkButton runat="server" ID="lbPublishMiddleColumn" OnClick="PublishContent" Visible="true" ForeColor="Green" Font-Size="10px">[Publish]</asp:LinkButton>&nbsp;&nbsp;<asp:LinkButton runat="server" ID="lbDeactivateMiddleColumn" OnClick="DeactivateContent" Visible="true" ForeColor="Red" Font-Size="10px">[Deactivate]</asp:LinkButton>
      <br /><br /><FTB:FreeTextBox id="ftbMiddleColumn" 
   toolbarlayout="ParagraphMenu,FontFacesMenu,FontSizesMenu,FontForeColorsMenu,FontForeColorPicker,FontBackColorsMenu,FontBackColorPicker|Bold,Italic,Underline,Strikethrough,Superscript,Subscript,RemoveFormat|JustifyLeft,JustifyRight,JustifyCenter,JustifyFull;BulletedList,NumberedList,Indent,Outdent;CreateLink,Unlink,InsertImage|Cut,Copy,Paste,Delete;Undo,Redo,Print,Save|SymbolsMenu,StylesMenu,InsertHtmlMenu|InsertRule,InsertDate,InsertTime|InsertTable,EditTable;InsertTableRowAfter,InsertTableRowBefore,DeleteTableRow;InsertTableColumnAfter,InsertTableColumnBefore,DeleteTableColumn|InsertForm,InsertTextBox,InsertTextArea,InsertRadioButton,InsertCheckBox,InsertDropDownList,InsertButton|InsertDiv,EditStyle,InsertImageFromGallery,Preview,SelectAll,WordClean,NetSpell" 
   Visible="true" Width="900px" Height="1100px" runat="Server" ButtonSet="Office2000" />
     </asp:TableCell>
    </asp:TableRow>
   </asp:Table>

  </asp:TableCell>
 </asp:TableRow>
</asp:Table>
