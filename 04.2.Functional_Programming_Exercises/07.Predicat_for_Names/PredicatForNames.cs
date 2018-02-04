/*
 * 07. Predicate for Names
 * 
 * Write a program that filters a list of names according to their length. On the first line you will be given integer n
 * representing name length. 
 * On the second line you will be given some names as strings separated by space. 
 * Write a function that prints only the names whose length is less than or equal to n.
 * 
 * Example
 * Input:                             Output:              Input:                             Output:
 * 4                                  Geo                  4                                  Asen
 * Kurnelia Qnaki Geo Muk Ivan        Muk                  Karaman Asen Kiril Yordan
 *                                    Ivan
 * 
 * 
 * https://github.com/PavelDoynov
 */


using System;
using System.Linq;
using System.Collections.Generic;

namespace _07.Predicat_for_Names
{
    class Program
    {
        static void Main()
        {
            int lenght = int.Parse(Console.ReadLine());

            Func<string, bool> takeNames = name => name.Length <= lenght;
            Action<string> Print = name => Console.WriteLine(name);

            Console.ReadLine()
                   .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                   .Where(takeNames)
                   .ToList()
                   .ForEach(Print);
        }
    }
}
