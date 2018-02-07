/*
 * 02. Knight Game
 * 
 * Chess is the oldest game, but it is still popular these days. For this task we will use only one chess
 * piece – the Knight.
 * 
 * The knight moves to the nearest square but not on the same row, column, or diagonal. 
 * (This can be thought of as moving two squares horizontally, then one square vertically, 
 * or moving one square horizontally then two squares vertically— i.e. in an "L" pattern.) 
 * 
 * The knight game is played on a board with dimensions N x N and a lot of chess knights 0 <= K <= N2. 
 * 
 * You will receive a board with K for knights and '0' for empty cells. Your task is to remove a minimum of the knights,
 * so there will be no knights left that can attack another knight. 
 * 
 * Input
 * On the first line, you will receive the N size of the board.
 * On the next N lines you will receive strings with Ks and 0s.
 * 
 * Output
 * Print a single integer with the minimum amount of knights that needs to be removed.
 * 
 * Constraints
 * •   Size of the board will be 0 < N < 30
 * •   Time limit: 0.3 sec. Memory limit: 16 MB.
 * 
 * Example
 * Input:       Output:        Input:       Output:          Input:       Output:
 * 8            12             5            1                2            0
 * 0K0KKK00                    0K0K0                         KK
 * 0K00KKKK                    K000K                         KK
 * 00K0000K                    00K00
 * KKKKKK0K                    K000K
 * K0K0000K                    0K0K0
 * KK00000K
 * 00K0K000
 * 000K00KK
 * 
 * https://github.com/PavelDoynov
 */


using System;

namespace _02.Knight_Game
{
    class Program
    {
        static void Main()
        {
            bool[,] chessMatrix = GetMatrix();

            int dangerousKnight = 0;
            int mostDangerousKnight = 0;
            int dangerRow = 0;
            int dangerCol = 0;
            int removedKnights = 0;

            while (true)
            {
                for (int row = 0; row < chessMatrix.GetLength(0); row++)
                {
                    for (int col = 0; col < chessMatrix.GetLength(1); col++)
                    {
                        if (chessMatrix[row, col] == true)
                        {
                            if (row - 1 >= 0 && col - 2 >= 0)
                            {
                                if (chessMatrix[row - 1, col - 2] == true)
                                {
                                    dangerousKnight++;
                                }
                            }

                            if (row + 1 < chessMatrix.GetLength(0) && col - 2 >= 0)
                            {
                                if (chessMatrix[row + 1, col - 2] == true)
                                {
                                    dangerousKnight++;
                                }
                            }

                            if (row - 1 >= 0 && col + 2 < chessMatrix.GetLength(1))
                            {
                                if (chessMatrix[row - 1, col + 2] == true)
                                {
                                    dangerousKnight++;
                                }
                            }

                            if (row + 1 < chessMatrix.GetLength(0) && col + 2 < chessMatrix.GetLength(1))
                            {
                                if (chessMatrix[row + 1, col + 2] == true)
                                {
                                    dangerousKnight++;
                                }
                            }

                            if (row + 2 < chessMatrix.GetLength(0) && col + 1 < chessMatrix.GetLength(1))
                            {
                                if (chessMatrix[row + 2, col + 1] == true)
                                {
                                    dangerousKnight++;
                                }
                            }

                            if (row - 2 >= 0 && col + 1 < chessMatrix.GetLength(1))
                            {
                                if (chessMatrix[row - 2, col + 1] == true)
                                {
                                    dangerousKnight++;
                                }
                            }

                            if (row - 2 >= 0 && col - 1 >= 0)
                            {
                                if (chessMatrix[row - 2, col - 1] == true)
                                {
                                    dangerousKnight++;
                                }
                            }

                            if (row + 2 < chessMatrix.GetLength(0) && col - 1 >= 0)
                            {
                                if (chessMatrix[row + 2, col - 1] == true)
                                {
                                    dangerousKnight++;
                                }
                            }
                        }
                        if (dangerousKnight > mostDangerousKnight)
                        {
                            mostDangerousKnight = dangerousKnight;
                            dangerRow = row;
                            dangerCol = col;
                        }
                        dangerousKnight = 0;
                    }
                }

                if (mostDangerousKnight > 0) 
                {
                    chessMatrix[dangerRow, dangerCol] = false;
                    removedKnights++;
                    mostDangerousKnight = 0;
                }
                else if (mostDangerousKnight == 0) 
                {
                    Console.WriteLine(removedKnights);
                    break;
                }
            }
        }

        private static bool[,] GetMatrix()
        {

            int dimensions = int.Parse(Console.ReadLine());

            bool[,] matrix = new bool[dimensions, dimensions];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] input = Console.ReadLine().ToCharArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (input[col] == 'K')
                    {
                        matrix[row, col] = true;
                    }
                    else
                    {
                        matrix[row, col] = false;
                    }
                }
            }

            return matrix;
        }
    }
}

