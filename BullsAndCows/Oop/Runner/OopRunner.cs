using BullsAndCows.Oop.GamerConsol;

namespace BullsAndCows.Oop.Runner
{
    public class OopRunner
    {
        private readonly IGamerConsoleInput _input;
        private readonly IOopRunnerOutput _output;
        private readonly IBuilder _builder;

        public OopRunner(IBuilder builder, IGamerConsoleInput input, IOopRunnerOutput output)
        {
            _builder = builder;
            _input = input;
            _output = output;
        }
       


        public void Run()
        {
            while (true)
            {                
                var game = _input.SelectGame();

                if (game == null)
                {
                    _output.ByeBye();
                    _input.PressAnyKey();
                    return;
                }

                _builder.GetGame(game.Value).Run();
            }
        }
    }
}
