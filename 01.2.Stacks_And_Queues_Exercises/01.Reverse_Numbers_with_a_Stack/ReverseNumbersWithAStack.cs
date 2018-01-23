/*
 * 01. Reverse Numbers with a Stack
 * 
 * Write a program that reads N integers from the console and reverses them using a stack. Use the Stack<int> class. 
 * Just put the input numbers in the stack and pop them. Examples:
 * 
 * Example
 * Input:       Output:         Input:       Output:
 * 1 2 3 4 5    5 4 3 2 1       1            1
 * 
 * https://github.com/PavelDoynov
 */


using System;
using System.Collections.Generic;
using System.Linq;

namespace Reverse_Numbers_with_a_Stack
{
    class MainClass
    {
        public static void Main()
        {
            int[] input = Console.ReadLine()
                                 .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                 .Select(int.Parse)
                                 .ToArray();

            Stack<int> inputStack = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                inputStack.Push(input[i]);
            }

            while (inputStack.Count != 0)
            {
                Console.Write($"{inputStack.Pop()} ");
            }
        }
    }
}
