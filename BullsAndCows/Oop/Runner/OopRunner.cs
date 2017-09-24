using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BullsAndCows.Oop.GamerConsol;
using BullsAndCows.Oop.Puzzle;
using BullsAndCows.Oop.Solwer;

namespace BullsAndCows.Oop
{
    public class OopRunner
    {
        private readonly IGamerConsoleInput _input;
        private readonly IOopRunnerOutput _output;

        public OopRunner(IGamerConsoleInput input = null, IOopRunnerOutput output = null)
        {
            _input = input ?? new GamerConsoleInput();
            _output = output ?? new GamerConsoleOutput();
        }
       


        public void Run()
        {
            Console.OutputEncoding = Encoding.UTF8;

            

            while (true)
            {
                Console.Clear();
                var game = SelectGame();

                switch (game)
                {
                    case Game.Solver:
                        new OopSolwer(_input, _output as ISolwerOutput).Run();
                        break;

                    case Game.Puzzle:
                        new OopPuzzle(_input, _output as IPuzzleOutput).Run();
                        break;

                    case null:
                        _output.ByeBye();
                        //Console.WriteLine("Как жаль что вы уже уходите.");
                        //Console.ReadLine();
                        return;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        private static Game? SelectGame()
        {
            Console.WriteLine(@"Укажите вариант игры:
1 - компьютер отгадывает число
2 - компьютер загадывает число
3 - выход");

            while (true)
            {
                var key = Console.ReadLine();

                if (int.TryParse(key, out var num) && num > 0 && num < 4)
                    return num == 3 ? (Game?)null : (Game)num;
            }
        }

    }
}
