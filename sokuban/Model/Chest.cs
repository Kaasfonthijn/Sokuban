using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sokuban.Model
{
    public class Chest : MoveableObject
    {
        public Chest(Tile currentTile) : base(currentTile)
        {
            CanMoveOtherObject = false;
        }

        public override void Show()
        {
            if (this.Tile is Destination)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write("0");
                Console.ResetColor();
             
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("o");
                Console.ResetColor();
            }
        }
    }
}
