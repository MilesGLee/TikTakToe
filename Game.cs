using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Tik_Tac_Toe
{
    class Game
    {
        private static bool _gameOver = false; //if the game is running or not.
        private Board _gameBoard = new Board(); //The game board.
        public static int Xwins; //Amount of X wins.
        public static int Owins; //Amount of O wins.

        public void Run()
        {
            Start();
            while (!_gameOver)
            {
                Update();
            }
            End();
        } //The run function, is called on startup of the program

        void Start() 
        {
            if (Load() == true) 
            {
                Console.WriteLine($"There have been {Xwins} wins for X, and {Owins} for O.");
            }
        } //First loads the game when it starts

        void Update() 
        {
            //Displays a main menu of sorts.
            Console.Clear();
            Console.WriteLine("Welcome to my chess game." + $" There have been {Xwins} wins for X, and {Owins} for O. " + "Please pick an option:");
            Console.WriteLine("1. Play 2. Quit");
            int choice = GetInput();
            if (choice == 1)
            {
                _gameBoard.Start(); //Starts a game
            }
            if (choice == 2)
            {
                Save(); //Saves win amounts before quitting.
                End();
            }
        }

        void Save() //Simple save
        {
            StreamWriter writer = new StreamWriter("SaveData.txt");
            writer.WriteLine(Xwins);
            writer.WriteLine(Owins);

            writer.Close();
        }

        bool Load() //Simple load
        {
            bool loadSuccessful = true;
            if (!File.Exists("SaveData.txt"))
                loadSuccessful = false;
            else
            {
                StreamReader reader = new StreamReader("SaveData.txt");
                if (!int.TryParse(reader.ReadLine(), out Xwins))
                    loadSuccessful = false;
                if (!int.TryParse(reader.ReadLine(), out Owins))
                    loadSuccessful = false;
                reader.Close();
            }
            return loadSuccessful;
        }

        void End() //Ends the game
        {
            Console.Clear();
            Console.WriteLine("Play again soon! Goodbye");
            Console.ReadKey(true);
            _gameOver = true;
        }

        public static int GetInput() //The get input we made, kept it as is because i didnt need it to do anything more.
        {
            int choice = -1;
            if (!int.TryParse(Console.ReadLine(), out choice))
                choice = -1;
            return choice;
        }
    }
}
