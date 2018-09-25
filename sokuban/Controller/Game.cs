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
        private int _labirinthNumber;
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
            AskLevel();
            _gamefieldView.showPlayField();
            //AskDirections();
            //ShowVictory();
        }
        public void AskLevel()
        {
            bool canRead = false;

            while (!canRead)
            {
                Console.WriteLine(">     Kies een doolhof (1 - 6), s = stop");
                char input = Console.ReadKey().KeyChar;

                switch (input)
                {
                    case 's':
                        Console.Clear();
                        EndApplicationGame();
                        canRead = true;
                        break;
                    case '1':
                        _labirinthNumber = 1;
                        Console.Clear();
                        LoadGame(_labirinthNumber);
                        canRead = true;
                        break;
                    case '2':
                        _labirinthNumber = 2;
                        Console.Clear();
                        LoadGame(_labirinthNumber);
                        canRead = true;
                        break;
                    case '3':
                        _labirinthNumber = 3;
                        Console.Clear();
                        LoadGame(_labirinthNumber);
                        canRead = true;
                        break;
                    case '4':
                        _labirinthNumber = 4;
                        Console.Clear();
                        LoadGame(_labirinthNumber);
                        canRead = true;
                        break;
                    case '5':
                        _labirinthNumber = 5;
                        Console.Clear();
                        LoadGame(_labirinthNumber);
                        canRead = true;
                        break;
                    case '6':
                        _labirinthNumber = 6;
                        Console.Clear();
                        LoadGame(_labirinthNumber);
                        canRead = true;
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
        public void EndApplicationGame()
        {
            System.Environment.Exit(1);
        }
    }
}
