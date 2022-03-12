using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Definitions
{
    public class Usuario
    {
        public string email { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public int numConfirmacion { get; set; }
        public bool confirmado { get; set; }
        public string tipo { get; set; }
        public string password { get; set; }
        public string codPassword { get; set; }
    }
}
