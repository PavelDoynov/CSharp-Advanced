/*
 * 05. Applied Arithmetics
 * 
 * Write a program that executes some mathematical operations on a given collection. On the first line you are given a 
 * list of numbers. On the next lines you are passed different commands that you need to apply to all numbers in 
 * the list: 
 * "add" -> add 1 to each number; 
 * "multiply" -> multiply each number by 2; 
 * "subtract" -> subtract 1 from each number; 
 * “print” -> print the collection. 
 * 
 * The input will end with an "end" command. Use functions.
 * 
 * Example
 * Input:         Output:             Input:         Output:
 * 1 2 3 4 5      3 4 5 6 7           5 10           9 19
 * add                                multiply
 * add                                subtract
 * print                              print
 * end                                end
 * 
 * https://github.com/PavelDoynov
 */


using System;
using System.Linq;
using System.Collections.Generic;

namespace _05.Applied_Arithmetics
{
    class Program
    {
        static void Main()
        {
            List<int> inputNumbers = Console.ReadLine()
                                            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                            .Select(int.Parse)
                                            .ToList();

            string command = Console.ReadLine();

            while (command != "end")
            {
                Func<int, int> fiter = GetFilteredNumbers(command);

                if (command == "print")
                {
                    Console.WriteLine(string.Join(" ", inputNumbers));
                }
                else
                {
                    inputNumbers = inputNumbers.Select(fiter).ToList();
                }

                command = Console.ReadLine();
            }
        }

        private static Func<int, int> GetFilteredNumbers(string command)
        {
            if (command == "add")
            {
                return x => x + 1;
            }
            else if (command == "multiply")
            {
                return x => x * 2;
            }
            else if (command == "subtract")
            {
                return x => x - 1;
            }
            return x => x;
        }
    }
}
