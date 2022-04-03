<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InstanciarTarea.aspx.cs" Inherits="RegistroUsuarios.Views.InstanciarTarea" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label Text="ALUMNOS" runat="server" />
            <br />
            <asp:Label Text="INSTANCIAR TAREA GENÉRICA" runat="server" />
        </div>
        <div>
            <asp:Label Text="Usuario" runat="server" />
            <asp:TextBox runat="server" Enabled="False" ID="txtUsuario" />
            <br />
            <asp:Label Text="Tarea" runat="server" />
            <asp:TextBox runat="server" Enabled="False" ID="txtTarea" />
            <br />
            <asp:Label Text="Horas Est." runat="server" />
            <asp:TextBox runat="server" Enabled="False" ID="txtHorasEstimadas" />
            <br />
            <asp:Label Text="Horas Reales" runat="server" />
            <asp:TextBox runat="server" ID="txtHorasReales" />
            <br />
            <asp:Button Text="Instanciar tarea" runat="server" ID="btnInstanciar" OnClick="btnInstanciar_Click" />
            <br />
            <asp:HyperLink NavigateUrl="~/Views/Alumnos/VerTareasEstudiante.aspx" runat="server" Text="Página anterior" />
            <br />
            <asp:Label Text="" runat="server" ID="txtMensaje" />
        </div>
        <div>
            <asp:GridView runat="server" ID="gridTareas"></asp:GridView>
        </div>
    </form>
</body>
</html>
