<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ThreeColumnTemplate.aspx.cs" Inherits="STFMPlatformTransition.ThreeColumnTemplate" %>
<%@ Register TagName="ThreeColumnTemplate" TagPrefix="UC" Src="~/Controls/ThreeColumnTemplate.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 <UC:ThreeColumnTemplate runat="server"></UC:ThreeColumnTemplate>
</asp:Content>


