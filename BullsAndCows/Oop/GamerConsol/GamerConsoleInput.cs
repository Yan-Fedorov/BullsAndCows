using System;
using BullsAndCows.Oop.Thinker;
using BullsAndCows.Oop.Solwer;
using BullsAndCows.Oop.Runner;

namespace BullsAndCows.Oop.GamerConsol
{
    public interface IGamerConsoleInput : IThinkerInput, ISolwerInput, IOopRunnerInput { }

    public class GamerConsoleInput: IGamerConsoleInput
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

        public GameInput<Game> SelectGame()
        {
            Console.Clear();
            Console.WriteLine(@"Укажите вариант игры:
1 - компьютер отгадывает число
2 - компьютер загадывает число
3 - выход
------------------------------
0 - загрузить сохранённую игру
");

            while (true)
            {
                var key = Console.ReadLine();

                if (!int.TryParse(key, out var num) || num < 0 || num >= 4) continue;

                switch (num)
                {
                    case 0:
                        return new GameInput<Game>{ Option = GameInputOption.CallGameMenu};
                    case 3:
                        return new GameInput<Game>{Option = GameInputOption.Exit};
                    default:
                        return new GameInput<Game>{Option = GameInputOption.GameInput, Input = (Game)num};
                }
            }
        }
         public void SelectSavedGame()
        {
            Console.Clear();
            Console.WriteLine("Укажите сохраненную игру или укажите 0 для выхода:");
            while (true)
            {
                var key = Console.ReadLine();

            }
        }



        public void PressAnyKey()
        {
            Console.Write("Нажмите любую клавишу...");
            Console.ReadKey(true);
        }
    }
}
