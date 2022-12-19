using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelManager
{
    public class InterfazUsuario
    {
        bool finalizar = false;
        GestorPersonas listaPersonas = new GestorPersonas();
        /*
• Eliminar personas (Se ha de pedir un rango de posiciones). Muestra los
datos de las personas a eliminar y pide confirmación previa.
• Visualizar toda las lista de Personas.
En cada línea aparecerá formateado el número de posición en la
colección (3 caracteres), Nombre (máximo 10 caracteres), Apellidos
(Máximo 20 caracteres), una E si es empleado y D si es Directivo.
Deben aparecer cabeceras en la parte superior.
Si el Nombre o los apellidos son muy grandes que los corte y le ponga
puntos suspensivos al final. Por ejemplo Nabucodonosor aparecerá como
Nabucod… (así ocupa los 10 caracteres).
• Visualización de una persona. Se pide el comienzo del apellido y
muestra los datos de la primera persona que corresponda simplemente
llamando a la función MostrarDatos. Si además es directivo, llama a
ganarPasta con parámetro 1000.
• Salir del programa */
        public void InsertarPersona()
        {
            int op;
            do
            {
                Console.WriteLine("Quere insertar un empregado ou directivo?" +
                    "\n1)Empregado" +
                    "\n2)Directivo" +
                    "\n3)Cancelar");
                int.TryParse(Console.ReadLine(), out op);
            } while (op < 1 || op > 3);
            if (op == 1)
            {
                Empleado empleado = new Empleado();
                empleado.PideCampos();
                int index = listaPersonas.Posicion(empleado.Edad);
                listaPersonas.personasDeLaEmpresa.Insert(index - 1, empleado);
            }
            else if (op == 2)
            {
                Directivo direct = new Directivo();
                direct.PideCampos();
                int index = listaPersonas.Posicion(direct.Edad);
                listaPersonas.personasDeLaEmpresa.Insert(index - 1, direct);
            }

        }
        public void EliminarPersona()
        {
            int index;
            int rango;
            do
            {
                Console.WriteLine("Vas a despedir a un numero de persoas segun a sua idade, quen queres que sexa o primeiro en marchar pola porta?");
            } while (!int.TryParse(Console.ReadLine(), out index));
            do
            {
                Console.WriteLine("Perfecto, e a cantos queres despedir?");
            } while (!int.TryParse(Console.ReadLine(), out rango));

            try
            {
                for (int i = index; i < rango + index; i++)
                {
                    listaPersonas.personasDeLaEmpresa[i].MuestraCampos();
                }
                int borrar;
                do
                {
                    Console.WriteLine("De verdade quere despedir a esas persoas? ON THIS ECONOMY?" +
                        "\n1)Sí" +
                        "\n2)No");
                } while (int.TryParse(Console.ReadLine(), out borrar));
                if (borrar == 1)
                {
                    listaPersonas.Eliminar(rango + index, index);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("As leis laborais (ou da física) impiden despedir a persoas que non existen");
            }
        }
        public void MuestraTodaLaLista()
        {
            int i=0;
            Console.WriteLine($"{0,3}{1,10}{2,20}{3,7}","Num", "Nome","Apelidos","Estatus");
            foreach (Persona persona in listaPersonas.personasDeLaEmpresa)
            {
                Console.WriteLine($"{0,3}{1,10}{2,20}{3,7}",
                    i, 
                    persona.Nombre.Length > 10 ? persona.Nombre.Substring(0, 7) + "..." : persona.Nombre,
                    persona.Apellidos.Length>20?persona.Apellidos.Substring(0,17)+"...":persona.Apellidos,
                    persona is Directivo?"D "/*+((Directivo)persona).ganarPasta(1000)*/:"E");
                i++;
            }
        }
        public void MuestraPersona()
        {
            Console.WriteLine("Poña o apelido da persoa que quere visualizar");
            string apelido = Console.ReadLine();
            bool segueBuscando = true;
            for (int i = 0; i < listaPersonas.personasDeLaEmpresa.Count && segueBuscando; i++)
            {
                if (listaPersonas.personasDeLaEmpresa[i].Apellidos.StartsWith(apelido))
                {
                    segueBuscando = false;
                    listaPersonas.personasDeLaEmpresa[i].MuestraCampos();
                    if(listaPersonas.personasDeLaEmpresa[i] is Directivo)
                    {
                        //listaPersonas.personasDeLaEmpresa[i].GetType() == typeof(Directivo) tmb vale
                        ((Directivo)listaPersonas.personasDeLaEmpresa[i]).ganarPasta(1000);
                    }
                }
            }
        }

        public void Inicio()
        {
            int opcion;
            do
            {
                Console.WriteLine("Escolla unha opción:" +
                    "\n1)Insertar unha nova persoa" +
                    "\n2)Eliminar unha persoa" +
                    "\n3)Visualizar todas as listas de persoas" +
                    "\n4)Visualizar unha persoa" +
                    "\n5)Saír");
                int.TryParse(Console.ReadLine(), out opcion); //lo malo del try parse es que no informo al usuario
                switch (opcion)
                {
                    case 1:
                        InsertarPersona();
                        break;
                    case 2:
                        EliminarPersona();
                        break;
                    case 3:
                        MuestraTodaLaLista();
                        break;
                    case 4:
                        MuestraPersona();
                        break;
                    case 5:
                        Console.WriteLine("Chao pescao");
                        break;
                }
            } while (opcion != 5);
        }
    }
}
