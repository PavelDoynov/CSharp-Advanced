/*
 * 02. Knights of Honor
 * 
 * Write a program that reads a collection of names as strings from the console then appends “Sir” in front of every 
 * name and prints it back onto the console. Use Action<T>.
 * 
 * Example
 * Input:                                Output:
 * Pesho Gosho Adasha StanleyRoyce       Sir Pesho
 *                                       Sir Gosho
 *                                       Sir Adasha
 *                                       Sir StanleyRoyce
 * 
 * https://github.com/PavelDoynov
 */


using System;
using System.Linq;

namespace _02.Knights_of_Honor
{
    class Program
    {
        static void Main()
        {
            Action<string> knights = sirName => Console.WriteLine($"Sir {sirName}");  

            Console.ReadLine()
                   .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                   .ToList()
                   .ForEach(knights);
        }
    }
}
