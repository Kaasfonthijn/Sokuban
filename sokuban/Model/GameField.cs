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
            string startupPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;

            try
            {
                allLines = File.ReadAllLines((@"" + startupPath + "/sokuban/Levels/doolhof" + level + ".txt"));
            }
            catch (DirectoryNotFoundException notFound)
            {
                Console.WriteLine("Cannot find the file!");
                Console.WriteLine("Press any key to stop Sokoban.");
                Console.ReadLine();
                System.Environment.Exit(1);
                return;
            }
            bool isFirstCharAndLine = true;
            bool isFirstLine = true;
            bool isFirstChar = true;

            foreach (string line in allLines)
            {
                isFirstChar = true;
                foreach (char c in line)
                {
                    Tile newTile;
                    switch (c)
                    {
                       
                        case '#':
                            // muur
                            newTile = new Wall();
                            break;
                        case '.':
                            // vloer
                            newTile = new Floor();
                            break;
                        case 'o':
                            // krat
                            newTile = new Floor();
                            newTile.MoveableObject = new Chest(newTile);
                            break;
                        case 'x':
                            // bestemming
                            newTile = new Destination();
                            break;
                        case '@':
                            // truck
                            newTile = new Floor();
                            Truck = new Truck(newTile);
                            newTile.MoveableObject = Truck;
                            break;
                        default:
                            // Empty aanmaken
                            newTile = new Empty();
                            break;
                    }
                    if (isFirstLine)
                    {
                        if (isFirstCharAndLine)
                        {
                            map.First = newTile;
                            map.Current = map.First;
                            isFirstCharAndLine = false;
                        }
                        else
                        {
                            map.Current.Right = newTile;
                            newTile.Left = map.Current;
                            map.Current = map.Current.Right;
                        }
                    }
                    else
                    {
                        if (isFirstChar)
                        {
                            Tile currentTile = map.First;
                            while (currentTile.Down != null)
                            {
                                currentTile = currentTile.Down;
                            }

                            currentTile.Down = newTile;
                            newTile.Up = currentTile;
                            map.Current = currentTile.Down;
                            isFirstChar = false;
                        }
                        else
                        {
                            map.Current.Right = newTile;
                            newTile.Left = map.Current;
                            newTile.Up = map.Current.Up.Right;
                            newTile.Up.Down = newTile;
                            map.Current = map.Current.Right;
                        }
                    }
                }

                isFirstLine = false;
            }
            Console.WriteLine("\n");
            Console.WriteLine();


        }
    }
}
