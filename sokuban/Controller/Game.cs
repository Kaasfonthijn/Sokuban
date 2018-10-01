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
                startGame();
            }
        }

        public void startGame()
        {
            _menuView = new MenuView();
            _gamefieldView = new GamefieldView(this);


            _menuView.ShowStart();
            getLevel();
            _gamefieldView.showPlayField();
            Console.ReadLine();
            //AskDirections();
            //ShowVictory();
        }
        public void getLevel()
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
                        endApplication();
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
        public void LoadGame(int level)
        {
           _gameField = new GameField(level);
        }
        public void endApplication()
        {
            System.Environment.Exit(1);
        }
        public void displayPlayfield()
        {
            _gameField.clearPlayfield();
            _gameField.showPlayfield();
        }
    }
}
