/*
 * 01. Reverse Strings
 * 
 * Write program that:
 * •   Reads an input string
 * •   Reverses it using a Stack<T>
 * •   Prints the result back at the terminal
 * 
 * Example
 * Input:           Output:                 Input:                Output:
 * Learning Java    avaJ gninraeL           Stacks and Queues     seueuQ dna skcatS
 * 
 * Hints
 * •   Use a Stack<string>
 * •   Use the methods Push(), Pop()
 * 
 * https://github.com/PavelDoynov
 */


using System;
using System.Collections.Generic;

namespace Reverse_Strings
{
    class MainClass
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            Stack<char> inputStack = new Stack<char>();

            for (int i = 0; i < input.Length; i++)
            {
                inputStack.Push(input[i]);
            }

            while (inputStack.Count != 0)
            {
                char currentElement = inputStack.Pop();

                Console.Write(currentElement);
            }
        }
    }
}
