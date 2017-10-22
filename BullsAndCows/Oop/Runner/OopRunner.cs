using BullsAndCows.Oop.GamerConsol;

namespace BullsAndCows.Oop.Runner
{
    public interface IOopRunner
    {
        void Run(IOopGame game);
        int Iteration { set; }
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

            bool isHasWin = false;
            do
            {
                Iteration++;
                if (Iteration > 10)
                    break;

                isHasWin = game.Run();
            } while (!isHasWin);

            game.ShowResult(isHasWin);


            _input.PressAnyKey();

            Iteration = 0;
        }
    }
}
