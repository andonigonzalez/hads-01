using Bll;
using Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RegistroUsuarios
{
    public partial class Inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            LimpiarMensajes();

            Usuarios usersBll = new Usuarios();
            Usuario user = usersBll.Login(this.txtEmail.Text, this.txtPassword.Text);
            if (user == null)
            {
                lblLoginIncorrecto.Visible = true;
                return;
            }

            Session.Add("usuario", user);
            Session.Add("email", user.email);

            Redireccion(user);
        }

        private void LimpiarMensajes()
        {
            this.lblLoginIncorrecto.Visible = false;
        }

        private void Redireccion(Usuario user)
        {
            if (user.tipo == "Alumno")
                Response.Redirect("Alumno.aspx");
            else if (user.tipo == "Profesor")
                Response.Redirect("Profesor.aspx");
            else
                Response.Redirect("Bienvenido.aspx");
        }
    }
}