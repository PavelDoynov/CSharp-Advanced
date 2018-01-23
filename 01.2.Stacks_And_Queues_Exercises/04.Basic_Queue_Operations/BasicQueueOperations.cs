/*
 * 04. Basic Queue Operations
 * 
 * Play around with a queue. You will be given an integer N representing the number of elements to enqueue (add), 
 * an integer S representing the number of elements to dequeue (remove) from the queue and finally an integer X, 
 * an element that you should look for in the queue. If it is, print true on the console. 
 * If it’s not print the smallest element currently present in the queue. If there are no elements in the sequence, 
 * print 0 on the console.
 * 
 * Example
 * Input:           Output:          Comments:
 * 5 2 32           true             We have to push 5 elements. Then we pop 2 of them.      
 * 1 13 45 32 4                      Finally, we have to check whether 13 is present in the stack. Since it is we print true.
 * 
 * Input:           Output:
 * 4 1 666          13
 * 666 69 13 420
 * 
 * Input:           Output:
 * 3 3 90           0
 * 90 90 90
 * 
 * https://github.com/PavelDoynov
 */


using System;
using System.Linq;
using System.Collections.Generic;

namespace Basic_Queue_Operations
{
    class MainClass
    {
        public static void Main()
        {
            int[] input = Console.ReadLine()
                                 .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                 .Select(int.Parse)
                                 .ToArray();

            int enqueueElements = input[0]; 
            int dequeueElements = input[1]; 
            int peekElements = input[2];

            Queue<int> elementsQueue = new Queue<int>();

            int[] elements = Console.ReadLine()
                                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToArray();

            int counterEqueueElements = 0;

            while (counterEqueueElements != enqueueElements) 
            {
                counterEqueueElements++;
                elementsQueue.Enqueue(elements[counterEqueueElements - 1]);
            }

            int counterDequeueElements = 0; 

            while (counterDequeueElements != dequeueElements)
            {
                elementsQueue.Dequeue();
                counterDequeueElements++;
            }

            if (elementsQueue.Contains(peekElements))
            {
                Console.WriteLine("true");
            }
            else if (elementsQueue.Count == 0)
            {
                Console.WriteLine("0");
            }
            else
            {
                Console.WriteLine($"{elementsQueue.Min()}");
            }
        }
    }
}
