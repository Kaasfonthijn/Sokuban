using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sokuban.Model
{
    class Floor : Tile
    {

        public override void Show()
        {
            if (MoveableObject != null)
            {
                MoveableObject.Show();
            }
            else
            {
                Console.Write(".");
            }
        }

        public override bool MoveTo(MoveableObject moveableObject)
        {
            if (MoveableObject != null)
            {
                bool result;
                Tile tempTile;

                if (moveableObject.Tile == Down)
                {
                    tempTile = Up;
                }
                else if (moveableObject.Tile == Left)
                {
                    tempTile = Right;
                }
                else if (moveableObject.Tile == Up)
                {
                    tempTile = Down;
                }
                else if (moveableObject.Tile == Right)
                {
                    tempTile = Left;
                }
                else
                {
                    return false;
                }

                if (!MoveableObject.CanMoveOtherObject && tempTile.MoveableObject != null && !tempTile.MoveableObject.CanMoveOtherObject)
                {
                    return false;
                }
                else
                {
                    result = tempTile.MoveTo(this.MoveableObject);
                }

                if (!result) { return false; }
            }
            
            moveableObject.Tile.MoveableObject = null;
            
            this.MoveableObject = moveableObject;
            
            moveableObject.Tile = this;

            return true;
        }
    }
}
