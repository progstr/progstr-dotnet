<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Logging with different severity levels.
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="width: 40%; float: left;">
    <h2><%= ViewData["Message"] %></h2>
    <% using (Html.BeginForm("Log", "LogExample")) { %>
    <p>Log message:</p>
    <p><%= Html.TextArea("logMessage", new { style = "height:150px;width:300px;" }) %></p>
    <p>Severity:</p>
    <p>
        <label><%= Html.RadioButton("severity", "Info", ViewData["Info"]) %>Info</label>
        <label><%= Html.RadioButton("severity", "Warning", ViewData["Warning"]) %>Warning</label>
        <label><%= Html.RadioButton("severity", "Error", ViewData["Error"]) %>Error</label>
        <label><%= Html.RadioButton("severity", "Fatal", ViewData["Fatal"]) %>Fatal</label>
    </p>
    <p><input type="submit" value="Log" /></p>
    <% } %>
    </div>
    <div class="code" style="float: right; width: 59%;">
    Log code:
    <pre class="brush: c#">
public ActionResult Log(string logMessage, string severity)
{
    switch (severity)
    {
        case "Info": 
            this.Log().Info(logMessage);
            break;
        case "Warning": 
            this.Log().Warning(logMessage);
            break;
        case "Error": 
            this.Log().Error(logMessage);
            break;
        case "Fatal": 
            this.Log().Fatal(logMessage);
            break;
        default:
            this.Log().Info(logMessage);
            break;
    }
            
    ViewData[severity ?? "Info"] = true;
    ViewData["Message"] = "Log sent to server.";
    return View("Index");
}    </pre>
    </div>
</asp:Content>
