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
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnRegistro_Click(object sender, EventArgs e)
        {
            LimpiarMensajes();

            if (!Validaciones())
                return;

            Usuario user = new Usuario();
            user.nombre = this.txtNombre.Text;
            user.apellidos = this.txtApellidos.Text;
            user.email = this.txtEmail.Text;
            user.password = this.txtPass1.Text;
            if (this.rbAlumno.Checked)
                user.tipo = "Alumno";
            else
                user.tipo = "Profesor";

            Usuarios usersDll = new Usuarios();
            bool resultado = usersDll.Registro(user);
            if (resultado)
                this.lblRegistroOK.Visible = true;
        }

        private bool Validaciones()
        {
            if (!Utilities.Utilities.IsValidEmail(this.txtEmail.Text))
            {
                this.lblEmailNoValido.Visible = true;
                return false;
            }

            if (!Utilities.Utilities.CheckPasswordsIguales(this.txtPass1.Text, this.txtPass2.Text))
            {
                this.lblPassNoCoinciden.Visible = true;
                return false;
            }

            if (!Utilities.Utilities.CheckLongitudMinimaPassword(this.txtPass1.Text))
            {
                this.lblPassCorta.Visible = true;
                return false;
            }

            return true;
        }

        private void LimpiarMensajes()
        {
            this.lblEmailNoValido.Visible = false;
            this.lblPassCorta.Visible = false;
            this.lblPassNoCoinciden.Visible = false;
            this.lblRegistroOK.Visible = false;
        }
    }
}