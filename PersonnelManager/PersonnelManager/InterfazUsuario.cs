using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelManager
{
    public class InterfazUsuario
    {
        GestorPersonas listaPersonas = new GestorPersonas();
        string path = Environment.GetEnvironmentVariable("appdata") + "\\empresa.dat";
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
                listaPersonas.personasDeLaEmpresa.Insert(index, direct);
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
                } while (!int.TryParse(Console.ReadLine(), out borrar));
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
            int i = 0;
            Console.WriteLine($"{"Num",3}{"Nome",10}{"Apelidos",20}{"Status",7}");
            foreach (Persona persona in listaPersonas.personasDeLaEmpresa)
            {
                Console.WriteLine($"{i,3}" +
                    $"{(persona.Nombre.Length > 10 ? persona.Nombre.Substring(0, 7) + "..." : persona.Nombre),10}" +
                    $"{(persona.Apellidos.Length > 20 ? persona.Apellidos.Substring(0, 17) + "..." : persona.Apellidos),20}" +
                    $"{(persona is Directivo ? "D"/*+((Directivo)persona).ganarPasta(1000)*/: "E"),7}");
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
                    if (listaPersonas.personasDeLaEmpresa[i] is Directivo)
                    {
                        //listaPersonas.personasDeLaEmpresa[i].GetType() == typeof(Directivo) tmb vale
                        ((Directivo)listaPersonas.personasDeLaEmpresa[i]).ganarPasta(1000);
                    }
                }
            }
        }
        public void CerrarPrograma()
        {
            using (PersonWriter psw = new PersonWriter(new FileStream(path, FileMode.Create)))
            {
                try
                {
                    for (int i = 0; i < listaPersonas.personasDeLaEmpresa.Count; i++)
                    {
                        if (listaPersonas.personasDeLaEmpresa[i] is Empleado)
                        {
                            psw.Write(0);
                            psw.Write((Empleado)listaPersonas.personasDeLaEmpresa[i]);
                            Console.WriteLine("Guardo");
                        }
                        else if (listaPersonas.personasDeLaEmpresa[i] is Directivo)
                        {
                            psw.Write(1);
                            psw.Write((Directivo)listaPersonas.personasDeLaEmpresa[i]);
                            Console.WriteLine("otro guardado");
                        }
                    }
                }
                catch (IOException e)
                {

                }
            }
        }
        public void Inicio()
        {
            int opcion;
            FileInfo dataFile = new FileInfo(path);
            if (dataFile.Exists)
            {
                List<Persona> personas = new List<Persona>();
                PersonReader leePerso = new PersonReader(new FileStream(path, FileMode.Open));
                try
                {
                    while (true)
                    {
                        int header = leePerso.ReadInt32();
                        if (header == 0)
                        {
                            listaPersonas.personasDeLaEmpresa.Add(leePerso.ReadEmployee());
                            Console.WriteLine("EMPLEAO");
                        }
                        else
                        {
                            listaPersonas.personasDeLaEmpresa.Add(leePerso.ReadDirect());
                            Console.WriteLine("DIRE");
                        }
                    }
                }
                catch (EndOfStreamException e)
                {
                    leePerso.Dispose();
                }
            }

            do
            {
                Console.WriteLine("Escolla unha opción:" +
                    "\n1)Insertar unha nova persoa" +
                    "\n2)Eliminar unha persoa" +
                    "\n3)Visualizar todas as listas de persoas" +
                    "\n4)Visualizar unha persoa" +
                    "\n5)Saír");
                int.TryParse(Console.ReadLine(), out opcion);
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
                        CerrarPrograma();
                        break;
                    default:
                        Console.WriteLine("Erro inesperado");
                        break;
                }
            } while (opcion != 5);
        }
    }
}
