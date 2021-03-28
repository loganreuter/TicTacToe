using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static int[] board = new int[9];
        public static bool playerTurn = true;
        public static int movesRemaining = 9;
        static string[] res = new string[3];

        //X = 88
        //O = 79

        public static string[] Move(char location)
        {
            AI ai = new AI();
            string player = "X";
            var x = Convert.ToInt32(Char.GetNumericValue(location));

            if (board[x] == 0)
            {
                board[x] = 'X';
            } else
            {
                res[0] = "Error";
                res[1] = "false";
                return res;
            }

            movesRemaining -= 1;

            var winner = CheckForWinner(board);

            if (winner)
            {
                Console.WriteLine("Game Over");
                res[0] = player;
                res[1] = "true";
                Reset();
                return res;
            }
            else if (movesRemaining == 0)
            {
                Console.WriteLine("No Winner");
                res[0] = player;
                res[1] = "Draw";
                Reset();
                return res;
            }

            int y = ai.MiniMax(board, true);
            Console.WriteLine(y);
            if(y == -1)
            {
                Console.WriteLine("All is Lost");
            }
            else
            {
                board[y] = 'O';
            }
            

            movesRemaining -= 1;
            
            winner = CheckForWinner(board);
            if (winner)
            {
                Console.WriteLine("Game Over");
                res[0] = player;
                res[1] = "true";
                Reset();
                return res;
            }
            else if(movesRemaining == 0)
            {
                Console.WriteLine("No Winner");
                res[0] = player;
                res[1] = "Draw";
                Reset();
                return res;
            }
            else
            {
                res[0] = player;
                res[1] = "false";
                res[2] = y.ToString();
                //playerTurn = !playerTurn;
                return res;
            }
        }

        public static bool CheckForWinner(int[] gameboard)
        {
            bool winner;
            //Checks Rows
            for(int i = 0; i < 9; i+=3)
            {
                if(gameboard[i] != 0 && gameboard[i] == gameboard[i+1] && gameboard[i] == gameboard[i+2])
                {
                    winner = true;
                    return winner;
                }
            }

            //Checks Columns
            for (int j = 0; j < 3; j++)
            {
                if(gameboard[j] != 0 && gameboard[j] == gameboard[j+3] && gameboard[j] == gameboard[j+6])
                {
                    winner = true;
                    return winner;
                }
            }


            if(gameboard[0] != 0 && gameboard[0] == gameboard[4] && gameboard[0] == gameboard[8])
            {
                winner = true;
                return winner;
                
            } else if(gameboard[2] != 0 && gameboard[2] == gameboard[4] && gameboard[2] == gameboard[6])
            {
                winner = true;
                return winner;   
            }


            return false;
        }

        static void Reset()
        {
            board = new int[9];
            playerTurn = true;
            movesRemaining = 9;
        }
    }
}
