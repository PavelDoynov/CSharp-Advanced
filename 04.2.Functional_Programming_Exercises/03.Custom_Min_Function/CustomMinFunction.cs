/*
 * 03. Custom Min Function
 * 
 * Write a simple program that reads from the console a set of integers and prints back onto the console the smallest 
 * number from the collection. Use Func<T, T>.
 * 
 * Example
 * Input:             Output:
 * 1 4 3 2 1 7 13     1
 * 
 * https://github.com/PavelDoynov
 */

using System;
using System.Linq;
using System.Collections.Generic;

namespace _03.Custom_Min_Function
{
    class Program
    {
        static void Main()
        {

            List<int> numbers = Console.ReadLine()
                                       .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                       .Select(int.Parse)
                                       .ToList();

            Func<List<int>, int> minNumber = GetMin;

            Console.WriteLine(minNumber(numbers));
        }

        private static int GetMin(List<int> arg)
        {
            int minimalNumber = arg.Max();

            for (int i = arg.Count() - 1; i >= 0; i--)
            {
                if (minimalNumber > arg[i])
                {
                    minimalNumber = arg[i];
                }
            }
            return minimalNumber;
        }
    }
}
