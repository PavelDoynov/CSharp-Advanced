/*
 * 02. Square With Maximum Sum
 * 
 * Write a program that read a matrix from console. Then find biggest sum of 2x2 submatrix and print it to console.
 * On first line you will get matrix sizes in format rows, columns.
 * One next rows lines you will get elements for each column separated with coma.
 * Print biggest top-left square, which you find and sum of its elements.
 * 
 * Example
 * Input:                Output:         Input:            Output:
 * 3, 6                  9 8             2, 4              12 13
 * 7, 1, 3, 3, 2, 1      7 9             10, 11, 12, 13    16 17
 * 1, 3, 9, 8, 5, 6      33              14, 15, 16, 17    58
 * 4, 6, 7, 9, 1, 0
 * 
 * Hints
 * •   Think about IndexOutOfRangeException()
 * •   If you find more than one max square, print the top-left one
 * 
 * https://github.com/PavelDoynov
 */


using System;
using System.Linq;

namespace Square_With_Maximum_Sum
{
    class MainClass
    {
        public static void Main()
        {
            int[] matrixDimensions = Console.ReadLine()
                                            .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                                            .Select(int.Parse)
                                            .ToArray();

            int rows = matrixDimensions[0];
            int cols = matrixDimensions[1];

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] numbers = Console.ReadLine()
                                       .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                                       .Select(int.Parse)
                                       .ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix.GetLength(1) == numbers.Length)
                    {
                        matrix[row, col] = numbers[col];
                    }
                }
            }

            int sum = 0;
            int indexRow = 0;
            int indexCol = 0;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    int currentSum = matrix[row, col] + matrix[row, col + 1] + 
                        matrix[row + 1, col] + matrix[row + 1, col + 1];

                    if (currentSum > sum)
                    {
                        sum = currentSum;
                        indexRow = row;
                        indexCol = col;
                    }
                }
            }

            Console.WriteLine($"{matrix[indexRow, indexCol]} {matrix[indexRow, indexCol + 1]}");
            Console.WriteLine($"{matrix[indexRow + 1, indexCol]} {matrix[indexRow + 1, indexCol + 1]}");
            Console.WriteLine(sum);
        }
    }
}
