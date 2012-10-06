<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustomTemplate.aspx.cs" Inherits="STFMPlatformTransition.CustomTemplate" %>
<%@ Register TagName="CustomTemplate" TagPrefix="UC" Src="~/Controls/CustomTemplate.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 <UC:CustomTemplate ID="CustomTemplate1" runat="server"></UC:CustomTemplate>
</asp:Content>
