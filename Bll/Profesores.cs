using Definitions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public class Profesores
    {
        private Dal.Profesores profesoresDal;

        public Profesores()
        {
            if (this.profesoresDal == null)
                this.profesoresDal = new Dal.Profesores();
        }

        public DataTable GetAsignaturasProfesor(string email)
        {
            return this.profesoresDal.GetAsignaturasProfesor(email);
        }

        public ResCrearTarea CrearTarea(TareaGenerica tarea)
        {
            return this.profesoresDal.CrearTarea(tarea);
        }
    }
}
