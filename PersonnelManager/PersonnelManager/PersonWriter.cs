using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelManager
{
    public class PersonWriter:BinaryWriter
    {
        public PersonWriter(Stream str) : base(str)
        {
        }
        
        public void Write(Empleado emp)
        {
            base.Write(emp.Salario);
            base.Write(emp.Telefono);
            base.Write(emp.Nombre);
            base.Write(emp.Apellidos);
            base.Write(emp.Dni);
            base.Write(emp.Edad);
        }
        public void Write(Directivo dir)
        {
            base.Write(dir.departamento);
            base.Write(dir.PersonasACargo);
            base.Write(dir.Nombre);
            base.Write(dir.Apellidos);
            base.Write(dir.Dni);
            base.Write(dir.Edad);
        }
    }
}
