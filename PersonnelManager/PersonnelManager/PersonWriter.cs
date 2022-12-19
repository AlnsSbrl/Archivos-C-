using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelManager
{
    public class PersonWriter:BinaryWriter
    {
        public override void Write(bool value)
        {
            base.Write(value);
        }
        
    }
}
