<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MemberDirectorySearch.aspx.cs" Inherits="STFMPlatformTransition.MemberDirectorySearch" %>
<%@ Register TagName="MemberDirectorySearch" TagPrefix="MDS" Src="~/Controls/MemberDirectorySearch.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 <MDS:MemberDirectorySearch ID="MemberDirectorySearch1" runat="server"></MDS:MemberDirectorySearch>
</asp:Content>
