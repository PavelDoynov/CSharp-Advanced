/*
 * 09. List of Predicates
 * 
 * Find all numbers in the range 1...N that are divisible by the numbers of a given sequence.
 * On the first line you will be given an integer N – which is the end of the range. 
 * On the second line you will be given a sequence of integers which are the dividers. 
 * Use predicates/functions.
 * 
 * Example
 * Input:        Output:            Input:        Output:
 * 10            2 4 6 8 10         100           20 40 60 80 100
 * 1 1 1 2                          2 5 10 20
 * 
 * https://github.com/PavelDoynov
 */


using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.List_of_Predicates
{
    class Program
    {
        static void Main()
        {
            List<int> numbers = GetNumbers();

            List<int> divisiors = Console.ReadLine()
                                         .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                         .Select(int.Parse)
                                         .ToList();

            for (int div = divisiors.Count() - 1; div >= 0; div--)
            {
                numbers = numbers.Where(x => x % divisiors[div] == 0).ToList();
            }

            Console.WriteLine(string.Join(" ", numbers));
        }

        private static List<int> GetNumbers()
        {
            int number = int.Parse(Console.ReadLine());

            List<int> numbers = new List<int>();

            for (int i = 1; i <= number; i++)
            {
                numbers.Add(i);
            }

            return numbers;
        }
    }
}
