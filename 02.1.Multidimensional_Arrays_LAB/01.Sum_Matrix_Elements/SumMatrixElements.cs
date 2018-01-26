/*
 * 01. Sum Matrix Elements
 * 
 * Write program that read a matrix from console and print:
 * •   Count of rows
 * •   Count of columns
 * •   Sum of all matrix elements
 * 
 * On first line you will get matrix sizes in format [rows, columns]
 * 
 * Example
 * Input:                 Output:
 * 3, 6                   3
 * 7, 1, 3, 3, 2, 1       6
 * 1, 3, 9, 8, 5, 6       76
 * 4, 6, 7, 9, 1, 0
 * 
 * Hints
 * •   On next [rows] lines you will get elements for each column separated with coma and whitespace
 * •   Try to use only foreach for printing
 * 
 * https://github.com/PavelDoynov
 */


using System;
using System.Linq;

namespace Sum_Matrix_Elements
{
    class MainClass
    {
        public static void Main()
        {
            int[] matrixDimensions = Console.ReadLine()
                                            .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                                            .Select(int.Parse)
                                            .ToArray();

            int rows = matrixDimensions[0];
            int cols = matrixDimensions[1];

            int[,] matrix = new int[rows, cols];

            int whileCounter = 0;
            int sum = 0;

            while (whileCounter != rows)
            {
                int[] input = Console.ReadLine()
                                      .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                                      .Select(int.Parse)
                                      .ToArray();

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    if (row == whileCounter)
                    {
                        for (int col = 0; col < matrix.GetLength(1); col++)
                        {
                            matrix[row, col] = input[col];
                        }
                    }
                }

                sum += input.Sum();
                whileCounter++;
            }

            Console.WriteLine(matrix.GetLength(0));
            Console.WriteLine(matrix.GetLength(1));
            Console.WriteLine(sum);

        }
    }
}
