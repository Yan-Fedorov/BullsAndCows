using System;

namespace BullsAndCows
{
    public enum Estimation
    {
        Equal = 1, Less, More
    }

    public class Solwer : IGame
    {
        public void Run()
        {
            Console.WriteLine("Загадайте 3-х значное число");
            Console.WriteLine();


            var line = 500;
            var assumption = line;
            var iteration = 10;
            var guessed = false;

            do
            {
                iteration--;

                line = line / 2;
                if (line == 0)
                    line = 1;

                Console.WriteLine($"Вы загадали {assumption} ?");

                var estimate = GetEstimation();
                switch (estimate)
                {
                    case Estimation.Equal:
                        guessed = true;
                        break;

                    case Estimation.Less:
                        assumption -= line;
                        break;

                    case Estimation.More:
                        assumption += line;
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

            } while (iteration > 0 && !guessed);

            Console.WriteLine(guessed
                ? "Ура, я угадал )))"
                : "Ой какое сложное число вы загадали");

            Console.ReadLine();

        }

        private static Estimation GetEstimation()
        {
            Console.WriteLine(@"
 1 - да
 2 - моё число меньше
 3 - моё число больше");

            while (true)
            {
                Console.Write("Укажите соответствующий вариант: ");

                var key = Console.ReadLine();

                if (int.TryParse(key, out var num) && num > 0 && num <= 3)
                    return (Estimation)num;
            }
        }
    }
    
}

