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

        public override bool MoveTo(MoveableObject requestObject)
        {
            if (this.MoveableObject != null)
            {
                // if there is another object on the requested tile
                bool result;
                Tile tempTile;

                if (requestObject.Tile == Down)
                {
                    tempTile = Up;
                }
                else if (requestObject.Tile == Left)
                {
                    tempTile = Right;
                }
                else if (requestObject.Tile == Up)
                {
                    tempTile = Down;
                }
                else if (requestObject.Tile == Right)
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

            // When requestObject should be placed

            // Remove old object
            requestObject.Tile.MoveableObject = null;

            // Set requestObject on current tile
            this.MoveableObject = requestObject;

            // Set requestObject tile on current tile
            requestObject.Tile = this;

            return true;
        }
    }
}
