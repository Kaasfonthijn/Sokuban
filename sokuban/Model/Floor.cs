using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sokuban.Model
{
    class Floor : Tile
    {
        public override bool MoveTo(MoveableObject moveableObject)
        {
            return true;
        }

        public override void Show()
        {
            Console.Write(".");
        }
    }
}
