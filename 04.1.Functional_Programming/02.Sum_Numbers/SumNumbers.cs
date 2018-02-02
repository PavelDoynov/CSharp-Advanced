/*
 * 02. Sum Numbers
 * 
 * Write a program that reads a line of integers separated by ", ". Print on two lines the count of numbers and their sum.
 * 
 * Example
 * Input:                              Output:
 * 4, 2, 1, 3, 5, 7, 1, 4, 2, 12       10
 *                                     41
 * 
 * Input:        Output:
 * 2, 4, 6       3
 *               12
 * 
 * https://github.com/PavelDoynov
 */


using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Sum_Numbers
{
    class Program
    {
        static void Main()
        {
            List<int> numbers = Console.ReadLine()
                                       .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                                       .Select(int.Parse)
                                       .ToList();

            Console.WriteLine(numbers.Count());
            Console.WriteLine(numbers.Sum());
        }
    }
}
