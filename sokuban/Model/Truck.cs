using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sokuban.Model
{
    public class Truck : MoveableObject
    {
        public Truck(Tile currentTile) : base(currentTile)
        {
        }

        public override void Show()
        {
            Console.Write("@");
        }
    }
}
