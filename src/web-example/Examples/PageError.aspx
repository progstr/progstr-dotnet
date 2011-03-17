<%@ Page Language="C#" 
    MasterPageFile="~/WebForms.Master" 
    AutoEventWireup="true" 
    CodeBehind="PageError.aspx.cs" 
    Inherits="WebExample.PageError" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Handle page errors
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form2" runat="server">
    <div>
    <h2><asp:Literal ID="message" runat="server" /></h2>
    <p>Trigger a test error:</p>
    <p><asp:Button runat="server" Text="Throw!" id="errorButton" OnClick="errorButton_Click"></asp:Button></p>
    </div>
    <p>ASP.NET pages have an OnError method that you can override and handle all unexpected errors. You can't 
    really affect page rendering at that point since you don't know at what stage of the page lifecycle the 
    error really occurred. To work around that we redirect to a page providing the error message in a query 
    string parameter. Here is the code:</p>
<pre class="brush: c#">
protected override void OnError(EventArgs e)
{
    var error = Server.GetLastError();
    this.Log().Error("Unhandled exception while executing page.", error);

    var message = "An error occurred: " + error.Message;

    Response.Redirect("~/Examples/PageError.aspx?error=" + HttpUtility.UrlEncode(message));
}
</pre>
    </form>
</asp:Content>
