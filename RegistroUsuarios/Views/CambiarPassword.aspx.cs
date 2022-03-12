using Bll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RegistroUsuarios.Views
{
    public partial class CambiarPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSolicitarClave_Click(object sender, EventArgs e)
        {
            LimpiarMensajes();

            Usuarios usersBll = new Usuarios();
            bool resultado = usersBll.SolicitarCambioPassword(this.txtEmail.Text);
            if (resultado)
                this.lblClaveEnviada.Visible = true;
        }

        protected void btnComprobarClave_Click(object sender, EventArgs e)
        {
            LimpiarMensajes();

            Usuarios usersBll = new Usuarios();
            bool res = usersBll.ComprobarClave(this.txtClave.Text, this.txtEmail.Text);
            if (res)
                this.panel.Visible = true;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            LimpiarMensajes();

            if (!Validaciones())
                return;
                    
            Usuarios usersDll = new Usuarios();
            bool res = usersDll.ModificarPassword(this.txtEmail.Text, this.txtPass1.Text);
            if (res)
                this.lblPassModificada.Visible = true;
        }

        private bool Validaciones()
        {
            if (!Utilities.Utilities.CheckPasswordsIguales(this.txtPass1.Text, this.txtPass2.Text))
            {
                this.lblPassDiferentes.Visible = true;
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
            this.lblClaveEnviada.Visible = false;
            this.lblPassCorta.Visible = false;
            this.lblPassDiferentes.Visible = false;
            this.lblPassModificada.Visible = false;
        }
    }
}