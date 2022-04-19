using Bll;
using Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
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
            if (user == null || !Utilities.Utilities.CheckPasswords(this.txtPassword.Text, user.password))
            {
                lblLoginIncorrecto.Visible = true;
                return;
            }

            Session.Add("usuario", user);
            Session.Add("email", user.email);

            SaveLoggedUser(user.email, user.tipo);

            GenerateAuthCookie(user);

            Redireccion(user);
        }

        private void SaveLoggedUser(string email, string rol)
        {
            if (rol == "Alumno")
            {
                List<string> alumnos = (List<string>)Application["alumnos"] ?? new List<string>();
                if (!alumnos.Contains(email))
                {
                    alumnos.Add(email);
                    Application["alumnos"] = alumnos;
                }
            }
            if (rol == "Profesor")
            {
                List<string> profesores = (List<string>)Application["profesores"] ?? new List<string>();
                if (!profesores.Contains(email))
                {
                    profesores.Add(email);
                    Application["profesores"] = profesores;
                }
            }
        }

        private void GenerateAuthCookie(Usuario user)
        {
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
            1,
            user.email,
            DateTime.Now,
            DateTime.Now.AddMinutes(30),
            true,
            user.tipo,
            FormsAuthentication.FormsCookiePath);

            string hash = FormsAuthentication.Encrypt(ticket);
            HttpCookie cookie = new HttpCookie(
               FormsAuthentication.FormsCookieName,
               hash);

            if (ticket.IsPersistent) cookie.Expires = ticket.Expiration;

            Response.Cookies.Add(cookie);
        }

        private void LimpiarMensajes()
        {
            this.lblLoginIncorrecto.Visible = false;
        }

        private void Redireccion(Usuario user)
        {
            if (user.tipo == "Alumno")
                Response.Redirect("~/Views/Alumnos/Alumno.aspx");
            else if (user.tipo == "Profesor")
                Response.Redirect("~/Views/Profesores/Profesor.aspx");
        }
    }
}