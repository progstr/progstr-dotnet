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
    <div id="overview-container">
        <h2 style="margin: 20px 0px 0px 0px">Feature Overview</h2>
        <ul id="overview" class="theme-agnostic-lead">
            <li>
                <h3>Familiar Log API Interface</h3>
                <p>Ever used a different log library like <em>log4net</em> or <em>nlog</em> before? You'll feel at home with a familiar programming model.</p>
                <p>Your classes get exposed as log sources and can generate events with one of four different <a href="/LogExample">severity levels</a>.</p>
            </li>
            <li>
                <h3>Taking Advantage of Modern .NET Design</h3>
                <p>Using generics and extension methods to provide a true developer-friendly API. Configuring a class as a log source and logging an event happens with a single line of code.</p>
            </li>
            <li>
                <h3>Easy Formatting for Common Cases</h3>
                <p>Want to log that exception with full details like stacktrace and any inner exceptions? Just pass it to the right log method overload and let the library take care of it.</p>
                <p>Bogged down trying to format a nice log message? Use the InfoFormat, etc methods with the familiar .NET format string syntax.</p>
            </li>
            <li>
                <h3>ASP.NET WebForms Support</h3>
                <p>ASP.NET applications expose the API to log interesting events such as unhandled exceptions at the application level. The <a href="/Examples/RaiseError.aspx">Global Errors</a> example shows how to do that.</p>
                <p>ASP.NET WebForms lets us handle errors at the page or control level as well. The <a href="/Examples/PageError.aspx">Page Errors</a> example demonstrates the technique.</p>
            </li>
            <li>
                <h3>ASP.NET MVC Support</h3>
                <p>MVC applications are ASP.NET applications, but their different programming model gives us different logging opportunities. The <a href="/ControllerErrors">Controller Errors</a> 
                example shows how to catch and log unhandled exceptions for a single controller's actions. Leaving errors aside, the <a href="/ControllerActions">Controller Actions</a> example 
                hooks before and after executing an action and logs an Info event for each.</p>
            </li>
            <li>
                <h3>Cross-platform</h3>
                <p>Apart from fully supporting .NET 3.5 and later, Progstr.Log is being extensively tested under Mono. Any version of Mono greater than 2.6.7 is fully supported.</p>
            </li>
        </ul>
    </div>
</asp:Content>
