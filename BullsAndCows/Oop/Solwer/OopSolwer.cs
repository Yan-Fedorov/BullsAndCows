using System;
namespace BullsAndCows.Oop.Solwer
{
    public enum OopEstimation
    {
        Equal = 1, Less, More
    }
    public class OopSolwer: IGame
    {
        private readonly ISolwerInput _input;
        private readonly ISolwerOutput _output;
        public OopSolwer(ISolwerInput input, ISolwerOutput output)
        {
            _input = input;
            _output = output;

        }
        public void Run(int? number = null, int? iteration = null)
        {
            _output.SolwerGreating();

            var line = 500;
            var assumption = line;
             iteration = 10;
            var guessed = false;

            do
            {
                iteration--;

                line = line / 2;
                if (line == 0)
                    line = 1;

                _output.Assumption(assumption);

                var estimate = _input.GetEstimation();
                switch (estimate)
                {
                    case OopEstimation.Equal:
                        guessed = true;
                        break;

                    case OopEstimation.Less:
                        assumption -= line;
                        break;

                    case OopEstimation.More:
                        assumption += line;
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

            } while (iteration > 0 && !guessed);

            _output.DisplayingResultOfGame(guessed);

        }
    }
}
