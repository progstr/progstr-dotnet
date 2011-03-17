<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Handle controller-specific errors
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%= ViewData["Message"] %></h2>
    <% using (Html.BeginForm("Throw", "ControllerErrors")) { %>
    <p>Trigger a test error:</p>
    <p><input type="submit" value="Throw!" /></p>
    <% } %>

    <p>Controllers have an OnException method that you can override and handle all unexpected errors:</p>
<pre class="brush: c#">
protected override void OnException(ExceptionContext exceptionContext)
{
    var error = exceptionContext.Exception;
    this.Log().Error("Unhandled exception while executing controller.", error);

    //Mark the error as handled and redirect to the default view.
    exceptionContext.ExceptionHandled = true;
    exceptionContext.Result = View("Index");

    ViewData["Message"] = "An error occurred: " + error.Message;
}
</pre>
</asp:Content>
