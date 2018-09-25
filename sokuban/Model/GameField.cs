using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sokuban.Model
{
  

    public class GameField
    {
        public TileList map;
        public Truck Truck { get; set; }

        public GameField(int level){
            map = new TileList();
            loadMap(level);
        }

        public void loadMap(int level)
        {
            string[] allLines;
            String startupPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString();

            try
            {
                allLines = System.IO.File.ReadAllLines((@"" + startupPath + "/sokuban/Levels/doolhof" + level + ".txt"));
            }
            catch (DirectoryNotFoundException notFound)
            {
                Console.WriteLine("Cannot find the file!");
                Console.WriteLine("Press any key to stop Sokoban.");
                Console.ReadLine();
                System.Environment.Exit(1);
                return;
            }

            Console.WriteLine(allLines);
            Console.ReadLine();

        }
    }
}
