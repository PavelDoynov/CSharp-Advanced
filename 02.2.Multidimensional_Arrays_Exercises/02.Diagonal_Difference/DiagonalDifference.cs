/*
 * 02. Diagonal Difference
 * 
 * Write a program that finds the difference between the sums of the square matrix diagonals (absolute value).
 * 
 *      0   1   2                         0   1   2
 *     -----------                       -----------
 *  0 | 11  2   4 |                   0 | 11  2   4 |
 *    |           |                     |           |
 *  1 | 4   5   6 |                   1 | 4   5   6 |
 *    |           |                     |           |
 *  2 | 10  8  -12|                   2 | 10  8  -12|     
 *     -----------                       -----------
 *    primery diagonal                 secondary diagonal
 *  sum = 11 + 5 + (-12)              sum = 4 + 5 + 10
 *  sum = 4                           sum = 19
 * 
 * Input
 * •   On the first line, you are given the integer N – the size of the square matrix
 * •   The next N lines holds the values for every row – N numbers separated by a space
 * 
 * Output
 * •   Print the absolute difference between the sums of the primary and the secondary diagonal
 * 
 * Example:
 * Input:        Output:      Comments:
 * 3             15           Primary diagonal: sum = 11 + 5 + (-12) = 4
 * 11 2 4                     Secondary diagonal: sum = 4 + 5 + 10 = 19
 * 4 5 6                      Difference: |4 - 19| = 15
 * 10 8 -12
 * 
 * https://github.com/PavelDoynov
 */


using System;
using System.Linq;

namespace Diagonal_Difference
{
    class MainClass
    {
        public static void Main()
        {
            int dimension = int.Parse(Console.ReadLine());

            int[,] squareMatrix = new int[dimension, dimension];

            for (int row = 0; row < squareMatrix.GetLength(0); row++)
            {
                int[] numbers = Console.ReadLine()
                                       .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                       .Select(int.Parse)
                                       .ToArray();

                for (int col = 0; col < squareMatrix.GetLength(1); col++)
                {
                    squareMatrix[row, col] = numbers[col];
                }
            }

            int firstDiagonalSum = 0;
            int firstDiagonalIndex = 0;
            int secondDiagonalSum = 0;
            int secondDiagonalIndex = squareMatrix.GetLength(1) - 1;

            for (int row = 0; row < squareMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < squareMatrix.GetLength(1); col++)
                {
                    if (col == firstDiagonalIndex && row == firstDiagonalIndex)
                    {
                        firstDiagonalSum += squareMatrix[row, col];
                        firstDiagonalIndex++;
                    }

                    if (col == secondDiagonalIndex) 
                    {
                        secondDiagonalSum += squareMatrix[row, col];
                        secondDiagonalIndex--;
                    }
                } 
            }

            int result = Math.Abs(firstDiagonalSum - secondDiagonalSum);
            Console.WriteLine(result);
        }
    }
}
