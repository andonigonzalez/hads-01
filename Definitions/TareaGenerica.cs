using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Definitions
{
    public class TareaGenerica
    {
        public string codigo { get; set; }
        public string descripcion { get; set; }
        public string codAsig { get; set; }
        public int hEstimadas { get; set; }
        public bool explotacion { get; set; }
        public string tipoTarea { get; set; }
    }
}
