﻿/*
 * 04. Maximal Sum
 * 
 * Write a program that reads a rectangular integer matrix of size N x M and finds in it the square 3 x 3 that has 
 * maximal sum of its elements.
 * 
 * Input
 * •   On the first line, you will receive the rows N and columns M. On the next N lines you will receive each row 
 * with its columns
 * 
 * Output
 * •   Print the elements of the 3 x 3 square as a matrix, along with their sum
 * 
 * Example
 * Input:            Output:
 * 4 5               Sum = 75
 * 1 5 5 2 4         1 4 14
 * 2 1 4 14 3        7 11 2
 * 3 7 11 2 8        8 12 16
 * 4 8 12 16 4
 * 
 * https://github.com/PavelDoynov
 */


using System;
using System.Linq;

namespace Maximal_Sum
{
    class MainClass
    {
        public static void Main()
        {
            int[] matrixDimensions = Console.ReadLine()
                                            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                            .Select(int.Parse)
                                            .ToArray();

            int rows = matrixDimensions[0];
            int cols = matrixDimensions[1];

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] inputNumbers = Console.ReadLine()
                                            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                            .Select(int.Parse)
                                            .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++) 
                {
                    if (matrix.GetLength(1) == inputNumbers.Length)
                    {
                        matrix[row, col] = inputNumbers[col];
                    }
                }
            }

            int sum = 0;
            int rowIndex = 0;
            int colIndex = 0;

            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++) 
                {
                    int currentSum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] +
                        matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2] +
                        matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];

                    if (currentSum > sum)
                    {
                        sum = currentSum;
                        rowIndex = row;
                        colIndex = col;
                    }
                }
            }

            Console.WriteLine($"Sum = {sum}");
            Console.WriteLine($"{matrix[rowIndex, colIndex]} {matrix[rowIndex, colIndex + 1]} " +
                              $"{matrix[rowIndex, colIndex + 2]}");
            Console.WriteLine($"{matrix[rowIndex + 1, colIndex]} {matrix[rowIndex + 1, colIndex + 1]} " +
                              $"{matrix[rowIndex + 1, colIndex + 2]}");
            Console.WriteLine($"{matrix[rowIndex + 2, colIndex]} {matrix[rowIndex + 2, colIndex + 1]} " +
                              $"{matrix[rowIndex + 2, colIndex + 2]}");
        }
    }
}
