using Definitions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public class Alumnos
    {
        private Dal.Alumnos alumnosDal;

        public Alumnos()
        {
            if (this.alumnosDal == null)
                this.alumnosDal = new Dal.Alumnos();
        }

        public DataTable GetAsignaturasByAlumno(string email)
        {
            return this.alumnosDal.GetAsignaturasAlumno(email);
        }

        public DataTable GetTareasByAlumnoAsignaturaNoInstanciadas(string email, string asignatura)
        {
            return this.alumnosDal.GetTareasByAlumnoAsignaturaNoInstanciadas(email, asignatura);
        }

        public DataTable GetTareasByAlumnoAsignaturaInstanciadas(string email)
        {
            return this.alumnosDal.GetTareasByAlumnoAsignaturaInstanciadas(email);
        }

        public TareaGenerica GetDatosEstudianteTarea(string codTarea)
        {
            return this.alumnosDal.GetDatosTareaGenerica(codTarea);
        }

        public ResInstanciarTarea InstanciarTarea(EstudianteTarea tarea)
        {
            return this.alumnosDal.InstanciarTarea(tarea);
        }
    }
}
