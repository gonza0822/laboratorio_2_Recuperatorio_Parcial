using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CentroDeAtencion
{
    public class CentroDeAtencion
    {
        private int cantRacPorSuper;
        private List<Empleado> empleados;
        private string nombre;

        public List<Empleado> Empleados
        {
            get { return this.empleados; }
        }

        public string Nombre
        {
            get { return this.nombre; }
        }

        public CentroDeAtencion(string nombre, int cantRacPorSuper)
        {
            this.nombre = nombre;
            this.cantRacPorSuper = cantRacPorSuper;
            this.empleados = new List<Empleado>();
        }

        public string ImprimirNomina()
        {
            StringBuilder sb = new StringBuilder();


            foreach (Empleado empleado in this.empleados)
            {
                sb.AppendLine(empleado.ToString());
            }

            return sb.ToString();   
        }

        private bool ValidarCantidadDeRacs()
        {
            if (this.empleados.OfType<Rac>().ToList().Count > this.cantRacPorSuper)
            {
                return true;
            } else { return false; }
        }

        public static bool operator ==(CentroDeAtencion c, Empleado e)
        {
            return c.empleados.Contains(e);
        }
        public static bool operator !=(CentroDeAtencion c, Empleado e)
        {
            return !c.empleados.Contains(e);
        }

        public static bool operator +(CentroDeAtencion c, Empleado e)
        {
            if(c != e && c.ValidarCantidadDeRacs())
            {
                c.empleados.Add(e); 
                return true;
            } else
            {
                return false;
            }
        }
        public static string operator -(CentroDeAtencion c, Empleado e)
        {
            if (c != e)
            {
                return "Empleado no encontrado";
            } else
            {
                e.HoraEgreso = DateTime.Now.TimeOfDay;
                c.empleados.Remove(e);
                return e.ToString();
            }
        }
    }
}
