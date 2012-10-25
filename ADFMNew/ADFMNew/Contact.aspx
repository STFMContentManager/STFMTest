<%@ Page Language="C#" MasterPageFile="Site1.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="ADFMNew.Contact" %>
<%@ Register TagPrefix="uc" TagName="Contact" Src="controls/Contact.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="maincontent" Runat="Server">
 <uc:Contact runat="server" id="ucContact"></uc:Contact>
</asp:Content>
