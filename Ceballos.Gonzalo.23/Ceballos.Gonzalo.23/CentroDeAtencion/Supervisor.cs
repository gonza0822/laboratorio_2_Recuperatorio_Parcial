using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentroDeAtencion
{
    public class Supervisor : Empleado
    {
        private static float valorHora;

        public float ValorHora
        {
            get { return valorHora; }
            set
            {
                if (value >= 0)
                {
                    valorHora = value;
                }
            }
        }

        private Supervisor()
        {
            ValorHora = 1025.50F;
        }

        private Supervisor(string legajo)
        {
            this.nombre = "n/a";
            this.legajo = legajo;
            this.horaIngreso = new TimeSpan(09, 00, 00);
        }

        private Supervisor(string legajo, string nombre, TimeSpan horaIngreso)
        {
            this.nombre = nombre;
            this.legajo = legajo;
            this.horaEgreso = horaIngreso;
        }

        public string EmitirFactura()
        {
            return $"Factura de: {this.ToString()}\nImporte a facturar: {this.Facturar()}";
        }

        protected new double Facturar()
        {
            return base.Facturar() * valorHora;
        }

        public override string ToString()
        {
            return $"{this.nombre.GetType()} - {this.legajo} - {this.nombre}";
        }

        public static implicit operator Supervisor(string legajo)
        {
            return new Supervisor(legajo);
        }



    }
}
