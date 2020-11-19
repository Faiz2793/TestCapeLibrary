    <%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="CapeLibManagementSystem._Default" %>
    <%@ Register Src="~/Content/UserControls/UserLogin.ascx" TagPrefix="uc" TagName="UserLogin" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <uc:UserLogin ID="studentcontrol" runat="server" /> 
 </asp:Content>


