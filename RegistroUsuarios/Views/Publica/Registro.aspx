<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="RegistroUsuarios.Registro" %>

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

        <asp:Label Text="Nombre" runat="server" />
        <asp:TextBox runat="server" ID="txtNombre" />
        <br />

        <asp:Label Text="Apellidos" runat="server" />
        <asp:TextBox runat="server" ID="txtApellidos" />
        <br />

        <asp:Label Text="Contraseña" runat="server" />
        <asp:TextBox runat="server" ID="txtPass1" TextMode="Password" />
        <br />

        <asp:Label Text="Repetir contraseña" runat="server" />
        <asp:TextBox runat="server" ID="txtPass2" TextMode="Password" />
        <br />

        <asp:Label Text="Rol" runat="server" />
        <asp:RadioButton Text="Alumno" runat="server" ID="rbAlumno" Checked="True" GroupName="Rol" />
        <asp:RadioButton Text="Profesor" runat="server" ID="rbProfesor" GroupName="Rol" />
        <br />

        <asp:Button Text="Registro" runat="server" ID="btnRegistro" OnClick="btnRegistro_Click" />
        <br />
        <asp:Label Text="Registro realizado correctamente" runat="server" ID="lblRegistroOK" Visible="False" />
        <br />
        <asp:Label Text="Formato de email no válido" runat="server" ID="lblEmailNoValido" Visible="False" />
        <br />
        <asp:Label Text="Las contraseñas no coinciden" runat="server" ID="lblPassNoCoinciden" Visible="False" />
        <br />
        <asp:Label Text="La contraseña debe ser mínimo de 6 carateres" runat="server" ID="lblPassCorta" Visible="False" />
        <br />

        <asp:HyperLink NavigateUrl="~/Views/Publica/Inicio.aspx" runat="server" ID="linkInicio" Text="Volver al inicio" />
        <br />
    </form>
</body>
</html>
