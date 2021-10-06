using System;
using System.Collections.Generic;
using System.Text;

namespace Tik_Tac_Toe
{
    class Board
    {
        private char _player1Token; //The icon to display where player 1 places their token
        private char _player2Token; //The icon to display where player 2 places their token
        private char _currentToken; //The current players move token.
        private char[,] _board; //The board matrix

        public void Start() //Initializes the tokens and board and then starts a new game.
        {
            _player1Token = 'x';
            _player2Token = 'o';
            _currentToken = _player1Token;
            _board = new char[3, 3] { {'7', '8', '9'}, {'4','5','6'}, {'1','2','3'} };
            RunTime();
        }

        public void RunTime() 
        {
            bool gameEnded = false;
            while (gameEnded == false) //A while loop for until the match is over.
            {
                Console.Clear();
                Console.WriteLine($"Player {_currentToken}'s turn."); //Displays the current turn.
                Draw();
                int turnsMade = 0; //Used to keep track of the amount of turns for a draw.
                bool turnOver = false;
                while (turnOver == false) //For placing tokens down on the board.
                {
                    int input = Game.GetInput();
                    if (input == 7 && _board[0, 0] == '7')
                    {
                        _board[0, 0] = _currentToken;
                        turnOver = true;
                        turnsMade++;
                    }
                    else if (input == 8 && _board[0, 1] == '8')
                    {
                        _board[0, 1] = _currentToken;
                        turnOver = true;
                        turnsMade++;
                    }
                    else if (input == 9 && _board[0, 2] == '9')
                    {
                        _board[0, 2] = _currentToken;
                        turnOver = true;
                        turnsMade++;
                    }
                    else if (input == 4 && _board[1, 0] == '4')
                    {
                        _board[1, 0] = _currentToken;
                        turnOver = true;
                        turnsMade++;
                    }
                    else if (input == 5 && _board[1, 1] == '5')
                    {
                        _board[1, 1] = _currentToken;
                        turnOver = true;
                        turnsMade++;
                    }
                    else if (input == 6 && _board[1, 2] == '6')
                    {
                        _board[1, 2] = _currentToken;
                        turnOver = true;
                        turnsMade++;
                    }
                    else if (input == 1 && _board[2, 0] == '1')
                    {
                        _board[2, 0] = _currentToken;
                        turnOver = true;
                        turnsMade++;
                    }
                    else if (input == 2 && _board[2, 1] == '2')
                    {
                        _board[2, 1] = _currentToken;
                        turnOver = true;
                        turnsMade++;
                    }
                    else if (input == 3 && _board[2, 2] == '3')
                    {
                        _board[2, 2] = _currentToken;
                        turnOver = true;
                        turnsMade++;
                    }
                }
                if (turnsMade >= 9) //if there was a tie.
                {
                    gameEnded = true;
                    Console.Clear();
                    Console.WriteLine("Neither player has won, it is a tie.");
                    Console.ReadKey();
                }
                else if ((_board[0, 0] == 'x' && _board[0, 1] == 'x' && _board[0, 2] == 'x') || (_board[1, 0] == 'x' && _board[1, 1] == 'x' && _board[1, 2] == 'x') || (_board[2, 0] == 'x' && _board[2, 1] == 'x' && _board[2, 2] == 'x') || (_board[0, 0] == 'x' && _board[1, 0] == 'x' && _board[2, 0] == 'x') || (_board[0, 1] == 'x' && _board[1, 1] == 'x' && _board[2, 1] == 'x') || (_board[0, 2] == 'x' && _board[1, 2] == 'x' && _board[2, 2] == 'x') || (_board[0, 0] == 'x' && _board[1, 1] == 'x' && _board[2, 2] == 'x') || (_board[0, 2] == 'x' && _board[1, 1] == 'x' && _board[2, 0] == 'x'))
                {
                    gameEnded = true;
                    Console.Clear();
                    Game.Xwins++;
                    Console.WriteLine("Player X won!");
                    Console.ReadKey();
                } //If player 1 wins

                else if ((_board[0, 0] == 'o' && _board[0, 1] == 'o' && _board[0, 2] == 'o') || (_board[1, 0] == 'o' && _board[1, 1] == 'o' && _board[1, 2] == 'o') || (_board[2, 0] == 'o' && _board[2, 1] == 'o' && _board[2, 2] == 'o') || (_board[0, 0] == 'o' && _board[1, 0] == 'o' && _board[2, 0] == 'o') || (_board[0, 1] == 'o' && _board[1, 1] == 'o' && _board[2, 1] == 'o') || (_board[0, 2] == 'o' && _board[1, 2] == 'o' && _board[2, 2] == 'o') || (_board[0, 0] == 'o' && _board[1, 1] == 'o' && _board[2, 2] == 'o') || (_board[0, 2] == 'o' && _board[1, 1] == 'o' && _board[2, 0] == 'o'))
                {
                    gameEnded = true;
                    Console.Clear();
                    Game.Owins++;
                    Console.WriteLine("Player O won!");
                    Console.ReadKey();
                } //If player 2 Wins

                if (_currentToken == _player1Token) //Swap the current token around for each players turn.
                {
                    _currentToken = _player2Token;
                }
                else
                {
                    _currentToken = _player1Token;
                }
            }
        }

        public void Draw() //Creates an empty board.
        {
            Console.WriteLine($"{_board[0,0]} | {_board[0,1]} | {_board[0,2]}" + "\n" +
                                                "__________\n" +
                              $"{_board[1,0]} | {_board[1,1]} | {_board[1,2]}" + "\n" +
                                                "__________\n" +
                              $"{_board[2,0]} | {_board[2,1]} | {_board[2,2]}");
        }
    }
}
