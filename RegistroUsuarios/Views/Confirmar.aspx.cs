using Bll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RegistroUsuarios.Views
{
    public partial class Confirmar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string email = Request.QueryString["mbr"];
            string numConfirmacion = Request.QueryString["numconf"];
            Usuarios usersDll = new Usuarios();
            bool resultado = usersDll.Confirmar(email, numConfirmacion);

            if (resultado)
            {
                this.ok.Visible = true;
                this.linkInicio.Visible = true;
            }
            else
            {
                this.ko.Visible = true;
                this.linkInicio.Visible = true;
                //RedireccionInicio();
            }
        }

        private void RedireccionInicio()
        {
            System.Threading.Thread.Sleep(3000);
            Response.Redirect("Inicio.aspx");
        }
    }
}