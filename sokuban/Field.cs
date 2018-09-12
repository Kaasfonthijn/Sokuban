using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sokuban
{
    class Field
    {
        private Truck truck;

        public Field()
        {
            truck = new Truck();
        }

        public void moveTo { get; set; }
    }
}
