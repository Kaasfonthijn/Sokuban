using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sokuban.View
{
    public class MenuView
    { 
        public void ShowStart()
        {
            Console.Clear();
            Console.WriteLine("______________________________________________________________");
            Console.WriteLine("|     Welkom bij Sokoban.                                    |");
            Console.WriteLine("|                                  |                         |");
            Console.WriteLine("|     Betekenis van de symbolen.   |   doel van het spel     |");
            Console.WriteLine("|                                  |                         |");
            Console.WriteLine("|     spatie : outerspace          |   duw met de tuck       |");
            Console.WriteLine("|          # : wall                |   de krat(ten)          |");
            Console.WriteLine("|          . : floor               |   naar de bestemming    |");
            Console.WriteLine("|          o : Chest               |                         |");
            Console.WriteLine("|          0 : Chest on destination|                         |");
            Console.WriteLine("|          x : Destination         |                         |");
            Console.WriteLine("|          @ : truck               |                         |");
            Console.WriteLine("|          $ : Worker              |                         |");
            Console.WriteLine("|          ~ : trap                |                         |");
            Console.WriteLine("|____________________________________________________________|");
            Console.WriteLine();
        }
    }
}
