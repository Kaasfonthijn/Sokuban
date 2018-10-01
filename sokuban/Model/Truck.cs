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

        public void Move(string direction)
        {
            switch (direction)
            {
                case "up":
                    Tile.Up.MoveTo(this);
                    break;
                case "down":
                    Tile.Down.MoveTo(this);
                    break;
                case "left":
                    Tile.Left.MoveTo(this);
                    break;
                case "right":
                    Tile.Right.MoveTo(this);
                    break;
            }
        }
    }
}
