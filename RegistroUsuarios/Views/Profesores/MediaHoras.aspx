<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MediaHoras.aspx.cs" Inherits="RegistroUsuarios.Views.Profesores.MediaHoras" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:DropDownList runat="server" DataSourceID="DataSourceAsignaturas" DataTextField="nombre" DataValueField="codigo" ID="listaAsignaturas" AutoPostBack="False">
            </asp:DropDownList>
        </div>
        <div>
            La media de horas en la asignatura seleccionada es: <span id="resultado"></span>
        </div>
    </form>
    <asp:SqlDataSource ID="DataSourceAsignaturas" runat="server" ConnectionString="<%$ ConnectionStrings:hadsConnectionString %>" SelectCommand="GetAsignaturas" SelectCommandType="StoredProcedure">
    </asp:SqlDataSource>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
    <script>
        $(document).ready(function () {
            $("#listaAsignaturas").change(function () {
                $.ajax({
                    url: "https://mediahorasapi.azurewebsites.net/mediahoras/"+$("#listaAsignaturas").val(),
                    success: function (result) {
                        $("#resultado").html(result);
                    }
                });
            });
        });
    </script>
</body>
</html>
