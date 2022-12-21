using System;
/*Dividimos el número completo del DNI entre 23, sin sacar decimales.
Utilizamos el resto de la división para calcular la letra. Dicho resto estará siempre entre 0 y 22.
Según el valor obtenido, sabremos qué letra corresponde siguiendo el siguiente código: TRWAGMYFPDXBNJZSQVHLCKE. Aquí, la T corresponde al valor 0 y la E al 22. */
namespace PersonnelManager
{
    public abstract class Persona
    {
        public string Nombre;
        public string Apellidos;
        private readonly string letrasDNI = "TRWAGMYFPDXBNJZSQVHLCKE";
        private string dni;
        public string Dni
        {
            set
            {
                try
                {
                    dni = Convert.ToString(Convert.ToInt32(value));
                }
                catch (ArgumentException)
                {
                    dni = value.Substring(0, value.Length - 1);
                }
                catch (System.FormatException)
                {
                    dni = value.Substring(0, value.Length - 1);
                }
            }
            get => dni + letrasDNI[Convert.ToInt32(dni) % 23];
        }
        private int edad;
        public int Edad
        {
            set
            {
                if (value < 0) edad = 0;
                else edad = value;
            }
            get => edad;
        }

        public virtual void MuestraCampos()
        {
            Console.WriteLine("Nombre: {0}\n"
                + "Apellido: {1}\n"
                + "Edad: {2}\n"
                + "DNI: {3}\n", this.Nombre, this.Apellidos, this.Edad, this.Dni);
        }

        public virtual void PideCampos()
        {
            Console.WriteLine("Deme el nombre");
            this.Nombre = Console.ReadLine();
            Console.WriteLine("Deme los apellidos");
            this.Apellidos = Console.ReadLine();
            Console.WriteLine("Deme la edad");
            this.Edad = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Deme el DNI");
            this.Dni = Console.ReadLine();
        }
        public abstract double Hacienda();


        public Persona(string nombre, string apellidos, string dni, int edad)
        {
            Nombre = nombre;
            Apellidos = apellidos;
            Dni = dni;
            Edad = edad;
        }
        public Persona()
            : this("", "", "1", 0)
        {
        }
    }
}
