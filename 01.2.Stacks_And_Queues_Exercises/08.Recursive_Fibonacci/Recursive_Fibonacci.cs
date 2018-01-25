/*
 * 08. Recursive Fibonacci
 * 
 * The Fibonacci sequence is quite a famous sequence of numbers. Each member of the sequence is calculated from the sum
 * of the two previous elements. The first two elements are 1, 1. 
 * Therefore the sequence goes as 1, 1, 2, 3, 5, 8, 13, 21, 34…
 * The following sequence can be generated with an array, but that’s easy, so your task is to implement recursively.
 * 
 * So if the function getFibonacci(n) returns the n’th Fibonacci number we can express it using 
 * getFibonacci(n) = getFibonacci(n-1) + getFibonacci(n-2).
 * However, this will never end and in a few seconds a StackOverflow Exception is thrown. In order for the recursion 
 * to stop it has to have a “bottom”. 
 * The bottom of the recursion is getFibonacci(2) should return 1 and getFibonacci(1) should return 1.
 * 
 * Input Format:
 * •   On the only line in the input the user should enter the wanted Fibonacci number.
 * 
 * Output Format:
 * •   The output should be the n’th Fibonacci number counting from 1.
 * 
 * Constraints:
 * •   1 ≤ N ≤ 50
 * 
 * Example
 * Input:    Output:       Input:    Output:       Input:    Output:
 * 5         5             10        55            21        10946
 * 
 * For the Nth Fibonacci number, we calculate the N-1th and the N-2th number, but for the calculation of N-1th number 
 * we calculate the N-1-1th(N-2th) and the N-1-2th number, so we have a lot of repeated calculations.
 * 
 * If you want to figure out how to skip those unnecessary calculations, you can search for a technique called "memoization".
 * 
 * https://github.com/PavelDoynov
 */


using System;

namespace Recursive_Fibonacci
{
    class MainClass
    {
        private static long[] memo;

        public static void Main()
        {
            long numberFibonacci = long.Parse(Console.ReadLine());
            memo = new long[numberFibonacci + 1];
            Console.WriteLine(GetFibonacci(numberFibonacci));
        } 

        private static long GetFibonacci(long n)
        {
            if (n <= 2)
            {
                return 1;
            }

            if (memo[n] == 0)
            {
                memo[n] = GetFibonacci(n - 1) + GetFibonacci(n - 2);
            }

            return memo[n];
        }
    }
}
