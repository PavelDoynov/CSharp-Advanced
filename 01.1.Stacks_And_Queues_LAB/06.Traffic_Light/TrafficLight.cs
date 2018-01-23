/*
 * 06. Traffic Light
 * 
 * Create a program that simulates the queue that forms during a traffic jam. During a traffic jam only N cars 
 * can pass the crossroads when the light goes green. Then the program reads the vehicles that arrive one by one and 
 * adds them to the queue. When the light goes green N number of cars pass the crossroads and for each a 
 * message "{car} passed!" is displayed. 
 * When the "end" command is given, terminate the program and display a message with the total number of cars that
 * passed the crossroads.
 * 
 * Input
 * •   On the first line you will receive N – the number of cars that can pass during a green light
 * •   On the next lines, until the "end" command is given, you will receive commands – a single string, 
 * either a car or "green"
 * 
 * Output
 * •   Every time the "green" command is given, print out a message for every car that passes the crossroads 
 * in the format "{car} passed!"
 * •   When the "end" command is given, print out a message in the format "{number of cars} cars passed the crossroads."
 * 
 * Example
 * Input:             Output:                                    Input:             Output:
 * 4                  Hummer H2 passed!                          3                  Pesho's car passed!
 * Hummer H2          Audi passed!                               Pesho's car        Gosho's car passed!
 * Audi               Lada passed!                               Gosho's car        Mercedes CLS passed!
 * Lada               Tesla passed!                              Mercedes CLS       Nekva troshka passed!
 * Tesla              Renault passed!                            Nekva troshka      BMW X5 passed!
 * Renault            Trabant passed!                            green              5 cars passed the crossroads.
 * Trabant            Mercedes passed!                           BMW X5
 * Mercedes           MAN Truck passed!                          green
 * MAN Truck          8 cars passed the crossroads.              end
 * green
 * green
 * Tesla
 * Renault
 * Trabant
 * end
 * 
 * https://github.com/PavelDoynov
 */


using System;
using System.Collections.Generic;

namespace Traffic_Light
{
    class MainClass
    {
        public static void Main()
        {
            int counter = int.Parse(Console.ReadLine());
            int passedCarsCount = 0;
            string input = Console.ReadLine();

            Queue<string> cars = new Queue<string>();

            while (input != "end")
            {
                if (input == "green")
                {
                    int currentCount = 0;
                    int currentCounter = Math.Min(counter, cars.Count);

                    while (currentCount != currentCounter)
                    {
                        string passedCar = cars.Dequeue();
                        currentCount++;
                        passedCarsCount++;
                        Console.WriteLine($"{passedCar} passed!");
                    }
                }
                else
                {
                    cars.Enqueue(input);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"{passedCarsCount} cars passed the crossroads.");
        }
    }
}
