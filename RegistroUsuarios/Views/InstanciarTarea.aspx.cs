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
    public partial class InstanciarTarea : System.Web.UI.Page
    {
        Usuario user;
        Alumnos bllAlumnos;

        public InstanciarTarea()
        {
            bllAlumnos = new Alumnos();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Utilities.Utilities.CheckSession(Session))
                Response.Redirect("Inicio.aspx");

            user = (Usuario)Session["usuario"];

            if (!Page.IsPostBack)
            {
                RellenarGridTareas();
                RellenarDatosTarea();
            }
        }

        private void RellenarGridTareas()
        {
            DataTable dt = bllAlumnos.GetTareasByAlumnoAsignaturaInstanciadas(user.email);
            gridTareas.DataSource = dt;
            gridTareas.DataBind();
        }

        private void RellenarDatosTarea()
        {
            if (!CheckQueryString())
                Response.Redirect("Inicio.aspx");

            TareaGenerica tarea = bllAlumnos.GetDatosEstudianteTarea(Request.QueryString["codTarea"]);
            txtTarea.Text = tarea.codigo;
            txtUsuario.Text = user.email;
            txtHorasEstimadas.Text = tarea.hEstimadas.ToString();
        }

        private bool CheckQueryString()
        {
            return !string.IsNullOrEmpty(Request.QueryString["codTarea"]);
        }

        protected void btnInstanciar_Click(object sender, EventArgs e)
        {
            int num;
            bool parseo = int.TryParse(this.txtHorasReales.Text, out num);
            if (this.txtHorasReales.Text == string.Empty || !parseo || num < 1)
            {
                this.txtMensaje.Text = "Las horas reales deben ser mayor que cero";
                return;
            }

            EstudianteTarea tarea = new EstudianteTarea
            {
                codTarea = this.txtTarea.Text,
                email = this.txtUsuario.Text,
                hEstimadas = int.Parse(this.txtHorasEstimadas.Text),
                hReales = int.Parse(this.txtHorasReales.Text)
            };
            ResInstanciarTarea res = bllAlumnos.InstanciarTarea(tarea);
            MostrarMensajesInstanciarTarea(res);
        }

        private void MostrarMensajesInstanciarTarea(ResInstanciarTarea res)
        {
            if (res == ResInstanciarTarea.Ok)
                this.txtMensaje.Text = "Tarea instanciada correctamente";
            else if (res == ResInstanciarTarea.TareaInstanciada)
                this.txtMensaje.Text = "Esa tarea ya está instanciada";
            else
                this.txtMensaje.Text = "Ha ocurrido un error";
        }
    }
}