/*
 * 03. Count Uppercase Words
 * 
 * Write a program that reads a line of text from the console. Print all words that start with an uppercase 
 * letter in the same order you receive them in the text.
 * 
 * Example
 * Input:                                                Output:
 * The following example shows how to use Function       The
 *                                                       Function
 * 
 * Input:                                                                               Output:
 * Write a program that reads one line of text from console.                            Write
 * Print count of words that start with Uppercase,                                      Print
 * after that print all those words in the same order like you find them in text.       Uppercase,
 * 
 * Hints
 * Use Func<string, bool> like or in if condition
 * Use " " for splitting words.
 * 
 * https://github.com/PavelDoynov
 */


using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Count_Uppercase_Words
{
    class Program
    {
        static void Main()
        {
            //Func<string, bool> uppercaseWord = word => char.IsUpper(word[0]);

            Func<string, bool> uppercaseWord = word => word[0] >= 65 && word[0] <= 90;

            List<string> result = Console.ReadLine()
                                         .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                         .ToList();

            foreach (var word in result.Where(uppercaseWord))
            { 
                Console.WriteLine(word);
            }
        }
    }
}
