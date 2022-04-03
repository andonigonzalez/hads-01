<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Confirmar.aspx.cs" Inherits="RegistroUsuarios.Views.Confirmar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label Text="Identificación incorrecta" runat="server" ID="ko" Visible="False" />
        <asp:Label Text="Identificación correcta" runat="server" ID="ok" Visible="False" />
        <br />
        <asp:HyperLink NavigateUrl="~/Views/Publica/Inicio.aspx" runat="server" ID="linkInicio" Visible="False" Text="Volver al inicio" />
    </form>
</body>
</html>
