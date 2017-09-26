using System;
using System.Text;

namespace BullsAndCows
{
    public class Thinker : IGame
    {
        public void Run()
        {
            Console.OutputEncoding = Encoding.UTF8;

            var number = new Random().Next(100, 999);

            Console.WriteLine("Я загадал 3-х значное число, угадывай )");

            var iteration = 0;
            do
            {
                Console.WriteLine();
                var assumption = GetNumber();

                if (assumption > number)
                {
                    Console.WriteLine("Загаданное число меньше");
                }
                else if (assumption < number)
                {
                    Console.WriteLine("Загаданное число больше");
                }
                else
                    break;

                iteration++;
            } while (iteration < 10);

            Console.WriteLine();
            Console.WriteLine(iteration == 10
                ? $"К сожалению у вас закончились попытки. Я загадывал {number}"
                : $"Верно, я загадывал {number}"
            );

            Console.ReadLine();
        }

        private static int GetNumber()
        {
            while (true)
            {
                Console.Write("Введите число: ");

                var st = Console.ReadLine();
                if (int.TryParse(st, out var num))
                    return num;
            }
        }
    }
}
