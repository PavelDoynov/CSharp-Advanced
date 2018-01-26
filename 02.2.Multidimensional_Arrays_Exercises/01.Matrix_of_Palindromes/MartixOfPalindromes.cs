/*
 * 01. Matrix of Palindromes
 * 
 * Write a program to generate and print the following matrix of palindromes of 3 letters with r rows and c columns 
 * like at the examples below.
 * •   Rows define the first and the last letter: row 0 → ‘a’, row 1 → ‘b’, row 2 → ‘c’, …
 * •   Columns + rows define the middle letter: 
 *   o   column 0, row 0 → ‘a’, column 1, row 0 → ‘b’, column 2, row 0 → ‘c’, …
 *   o   column 0, row 1 → ‘b’, column 1, row 1 → ‘c’, column 2, row 1 → ‘d’, …
 * 
 * Input
 * •   On the first line, you are given the integers r and c, separated by a space.
 * 
 * Output
 * •   On r * c number of lines, print the matrix of palindromes as shown in the example.
 * 
 * Constraints
 * •   Constraints: r and c are integers in the range [1…26]; r + c ≤ 27.
 * 
 * Example
 * Input:      Output:                           Input:      Output:
 * 4 6         aaa aba aca ada aea afa           3 2         aaa aba
 *             bbb bcb bdb beb bfb bgb                       bbb bcb
 *             ccc cdc cec cfc cgc chc                       ccc cdc
 *             ddd ded dfd dgd dhd did
 * 
 * Hints
 * •   char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
 * 
 * https://github.com/PavelDoynov
 */


using System;
using System.Linq;

namespace Matrix_of_Palindromes
{
    class MainClass
    {
        public static void Main()
        {
            int[] matrixDimensions = Console.ReadLine()
                                            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                            .Select(int.Parse)
                                            .ToArray();

            int row = matrixDimensions[0];
            int col = matrixDimensions[1];

            int[,] matrixPalindromes = new int[row, col];
            char firstChar = 'a';

            for (char rows = firstChar; rows < firstChar + row; rows++)
            {
                for (char cols = rows; cols < rows + col;  cols++)
                {
                    string result = rows.ToString() + cols.ToString() + rows.ToString();
                    Console.Write($"{result} ");
                }
                Console.WriteLine();
            }
        }
    }
}
