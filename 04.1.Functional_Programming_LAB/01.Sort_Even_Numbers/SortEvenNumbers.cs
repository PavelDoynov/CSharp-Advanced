/*
 * 01.Sort Even Numbers
 * 
 * Write a program that reads one line of integers separated by ", ". 
 * Then print the even numbers of that sequence sorted in increasing order.
 * 
 * Example
 * Input:                                  Output:
 * 4, 2, 1, 3, 5, 7, 1, 4, 2, 12           2, 2, 4, 4, 12
 * 
 * Input:      Output:
 * 1, 3, 5
 * 
 * Input:      Output:
 * 2, 4, 6     2, 4, 6
 * 
 * https://github.com/PavelDoynov
 */


using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Sort_Even_Numbers
{
    class Program
    {
        static void Main()
        {
            List<int> numbers = Console.ReadLine()
                                       .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                                       .Select(int.Parse)
                                       .Where(x => x % 2 == 0)
                                       .OrderBy(x => x)
                                       .ToList();

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
