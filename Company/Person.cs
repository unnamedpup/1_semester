using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company
{
    public abstract class Person
    {
        public string Name { get; protected set; }
        public string Surname { get; protected set; }
    }
}
