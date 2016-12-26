using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapperTests
{
    public class EmptyClass
    {
        public override bool Equals(object obj)
        {
            return obj is EmptyClass;
        }
    }
}
