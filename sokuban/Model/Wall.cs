using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sokuban.Model
{
    class Wall : Tile
    {
        public override bool MoveTo(MoveableObject moveableObject)
        {
            Console.WriteLine("deze g is een muur swa");
            return false;
        }

        public override void Show()
        {
            Console.Write("#");
        }
    }
}
