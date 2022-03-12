using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RegistroUsuarios.Views
{
    public partial class GestionarTareas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Utilities.Utilities.CheckSession(Session))
                Response.Redirect("Inicio.aspx");
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Inicio.aspx");
        }

        protected void btnInsertarTarea_Click(object sender, EventArgs e)
        {
            Response.Redirect("InsertarTarea.aspx");
        }
    }
}