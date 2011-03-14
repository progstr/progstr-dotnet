<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormExample.aspx.cs" Inherits="WebExample.WebFormExample" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
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
    </div>
    </form>
</body>
</html>
