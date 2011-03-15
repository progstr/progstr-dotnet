<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%= ViewData["Message"] %></h2>
    <% using (Html.BeginForm("Log", "LogExample")) { %>
    <p>Log message:</p>
    <p><%= Html.TextArea("logMessage", new { style = "height:150px;width:300px;" }) %></p>
    <p>Severity:</p>
    <p>
        <label><%= Html.RadioButton("severity", "Info", ViewData["Info"] ?? false) %>Info</label>
        <label><%= Html.RadioButton("severity", "Warning", ViewData["Warning"] ?? false) %>Warning</label>
        <label><%= Html.RadioButton("severity", "Error", ViewData["Error"] ?? false) %>Error</label>
        <label><%= Html.RadioButton("severity", "Fatal", ViewData["Fatal"] ?? false) %>Fatal</label>
    </p>
    <p><input type="submit" value="Log" /></p>
    <% } %>
</asp:Content>
