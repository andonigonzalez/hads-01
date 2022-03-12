<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GestionarTareas.aspx.cs" Inherits="RegistroUsuarios.Views.GestionarTareas" %>

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
            <br />
            <asp:Button Text="Cerrar Sesión" runat="server" ID="btnCerrarSesion" OnClick="btnCerrarSesion_Click" />
        </div>
        <div>
            <asp:DropDownList runat="server" DataSourceID="DataSourceAsignaturas" DataTextField="nombre" DataValueField="codigo" ID="listaAsignaturas" AutoPostBack="True">
                <asp:ListItem Text="text1" />
                <asp:ListItem Text="text2" />
            </asp:DropDownList>
            <asp:Button Text="Insertar nueva tarea" runat="server" ID="btnInsertarTarea" OnClick="btnInsertarTarea_Click" />
            <asp:GridView ID="gridTareas" runat="server" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="codigo" DataSourceID="DataSourceTareas">
                <Columns>
                    <asp:CommandField ShowEditButton="True" />
                    <asp:BoundField DataField="codigo" HeaderText="codigo" ReadOnly="True" SortExpression="codigo" />
                    <asp:BoundField DataField="descripcion" HeaderText="descripcion" SortExpression="descripcion" />
                    <asp:BoundField DataField="hEstimadas" HeaderText="hEstimadas" SortExpression="hEstimadas" />
                    <asp:CheckBoxField DataField="explotacion" HeaderText="explotacion" SortExpression="explotacion" />
                    <asp:BoundField DataField="tipoTarea" HeaderText="tipoTarea" SortExpression="tipoTarea" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
    <asp:SqlDataSource ID="DataSourceAsignaturas" runat="server" ConnectionString="<%$ ConnectionStrings:hadsConnectionString %>" SelectCommand="GetAsignaturasByProfesor" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:SessionParameter DbType="String" Name="email" SessionField="email" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="DataSourceTareas" runat="server" ConnectionString="<%$ ConnectionStrings:hadsConnectionString %>" DeleteCommand="DELETE FROM [TareaGenerica] WHERE [codigo] = @codigo" InsertCommand="INSERT INTO [TareaGenerica] ([codigo], [descripcion], [hEstimadas], [explotacion], [tipoTarea]) VALUES (@codigo, @descripcion, @hEstimadas, @explotacion, @tipoTarea)" SelectCommand="SELECT [codigo], [descripcion], [hEstimadas], [explotacion], [tipoTarea] FROM [TareaGenerica] WHERE ([codAsig] = @codAsig)" UpdateCommand="UPDATE [TareaGenerica] SET [descripcion] = @descripcion, [hEstimadas] = @hEstimadas, [explotacion] = @explotacion, [tipoTarea] = @tipoTarea WHERE [codigo] = @codigo">
        <DeleteParameters>
            <asp:Parameter Name="codigo" Type="String" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="codigo" Type="String" />
            <asp:Parameter Name="descripcion" Type="String" />
            <asp:Parameter Name="hEstimadas" Type="Int32" />
            <asp:Parameter Name="explotacion" Type="Boolean" />
            <asp:Parameter Name="tipoTarea" Type="String" />
        </InsertParameters>
        <SelectParameters>
            <asp:ControlParameter ControlID="listaAsignaturas" Name="codAsig" PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="descripcion" Type="String" />
            <asp:Parameter Name="hEstimadas" Type="Int32" />
            <asp:Parameter Name="explotacion" Type="Boolean" />
            <asp:Parameter Name="tipoTarea" Type="String" />
            <asp:Parameter Name="codigo" Type="String" />
        </UpdateParameters>
    </asp:SqlDataSource>
</body>
</html>
