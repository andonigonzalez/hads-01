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
            <asp:HyperLink NavigateUrl="GestionarTareas.aspx" runat="server" Text="Tareas" />
            <br />
            <asp:HyperLink NavigateUrl="#" runat="server" Text="Grupos" />
            <br />
            <asp:HyperLink NavigateUrl="ImportarTareasXMLDocument.aspx" runat="server" Text="Importar v. XML Document" />
            <br />
            <asp:HyperLink NavigateUrl="ExportarTareas.aspx" runat="server" Text="Exportar" />
            <br />
            <asp:HyperLink NavigateUrl="#" runat="server" Text="Importar v. DataSet" />
        </div>
        <div>
            <asp:Label Text="Gestión Web de Tareas-Dedicación" runat="server" />
            <br />
            <asp:Label Text="Profesores" runat="server" />
        </div>
    </form>
</body>
</html>
