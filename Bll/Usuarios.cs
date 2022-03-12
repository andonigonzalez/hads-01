using Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public class Usuarios
    {
        private Dal.Usuarios usersDal;

        public Usuarios()
        {
            if (this.usersDal == null)
                this.usersDal = new Dal.Usuarios();
        }

        public bool Registro(Usuario user)
        {
            user.numConfirmacion = GenerarNumConfirmacion();

            bool resRegistro = this.usersDal.Registro(user);
            if (!resRegistro)
                return false;

            bool resEmail = EnvioMailConfirmacion(user);
            if (!resEmail)
                return false;

            return true;
        }

        public bool Confirmar(string email, string numConfirmacion)
        {
            int numConf = Int32.Parse(numConfirmacion);
            return usersDal.Confirmar(email, numConf);
        }

        public bool SolicitarCambioPassword(string email)
        {
            int clave = GenerarClavePassword();
            bool resGuardarClave = usersDal.GuardarClave(email, clave);
            if (!resGuardarClave)
                return false;

            bool resEnvioMail = EnvioMailSolicitudCambioPassword(email, clave);
            if (!resEnvioMail)
                return false;

            return true;
        }

        public bool ComprobarClave(string clave, string email)
        {
            int claveInt = Int32.Parse(clave);
            return usersDal.ComprobarClave(email, claveInt);
        }

        public bool ModificarPassword(string email, string pass1)
        {
            return usersDal.ModificarPassword(email, pass1);
        }

        public Usuario Login(string email, string pass)
        {
            return usersDal.Login(email, pass);
        }

        private int GenerarNumConfirmacion()
        {
            Random rnd = new Random();
            return rnd.Next(1000000, 9000000);
        }

        private int GenerarClavePassword()
        {
            Random rnd = new Random();
            return rnd.Next(100000, 999999);
        }

        private bool EnvioMailConfirmacion(Usuario user)
        {
            try
            {
                string subject = "Confirmación de registro";
                string body = "Este es un correo para confirmar el registro en la app del laboratorio de HADS.\n" +
                    "Haz click en el siguiente enlace para realizar la confirmación \n" +
                    "http://hads01.azurewebsites.net/Views/Confirmar.aspx?mbr=" + user.email + "&numconf=" + user.numConfirmacion;

                Email email = new Email();
                email.Crear(user.email, subject, body);
                email.Enviar();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool EnvioMailSolicitudCambioPassword(string to, int clave)
        {
            try
            {
                string subject = "Solicitud cambio password";
                string body = "Esta es la clave para modificar la contraseña: " + clave.ToString();

                Email email = new Email();
                email.Crear(to, subject, body);
                email.Enviar();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
