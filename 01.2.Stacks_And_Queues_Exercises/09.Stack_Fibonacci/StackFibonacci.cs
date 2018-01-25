/*
 * 09. Stack Fibonacci 
 * 
 * There is another way of calculating the Fibonacci sequence using a stack. It is non-recursive, 
 * so it does not make any unnecessary calculations. Try implementing it. This time set the Fibonacci 
 * sequence to start from 0, i.e. 0, 1, 1, 2, 3, 5, 8… and so on. 
 * First push 0 and 1 and then use popping, peeking and pushing to generate every consecutive number.
 * 
 * Example
 * Input:    Output:       Input:    Output:      Input:    Output:
 * 7         13            15        610          33        3524578
 * 
 * https://github.com/PavelDoynov
 */

using System;
using System.Collections.Generic;

namespace Stack_Fibonacci
{
    class MainClass
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            Stack<long> fibonacciStack = new Stack<long>();
            fibonacciStack.Push(1);
            fibonacciStack.Push(1);

            while (number - 2 != 0)
            {
                long currentNumber = 0;
                long previousNumber = 0;
                long previousPreviousNumber = 0;

                previousNumber = fibonacciStack.Pop();
                previousPreviousNumber = fibonacciStack.Peek();
                fibonacciStack.Push(previousNumber);

                currentNumber = previousNumber + previousPreviousNumber;
                fibonacciStack.Push(currentNumber);

                number--;
            }

            Console.WriteLine($"{fibonacciStack.Pop()}");
        }
    }
}
