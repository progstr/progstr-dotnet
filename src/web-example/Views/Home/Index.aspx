<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Welcome to the Progstr.Log web examples.</h2>
    <p>This web application demonstrates how to use the Progstr.Log client library and send log messages to the server. 
    It contains both examples using ASP.NET MVC and classic WebForms &mdash; click the links to visit a specific example.</p>
    <p>In addition we demonstrate techniques for intercepting interesting events and errors in a typical web 
    application and logging them. That is invaluable for any production deployment - especially when we are 
    troubleshooting problems.
    </p>
</asp:Content>
