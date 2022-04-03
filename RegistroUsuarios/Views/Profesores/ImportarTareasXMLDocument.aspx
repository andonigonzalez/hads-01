<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImportarTareasXMLDocument.aspx.cs" Inherits="RegistroUsuarios.Views.ImportarTareasXMLDocument" %>

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
            <asp:Label Text="IMPORTAR TAREAS GENÉRICAS" runat="server" />
        </div>
        <div>
            <asp:Label Text="Seleccionar asignatura a importar:" runat="server" />
            <br />
            <asp:DropDownList runat="server" ID="listaAsignaturas" AutoPostBack="true" DataSourceID="DataSourceAsignaturas" DataTextField="nombre" DataValueField="codigo" OnSelectedIndexChanged="listaAsignaturas_SelectedIndexChanged">
            </asp:DropDownList>
        </div>
        <div>
            <asp:Button Text="IMPORTAR (XMLD)" ID="btnImportar" runat="server" OnClick="btnImportar_Click" />
        </div>
        <div>
            <asp:Label Text="Lista de tareas de la asignatura seleccionada" runat="server" />
            <br />
            <asp:Xml ID="Xml1" runat="server"></asp:Xml>
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
    <!--<asp:SqlDataSource ID="DataSourceTareas" runat="server" ConnectionString="<%$ ConnectionStrings:hadsConnectionString %>" SelectCommand="SELECT [codigo], [descripcion], [hEstimadas], [explotacion], [tipoTarea] FROM [TareaGenerica] WHERE ([codAsig] = @codAsig)">
        <SelectParameters>
            <asp:ControlParameter ControlID="listaAsignaturas" Name="codAsig" PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>-->
</body>
</html>
