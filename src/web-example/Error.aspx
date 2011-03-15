<%@ Page Language="C#" 
    MasterPageFile="~/WebForms.Master" 
    AutoEventWireup="true" 
    CodeBehind="Error.aspx.cs" 
    Inherits="WebExample.Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Raise a Test Error
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form2" runat="server">
    <div>
    <h2 style="color: red">A server-side error has occurred. We have logged it will look into it ASAP!</h2>
    <p>Again, here is the code in Global.asax.cs that makes this work:</p>
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
    </div>
    
    </form>
</asp:Content>
