using Bll;
using Definitions;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace RegistroUsuarios.Views
{
    public partial class ImportarTareasXMLDocument : System.Web.UI.Page
    {
        Profesores bllProfesores;
        string pathDocument = string.Empty;

        public ImportarTareasXMLDocument()
        {
            bllProfesores = new Profesores();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Utilities.Utilities.CheckSession(Session))
                Response.Redirect("Inicio.aspx");

            CargarXml();
        }

        protected void listaAsignaturas_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarXml();
        }

        private void CargarXml()
        {
            try
            {
                this.txtMensajes.Text = string.Empty;

                this.pathDocument = Server.MapPath(string.Format("~/App_Data/{0}.xml", listaAsignaturas.SelectedValue));
                string pathTransform = Server.MapPath("~/App_Data/VerTablaTareas.xsl");

                if (!File.Exists(pathDocument))
                {
                    this.txtMensajes.Text = string.Format("No existe el fichero {0}", pathDocument);
                    return;
                }
                if (!File.Exists(pathTransform))
                {
                    this.txtMensajes.Text = string.Format("No existe el fichero {0}", pathTransform);
                    return;
                }

                Xml1.DocumentSource = pathDocument;
                Xml1.TransformSource = pathTransform;
            }
            catch (Exception ex)
            {
                this.txtMensajes.Text = ex.Message;
            }
        }

        protected void btnImportar_Click(object sender, EventArgs e)
        {
            if (File.Exists(pathDocument))
            {
                ResCrearTarea res = bllProfesores.ImportarTareas(pathDocument, listaAsignaturas.SelectedValue);

                if (res == ResCrearTarea.Ok)
                    this.txtMensajes.Text = "Tareas importadas correctamente";
                else if (res == ResCrearTarea.TareaExistente)
                    this.txtMensajes.Text = "Tareas existentes";
                else
                    this.txtMensajes.Text = "Ha ocurrido un error";
            }
        }
    }
}