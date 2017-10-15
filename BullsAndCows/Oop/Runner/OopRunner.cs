using BullsAndCows.Oop.GamerConsol;

namespace BullsAndCows.Oop.Runner
{
    public interface IOopRunner
    {
        void Run(IOopGame game);
    }


    public class OopRunner : IOopRunner
    {
        private readonly IGamerConsoleInput _input;

        public int Iteration { get; set; }

        public OopRunner(IGamerConsoleInput input)
        {
            _input = input;
            Iteration = 0;
        }

        public void Run(IOopGame game)
        {
            game.MakeGreating();

            bool isHasWin;
            do
            {
                Iteration++;
                isHasWin = game.Run();
            } while (Iteration < 10 && !isHasWin);

            game.ShowResult(Iteration < 10);
            _input.PressAnyKey();

            Iteration = 0;
        }
    }
}
