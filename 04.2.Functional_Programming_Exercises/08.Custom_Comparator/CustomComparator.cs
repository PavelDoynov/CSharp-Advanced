/*
 * 08. Custom Comparator
 * 
 * Write a custom comparator that sorts all even numbers before all odd ones in ascending order. 
 * Pass it to an Array.Sort() function and print the result. Use functions.
 * 
 * Example
 * Input:          Output:                 Input:     Output:
 * 1 2 3 4 5 6     2 4 6 1 3 5             -3 2       2 -3
 * 
 * https://github.com/PavelDoynov
 */


using System;
using System.Linq;
using System.Collections.Generic;

namespace _08.Custom_Comparator
{
    class Program
    {
        static void Main()
        {
            List<int> inputNumbers = GetFilteredInput();

            Console.WriteLine(string.Join(" ", inputNumbers));
        }

        private static List<int> GetFilteredInput()
        {
            List<int> input = Console.ReadLine()
                                     .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                     .Select(int.Parse)
                                     .OrderBy(x => x)
                                     .ToList();

            List<int> evenNumbers = input.Where(x => x % 2 == 0).ToList();
            List<int> oddNumbers = input.Where(x => x % 2 != 0).ToList();

            return evenNumbers.Concat(oddNumbers).ToList();
        }
    }
}
