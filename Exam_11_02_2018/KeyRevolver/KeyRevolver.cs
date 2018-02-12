/*
 * 01. Key Revolver
 * 
 * Our favorite super-spy action hero Sam is back from his mission in another exam, and this time he has an even more
 * difficult task. He needs to unlock a safe. The problem is that the safe is locked by several locks in a row, which 
 * all have varying sizes.
 * 
 * Our hero posesses a special weapon though, called the Key Revolver, with special bullets. Each bullet can unlock a 
 * lock with a size equal to or smaller than the size of the bullet. The bullet goes into the keyhole, then explodes, 
 * completely destroying it. Sam doesn’t know the size of the locks, so he needs to just shoot at all of them, until the 
 * safe runs out of locks.
 * 
 * What’s behind the safe, you ask? Well, intelligence! It is told that Sam’s sworn enemy – Nikoladze, keeps his top 
 * secret Georgian Chacha Brandy recipe inside. It’s valued differently across different times of the year, so Sam’s boss
 * will tell him what it’s worth over the radio. One last thing, every bullet Sam fires will also cost him money, which 
 * will be deducted from his pay from the price of the intelligence. 
 * 
 * Good luck, operative.
 * 
 * Input
 * •   On the first line of input, you will receive the price of each bullet – an integer in the range [0-100]
 * •   On the second line, you will receive the size of the gun barrel – an integer in the range [1-5000]
 * •   On the third line, you will receive the bullets – a space-separated integer sequence with [1-100] integers
 * •   On the fourth line, you will receive the locks – a space-separated integer sequence with [1-100] integers
 * •   On the fifth line, you will receive the value of the intelligence – an integer in the range [1-100000]
 * 
 * After Sam receives all of his information and gear (input), he starts to shoot the locks front-to-back, while going
 * through the bullets back-to-front.
 * If the bullet has a smaller or equal size to the current lock, print “Bang!”, then remove the lock. 
 * If not, print “Ping!”, leaving the lock intact. The bullet is removed in both cases.
 * 
 * If Sam runs out of bullets in his barrel, print “Reloading!” on the console, then continue shooting. 
 * If there aren’t any bullets left, don’t print it.
 * 
 * The program ends when Sam either runs out of bullets, or the safe runs out of locks.
 * 
 * Output
 * •    If Sam runs out of bullets before the safe runs out of locks, print:
 * “Couldn't get through. Locks left: {locksLeft}”
 * •   If Sam manages to open the safe, print:
 * “{bulletsLeft} bullets left. Earned ${moneyEarned}”
 * Make sure to account for the price of the bullets when calculating the money earned.
 * 
 * Constraints
 * •   The input will be within the constaints specified above and will always be valid. There is no need to check it 
 * explicitly.
 * •   There will never be a case where Sam breaks the lock and ends up with negative balance.
 * 
 * Example
 * Input:                Output:                                  Comments:
 * 50                    Ping!                                    20 shoots lock 15 (ping)
 * 2                     Bang!                                    10 shoots lock 15 (bang)
 * 11 10 5 11 10 20      Reloading!                               11 shoots lock 13 (bang)
 * 15 13 16              Bang!                                    5 shoots lock 13 (bang)
 * 1500                  Bang!
 *                       Reloading!                               Bullet cost: 4 * 50 = $200
 *                       2 bullets left. Earned $1300             Earned: 1500 – 200 = $1300
 * 
 * Input:                Output:                                  Comments:
 * 20                    Bang!                                    5 shoots lock 13 (bang)
 * 6                     Ping!                                    10 shoots lock  3 (ping)
 * 14 13 12 11 10 5      Ping!                                    11 shoots lock  3 (ping)
 * 13 3 11 10            Ping!                                    12 shoots lock  3 (ping)
 * 800                   Ping!                                    13 shoots lock  3 (ping)
 *                       Ping!                                    14 shoots lock  3 (ping)
 *                       Couldn't get through. Locks left: 3
 * 
 * Input:                Output:                                  Comments:
 * 33                    Bang!                                    10 shoots lock 10 (bang)
 * 1                     Reloading!                               11 shoots lock 20 (bang)
 * 12 11 10              Bang!                                    12 shoots lock 30 (bang)
 * 10 20 30              Reloading!
 * 100                   Bang!                                    Bullet cost: 3 * 33 = $99
 *                       0 bullets left. Earned $1                Earned: 100 – 99 = $1
 * 
 * https://github.com/PavelDoynov
 */


using System;
using System.Collections.Generic;
using System.Linq;

namespace KeyRevolver
{
    class Program
    {
        static void Main()
        {
            int moneyPerBullet = int.Parse(Console.ReadLine());
            int reloading = int.Parse(Console.ReadLine());

            Stack<int> bullets = GetBullets();
            Queue<int> locks = GetLocks();

            int intelligence = int.Parse(Console.ReadLine());

            int bulletCounter = 0;
            int reloadCounter = 0;

            while (true)
            {
                if (bullets.Count <= 0 && locks.Count > 0)
                {
                    Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
                    break;
                }
                if (locks.Count <= 0 || bullets.Count <= 0 && locks.Count <= 0)
                {
                    Console.WriteLine($"{bullets.Count} bullets left. Earned ${intelligence - (bulletCounter * moneyPerBullet)}");
                    break;
                }

                int currentBullet = bullets.Pop();
                int currentLock = locks.Peek();

                if (currentBullet <= currentLock)
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                reloadCounter++;
                bulletCounter++;

                if (reloadCounter == reloading && bullets.Count != 0)
                {
                    Console.WriteLine("Reloading!");
                    reloadCounter = 0;
                }
            }
        }

        private static Queue<int> GetLocks()
        {
            int[] lockArr = Console.ReadLine()
                                   .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                   .Select(int.Parse)
                                   .ToArray();

            Queue<int> locks = new Queue<int>();

            for (int i = 0; i < lockArr.Length; i++)
            {
                locks.Enqueue(lockArr[i]);
            }
            return locks;
        }

        private static Stack<int> GetBullets()
        {
            int[] bullets = Console.ReadLine()
                                   .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                   .Select(int.Parse)
                                   .ToArray();

            Stack<int> bulletsStack = new Stack<int>();

            for (int i = 0; i < bullets.Length; i++)
            {
                bulletsStack.Push(bullets[i]);
            }

            return bulletsStack;
        }
    }
}
