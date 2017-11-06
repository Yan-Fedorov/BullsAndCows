﻿using System;
using BullsAndCows.Oop.Thinker;
using BullsAndCows.Oop.Solwer;
using BullsAndCows.Oop.Runner;
using System.Collections.Generic;
using BullsAndCows.Oop.GameLoader;
using BullsAndCows.Oop;

namespace BullsAndCows.Oop.GamerConsol
{
    public interface IGamerConsoleInput : IThinkerInput, ISolwerInput, IOopRunnerInput
    {
        GameInput<int> SelectSavedGame(List<string> games);
        int GetGameMenuOption();
        string GetSaveGameName();
    }

    public class GamerConsoleInput : IGamerConsoleInput
    {
        private readonly IConsoleHistorySaver _consoleHistorySaver;

        public GamerConsoleInput(IConsoleHistorySaver consoleHistorySaver)
        {
            _consoleHistorySaver = consoleHistorySaver;
        }


        public GameInput<int> GetNumber()
        {
            const string msg = "Введите число: ";
            while (true)
            {
                Console.Write(msg);

                var st = Console.ReadLine();
                if (st == "q")
                    return new GameInput<int> { Option = GameInputOption.CallGameMenu };

                if (!int.TryParse(st, out var num)) continue;

                _consoleHistorySaver.SaveGameHistory(msg + st + Environment.NewLine);
                return new GameInput<int> { Option = GameInputOption.GameInput, Input = num };
            }
        }

        public GameInput<int> GetEstimation()
        {
            var msg = @"
 1 - да
 2 - моё число меньше
 3 - моё число больше";
            Console.WriteLine(msg);
            _consoleHistorySaver.SaveGameHistory(msg + Environment.NewLine);

            msg = "Укажите соответствующий вариант: ";


            while (true)
            {
                Console.Write(msg);

                var st = Console.ReadLine();

                if (st == "q")
                    return new GameInput<int> { Option = GameInputOption.CallGameMenu };

                if (!int.TryParse(st, out var num) || num <= 0 || num > 3)
                    continue;


                _consoleHistorySaver.SaveGameHistory(msg + st + Environment.NewLine);
                return new GameInput<int> { Option = GameInputOption.GameInput, Input = num };
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
                        return new GameInput<Game> { Option = GameInputOption.CallGameMenu };
                    case 3:
                        return new GameInput<Game> { Option = GameInputOption.Exit };
                    default:
                        return new GameInput<Game> { Option = GameInputOption.GameInput, Input = (Game)num };
                }
            }
        }


        public GameInput<int> SelectSavedGame(List<string> games)
        {
            if (games.Count == 0)
            {
                Console.WriteLine("Сохранённых игр не найдено");
            }
            Console.Clear();
            Console.WriteLine("Укажите сохраненную игру, нажав на клавиши от 1 до {0} или укажите 0 для выхода:", games.Count);
            for (int i = 0; i < games.Count; i++)
            {
                Console.WriteLine((i + 1) + " - " + games[i]);
            }

            Console.WriteLine();
            while (true)
            {
                var key = Console.ReadLine();


                if (!int.TryParse(key, out var num) || num < 0) continue;


                switch (num)
                {
                    case 0:
                        return new GameInput<int> { Option = GameInputOption.Exit };

                    default:
                        return new GameInput<int> { Option = GameInputOption.GameInput, Input = num };
                        // вот тут нужно как то выбрать загрузку сохраненной игры

                        // зачем нам gameLoader если он не используется,
                        // как играм передавать параметры

                        // можно определять какую конкретно игру загружать по параметрам

                }

            }
        }


        public int GetGameMenuOption()
        {
            while (true)
            {
                Console.Clear();
                Console.Write(@"
Игровое меню:
1 - сохранить
2 - выйти
3 - вернуться к игре

Выберите вариант: ");

                var key = Console.ReadLine();
                if (int.TryParse(key, out var num) &&  0 < num && num <= 3)
                    return num;
            }

        }

        public string GetSaveGameName()
        {
            Console.WriteLine();
            Console.Write("Введите имя для сохраняемой игры: ");
            return Console.ReadLine();
        }


        public void PressAnyKey()
        {
            Console.Write("Нажмите любую клавишу...");
            Console.ReadKey(true);
        }
    }
}
