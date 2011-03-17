<%@ Page Language="C#" 
    MasterPageFile="~/WebForms.Master" 
    AutoEventWireup="true" 
    CodeBehind="WebFormsExample.aspx.cs" 
    Inherits="WebExample.WebFormsExample" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    ASP.NET WebForms Example
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="width: 45%; float: left;">
    <form id="form1" runat="server">
    <p>Log message:</p>
    <p><asp:TextBox runat="server" id="logMessage" TextMode="MultiLine" Width="300px" Height="150px"></asp:TextBox></p>
    <p>Severity:</p>
    <p>
        <asp:RadioButtonList id="severityList" runat="server">
            <asp:ListItem id="info" runat="server" Value="Info" />
            <asp:ListItem id="warning" runat="server" Value="Warning" />
            <asp:ListItem id="error" runat="server" Value="Error" />
            <asp:ListItem id="fatal" runat="server" Value="Fatal" />
        </asp:RadioButtonList>
    </p>
    <p><asp:Button runat="server" Text="Log" id="logButton" OnClick="logButton_Click"></asp:Button></p>
    <p><asp:Label id="messageArea" runat="server" ForeColor="Red"></asp:Label></p>
    </form>
    </div>
    <div class="code" style="float: right; width: 54%;">
    Log code:
    <pre class="brush: c#">
public void logButton_Click(object sender, EventArgs e)
{
    var severity = severityList.SelectedValue;
    var message = logMessage.Text;
    switch (severity)
    {
        case "Info": 
            this.Log().Info(message);
            break;
        case "Warning": 
            this.Log().Warning(message);
            break;
        case "Error": 
            this.Log().Error(message);
            break;
        case "Fatal": 
            this.Log().Fatal(message);
            break;
        default:
            this.Log().Info(message);
            break;
    }
            
    messageArea.Text = "Log sent to server.";
}
    </pre>
    </div>
</asp:Content>