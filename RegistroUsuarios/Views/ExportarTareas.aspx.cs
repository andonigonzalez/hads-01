using Bll;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace RegistroUsuarios.Views
{
    public partial class ExportarTareas : System.Web.UI.Page
    {
        Profesores bllProfesores;
        DataSet ds;

        public ExportarTareas()
        {
            bllProfesores = new Profesores();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Utilities.Utilities.CheckSession(Session))
                Response.Redirect("Inicio.aspx");

            CargarGrid();
        }

        private void CargarGrid()
        {
            this.ds = this.bllProfesores.GetTareasByAsignatura(this.listaAsignaturas.SelectedValue);
            this.gridTareas.DataSource = this.ds;
            this.gridTareas.DataBind();
        }

        protected void listaAsignaturas_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarGrid();
        }

        protected void btnExportarXml_Click(object sender, EventArgs e)
        {
            try
            {
                XmlDocument xml = new XmlDocument();
                XmlElement tareas = xml.CreateElement("tareas");
                xml.AppendChild(tareas);
                foreach (DataRow dr in this.ds.Tables["TareasGenericas"].Rows)
                {
                    XmlElement tarea = xml.CreateElement("tarea");
                    tarea.SetAttribute("codigo", dr["codigo"].ToString());
                    tareas.AppendChild(tarea);

                    XmlElement descripcion = xml.CreateElement("descripcion");
                    descripcion.InnerText = dr["descripcion"].ToString();
                    tarea.AppendChild(descripcion);

                    XmlElement hEstimadas = xml.CreateElement("hestimadas");
                    hEstimadas.InnerText = dr["hestimadas"].ToString();
                    tarea.AppendChild(hEstimadas);

                    XmlElement tipoTarea = xml.CreateElement("tipotarea");
                    tipoTarea.InnerText = dr["tipotarea"].ToString();
                    tarea.AppendChild(tipoTarea);

                    XmlElement explotacion = xml.CreateElement("explotacion");
                    explotacion.InnerText = dr["explotacion"].ToString();
                    tarea.AppendChild(explotacion);
                }

                string path = Server.MapPath(string.Format("~/App_Data/{0}.xml", this.listaAsignaturas.SelectedValue));
                xml.Save(path);

                this.txtMensajes.Text = string.Format("El archivo se ha generado correctamente en la siguiente ruta '{0}'", path);
            }
            catch (Exception)
            {
                this.txtMensajes.Text = "Ha ocurrido un error";
            }
        }
    }
}