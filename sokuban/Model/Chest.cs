﻿using System;
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
        }

        public override void Show()
        {
            Console.Write("@");
        }
    }
}
