/*
 * 03. 2x2 Squares in Matrix
 * 
 * Find the count of 2 x 2 squares of equal chars in a matrix.
 * 
 * Input
 * •   On the first line, you are given the integers rows and cols – the matrix’s dimensions
 * •   Matrix characters come at the next rows lines (space separated)
 * 
 * Output
 * •   Print the number of all the squares matrixes you have found
 * 
 * Example
 * Input:        Output:       Comments:
 * 3 4           2             Two 2 x 2 squares of equal cells: B B
 * A B B D                     a B B d        a b b d            B B
 * E B B B                     a B B b        a b B B
 * I J B B                     i j b b        i j B B
 * 
 * Input:        Output:       Comments:
 * 2 2           0             No 2 x 2 squares of equal cells exist.
 * a b
 * c d
 * 
 * https://github.com/PavelDoynov
 */


using System;
using System.Linq;

namespace x2_Squares_in_Matrix
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

            char[,] charMatrix = new char[rows, cols];

            for (int row = 0; row < charMatrix.GetLength(0); row++)
            {
                char[] inputChars = Console.ReadLine()
                                           .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                                           .Select(char.Parse)
                                           .ToArray();

                for (int col = 0; col < charMatrix.GetLength(1); col++) 
                {
                    if (charMatrix.GetLength(1) == inputChars.Length) 
                    {
                        charMatrix[row, col] = inputChars[col];
                    }
                }
            }

            int result = 0;

            for (int row = 0; row < charMatrix.GetLength(0) - 1; row++) 
            {
                for (int col = 0; col < charMatrix.GetLength(1) - 1; col++) 
                {
                    char currentChar = charMatrix[row, col];

                    if (currentChar == charMatrix[row, col + 1] && currentChar == charMatrix[row + 1, col] &&
                        currentChar == charMatrix[row + 1, col + 1])
                    {
                        result++;
                    }
                }
            }

            Console.WriteLine(result);
        }
    }
}
