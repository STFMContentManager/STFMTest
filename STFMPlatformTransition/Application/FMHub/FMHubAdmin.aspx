<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FMHubAdmin.aspx.cs" Inherits="STFMPlatformTransition.Application.FHHub.WebForm1" %>
<%@ Register TagName="FMHub" TagPrefix="UC" Src="~/Controls/FMHubAdmin1.ascx" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="MainContent">
    <UC:FMHub runat="server"></UC:FMHub>
</asp:Content>
