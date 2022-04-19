<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profesor.aspx.cs" Inherits="RegistroUsuarios.Views.Profesor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:HyperLink NavigateUrl="#" runat="server" Text="Asignaturas" />
            <br />
            <asp:HyperLink NavigateUrl="~/Views/Profesores/GestionarTareas.aspx" runat="server" Text="Tareas" />
            <br />
            <asp:HyperLink NavigateUrl="#" runat="server" Text="Grupos" />
            <br />
            <asp:HyperLink NavigateUrl="~/Views/Profesores/ImportarTareasXMLDocument.aspx" runat="server" Text="Importar v. XML Document" />
            <br />
            <asp:HyperLink NavigateUrl="~/Views/Profesores/ExportarTareas.aspx" runat="server" Text="Exportar" />
            <br />
            <asp:HyperLink NavigateUrl="#" runat="server" Text="Importar v. DataSet" />
            <br />
            <asp:HyperLink NavigateUrl="~/Views/Profesores/MediaHoras.aspx" runat="server" Text="Medias de horas dedicadas" />
        </div>
        <div>
            <asp:Label Text="Gestión Web de Tareas-Dedicación" runat="server" />
            <br />
            <asp:Label Text="Profesores" runat="server" />
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
