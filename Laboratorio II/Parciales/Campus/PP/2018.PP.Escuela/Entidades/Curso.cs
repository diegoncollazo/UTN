using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Curso
    {
        private List<Alumno> alumnos;
        private short anio;
        private Divisiones division;
        private Profesor profesor;

        public string AnioDivision
        {
            get
            {
                StringBuilder retorno = new StringBuilder();
                retorno.AppendFormat(this.anio + "º" + this.division);
                return retorno.ToString();
            }
        }
        private Curso()
        {
            this.alumnos = new List<Alumno>();
        }

        public Curso(short anio, Divisiones division, Profesor profesor) : this()
        {
            this.profesor = profesor;
            this.division = division;
            this.anio = anio;
        }

        public static explicit operator string(Curso curso)
        {
            StringBuilder retorno = new StringBuilder();
            retorno.Append("Año: ");
            retorno.AppendLine(Convert.ToString(curso.anio));
            retorno.Append("Division: ");
            retorno.AppendLine(Convert.ToString(curso.division));
            retorno.Append("Profesor: ");
            retorno.AppendLine(Convert.ToString(curso.profesor.ExponerDatos()));

            foreach (Alumno alumno in curso.alumnos)
            {
                retorno.AppendLine(alumno.ExponerDatos());
            }
            return retorno.ToString();
        }
        public static bool operator ==(Curso curso, Alumno alumno)
        {
            bool retorno = false;

            if (curso.AnioDivision == alumno.AnioDivision)
            {
                retorno = true;
            }
            return retorno;
        }
        public static bool operator !=(Curso curso, Alumno alumno)
        {
            return !(curso == alumno);
        }

        public static Curso operator +(Curso curso, Alumno alumno)
        {
            if (curso.AnioDivision == alumno.AnioDivision)
            {
                curso.alumnos.Add(alumno);
            }
            return curso;
        }
    }
}
