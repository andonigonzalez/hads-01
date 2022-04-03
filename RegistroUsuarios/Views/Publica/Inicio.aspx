<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="RegistroUsuarios.Inicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label Text="Email" runat="server" />
        <asp:TextBox runat="server" ID="txtEmail" />
        <br />

        <asp:Label Text="Password" runat="server" />
        <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" />
        <br />

        <asp:Button Text="Login" runat="server" ID="btnLogin" OnClick="LoginBtn_Click" />
        <br />

        <asp:HyperLink NavigateUrl="~/Views/Publica/Registro.aspx" runat="server" Text="Registro" />
        <br />
        <asp:HyperLink NavigateUrl="~/Views/Publica/CambiarPassword.aspx" runat="server" Text="Cambiar password" />
        <br />

        <asp:Label Text="Usuario o contraseña incorrectos" runat="server" ID="lblLoginIncorrecto" Visible="False" />
        <br />
    </form>
</body>
</html>
