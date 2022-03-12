<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VerTareasEstudiante.aspx.cs" Inherits="RegistroUsuarios.Views.VerTareasEstudiante" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button Text="Cerrar Sesión" runat="server" ID="btnCerrarSesion" CausesValidation="False" OnClick="btnCerrarSesion_Click" UseSubmitBehavior="False" />
            <br />
            <asp:Label Text="ALUMNOS" runat="server" />
            <br />
            <asp:Label Text="GESTIÓN DE TAREAS GENÉRICAS" runat="server" />
        </div>
        <div>
            <asp:Label Text="Seleccionar Asignatura (sólo se muestran aquellas en las que está matriculado):" runat="server" />
            <br />
            <asp:DropDownList runat="server" ID="listaAsignaturas" AutoPostBack="true">

            </asp:DropDownList>
        </div>
        <div>

            <asp:GridView ID="gridTareas" runat="server" OnSelectedIndexChanged="gridTareas_SelectedIndexChanged">
                <Columns>
                    <asp:CommandField ShowSelectButton="true" ButtonType="Button" SelectText="Instanciar" />
                </Columns>
                
            </asp:GridView>

        </div>

    </form>
</body>
</html>
