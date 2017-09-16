using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BullsAndCows.Oop.Puzzle;

namespace BullsAndCows.Oop.GamerConsol
{
    public class GamerConsoleOutput : IPuzzleOutput
    {
        #region IPuzzleOutput
        public void Greating()
        {
            Console.WriteLine("Я загадал 3-х значное число, угадывай )");
        }

        public void ShowEstimation(int assumption, bool isAssumptionBigger)
        {
            Console.WriteLine($"Число {assumption} {(isAssumptionBigger ? "больше" : "меньше")} загаданного");
        }

        public void ShowResult(int number, bool isGuessed)
        {
            Console.WriteLine();
            Console.WriteLine(isGuessed
                ? $"Верно, я загадывал {number}"
                : $"К сожалению у вас закончились попытки. Я загадывал {number}"
            );
        }
        #endregion
    }
}
