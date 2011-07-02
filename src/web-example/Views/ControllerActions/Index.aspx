<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Handle controller-specific errors
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% using (Html.BeginForm("DepositMoney", "ControllerActions")) { %>
    <h2><%= ViewData["Message"] %></h2>
    <p>
        Trigger a new controller action: <input type="submit" value="Deposit some money!" />
        <a href="https://app.progstr.com/demoAutoLogin"
                    title="Log management area for our demo account."
                    target="_blank">View Logs</a>
    </p>
    <% } %>
    <p>Important controllers such as the ones handling payments or important user actions might benefit from 
    logging the actions that got executed. We can do that by overriding the OnActionExecuting and/or 
    OnActionExecuted controller methods. Below is a possible implementation:</p>
<pre class="brush: c#">
protected override void OnActionExecuting(ActionExecutingContext executingContext)
{
    var controller = executingContext.ActionDescriptor.ControllerDescriptor.ControllerName;
    var action = executingContext.ActionDescriptor.ActionName;
    this.Log().InfoFormat("Executing action '{0}' of controller '{1}'", action, controller);
}

protected override void OnActionExecuted(ActionExecutedContext executedContext)
{
    var controller = executedContext.ActionDescriptor.ControllerDescriptor.ControllerName;
    var action = executedContext.ActionDescriptor.ActionName;
    this.Log().InfoFormat("Executed action '{0}' of controller '{1}'", action, controller);
}
</pre>
</asp:Content>
