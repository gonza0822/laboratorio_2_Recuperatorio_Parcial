using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CentroDeAtencion
{
    public enum EGrupo
    {
        CALL_IN,
        CALL_OUT,
        RRSS
    }
    public class Rac : Empleado
    {
        private static double valorHora;
        private EGrupo grupo;

        private Rac() 
        {
            this.grupo = EGrupo.CALL_IN;
            valorHora = 875.90F;
        }

        public Rac(string legajo, string nombre, TimeSpan horaIngreso)
        {
            this.nombre = nombre;
            this.legajo = legajo;
            this.horaIngreso = horaIngreso;
        }
        public Rac(string legajo, string nombre, TimeSpan horaIngreso, EGrupo grupo, double valorHora)
        {
            this.nombre = nombre;
            this.legajo = legajo;
            this.horaIngreso = horaIngreso;
            this.grupo = grupo;
            valorHora = valorHora;
        }


        public double ValorHora
        {
            get { return valorHora; }
            set
            {
                if(value >= 0)
                {
                    valorHora = value;
                }
            }
        }

        public EGrupo Grupo { get { return grupo; } }

        public string EmitirFactura()
        {
            return $"Factura de: {this.ToString()}\nImporte a facturar: {this.Facturar()}";
        }

        private double CalcularBonoDeGrupo()
        {
            if(this.grupo == EGrupo.CALL_IN)
            {
                return 0;
            } else if(this.grupo == EGrupo.CALL_OUT)
            {
                return 0.1;
            } else
            {
                return 0.2;
            }
        }

        protected new double Facturar()
        {   
            double incrementoValorHora = this.valorHora + (valorHora * CalcularBonoDeGrupo());
            return base.Facturar() * incrementoValorHora;
        }

        public override string ToString()
        {
            return $"{this.nombre.GetType()} - {this.grupo}- { this.legajo} - { this.nombre}";
        }






    }
        
}
