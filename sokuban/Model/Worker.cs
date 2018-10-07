using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sokuban.Model {
    public class Worker : MoveableObject {

        public bool IsSleeping { get; set; }
        private Random _random;

        public Worker(Tile currentTile) : base(currentTile)
        {
            IsSleeping = false;
            _random = new Random();
            CanMoveOtherObject = false;
        }

        public override void Show()
        {
                if (IsSleeping) {
                    Console.Write("Z");
                }
                else {
                    Console.Write("$");
                }
         
        }
         public void FallAsleep()
        {
            if(IsSleeping)
            {
                if(_random.Next(0,10) == 0)
                {
                    IsSleeping = false;
                }
            }

            else
            {
                if (_random.Next(0, 4) == 0)
                {
                    IsSleeping = true;
                }
            }

            if(!IsSleeping)
            {
                Move(_random.Next(1, 5));
            }
        }

        public void Move(int direction) {
            switch (direction) {
                case 1:
                    Tile.Up.MoveTo(this);
                    break;
                case 2:
                    Tile.Down.MoveTo(this);
                    break;
                case 3:
                    Tile.Left.MoveTo(this);
                    break;
                case 4:
                    Tile.Right.MoveTo(this);
                    break;
            }
        }
    }
}
