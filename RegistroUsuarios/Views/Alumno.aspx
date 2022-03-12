<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Alumno.aspx.cs" Inherits="RegistroUsuarios.Views.Alumno" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:HyperLink NavigateUrl="VerTareasEstudiante.aspx" runat="server" Text="Tareas Genéricas" />
        </div>
        <div>
            <asp:Label Text="Gestión Web de Tareas-Dedicación" runat="server" />
            <br />
            <asp:Label Text="Alumnos" runat="server" />
        </div>
    </form>
</body>
</html>
