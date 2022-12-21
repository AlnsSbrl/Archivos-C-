using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelManager
{
    public class Empleado : Persona
    {
        private double salario;
        private double IRPF;
        public double Salario
        {
            set
            {
                salario = value;
                switch (value)
                {
                    case double salario when (salario < 600):
                        IRPF = 7;
                        break;
                    case double salario when (salario >= 600 && salario < 3000):
                        IRPF = 15;
                        break;
                    case double salario when salario >= 3000:
                        IRPF = 20;
                        break;
                }
            }
            get => salario;
        }

        private string telefono;
        public string Telefono
        {
            set
            {
                telefono = value;
            }
            get => "+34" + telefono;
        }

        public override double Hacienda()
        {
            return IRPF / 100 * Salario;
        }
        public override void MuestraCampos()
        {
            base.MuestraCampos();
            Console.WriteLine("Teléfono: {0}\n"
                + "Salario: {1}\n"
                + "Para Hacienda {2}", Telefono, Salario, Hacienda());
        }
        public override void PideCampos()
        {
            base.PideCampos();
            Console.WriteLine("Deme el salario");
            Salario = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Deme el teléfono");
            Telefono = Console.ReadLine();
        }

        public Empleado()
            : this(0, "", "", "", "1", 0)
        {
        }
        public Empleado(double salario, string telefono, string nombre, string apellidos, string dni, int edad)
            : base(nombre, apellidos, dni, edad)
        {
            Salario = salario;
            Telefono = telefono;
        }
    }
}
