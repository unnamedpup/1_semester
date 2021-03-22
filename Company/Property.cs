using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company
{
    public abstract class Property
    {
        public int Square { get; protected set; }
        public int MetrCost { get; set; }
        public string Location { get; protected set; }
        public virtual int GetPrice()
        {
            return Square * MetrCost;
        }
    }
}
