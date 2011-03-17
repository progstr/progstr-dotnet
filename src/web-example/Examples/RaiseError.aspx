<%@ Page Language="C#" 
    MasterPageFile="~/WebForms.Master" 
    AutoEventWireup="true" 
    CodeBehind="RaiseError.aspx.cs" 
    Inherits="WebExample.RaiseError" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Raise a Test Error
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form2" runat="server">
    <div>
    <p>Trigger a test error:</p>
    <p><asp:Button runat="server" Text="Throw!" id="errorButton" OnClick="errorButton_Click"></asp:Button></p>
    </div>
    <p>Here is the code that we use in Global.asax.cs to catch all exceptions and log them:</p>
<pre class="brush: c#">
protected void Application_Error(object sender, EventArgs e)
{
    var url = HttpContext.Current.Request.Url;
    var exception = this.Server.GetLastError();
    var requestBody = this.ReadRequestBody();

    var message = string.Format("Uncaught exception for URL:{0}\r\nREQUEST:\r\n{1}", url, requestBody);
    this.Log().Error(message, exception);
}
</pre>
    </form>
</asp:Content>
