using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sokuban.Model;
using sokuban.View;

namespace sokuban
{
    public class Game
    {

        public MenuView _menuView;
        public GamefieldView _gamefieldView;
        public VictoryView _victoryView;

        private bool isPlaying = true;
        private GameField _gameField;
        public Game()
        {
            while (true)
            {
                isPlaying = true;
                StartGame();
            }
        }

        public void StartGame()
        {
            _menuView = new MenuView();
            _gamefieldView = new GamefieldView(this);


            _menuView.ShowStart();
            GetLevel();
            _gamefieldView.showPlayField();
            GetDirection();
            //ShowVictory();
        }
        public void GetLevel()
        {
            bool loadGame = false;

            while (!loadGame)
            {
                Console.WriteLine(">     Kies een doolhof (1 - 6), s = stop");
                char input = Console.ReadKey().KeyChar;

                switch (input)
                {
                    case 's':
                        Console.Clear();
                        EndApplication();
                        loadGame = true;
                        break;
                    case '1':   
                        Console.Clear();
                        LoadGame(1);
                        loadGame = true;
                        break;
                    case '2':
                        Console.Clear();
                        LoadGame(2);
                        loadGame = true;
                        break;
                    case '3':
                        Console.Clear();
                        LoadGame(3);
                        loadGame = true;
                        break;
                    case '4':
                        Console.Clear();
                        LoadGame(4);
                        loadGame = true;
                        break;
                    case '5':
                        Console.Clear();
                        LoadGame(5);
                        loadGame = true;
                        break;
                    case '6':
                        Console.Clear();
                        LoadGame(6);
                        loadGame = true;
                        break;
                    default:
                        Console.WriteLine("\n?");
                        break;
                }
            }
        }

        public void GetDirection()
        {
            while (isPlaying)
            {

                bool canRead = false;
                while (!canRead)
                {
                    Console.WriteLine("─────────────────────────────────────────────────────────────────────────");
                    Console.WriteLine(">     Gebruik pijljestoetsen (s = stop, r = reset)");

                    var input = Console.ReadKey(false).Key;
                    switch (input)
                    {
                        case ConsoleKey.UpArrow:
                            _gameField.Truck.Move("up");
                            break;
                        case ConsoleKey.RightArrow:
                            _gameField.Truck.Move("right");
                            break;
                        case ConsoleKey.DownArrow:
                            _gameField.Truck.Move("down");
                            break;
                        case ConsoleKey.LeftArrow:
                            _gameField.Truck.Move("left");
                            break;
                    }
                    displayPlayfield();

//                    if (checkIfWon())
//                    {
//                        break;
//                    }

                    canRead = false;
                }
            }
        }

        public void LoadGame(int level)
        {
           _gameField = new GameField(level);
        }
        public void EndApplication()
        {
            System.Environment.Exit(1);
        }
        public void displayPlayfield()
        {
            _gameField.ClearPlayfield();
            _gameField.ShowPlayfield();
        }
    }
}
