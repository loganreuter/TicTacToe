using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class AI
    {
        List<int[]> AllResults = new List<int[]>();

        public int MiniMax(int[] board, bool isMax)
        {
            int[] AvailCells = IndexFreeSpace(board);

            if (App.CheckForWinner(board))
            {
                Console.WriteLine("The Game Is Over");
                if (isMax)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }   
            } else if(AvailCells.Length == 0)
            {
                return 0;
            }

            for(int i = 0; i < AvailCells.Length; i++)
            {
                int x = AvailCells[i];
                Console.WriteLine(x);

                if (isMax)
                {
                    board[x] = 'O';
                }
                else
                {
                    board[x] = 'X';
                }

                //int[] result = { 1, x };
                //Console.WriteLine("Result " + result);
                int[] result = { MiniMax(board, !isMax), x };
                AllResults.Add(result);
                board[x] = 0;
            }

            int BestPosition = 0;

            if (isMax)
            {
                float Best = float.NegativeInfinity;
                foreach(int[] result in AllResults)
                {
                    if(result[0] > Best)
                    {
                        Best = result[0];
                        BestPosition = result[1];
                    }
                }
            } 
            else
            {
                float Best = float.PositiveInfinity;
                foreach (int[] result in AllResults)
                {
                    if (result[0] < Best)
                    {
                        Best = result[0];
                        BestPosition = result[1];
                    }
                }
            }

            //Console.WriteLine("Best Position: " + BestPosition);
            //AllResults = new List<int[]>();
            return BestPosition;
        }

        int[] IndexFreeSpace(int[] board)
        {
            List<int> list = new List<int>();
            for (int i = 0; i < board.Length; i++)
            {
                if(board[i] == 0)
                {
                    list.Add(i);
                }
            }

            int[] FreeSpace = list.ToArray();
            //Console.WriteLine("Free Space: " + FreeSpace.Length);
            //foreach(int space in FreeSpace)
            //{
            //    Console.WriteLine("Blah" + space);
            //}
            
            return FreeSpace;
        }
    }
}
