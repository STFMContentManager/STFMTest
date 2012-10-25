<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OneColumnTemplate.aspx.cs" Inherits="STFMPlatformTransition.OneColumnTemplate" %>
<%@ Register TagName="OneColumnTemplate" TagPrefix="UC" Src="~/Controls/OneColumnTemplate.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<!--Test Comment Here-->

 <UC:OneColumnTemplate ID="OneColumnTemplate1" runat="server"></UC:OneColumnTemplate>
</asp:Content>