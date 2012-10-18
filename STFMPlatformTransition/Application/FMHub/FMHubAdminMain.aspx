<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="FMHubAdminMain.aspx.cs" Inherits="STFMPlatformTransition.Application.FMHub.FMHubAdminMain" %>
<%@ Register TagName="FMAdminMain" TagPrefix="UC" Src="~/Controls/FMHubAdminMain.ascx" %>

<asp:Content ID="content1" runat="server" ContentPlaceHolderID="MainContent">
    <UC:FMAdminMain ID="FMAdmin" runat="server"></UC:FMAdminMain>
</asp:Content>
