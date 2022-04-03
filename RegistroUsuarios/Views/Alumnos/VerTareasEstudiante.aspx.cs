using Bll;
using Definitions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RegistroUsuarios.Views
{
    public partial class VerTareasEstudiante : System.Web.UI.Page
    {
        Usuario user;
        Alumnos bllAlumnos;

        public VerTareasEstudiante()
        {
            bllAlumnos = new Alumnos();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            /*if (!Utilities.Utilities.CheckSession(Session))
                Response.Redirect("~/Views/Publica/Inicio.aspx");*/

            user = (Usuario)Session["usuario"];

            if (Page.IsPostBack)
            {
                RellenarGridTareas();
            }
            else
            {
                RellenarDropDown();
                RellenarGridTareas();
            }
        }

        private void RellenarGridTareas()
        {
            DataTable dt = bllAlumnos.GetTareasByAlumnoAsignaturaNoInstanciadas(user.email, this.listaAsignaturas.SelectedValue);
            gridTareas.DataSource = dt;
            gridTareas.DataBind();
        }

        private void RellenarDropDown()
        {
            DataTable dt = bllAlumnos.GetAsignaturasByAlumno(user.email);
            DataView dv = new DataView(dt);
            this.listaAsignaturas.DataSource = dv;
            this.listaAsignaturas.DataTextField = "Nombre";
            this.listaAsignaturas.DataValueField = "Codigo";
            this.listaAsignaturas.DataBind();
        }

        protected void gridTareas_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Alumnos/InstanciarTarea.aspx?codTarea=" + gridTareas.SelectedRow.Cells[1].Text);
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            Response.Redirect("~/Views/Publica/Inicio.aspx");
        }
    }
}