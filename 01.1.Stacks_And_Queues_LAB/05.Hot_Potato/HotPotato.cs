/*
 * 05. Hot Potato
 * 
 * Hot potato is a game in which children form a circle and start passing a hot potato. The counting starts with 
 * the fist kid. Every nth toss the child left with the potato leaves the game. When a kid leaves the game, it passes
 * the potato along. This continues until there is only one kid left.
 * Create a program that simulates the game of Hot Potato.  Print every kid that is removed from the circle.
 * In the end, print the kid that is left last.
 * 
 * Example
 * Input:                  Output:                      Input:                                  Output:
 * Mimi Pepi Toshko        Removed Pepi                 Gosho Pesho Misho Stefan Krasi          Removed Krasi
 * 2                       Removed Mimi                 10                                      Removed Pesho
 *                         Last is Toshko                                                       Removed Misho
 *                                                                                              Removed Gosho
 *                                                                                              Last is Stefan
 * Input:                                  Output:
 * Gosho Pesho Misho Stefan Krasi          Removed Gosho
 * 1                                       Removed Pesho
 *                                         Removed Misho
 *                                         Removed Stefan
 *                                         Last is Krasi
 * 
 * https://github.com/PavelDoynov
 */


using System;
using System.Linq;
using System.Collections.Generic;

namespace Hot_Potato
{
    class MainClass
    {
        public static void Main()
        {
            string[] input = Console.ReadLine()
                                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                    .ToArray();

            int counter = int.Parse(Console.ReadLine());
            int count = 0;

            Queue<string> inputQueue = new Queue<string>();

            for (int i = 0; i < input.Length; i++)
            {
                inputQueue.Enqueue(input[i]);
            }

            while (inputQueue.Count != 1)
            {
                string currentName = inputQueue.Dequeue();
                count++;

                if (count == counter)
                {
                    Console.WriteLine($"Removed {currentName}");
                    count = 0;
                }
                else
                {
                    inputQueue.Enqueue(currentName);
                }
            }

            Console.WriteLine($"Last is {inputQueue.Dequeue()}");
        }
    }
}
