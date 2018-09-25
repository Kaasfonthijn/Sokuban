using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sokuban.Model
{
    class Empty : Tile
    {
        public override bool MoveTo(MoveableObject moveableObject)
        {
            return false;
        }

        public override void Show()
        {
            Console.Write(" ");
        }
    }
}
