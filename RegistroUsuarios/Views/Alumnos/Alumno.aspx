<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Alumno.aspx.cs" Inherits="RegistroUsuarios.Views.Alumno" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:HyperLink NavigateUrl="~/Views/Alumnos/VerTareasEstudiante.aspx" runat="server" Text="Tareas Genéricas" />
        </div>
        <div>
            <asp:Label Text="Gestión Web de Tareas-Dedicación" runat="server" />
            <br />
            <asp:Label Text="Alumnos" runat="server" />
        </div>
        <div id="loggedUsers"></div>
    </form>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
    <script>
        $(document).ready(function () {
            setInterval(function () {
                $.ajax({
                    url: "../Publica/UsuariosLogeados.aspx",
                    success: function (result) {
                        $("#loggedUsers").html(result);
                    }
                });
            }, 5000);
        });
    </script>
</body>
</html>
