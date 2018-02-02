/*
 * 05. Filter by Age
 * 
 * Write a program that receives an integer N on first line. On the next N lines, read pairs of "[name], [age]".
 * Then read three lines with:
 * 
 * •   Condition - "younger" or "older"
 * •   Age - Integer
 * •   Format - "name", "age" or "name age"
 * 
 * Depending on the condition, print the correct pairs in the correct format.
 * Don’t use the built-in functionality from .NET. Create your own methods.
 * 
 * Example
 * Input:         Output:            Input:         Output:       Input:         Output:
 * 5              Pesho - 20         5              Gosho         5              20
 * Pesho, 20      Mimi - 29          Pesho, 20      Simo          Pesho, 20      18
 * Gosho, 18      Ico - 31           Gosho, 18                    Gosho, 18      29
 * Mimi, 29                          Mimi, 29                     Mimi, 29       31
 * Ico, 31                           Ico, 31                      Ico, 31        16
 * Simo, 16                          Simo, 16                     Simo, 16
 * older                             younger                      younger
 * 20                                20                           50
 * name age                          name                         age
 * 
 * https://github.com/PavelDoynov
 */


using System;
using System.Collections.Generic;

namespace _05.Filter_by_Age
{
    class Program
    {
        static void Main()
        {
            Dictionary<string, int> data = new Dictionary<string, int>();

            int numberOfRows = int.Parse(Console.ReadLine());

            while (numberOfRows != 0)
            {
                string[] args = Console.ReadLine()
                                       .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

                if (!data.ContainsKey(args[0]))
                {
                    data[args[0]] = int.Parse(args[1]);
                }

                numberOfRows--;
            }

            string youngerOlder = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string nameAge = Console.ReadLine();

            Func<int, bool> filter = AgeFilter(youngerOlder, age);
            Action<KeyValuePair<string, int>> print = Result(nameAge);

            foreach (var person in data)
            {
                if (filter(person.Value))
                {
                    print(person);
                }
            }
        }

        static Func<int, bool> AgeFilter (string youngerOlder, int age)
        {
            if (youngerOlder == "younger")
            {
                return x => x < age;
            }
            else
            {
                return x => x >= age;
            }
        }

        static Action<KeyValuePair<string, int>> Result (string nameAge)
        {
            if (nameAge == "name")
            {
                return x => Console.WriteLine($"{x.Key}");
            }
            else if (nameAge == "age")
            {
                return x => Console.WriteLine($"{x.Value}");
            }
            else 
            {
                return x => Console.WriteLine($"{x.Key} - {x.Value}");
            }
        }
    }
}
