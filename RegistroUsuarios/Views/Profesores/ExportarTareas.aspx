<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExportarTareas.aspx.cs" Inherits="RegistroUsuarios.Views.ExportarTareas" %>

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
            <asp:Label Text="EXPORTAR TAREAS GENÉRICAS" runat="server" />
        </div>
        <div>
            <asp:Label Text="Seleccionar Asignatura a Exportar:" runat="server" />
            <br />
            <asp:DropDownList runat="server" ID="listaAsignaturas" AutoPostBack="true" DataSourceID="DataSourceAsignaturas" DataTextField="nombre" DataValueField="codigo" OnSelectedIndexChanged="listaAsignaturas_SelectedIndexChanged" >
            </asp:DropDownList>
        </div>
        <div>
            <asp:Button Text="EXPORTAR XML" ID="btnExportarXml" runat="server" OnClick="btnExportarXml_Click" />
        </div>
        <div>
            <asp:GridView ID="gridTareas" runat="server"></asp:GridView>
        </div>
        <div>
            <asp:HyperLink NavigateUrl="~/Views/Profesores/Profesor.aspx" runat="server" Text="Menu Profesor" />
        </div>
        <div>
            <asp:Label Text="" runat="server" ID="txtMensajes" />
        </div>
    </form>
    <asp:SqlDataSource ID="DataSourceAsignaturas" runat="server" ConnectionString="<%$ ConnectionStrings:hadsConnectionString %>" SelectCommand="GetAsignaturasByProfesor" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:SessionParameter DbType="String" Name="email" SessionField="email" />
        </SelectParameters>
    </asp:SqlDataSource>
</body>
</html>
