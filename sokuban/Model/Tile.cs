using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sokuban
{
    class Tile : Field
    {
        public bool hasChest
        {
            get
            {
                return false;
            }
            set { hasChest = value; }
        }
    }
}
