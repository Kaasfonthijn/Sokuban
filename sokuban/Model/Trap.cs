using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sokuban.Model {
    public class Trap : Tile {
        public int ActivationCounter { get; set; }



        public override bool MoveTo(MoveableObject moveableObject)
        {
            if (MoveableObject != null) {
                bool result;
                Tile tempTile;

                if (moveableObject.Tile == Down) {
                    tempTile = Up;
                }
                else if (moveableObject.Tile == Left) {
                    tempTile = Right;
                }
                else if (moveableObject.Tile == Up) {
                    tempTile = Down;
                }
                else if (moveableObject.Tile == Right) {
                    tempTile = Left;
                }
                else {
                    return false;
                }

                if (!MoveableObject.CanMoveOtherObject && tempTile.MoveableObject != null && !tempTile.MoveableObject.CanMoveOtherObject) {
                    return false;
                }
                else {
                    result = tempTile.MoveTo(MoveableObject);
                }

                if (!result) { return false; }
            }
            
            moveableObject.Tile.MoveableObject = null;
            
            MoveableObject = moveableObject;
            
            moveableObject.Tile = this;

            if (ActivationCounter >= 3 && !moveableObject.CanMoveOtherObject) {
                MoveableObject = null;
            }

            ActivationCounter += 1;

            return true;
        }
    

        public override void Show()
        {
            if (MoveableObject != null) {
                MoveableObject.Show();
            }
            else {
                if (ActivationCounter >= 3) {
                    Console.Write(" ");
                }
                else {
                    Console.Write("~");
                }

            }
        }

    }
}
