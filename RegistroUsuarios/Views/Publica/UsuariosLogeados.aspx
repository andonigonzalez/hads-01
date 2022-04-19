<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsuariosLogeados.aspx.cs" Inherits="RegistroUsuarios.Views.Publica.UsuariosLogeados" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="txtCuantos" Text="USUARIOS LOGEADOS: 0 Alumno/s y 0 Profe/s" runat="server" />
        </div>
        <div>
            <asp:ListBox ID="listaAlumnos" runat="server" Width="200"></asp:ListBox>
            <asp:ListBox ID="listaProfes" runat="server" Width="200"></asp:ListBox>
        </div>
    </form>
</body>
</html>
