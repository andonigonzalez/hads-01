using Definitions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

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

        public ResCrearTarea ImportarTareas(string path, string codAsig)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(path);
            XmlReader reader = new XmlNodeReader(xml);

            DataSet ds = new DataSet();
            ds.ReadXml(reader);

            ds.Tables[0].Columns.Add("codAsig");

            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                dr["codAsig"] = codAsig;
            }

            return this.profesoresDal.ImportarTareas(ds);
        }

        public DataSet GetTareasByAsignatura(string codAsig)
        {
            return this.profesoresDal.GetTareasByAsignatura(codAsig);
        }
    }
}
