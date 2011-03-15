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
    </form>
</asp:Content>
