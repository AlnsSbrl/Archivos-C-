using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelManager
{
    public class GestorPersonas
    {
        internal List<Persona> personasDeLaEmpresa = new List<Persona>();

        public int Posicion(int edad)
        {
            for (int i = 0; i < personasDeLaEmpresa.Count; i++)
            {
                if (personasDeLaEmpresa[i].Edad > edad)
                {
                    return i;
                }
            }
            return personasDeLaEmpresa.Count+1;
        }

        public int Posicion(string apellido)
        {
            int indexPerso = -1;
            foreach (Persona persona in personasDeLaEmpresa)
            {
                if (persona.Nombre.StartsWith(apellido))
                {
                    indexPerso = personasDeLaEmpresa.IndexOf(persona);
                    break;
                }
            }
            return indexPerso;
        }

        public bool Eliminar(int posMaxima, int posMinima = 0)
        {
            try
            {
                personasDeLaEmpresa.RemoveRange(posMinima, posMaxima - posMinima);
            }
            catch (ArgumentOutOfRangeException e)
            {
                return false;
            }
            return true;
        }
    }
}
