<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ThreeColumnTemplate.ascx.cs" Inherits="STFMPlatformTransition.ThreeColumnTemplate1" %>
<%@ Register TagPrefix="FTB" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>

  <script type="text/javascript">

      var exp = 5;

      function newCookie(name, value, days) {
          if (days) {
              var date = new Date();
              date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
              var expires = "; expires=" + date.toGMTString();
          } else var expires = "";
          document.cookie = name + "=" + value + expires + "; path=/";
      }

      function readCookie(name) {
          var nameSG = name + "=";
          var nuller = '';
          if (document.cookie.indexOf(nameSG) == -1)
              return nuller;
          var ca = document.cookie.split(';');
          for (var i = 0; i < ca.length; i++) {
              var c = ca[i];
              while (c.charAt(0) == ' ') c = c.substring(1, c.length);
              if (c.indexOf(nameSG) == 0) return c.substring(nameSG.length, c.length);
          }
          return null;
      }

      function eraseCookie(name) {
          newCookie(name, "", -1);
      }

      if (document.getElementById) {
          document.writeln('<style type="text/css">')
          document.writeln('.main {text-decoration:none; color:blue; cursor:hand; cursor:pointer}')
          document.writeln('span:hover.mainLink {text-decoration:underline; color:red}')
          document.writeln('.sublinks1 {display:none; padding-left:14px}')
          document.writeln('.link2 {text-decoration:none; color:blue}')
          document.writeln('a:hover.link2 {text-decoration:underline; color:red}')
          document.writeln('</style>')
      }

      // Below you should add a1, a2 etc. for each main link you wish to include
      // so if you want 3 main links you should add a1, a2, a3 in the format shown
      // enclosed in double quotes
      var mainNum = new Array("a1", "a2", "a3");

      // Below you should add b1, b2 etc. for each sub link you wish to include
      // under one main link, here the first main link. so if you want 4 sub links you
      // should add b1, b2, b3, b4 in the format shown enclosed in double quotes
      var subNum1 = new Array("b1", "b2");

      // Below, this is for sub links under the second main link. there are 3 sub links
      // in the given example
      var subNum2 = new Array("c1", "c2", "c3");


      function openClose(theName, menuArray, theID) {
          for (var i = 0; i < menuArray.length; i++) {
              if (menuArray[i] == theID) {
                  if (document.getElementById(theID).style.display == "block") {
                      document.getElementById(theID).style.display = "none";
                      //document.getElementById("tick_" + menuArray[i]).innerHTML = "+";
                      eraseCookie(theName);
                  }
                  else {
                      document.getElementById(theID).style.display = "block";
                      //document.getElementById("tick_" + menuArray[i]).innerHTML = "-";
                      newCookie(theName, menuArray[i], exp);
                  }
              }
              else {
                  if (theID != "b1") {
                      document.getElementById(menuArray[i]).style.display = "none";
                      //document.getElementById("tick_" + menuArray[i]).innerHTML = "+";
                  }
              }
          }
      }

      function memStatus() {
          var num = readCookie("MN");
          if (num) {
              document.getElementById(num).style.display = "block";
              //document.getElementById("tick_" + num).innerHTML = "-";
          }
          var num1 = readCookie("SB");
          if (num1) {
              document.getElementById(num1).style.display = "block";
              //document.getElementById("tick_" + num1).innerHTML = "-";
          }
      }

      function addLoadEvent(func) {
          var oldonload = window.onload;
          if (typeof window.onload != 'function') {
              window.onload = func;
          } else {
              window.onload = function () {
                  if (oldonload) {
                      oldonload();
                  }
                  func();
              }
          }
      }

      addLoadEvent(function () {
          memStatus();
      });
</script>

<style type="text/css">
.menu1 {
  color:#000000;
  background: #cccccc;
  font-family: verdana;
  font-weight:bold;
  font-size:12px;
  width: 150px;
}

.menu2 {
  background: #ffffff;
  color: blue;
  font-family:verdana;
  font-size:12px;
  line-height: 19px;
}
.main
{
    width: 150px;
}
</style>

<asp:Table ID="tabDisplay" HorizontalAlign="Center" runat="server" Width="880px" CellPadding="0" Visible="true">
 <asp:TableRow>
  <asp:TableCell CssClass="LeftColumnStyle" Width="20%" VerticalAlign="Top"><asp:Label CssClass="DisplayFontStyle" runat="server" ID="lblLeftColumn"></asp:Label></asp:TableCell>
  <asp:TableCell CssClass="MiddleColumnStyle" width="65%" VerticalAlign="Top"><asp:Label CssClass="DisplayFontStyle" runat="server" ID="lblMiddleColumn"></asp:Label></asp:TableCell>
  <asp:TableCell CssClass="RightColumnStyle" width="15%" VerticalAlign="Top" HorizontalAlign="Center"><asp:Label CssClass="DisplayFontStyle" runat="server" ID="lblRightColumn"></asp:Label></asp:TableCell>
 </asp:TableRow>
</asp:Table>

<asp:Table ID="tabCMSDisplay" HorizontalAlign="Center" runat="server" Width="100%" Visible="false">
 <asp:TableRow>
  <asp:TableCell Width="20%">
   <asp:LinkButton runat="server" ID="lbSaveLeftColumn" OnClick="SaveContent" Visible="true" ForeColor="Green" Font-Size="10px">[Save]</asp:LinkButton>&nbsp;&nbsp;<asp:LinkButton runat="server" ID="lbPublishLeftColumn" OnClick="PublishContent" Visible="true" ForeColor="Blue" Font-Size="10px">[Publish]</asp:LinkButton>&nbsp;&nbsp;<asp:LinkButton runat="server" ID="lbDeactivateLeftColumn" OnClick="DeactivateContent" Visible="true" ForeColor="Red" Font-Size="10px">[Deactivate]</asp:LinkButton>&nbsp;&nbsp;<asp:LinkButton runat="server" ID="lbRevertLeftColumn" OnClick="RevertContent" Visible="true" ForeColor="Purple" Font-Size="10px">[Revert]</asp:LinkButton>
   <br /><br /><FTB:FreeTextBox id="ftbLeftColumn" 
   toolbarlayout="ParagraphMenu,FontFacesMenu,FontSizesMenu,FontForeColorsMenu,FontForeColorPicker,FontBackColorsMenu,FontBackColorPicker|Bold,Italic,Underline,Strikethrough,Superscript,Subscript,RemoveFormat|JustifyLeft,JustifyRight,JustifyCenter,JustifyFull;BulletedList,NumberedList,Indent,Outdent;CreateLink,Unlink,InsertImage|Cut,Copy,Paste,Delete;Undo,Redo,Print,Save|SymbolsMenu,StylesMenu,InsertHtmlMenu|InsertRule,InsertDate,InsertTime|InsertTable,EditTable;InsertTableRowAfter,InsertTableRowBefore,DeleteTableRow;InsertTableColumnAfter,InsertTableColumnBefore,DeleteTableColumn|InsertForm,InsertTextBox,InsertTextArea,InsertRadioButton,InsertCheckBox,InsertDropDownList,InsertButton|InsertDiv,EditStyle,InsertImageFromGallery,Preview,SelectAll,WordClean,NetSpell" 
   Visible="true" Width="100%" Height="500px" runat="Server" ButtonSet="Office2000" />
  </asp:TableCell>
  <asp:TableCell width="65%">
   <asp:LinkButton runat="server" ID="lbSaveMiddleColumn" OnClick="SaveContent" Visible="true" ForeColor="Green" Font-Size="10px">[Save]</asp:LinkButton>&nbsp;&nbsp;<asp:LinkButton runat="server" ID="lbPublishMiddleColumn" OnClick="PublishContent" Visible="true" ForeColor="Blue" Font-Size="10px">[Publish]</asp:LinkButton>&nbsp;&nbsp;<asp:LinkButton runat="server" ID="lbDeactivateMiddleColumn" OnClick="DeactivateContent" Visible="true" ForeColor="Red" Font-Size="10px">[Deactivate]</asp:LinkButton>&nbsp;&nbsp;<asp:LinkButton runat="server" ID="lbRevertMiddleColumn" OnClick="RevertContent" Visible="true" ForeColor="Purple" Font-Size="10px">[Revert]</asp:LinkButton>
   <br /><br /><FTB:FreeTextBox id="ftbMiddleColumn" 
   toolbarlayout="ParagraphMenu,FontFacesMenu,FontSizesMenu,FontForeColorsMenu,FontForeColorPicker,FontBackColorsMenu,FontBackColorPicker|Bold,Italic,Underline,Strikethrough,Superscript,Subscript,RemoveFormat|JustifyLeft,JustifyRight,JustifyCenter,JustifyFull;BulletedList,NumberedList,Indent,Outdent;CreateLink,Unlink,InsertImage|Cut,Copy,Paste,Delete;Undo,Redo,Print,Save|SymbolsMenu,StylesMenu,InsertHtmlMenu|InsertRule,InsertDate,InsertTime|InsertTable,EditTable;InsertTableRowAfter,InsertTableRowBefore,DeleteTableRow;InsertTableColumnAfter,InsertTableColumnBefore,DeleteTableColumn|InsertForm,InsertTextBox,InsertTextArea,InsertRadioButton,InsertCheckBox,InsertDropDownList,InsertButton|InsertDiv,EditStyle,InsertImageFromGallery,Preview,SelectAll,WordClean,NetSpell" 
   Visible="true" Width="100%" Height="500px" runat="Server" ButtonSet="Office2000" />
  </asp:TableCell>
  <asp:TableCell width="15%">
   <asp:LinkButton runat="server" ID="lbSaveRightColumn" OnClick="SaveContent" Visible="true" ForeColor="Green" Font-Size="10px">[Save]</asp:LinkButton>&nbsp;&nbsp;<asp:LinkButton runat="server" ID="lbPublishRightColumn" OnClick="PublishContent" Visible="true" ForeColor="Blue" Font-Size="10px">[Publish]</asp:LinkButton>&nbsp;&nbsp;<asp:LinkButton runat="server" ID="lbDeactivateRightColumn" OnClick="DeactivateContent" Visible="true" ForeColor="Red" Font-Size="10px">[Deactivate]</asp:LinkButton>&nbsp;&nbsp;<asp:LinkButton runat="server" ID="lbRevertRightColumn" OnClick="RevertContent" Visible="true" ForeColor="Purple" Font-Size="10px">[Revert]</asp:LinkButton>
   <br /><br /><FTB:FreeTextBox id="ftbRightColumn" 
   toolbarlayout="ParagraphMenu,FontFacesMenu,FontSizesMenu,FontForeColorsMenu,FontForeColorPicker,FontBackColorsMenu,FontBackColorPicker|Bold,Italic,Underline,Strikethrough,Superscript,Subscript,RemoveFormat|JustifyLeft,JustifyRight,JustifyCenter,JustifyFull;BulletedList,NumberedList,Indent,Outdent;CreateLink,Unlink,InsertImage|Cut,Copy,Paste,Delete;Undo,Redo,Print,Save|SymbolsMenu,StylesMenu,InsertHtmlMenu|InsertRule,InsertDate,InsertTime|InsertTable,EditTable;InsertTableRowAfter,InsertTableRowBefore,DeleteTableRow;InsertTableColumnAfter,InsertTableColumnBefore,DeleteTableColumn|InsertForm,InsertTextBox,InsertTextArea,InsertRadioButton,InsertCheckBox,InsertDropDownList,InsertButton|InsertDiv,EditStyle,InsertImageFromGallery,Preview,SelectAll,WordClean,NetSpell" 
   Visible="true" Width="100%" Height="500px" runat="Server" ButtonSet="Office2000" />
  </asp:TableCell>
 </asp:TableRow>
</asp:Table>
