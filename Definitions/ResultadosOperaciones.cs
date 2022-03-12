using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Definitions
{
    class ResultadosOperaciones
    {
    }

    public enum ResInstanciarTarea
    {
        Error = -2,
        TareaInstanciada = -1,
        Ok = 0
    }

    public enum ResCrearTarea
    {
        Error = -2,
        TareaExistente = -1,
        Ok = 0
    }
}
