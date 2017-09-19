using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BullsAndCows.Oop.Puzzle;

namespace BullsAndCows.Oop.GamerConsol
{
    public class GamerConsoleInput: IPuzzleInput, ISolwerInput
    {
        public int GetNumber()
        {
            while (true)
            {
                Console.Write("Введите число: ");

                var st = Console.ReadLine();
                if (int.TryParse(st, out var num))
                    return num;
            }
        }
        public OopEstimation GetEstimation()
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
                    return (OopEstimation)num;
            }
        }
    }
}
