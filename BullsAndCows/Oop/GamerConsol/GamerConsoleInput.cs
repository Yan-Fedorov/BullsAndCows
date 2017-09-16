using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BullsAndCows.Oop.Puzzle;

namespace BullsAndCows.Oop.GamerConsol
{
    public class GamerConsoleInput: IPuzzleInput
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
    }
}
