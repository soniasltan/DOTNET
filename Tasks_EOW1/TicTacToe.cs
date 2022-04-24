using System;

namespace TicTacToe
{
    class Program
    {
        static int turn = 1;
        static bool playing = true;
        static string[,] board = new string[,]
        {
            {"( )", "( )", "( )"},
            {"( )", "( )", "( )"},
            {"( )", "( )", "( )"}
        };

        public static void ShowBoard()
        {
            Console.Clear();
            Console.WriteLine("Select your desired space by typing: row number, column number (e.g. 0,0 to select the top left space).");
            for (int i = 0; i < board.GetLength(0); i++)
            {
                Console.WriteLine("{0} {1} {2}", board[i, 0], board[i, 1], board[i, 2]);
            }
        }

        public static void SelectSquare()
        {
            string[] input = Console.ReadLine().Split(",");
            int row = Convert.ToInt16(input[0]);
            int column = Convert.ToInt16(input[1]);
            if (board[row, column] != "( )")
            {
                Console.WriteLine("Oops, that spot is already taken. Please select a different space: ");
            }
            else
            {
                if (turn == 1)
                {
                    board[row, column] = "(X)";
                }
                else
                {
                    board[row, column] = "(O)";
                }
            }
        }

        public static void CheckWin()
        {
            for (int i=0; i<board.GetLength(0); i++)
            {
                if (board[i,0] != "( )" && board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2])
                {
                    playing = false;
                    if (turn == 1)
                    {
                        Console.WriteLine("Player 1 wins horizontally!");
                    }
                    else
                    {
                        Console.WriteLine("Player 2 wins horizontally!");
                    }
                }
                else if (board[i, 0] != "( )" && board[0,i] == board[1,i] && board [1,i] == board[2, i])
                {
                    playing = false;
                    if (turn == 1)
                    {
                        Console.WriteLine("Player 1 wins vertically!");
                    }
                    else
                    {
                        Console.WriteLine("Player 2 wins vertically!");
                    }
                }
                else if (board[1,1] != "( )" && board[0,0] == board[1,1] && board[1,1] == board[2,2])
                {
                    playing = false;
                    if (turn == 1)
                    {
                        Console.WriteLine("Player 1 wins diagonally!");
                    }
                    else
                    {
                        Console.WriteLine("Player 2 wins diagonally!");
                    }
                }
                else if (board[1, 1] != "( )" && board[0, 2] == board[1, 1] && board[1, 1] == board[2,0])
                {
                    playing = false;
                    if (turn == 1)
                    {
                        Console.WriteLine("Player 1 wins diagonally!");
                    }
                    else
                    {
                        Console.WriteLine("Player 2 wins diagonally!");
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Let's play Tic Tac Toe!");
            Console.WriteLine("Select your desired space by typing: row number, column number (e.g. 0,0 to select the top left space).");
            while (playing)
            {
                if (turn == 1)
                {
                    Console.WriteLine("It's Player 1's turn to place an X: ");
                }
                else
                {
                    Console.WriteLine("It's Player 2's turn to place an O: ");
                }

                string[] input = Console.ReadLine().Split(",");
                int row = Convert.ToInt16(input[0]);
                int column = Convert.ToInt16(input[1]);
                if (board[row, column] != "( )")
                {
                    Console.WriteLine("Oops, that spot is already taken. Please select a different space: ");
                }
                else
                {
                    if (turn == 1)
                    {
                        board[row, column] = "(X)";
                        ShowBoard();
                        CheckWin();
                        turn = 2;
                    }
                    else
                    {
                        board[row, column] = "(O)";
                        ShowBoard();
                        CheckWin();
                        turn = 1;
                    }
                }
            }

            Console.ReadLine();
        }
    }
}

