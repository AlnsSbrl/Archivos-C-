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

        public PersonReader(Stream input, Encoding encoding) : base(input, encoding)
        {
        }

        public PersonReader(Stream input, Encoding encoding, bool leaveOpen) : base(input, encoding, leaveOpen)
        {
        }
    }
}
