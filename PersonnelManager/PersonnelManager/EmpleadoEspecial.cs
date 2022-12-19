using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelManager
{
    class EmpleadoEspecial : Empleado, IPastaGansa
    {
        private double pastaGanada;
        public double PastaGanada
        {
            get => pastaGanada;
        }

        public double ganarPasta(double beneficio)
        {
            pastaGanada = beneficio * 0.5 / 100;
            return pastaGanada;
        }

        public override double Hacienda()
        {
            return 1.05 * base.Hacienda();
        }
        public EmpleadoEspecial(double salario, string telefono, string nombre, string apellidos, string dni, int edad)
            : base(salario, telefono, nombre, apellidos, dni, edad)
        {
        }
    }
}
