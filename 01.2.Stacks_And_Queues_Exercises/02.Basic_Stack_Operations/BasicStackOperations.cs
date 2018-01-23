/*
 * 02. Basic Stack Operations
 * 
 * Play around with a stack. You will be given an integer N representing the number of elements to push onto the stack, 
 * an integer S representing the number of elements to pop from the stack and finally an integer X, an element that you 
 * should look for in the stack. If it’s found, print “true” on the console. 
 * If it isn’t, print the smallest element currently present in the stack.
 * 
 * Input Format:
 * •   On the first line you will be given N, S and X, separated by a single space
 * •   On the next line you will be given N number of integers
 * 
 * Output Format:
 * •   On a single line print either true if X is present in the stack, otherwise print the smallest element in the stack. 
 * If the stack is empty, print 0.
 * 
 * Example
 * Input:            Output:         Comments:
 * 5 2 13            true            We have to push 5 elements. Then we pop 2 of them.
 * 1 13 45 32 4                      Finally, we have to check whether 13 is present in the stack. Since it is we print true.
 * 
 * Input:            Output:
 * 4 1 666           13
 * 420 69 13 666
 * 
 * https://github.com/PavelDoynov
 */



using System;
using System.Collections.Generic;
using System.Linq;

namespace Basic_Stack_Operations
{
    class MainClass
    {
        public static void Main()
        {
            int[] input = Console.ReadLine()
                                 .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                 .Select(int.Parse)
                                 .ToArray();

            int pushElements = input[0];
            int popElements = input[1];
            int peekElements = input[2];

            Stack<int> elementsStack = new Stack<int>();

            int[] elements = Console.ReadLine()
                                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToArray();

            int counterPushElements = 0;

            while (counterPushElements != pushElements)
            {
                counterPushElements++;
                elementsStack.Push(elements[counterPushElements - 1]);
            }

            int counterPopElements = 0;

            while (counterPopElements != popElements)
            {
                elementsStack.Pop();
                counterPopElements++;
            }

            if (elementsStack.Contains(peekElements))
            {
                Console.WriteLine("true");
            }
            else if (elementsStack.Count == 0)
            {
                Console.WriteLine("0");
            }
            else
            {
                Console.WriteLine($"{elementsStack.Min()}");
            }
        }
    }
}
