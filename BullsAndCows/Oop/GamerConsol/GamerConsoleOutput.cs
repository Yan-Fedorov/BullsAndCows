using System;
using System.Text;
using BullsAndCows.Oop.GameContext;
using BullsAndCows.Oop.OopGameLoader;
using BullsAndCows.Oop.Thinker;
using BullsAndCows.Oop.Solwer;
using BullsAndCows.Oop.Runner;

namespace BullsAndCows.Oop.GamerConsol
{
    public interface IGamerConsoleOutput : IThinkerOutput, ISolwerOutput,
        IOopRunnerOutput, IGameMenuOutput
    { }

    public class GamerConsoleOutput : IGamerConsoleOutput
    {
        private readonly IConsoleHistorySaver _consoleHistorySaver;

        public GamerConsoleOutput(IConsoleHistorySaver consoleHistorySaver)
        {
            _consoleHistorySaver = consoleHistorySaver;
            Console.OutputEncoding = Encoding.UTF8;
        }


        #region IThinkerOutput
        public void ThinkerGreating()
        {
            const string msg = "Я загадал 3-х значное число, угадывай )";
            _consoleHistorySaver.SaveGameHistory(msg + Environment.NewLine);
            Console.WriteLine(msg);
        }

        public void ShowEstimationThinker(int assumption, bool isAssumptionBigger)
        {
            var msg = $"Число {assumption} {(isAssumptionBigger ? "больше" : "меньше")} загаданного";
            _consoleHistorySaver.SaveGameHistory(msg + Environment.NewLine);
            Console.WriteLine(msg);
        }

        public void ShowResultThinker(int number, bool isGuessed)
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
            var msg = "Загадайте 3-х значное число и нажмите любую клавишу";
            _consoleHistorySaver.SaveGameHistory(msg + Environment.NewLine);
            Console.WriteLine(msg);
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

        public void ReloadGameHistory(string history)
        {
            Console.WriteLine(history);
        }
        public void Exeption()
        {
            Console.WriteLine("Сохранённых игр не найдено");
        }
        #endregion
    }
}
