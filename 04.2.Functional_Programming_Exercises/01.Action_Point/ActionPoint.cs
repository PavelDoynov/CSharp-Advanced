/*
 * 01. Action Point
 * 
 * Write a program that reads a collection of strings from the console and then prints them onto the console. 
 * Each name should be printed on a new line. Use Action<T>.
 * 
 * Example
 * Input:                  Output:
 * Pesho Gosho Adasha      Pesho
 *                         Gosho
 *                         Adasha
 * 
 * https://github.com/PavelDoynov
 */

using System;
using System.Linq;

namespace _01.Action_Point
{
    class Program
    {
        static void Main()
        {
            Action<string> names = name => Console.WriteLine(name);

            Console.ReadLine()
                   .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                   .ToList()
                   .ForEach(names);
        }
    }
}
