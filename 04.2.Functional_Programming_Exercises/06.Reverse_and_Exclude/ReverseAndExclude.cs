/*
 * 06. Reverse and Exclude
 * 
 * Write a program that reverses a collection and removes elements that are divisible by a given integer n. 
 * Use predicates/functions.
 * 
 * Example
 * Input:            Output:         Input:                Output:
 * 1 2 3 4 5 6       5 3 1           20 10 40 30 60 50     50 40 10 20
 * 2                                 3
 * 
 * https://github.com/PavelDoynov
 */


using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Reverse_and_Exclude
{
    class Program
    {
        static void Main()
        {
            List<int> numbers = Console.ReadLine()
                                       .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                       .Select(int.Parse)
                                       .ToList();

            int divisor = int.Parse(Console.ReadLine());

            Console.WriteLine(string.Join(" ", numbers.Where(x => x % divisor != 0).Reverse()));

            //numbers = numbers.Where(x => x % divisor != 0).Reverse().ToList(); 
            //Console.WriteLine(string.Join(" ", numbers));

        }
    }
}
