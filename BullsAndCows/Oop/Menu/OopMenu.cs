using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BullsAndCows.Oop.GameLoader;
using BullsAndCows.Oop.GamerConsol;
using BullsAndCows.Oop.Runner;
using BullsAndCows.Oop.Thinker;

namespace BullsAndCows.Oop.Menu
{
    public class OopMenu
    {
        private readonly IGamerConsoleInput _input;
        private readonly IOopRunnerOutput _output;
        private readonly IGameLoader _gameLoader;
        private readonly IBuilder _builder;
        private readonly IOopRunner _oopRunner;

        public OopMenu(IGamerConsoleInput input, IOopRunnerOutput output, IGameLoader gameLoader, IBuilder builder, IOopRunner oopRunner)
        {
            _input = input;
            _output = output;
            _gameLoader = gameLoader;
            _builder = builder;
            _oopRunner = oopRunner;
        }


        public void RunMainMenu()
        {
            while (true)
            {
                var input = _input.SelectGame();
                IOopGame game;

                switch (input.Option)
                {
                    case GameInputOption.CallGameMenu:
                        game = _builder.GetGame(Game.Thinker);
                        _gameLoader.Load(game, new OopThinkerData { Iteration = 4, Number = 200 });
                        break;

                    case GameInputOption.Exit:
                        _output.ByeBye();
                        _input.PressAnyKey();
                        return;

                    case GameInputOption.GameInput:
                        game = _builder.GetGame(input.Input);
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                _oopRunner.Run(game);
            }
        }
    }
}
