<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsertarTarea.aspx.cs" Inherits="RegistroUsuarios.Views.InsertarTarea" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label Text="PROFESOR" runat="server" />
            <br />
            <asp:Label Text="GESTIÓN DE TAREAS GENÉRICAS" runat="server" />
        </div>
        <div>
            <asp:Label Text="Código" runat="server" />
            <asp:TextBox runat="server" ID="txtCodigo" />
            <br />
            <asp:Label Text="Descripción" runat="server" />
            <asp:TextBox runat="server" ID="txtDescripcion" Rows="3" Columns="50" TextMode="MultiLine" />
            <br />
            <asp:Label Text="Asignatura" runat="server" />
            <asp:DropDownList runat="server" ID="listaAsignaturas">
                <asp:ListItem Text="text1" />
                <asp:ListItem Text="text2" />
            </asp:DropDownList>
            <br />
            <asp:Label Text="Horas Estimadas" runat="server" />
            <asp:TextBox runat="server" ID="txtHorasEstimadas" />
            <br />
            <asp:Label Text="TipoTarea" runat="server" />
            <asp:DropDownList runat="server" ID="listaTiposTarea">
                <asp:ListItem Text="Ejercicio" />
                <asp:ListItem Text="Examen" />
                <asp:ListItem Text="Laboratorio" />
            </asp:DropDownList>
            <br />
            <asp:Button Text="Añadir Tarea" runat="server" ID="btnAddTarea" OnClick="btnAddTarea_Click" UseSubmitBehavior="False" />
            <br />
            <asp:HyperLink NavigateUrl="~/Views/Profesores/GestionarTareas.aspx" runat="server" Text="Ver Tareas" />
            <br />
            <asp:Label Text="" runat="server" ID="txtMensaje" />
        </div>
    </form>
</body>
</html>
