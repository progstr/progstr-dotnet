<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Welcome to the Progstr.Log web examples.</h2>
    <p>This web application demonstrates how to use the Progstr.Log client library and send log messages to the server. 
    It contains both examples using ASP.NET MVC and classic WebForms &mdash; click the links to visit a specific example.</p>
    <p>In addition we demonstrate a technique to intercept all uncaught exceptions and log them as error events.
    That happens in the Global.asax.cs file where we catch the Application_Error event and extract the last exception. 
    A sample page demonstrating the technique is available <a href="/RaiseError.aspx">here</a>.</p>
</asp:Content>
