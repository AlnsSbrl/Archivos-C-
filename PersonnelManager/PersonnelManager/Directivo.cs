using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelManager
{
    public class Directivo : Persona, IPastaGansa
    {
        public string departamento;
        private double beneficios;
        private double pastaGanada;
        public double PastaGanada
        {
            get => pastaGanada;
        }

        public double Beneficios
        {
            get => beneficios;
        }
        private int personasACargo;
        public int PersonasACargo
        {
            set
            {
                personasACargo = value;
                if (personasACargo <= 10)
                {
                    beneficios = 2;
                }
                else if (personasACargo <= 50)
                {
                    beneficios = 3.5;
                }
                else
                {
                    beneficios = 4;
                }
            }
            get => personasACargo;
        }

        public Directivo(string departamento, double beneficios, int personasACargo, string nombre, string apellidos, string dni, int edad)
            : base(nombre, apellidos, dni, edad)
        {
            this.departamento = departamento;
            this.PersonasACargo = personasACargo;
            this.beneficios = beneficios;
        }
        public Directivo(string departamento, int personasACargo, string nombre, string apellidos, string dni, int edad)
            : base(nombre, apellidos, dni, edad)
        {
            this.departamento = departamento;
            this.PersonasACargo = personasACargo;
        }

        public Directivo()
            : this("", 0, 0, "", "", "1", 0)
        {
        }
        //Sobrecarga el operador -- (mira el apéndice y deduce como hacerlo) de forma que si se aplica a un 
        // Directivo decremente en una unidad el porcentaje de beneficios pero nunca bajará de 0.

        public static Directivo operator --(Directivo direct)
        {
            if (direct.beneficios > 1)
            {
                direct.beneficios = direct.beneficios - 1;
            }
            return direct;
        }
        public override double Hacienda()
        {
            return 0.3 * PastaGanada;
        }

        public override void MuestraCampos()
        {
            base.MuestraCampos();
            Console.WriteLine("El nombre del departamento es {0}", this.departamento);
            Console.WriteLine("El número de personas que tiene a cargo es de {0}", this.personasACargo);
            Console.WriteLine("El porcentaje de beneficios es: {0}%", this.beneficios);
        }

        public override void PideCampos()
        {
            base.PideCampos();
            Console.WriteLine("Deme el nombre del departamento");
            this.departamento = Console.ReadLine();
            Console.WriteLine("Deme el numero de personas de las que está a cargo");
            this.personasACargo = Convert.ToInt32(Console.ReadLine());
        }

        public double ganarPasta(double beneficio)
        {
            if (beneficio < 0)
            {
                Directivo thisDecre = this;
                pastaGanada = 0;
                thisDecre--;
                return 0;
            }
            pastaGanada = beneficio * beneficios / 100;
            return pastaGanada;
        }
    }
}
