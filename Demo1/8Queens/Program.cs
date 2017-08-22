using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8Queens
{
    class Program
    {
        private const int n = 2;
        static void Main()
        {
            int[,] board = new int[n, n];
            if (SolveNQ(board, 0))
            {
                PrintSolution(board);
                Console.WriteLine("Possible");
            }
            else
            {
                Console.WriteLine("Impossible");
            }
        }

        private static void PrintSolution(int[,] board)
        {
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                    Console.Write(" {0} ", board[i, j]);

                Console.WriteLine();
            }
        }


        private static bool IsSafe(int[,] board, int row, int col)
        {
            int i, j;

            for (i = 0; i < col; ++i)
                if (Convert.ToBoolean(board[row, i]))   //Checks the row.
                    return false;

            for (i = row, j = col; i >= 0 && j >= 0; --i, --j) //Checks the diagonal from the given cell to top left corner.
                if (Convert.ToBoolean(board[i, j]))
                    return false;

            for (i = row, j = col; j >= 0 && i < n; ++i, --j) //Check the diagonal from the given cell to bottom left corner.
                if (Convert.ToBoolean(board[i, j]))
                    return false;

            return true;
        }

        private static bool SolveNQ(int[,] board, int col)
        {
            if (col >= n)
                return true;

            for (int i = 0; i < n; ++i)
            {
                if (IsSafe(board, i, col))
                {
                    board[i, col] = 1;
                    if (SolveNQ(board, col + 1))
                        return true;

                    board[i, col] = 0;
                }
            }
            return false;
        }
    }
}
