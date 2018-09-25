using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sokuban.Model
{
    public abstract class Tile
    {
        public MoveableObject MoveableObject { get; set; }

        public Tile Up { get; set; }
        public Tile Right { get; set; }
        public Tile Down { get; set; }
        public Tile Left { get; set; }

        public abstract bool MoveTo(MoveableObject moveableObject);

        public abstract void Show();
    }
}
