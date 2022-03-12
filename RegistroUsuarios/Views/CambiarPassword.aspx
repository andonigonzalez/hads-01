<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CambiarPassword.aspx.cs" Inherits="RegistroUsuarios.Views.CambiarPassword" %>

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
        
        <asp:Button Text="Solicitar cambio password" runat="server" ID="btnSolicitarClave" OnClick="btnSolicitarClave_Click" />
        <br />

        <asp:Label Text="Clave" runat="server" />
        <asp:TextBox runat="server" ID="txtClave" />
        <br />

        <asp:Button Text="Comprobar clave" runat="server" ID="btnComprobarClave" OnClick="btnComprobarClave_Click" />
        <br />
        
        <asp:Panel runat="server" ID="panel" Visible="False">
            <asp:Label Text="Nueva contraseña" runat="server" />
            <asp:TextBox runat="server" ID="txtPass1" TextMode="Password" />
            <br />

            <asp:Label Text="Repetir contraseña" runat="server" />
            <asp:TextBox runat="server" ID="txtPass2" TextMode="Password" />
            <br />
            
            <asp:Button Text="Guardar" runat="server" ID="btnGuardar" OnClick="btnGuardar_Click" />
            <br />
        </asp:Panel>

        <asp:Label Text="Clave enviada correctamente" runat="server" ID="lblClaveEnviada" Visible="False" />
        <br />
        <asp:Label Text="Contraseñas no coinciden" runat="server" ID="lblPassDiferentes" Visible="False" />
        <br />
        <asp:Label Text="La contraseña debe ser mínimo de 6 carateres" runat="server" ID="lblPassCorta" Visible="False" />
        <br />
        <asp:Label Text="Contraseña modificada correctamente" runat="server" ID="lblPassModificada" Visible="False" />
        <br />

        <asp:HyperLink NavigateUrl="Inicio.aspx" runat="server" ID="linkInicio" Text="Volver al inicio" />
        <br />

    </form>
</body>
</html>
