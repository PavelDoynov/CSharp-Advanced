/*
 * 07. Lego Blocks
 * 
 * You are given two jagged arrays. Each array represents a Lego block containing integers. 
 * Your task is first to reverse the second jagged array and then check if it would fit perfectly in the first jagged array.
 * 
 * First Jagged Array:      Second Jagged Array:        Reversed Second Array:
 * 1 1 1 1 1 1              1 1                              1 1
 * 2 1 1 3                  2 2 2 3                      3 2 2 2
 * 2 1 1 2 3                3 3 3                          3 3 3
 * 7 7 7 5 3 2              4 4                              4 4
 * 
 * Matched Arrays:
 * 1 1 1 1 1 1 1 1
 * 2 1 1 3 3 2 2 2
 * 2 1 1 2 3 3 3 3
 * 7 7 7 5 3 2 4 4
 * 
 * The picture above shows exactly what fitting arrays means. If the arrays fit perfectly you should print out the newly 
 * made rectangular matrix. If the arrays do not match (they do not form a rectangular matrix) you should print out the 
 * number of cells in the first array and in the second array combined. 
 * The examples below should help you understand the assignment better.
 * 
 * Input
 * The first line of the input comes as an integer number, n, saying how many rows are there in both arrays. 
 * Then you have 2 * n lines of numbers separated by whitespace(s). The first n lines are the rows of the first jagged 
 * array; the next n lines are the rows of the second jagged array. There might be leading and/or trailing whitespace(s).
 * 
 * Output
 * You should print out the combined matrix in the format:
 * [elem, elem, …, elem]
 * [elem, elem, …, elem]
 * [elem, elem, …, elem]
 * If the two arrays do not fit you should print out: The total number of cells is: count
 * 
 * Constraints
 * •   The number n will be in the range [2…10]
 * •   Time limit: 0.3 sec. Memory limit: 16 MB
 * 
 * Example
 * Input:            Output:                        Input:            Output:
 * 2                 [1, 1, 1, 1, 1, 1, 1, 1]       2                 The total number of cells is: 14
 * 1 1 1 1 1 1       [2, 1, 1, 3, 3, 2, 2, 2]       1 1 1 1 1
 * 2 1 1 3                                          1 1 1
 * 1 1                                              1
 * 2 2 2 3                                          1 1 1 1 1
 * 
 * https://github.com/PavelDoynov
 */


using System;
using System.Linq;

namespace Lego_Blocks
{
    class MainClass
    {
        public static void Main()
        {
            int numbersOfArrays = int.Parse(Console.ReadLine());

            int[][] firstJaggedArray = new int[numbersOfArrays][];
            int[][] secondJaggedArray = new int[numbersOfArrays][];

            for (int numbers = 0; numbers < firstJaggedArray.Length; numbers++)
            {
                int[] inputArray = Console.ReadLine()
                                          .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                          .Select(int.Parse)
                                          .ToArray();
                
                firstJaggedArray[numbers] = inputArray;
            }

            for (int numbers = 0; numbers < secondJaggedArray.Length; numbers++)
            {
                int[] inputArray = Console.ReadLine()
                                          .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                          .Select(int.Parse)
                                          .ToArray();

                Array.Reverse(inputArray);
                secondJaggedArray[numbers] = inputArray;
            }

            bool checker = true;
            int[] currentArray = new int[numbersOfArrays];
            for (int i = 0; i < currentArray.Length; i++)
            {
                currentArray[i] = firstJaggedArray[i].Length + secondJaggedArray[i].Length;
            }

            for (int i = 1; i < currentArray.Length; i++) 
            {
                if (currentArray[i] != currentArray[i - 1])
                {
                    checker = false;
                }
            }

            if (checker)
            {
                for (int i = 0; i < numbersOfArrays; i++) 
                {
                    Console.WriteLine("[{0}, {1}]", string.Join(", ", firstJaggedArray[i]), 
                                      string.Join(", ", secondJaggedArray[i]));
                }
            }
            else
            {
                Console.WriteLine($"The total number of cells is: {currentArray.Sum()}");
            }
        }
    }
}
