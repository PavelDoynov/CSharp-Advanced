/*
 * 03. Group Numbers
 * 
 * Read a set of numbers and group them by their remainder when dividing to 3 (0, 1 and 2).
 * One first line, you will get numbers separated with coma and whitespace.
 * 
 * Example:
 * Input:                                          Output:
 * 1, 4, 113, 55, 3, 1, 2, 66, 557, 124, 2         3 66 
 *                                                 1 4 55 1 124 
 *                                                 113 2 557 2
 * 
 * Input:                                          Output:
 * 1, 4, -113, 55, -3, 1, -2, 66, 557, -124, 2     -3 66 
 *                                                 1 4 55 1 -124 
 *                                                 -113 -2 557 2
 * 
 * Hints
 * •   Think about how to get all rows lengths
 * •   First element in each array will be easy, but what will happen with next numbers we need to add to each row.  
 * Probably you will need one more array to save the next index for each row.
 * 
 * https://github.com/PavelDoynov
 */


using System;
using System.Linq;

namespace Group_Numbers
{
    class MainClass
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine()
                                   .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                                   .Select(int.Parse)
                                   .ToArray();

            int numbersEqualZero = 0; 
            int numbersEqualOne = 0;
            int numbersEqualTwo = 0; 

            foreach (var number in numbers)
            {
                int currentNumber = Math.Abs(number);
                if (currentNumber % 3 == 0)
                {
                    numbersEqualZero++;
                }
                else if (currentNumber % 3 == 1)
                {
                    numbersEqualOne++;
                }
                else if (currentNumber % 3 == 2)
                {
                    numbersEqualTwo++;
                }
            }

            int[] zeroArr = new int[numbersEqualZero];
            int[] oneArr = new int[numbersEqualOne];
            int[] twoArr = new int[numbersEqualTwo];

            int counterZero = 0;
            int counterOne = 0;
            int counterTwo = 0;

            for (int number = 0; number < numbers.Length; number++)
            {
                int currentNumber = Math.Abs(numbers[number]);
                if (currentNumber % 3 == 0)
                {
                    for (int currentIndex = 0; currentIndex < zeroArr.Length; currentIndex++)
                    {
                        if (currentIndex == counterZero) 
                        {
                            zeroArr[currentIndex] = numbers[number];
                            counterZero++;
                            break;
                        }
                    }
                }
                else if (currentNumber % 3 == 1)
                {
                    for (int currentIndex = 0; currentIndex < oneArr.Length; currentIndex++)
                    {
                        if (currentIndex == counterOne)
                        {
                            oneArr[currentIndex] = numbers[number];
                            counterOne++;
                            break;
                        }
                    }
                }
                else if (currentNumber % 3 == 2)
                {
                    for (int currentIndex = 0; currentIndex < twoArr.Length; currentIndex++)
                    {
                        if (currentIndex == counterTwo)
                        {
                            twoArr[currentIndex] = numbers[number];
                            counterTwo++;
                            break;
                        }
                    }
                }
            }

            int[][] jaggedArray = new int[3][];
            jaggedArray[0] = zeroArr;
            jaggedArray[1] = oneArr;
            jaggedArray[2] = twoArr;

            for (int arr = 0; arr < jaggedArray.Length; arr++)
            {
                for (int number = 0; number < jaggedArray[arr].Length; number++)
                {
                    Console.Write($"{jaggedArray[arr][number]} ");
                }
                Console.WriteLine();
            }
        }
    }
}

/*   

  int[] numbers = Console.ReadLine()
                         .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                         .Select(int.Parse)
                         .ToArray();

  int[] zeroArr = numbers.Where(num => Math.Abs(num) % 3 == 0).ToArray();
  int[] oneArr = numbers.Where(num => Math.Abs(num) % 3 == 1).ToArray();
  int[] twoArr = numbers.Where(num => Math.Abs(num) % 3 == 2).ToArray();

  int[][] jaggedArray = new int[3][];
  jaggedArray[0] = zeroArr;
  jaggedArray[1] = oneArr;
  jaggedArray[2] = twoArr;

  foreach (var arr in jaggedArray)
  {
       Console.WriteLine($"{string.Join(" ", arr)}");
  }

*/
