/*
 * 09. Crossfire
 * 
 * You will receive two integers which represent the dimensions of a matrix. Then, you must fill the matrix with increasing
 * integers starting from 1, and continuing on every row, like this:
 * first row: 1, 2, 3, …, n
 * second row: n + 1, n + 2, n + 3, …, n + n
 * third row: 2 * n + 1, 2 * n + 2, …, 2 * n + n
 * 
 * You will also receive several commands in the form of 3 integers separated by a space. Those 3 integers will represent 
 * a row in the matrix, a column and a radius. You must then destroy the cells which correspond to those arguments 
 * cross-like.
 * 
 * Destroying a cell means that, that cell becomes completely nonexistent in the matrix. Destroying cells cross-like means
 * that you form a cross figure with center point - equal to the cell with coordinates – the given row and column, 
 * and lines with length equal to the given radius. See the examples for more info.
 * 
 * The input ends when you receive the command “Nuke it from orbit”. When that happens, you must print what has 
 * remained from the initial matrix.
 * 
 * Input
 * •   On the first line you will receive the dimensions of the matrix. You must then fill the matrix according to
 * those dimensions
 * •   On the next several lines you will begin receiving 3 integers separated by a single space, which represent the row,
 * col and radius. You must then destroy cells according to those coordinates
 * •   When you receive the command “Nuke it from orbit” the input ends
 * 
 * Output
 * •   The output is simple. You must print what is left from the matrix
 * •   Every row must be printed on a new line and every column of a row - separated by a space
 * 
 * Constraints
 * •   The dimensions of the matrix will be integers in the range [2, 100]
 * •   The given rows and columns will be valid integers in the range [-231 + 1, 231 - 1]
 * •    The radius will be in range [0, 231 - 1]
 * •   Allowed time/memory: 250ms/16MB
 * 
 * Example
 * Input:                    Output:          Comments:
 * 5 5                       1 2 3 4 5        1 2 3 4 5      After           1 2 3 4 5      After
 * 3 3 2                     6 7 8 10         6 7 8 10    <- first           6 7 8 10    <- second
 * 4 3 2                     11 12 13         11 12 13 1     explosion       11 12 13       explosion
 * Nuke it from orbit        21               16                             16
 *                                            21 22 23 25                    21
 * 
 * Input:                    Output:
 * 5 5                       1 2 3 4
 * 4 4 4                     6 7 8 9
 * Nuke it from orbit        11 12 13 14
 *                           16 17 18 19
 * 
 * https://github.com/PavelDoynov
 */


using System;
using System.Collections.Generic;
using System.Linq;

namespace Crossfire
{
    class MainClass
    {
        public static void Main()
        {
            List<List<int>> matrix = GetMatrix();
            string input = Console.ReadLine();

            while (input != "Nuke it from orbit")
            {
                matrix = RegenerateMatrix(matrix, input);

                input = Console.ReadLine();
            }

            ViewMatrix(matrix);
        }

        private static List<List<int>> RegenerateMatrix(List<List<int>> matrix, string input)
        {
            int[] coordinates = input
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int blastRowCoordinate = coordinates[0];
            int blastColCoordinate = coordinates[1];
            int blastRange = coordinates[2];

            if (blastRowCoordinate >= 0 && blastRowCoordinate < matrix.Count())
            {
                int blastFromLeft = Math.Max(blastColCoordinate - blastRange, 0);
                int blastToRight = Math.Min(blastColCoordinate + blastRange, matrix[blastRowCoordinate].Count() - 1);

                for (int col = blastFromLeft; col <= blastToRight; col++)
                {
                    matrix[blastRowCoordinate][col] = 0;
                }
            }

            if (blastColCoordinate >= 0)
            {
                int blastFromUp = Math.Max(blastRowCoordinate - blastRange, 0);
                int blastToDown = Math.Min(blastRowCoordinate + blastRange, matrix.Count() - 1);

                for (int row = blastFromUp; row <= blastToDown; row++) 
                {
                    if (blastColCoordinate < matrix[row].Count())
                    {
                        matrix[row][blastColCoordinate] = 0;
                    }
                }
            }

            matrix = RemoveEmptyIndex(matrix);

            return matrix;
        }

        private static List<List<int>> RemoveEmptyIndex(List<List<int>> matrix)
        {
            for (int row = 0; row < matrix.Count; row++)
            {
                if (matrix[row].Contains(0))
                {
                    List<int> elements = new List<int>();

                    for (int col = 0; col < matrix[row].Count; col++)
                    {
                        if (matrix[row][col] != 0)
                        {
                            elements.Add(matrix[row][col]);
                        }
                    }

                    if (elements.Count > 0)
                    {
                        matrix[row] = elements;
                    }
                    else
                    {
                        matrix.RemoveAt(row);
                        row--;
                    }
                }
            }
            return matrix;
        }

        private static void ViewMatrix(List<List<int>> matrix)
        {
            for (int row = 0; row < matrix.Count(); row++) 
            {
                for (int col = 0; col < matrix[row].Count(); col++) 
                {
                    Console.Write($"{matrix[row][col]} ");
                }
                Console.WriteLine();
            }
        }

        private static List<List<int>> GetMatrix()
        {
            int[] dimensions = Console.ReadLine()
                                      .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                      .Select(int.Parse)
                                      .ToArray();

            List<List<int>> matrix = new List<List<int>>();
            int number = 1;

            for (int row = 0; row < dimensions[0]; row++)
            {
                matrix.Add(new List<int>());
                for (int i = 0; i < dimensions[1]; i++)
                {
                    matrix[row].Add(number);
                    number++;
                }
            }
            return matrix;
        }
    }
}
