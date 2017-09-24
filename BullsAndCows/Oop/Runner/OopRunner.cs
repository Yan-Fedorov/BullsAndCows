using System;
using System.Text;
using BullsAndCows.Oop.GamerConsol;
using BullsAndCows.Oop.Puzzle;
using BullsAndCows.Oop.Solwer;

namespace BullsAndCows.Oop.Runner
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
                var game = _input.SelectGame();

                switch (game)
                {
                    case Game.Solver:
                        new OopSolwer(_input, _output as ISolwerOutput).Run();
                        _input.PressAnyKey();
                        break;

                    case Game.Puzzle:
                        new OopPuzzle(_input, _output as IPuzzleOutput).Run();
                        _input.PressAnyKey();
                        break;

                    case null:
                        _output.ByeBye();
                        _input.PressAnyKey();
                        return;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}
