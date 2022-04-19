using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RegistroUsuarios.Views.Publica
{
    public partial class UsuariosLogeados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<string> alumnos = (List<string>)Application["alumnos"] ?? new List<string>();
            List<string> profes = (List<string>)Application["profesores"] ?? new List<string>();
            txtCuantos.Text = string.Format("USUARIOS LOGEADOS: {0} Alumno/s y {1} Profe/s", alumnos.Count, profes.Count);
            listaAlumnos.DataSource = alumnos;
            listaAlumnos.DataBind();
            listaProfes.DataSource = profes;
            listaProfes.DataBind();
        }
    }
}