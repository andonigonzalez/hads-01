using Bll;
using Definitions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RegistroUsuarios.Views
{
    public partial class InsertarTarea : System.Web.UI.Page
    {
        Profesores bllProfesores;

        public InsertarTarea()
        {
            bllProfesores = new Profesores();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Utilities.Utilities.CheckSession(Session))
                Response.Redirect("Inicio.aspx");

            if(!Page.IsPostBack)
                RellenarListaAsignaturas();
        }

        private void RellenarListaAsignaturas()
        {
            DataTable dt = bllProfesores.GetAsignaturasProfesor(Session["email"].ToString());
            DataView dv = new DataView(dt);
            this.listaAsignaturas.DataSource = dv;
            this.listaAsignaturas.DataTextField = "Nombre";
            this.listaAsignaturas.DataValueField = "Codigo";
            this.listaAsignaturas.DataBind();
        }

        protected void btnAddTarea_Click(object sender, EventArgs e)
        {
            TareaGenerica tarea = new TareaGenerica
            {
                codigo = this.txtCodigo.Text,
                descripcion = this.txtDescripcion.Text,
                codAsig = this.listaAsignaturas.SelectedValue,
                hEstimadas = int.Parse(this.txtHorasEstimadas.Text),
                explotacion = false,
                tipoTarea = this.listaTiposTarea.SelectedValue
            };

            ResCrearTarea res = bllProfesores.CrearTarea(tarea);

            MostrarResultado(res);
        }

        private void MostrarResultado(ResCrearTarea res)
        {
            if (res == ResCrearTarea.Ok)
                this.txtMensaje.Text = "Tarea creada correctamente";
            else if (res == ResCrearTarea.TareaExistente)
                this.txtMensaje.Text = "Tarea ya existente";
            else
                this.txtMensaje.Text = "Ha ocurrido un error";
        }
    }
}