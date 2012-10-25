<%@ Page Language="C#"MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FMJournal.aspx.cs" Inherits="STFMPlatformTransition.Application.FMHub.FMJournal1" %>
<%@ Register TagName="FMJournal" TagPrefix="UC" Src="~/Controls/FMJournal.ascx" %>
<asp:Content ID="content1" runat="server" ContentPlaceHolderID="MainContent">
    <UC:FMJournal runat="server"></UC:FMJournal>
</asp:Content>
