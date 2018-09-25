using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sokuban.View
{
    public class GamefieldView
    {
        private Game game;

        public GamefieldView(Game game)
        {
            this.game = game;
        }

        public void showPlayField()
        {
            Console.WriteLine("┌──────────┐");
            Console.WriteLine("| Sokoban  |");
            Console.WriteLine("└──────────┘");
            Console.WriteLine("─────────────────────────────────────────────────────────────────────────");
            // draw playfield on canvas
//            game.ShowPlayField();
        }
    }
}
