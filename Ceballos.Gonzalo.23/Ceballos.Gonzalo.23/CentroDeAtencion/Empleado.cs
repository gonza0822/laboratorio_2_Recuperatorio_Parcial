using System.Numerics;

namespace CentroDeAtencion
{
    public abstract class Empleado
    {
        protected TimeSpan horaEgreso;
        protected TimeSpan horaIngreso;
        protected string legajo;
        protected string nombre;

        public TimeSpan HoraEgreso
        {
            get { return horaEgreso; }
            set
            {
                this.horaEgreso = validarHoraEgreso(value);
            }
        }

        public TimeSpan HoraIngreso
        {
            get { return horaIngreso; }
        }

        public string Legajo
        {
            get { return legajo; }
        }

        public string Nombre
        {
            get { return nombre; }
        }

        private TimeSpan validarHoraEgreso(TimeSpan hora)
        {
            if(this.HoraEgreso < hora)
            {
                return hora;
            } else
            {
                return DateTime.Now.TimeOfDay;
            }
        }

        protected double Facturar()
        {
            TimeSpan horasTrabajadas = this.horaEgreso - this.HoraIngreso;
            return horasTrabajadas.TotalHours;
        }

        public static bool operator ==(Empleado emp1, Empleado emp2)
        {
            return emp1.legajo == emp2.legajo;
        }
        public static bool operator !=(Empleado emp1, Empleado emp2)
        {
            return emp1.legajo != emp2.legajo;
        }

    }
}