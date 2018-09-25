using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sokuban.Model
{
    public abstract class MoveableObject
    {
        public bool CanMoveOtherObject { get; set; } = true;
        public Tile Tile { get; set; }

        public MoveableObject(Tile currentTile)
        {
            Tile = currentTile;
        }

        public abstract void Show();
    }
}
