using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BullsAndCows.Oop.Thinker;
using BullsAndCows.Oop.Solwer;
using BullsAndCows.Oop;
using BullsAndCows.Oop.Runner;

namespace BullsAndCows.Oop.GamerConsol
{
    public class GamerConsoleOutput : IThinkerOutput, ISolwerOutput, IOopRunnerOutput
    {
        #region IPuzzleOutput
        public void PuzzleGreating()
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



        #region ISolwerOutput
        public void SolwerGreating()
        {
            Console.WriteLine("Загадайте 3-х значное число и нажмите любую клавишу");
        }

        public void Assumption(int assumption)
        {
            Console.WriteLine($"Вы загадали {assumption} ?");
        }

        public void DisplayingResultOfGame(bool guessed)
        {
            Console.WriteLine(guessed
                ? "Ура, я угадал )))"
                : "Ой какое сложное число вы загадали");
        }
        #endregion



        #region OopRunner
        public void ByeBye()
        {
            Console.WriteLine("Как жаль что вы уже уходите.");
        }
        #endregion
    }
}
