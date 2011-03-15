<%@ Page Language="C#" 
    MasterPageFile="~/WebForms.Master" 
    AutoEventWireup="true" 
    CodeBehind="WebFormsExample.aspx.cs" 
    Inherits="WebExample.WebFormsExample" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    ASP.NET WebForms Example
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
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
</asp:Content>