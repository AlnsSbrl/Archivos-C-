using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelManager
{
    public class PersonReader : BinaryReader
    {
        public PersonReader(Stream input) : base(input)
        {
        }
        public Empleado ReadEmployee()
        {
            Empleado emp = new Empleado();
            emp.Salario = base.ReadDouble();
            emp.Telefono = base.ReadString();
            emp.Nombre = base.ReadString();
            emp.Apellidos = base.ReadString();
            emp.Dni = base.ReadString();
            emp.Edad = base.ReadInt32();
            return emp;
        }
        public Directivo ReadDirect()
        {
            Directivo dir = new Directivo();
            dir.departamento = base.ReadString();
            dir.PersonasACargo = base.ReadInt32();
            dir.Nombre = base.ReadString();
            dir.Apellidos = base.ReadString();
            dir.Dni = base.ReadString();
            dir.Edad = base.ReadInt32();
            return dir;
        }
      
    }
}
