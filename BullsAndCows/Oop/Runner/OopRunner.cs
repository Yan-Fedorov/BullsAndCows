using BullsAndCows.Oop.GamerConsol;

namespace BullsAndCows.Oop.Runner
{
    public interface IOopRunner
    {
        GameInputOption Run(IOopGame game);
        int Iteration { set; get; }
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

        public GameInputOption Run(IOopGame game)
        {
            if (Iteration == 0)
            {
                game.MakeGreating();
            }

            bool? isHasWin = false;
            do
            {
                Iteration++;
                if (Iteration > 10)
                    break;

                isHasWin = game.Run();
                if (isHasWin == null)
                    return GameInputOption.CallGameMenu;

            } while (isHasWin == false);

            game.ShowResult(isHasWin == true);


            _input.PressAnyKey();

            Iteration = 0;
            return GameInputOption.Exit;
        }
    }
}
