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
        private int levelNumber;
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
            ShowVictory();
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
                        levelNumber = 1;
                        Console.Clear();
                        LoadGame(levelNumber);
                        loadGame = true;
                        break;
                    case '2':
                        levelNumber = 2;
                        Console.Clear();
                        LoadGame(levelNumber);
                        loadGame = true;
                        break;
                    case '3':
                        levelNumber = 3;
                        Console.Clear();
                        LoadGame(levelNumber);
                        loadGame = true;
                        break;
                    case '4':
                        levelNumber = 4;
                        Console.Clear();
                        LoadGame(levelNumber);
                        loadGame = true;
                        break;
                    case '5':
                        levelNumber = 5;
                        Console.Clear();
                        LoadGame(levelNumber);
                        loadGame = true;
                        break;
                    case '6':
                        levelNumber = 6;
                        Console.Clear();
                        LoadGame(levelNumber);
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

                    if (_gameField.Worker != null)
                    {
                    _gameField.Worker.FallAsleep();
                    }

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
                        case ConsoleKey.R:
                            Console.Clear();
                            LoadGame(levelNumber);
                            break;
                        case ConsoleKey.S:
                            Console.Clear();
                            StopGame();
                            canRead = true;
                            break;
                    }
                    
                    displayPlayfield();

                    if (GameEnd())
                    {
                        break;
                    }

                    canRead = false;
                }
            }
        }

        public bool GameEnd()
        {
            if (_gameField.GameEnd())
            {
                isPlaying = false;
            }

            return _gameField.GameEnd();
        }

        public void ShowVictory() {
            _victoryView = new VictoryView();
            _victoryView.showVictory();
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
        public void StopGame() {
            while (true) {
                isPlaying = true;
                StartGame();
            }
        }
    }
}
