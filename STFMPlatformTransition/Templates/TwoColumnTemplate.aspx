<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TwoColumnTemplate.aspx.cs" Inherits="STFMPlatformTransition.TwoColumnTemplate" %>
<%@ Register TagName="TwoColumnTemplate" TagPrefix="UC" Src="~/Controls/TwoColumnTemplate.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 <UC:TwoColumnTemplate ID="TwoColumnTemplate1" runat="server"></UC:TwoColumnTemplate>
</asp:Content>
