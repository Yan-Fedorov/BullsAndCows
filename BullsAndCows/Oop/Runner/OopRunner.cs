using BullsAndCows.Oop.GameLoader;
using BullsAndCows.Oop.GamerConsol;
using BullsAndCows.Oop.Thinker;

namespace BullsAndCows.Oop.Runner
{
    public class OopRunner
    {
        private readonly IGamerConsoleInput _input;
        private readonly IOopRunnerOutput _output;
        private readonly IBuilder _builder;
        private readonly IGameLoader _gameLoader;

        public OopRunner(IBuilder builder, IGamerConsoleInput input, IOopRunnerOutput output, IGameLoader gameLoader)
        {
            _builder = builder;
            _input = input;
            _output = output;
            _gameLoader = gameLoader;
        }
       


        public void Run()
        {
            while (true)
            {                
                var input = _input.SelectGame();

                if (input.Option == GameInputOption.Exit)
                {
                    _output.ByeBye();
                    _input.PressAnyKey();
                    return;
                }

                IOopGame game;

                if (input.Option == GameInputOption.CallGameMenu)
                {
                    game = _builder.GetGame(Game.Thinker);
                    _gameLoader.Load(game, new OopThinkerData {Iteration = 4, Number = 200});
                }
                else
                    game = _builder.GetGame(input.Input);


                game.MakeGreating();

                var iteration = 0;
                bool isHasWin;
                do
                {
                    iteration++;
                    isHasWin = game.Run();
                } while (iteration < 10 && !isHasWin);

                game.ShowResult(iteration < 10);
                _input.PressAnyKey();
            }
        }
    }
}
