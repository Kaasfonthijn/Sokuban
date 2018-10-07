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
        public Worker Worker { get; set; }

        public List<MoveableObject> BoxTiles;

        public GameField(int level){
            map = new TileList();
            BoxTiles = new List<MoveableObject>();
            LoadMap(level);
        }

        public void LoadMap(int level)
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
                            newTile = new Wall();
                            break;
                        case '.':
                            newTile = new Floor();
                            break;
                        case 'o':
                            newTile = new Floor();
                            newTile.MoveableObject = new Chest(newTile);
                            BoxTiles.Add(newTile.MoveableObject);
                            break;
                        case 'x':
                            newTile = new Destination();
                            break;
                        case '~':
                            newTile = new Trap();
                            break;
                        case '@':
                            newTile = new Floor();
                            Truck = new Truck(newTile);
                            newTile.MoveableObject = Truck;
                            break;
                        case '$':
                            newTile = new Floor();
                            Worker = new Worker(newTile);
                            newTile.MoveableObject = Worker;
                            break;
                        default:
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

        public void ShowPlayfield()
        {
            
            bool isNotLastLine = true;
            int lineCounter = 1;
            Tile currentTile = map.First;

            while (isNotLastLine)
            {
                while (currentTile != null)
                {
                    currentTile.Show();
                    currentTile = currentTile.Right;
                }

                lineCounter++;

                currentTile = map.First;
                for (int i = 1; i < lineCounter; i++)
                {
                    currentTile = currentTile.Down;
                }

                if (currentTile.Down == null)
                {
                    isNotLastLine = false;
                }
                Console.WriteLine();
            }

            while (currentTile != null)
            {
                currentTile.Show();
                currentTile = currentTile.Right;
            }
            Console.WriteLine();
        }

        public bool GameEnd()
        {
            int Destinations = 0;
            int DestinationsOccupied = 0;
            foreach (MoveableObject BoxTile in BoxTiles)
            {
                Destinations++;
                if (BoxTile.Tile.GetType() == typeof(Destination))
                {

                    DestinationsOccupied++;
                    if (DestinationsOccupied == Destinations)
                    {
                        return true;
                    }
                }
            }
            
            return false;
        }

        public void ClearPlayfield()
        {
            Console.Clear();
        }
    }
}
