/*
 * 04. Find Evens or Odds
 * 
 * You are given a lower and an upper bound for a range of integer numbers. 
 * Then a command specifies if you need to list all even or odd numbers in the given range. Use Predicate <T>.
 * 
 * Example
 * Input:     Output:               Input:     Output:
 * 1 10       1 3 5 7 9             20 30      20 22 24 26 28 30
 * odd                              even
 * 
 * https://github.com/PavelDoynov
 */


using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Find_Evens_or_Odds
{
    class Program
    {
        static void Main()
        {
            List<int> inputList = InitializeArray();

            string command = Console.ReadLine();

            Action<int> printNumbers = number => Console.Write($"{number} "); 
            Func<int, bool> sortingNumbers = Sorting(command);

            inputList.Where(sortingNumbers).ToList().ForEach(printNumbers);
        }

        private static List<int> InitializeArray()
        {
            int[] startEnd = Console.ReadLine()
                                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToArray();

            List<int> currentList = new List<int>();

            for (int number = startEnd[0]; number <= startEnd[1]; number++)
            {
                currentList.Add(number);
            }

            return currentList;
        }

        private static Func<int, bool> Sorting (string command)
        {
            if (command == "even")
            {
                return x => x % 2 == 0;
            }
            return x => x % 2 != 0;
        }
    }
}
