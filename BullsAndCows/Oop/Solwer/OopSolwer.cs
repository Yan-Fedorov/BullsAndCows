using System;
namespace BullsAndCows.Oop.Solwer
{
    public enum OopEstimation
    {
        Equal = 1, Less, More
    }
    public class OopSolwer : IOopGame
    {
        private readonly ISolwerInput _input;
        private readonly ISolwerOutput _output;
        public OopSolwer(ISolwerInput input, ISolwerOutput output)
        {
            _input = input;
            _output = output;
            Line = 500;

        }

        public int Iteration { get; set; }
        public int Assumption { get; set; }
        public int Line { get; set; }
        

        public void MakeGreating()
        {
            _output.SolwerGreating();
        }

        public bool Run()
        {
            
            Assumption = Line;
            var guessed = false;
            Line = Line / 2;
            if (Line == 0)
                Line = 1;

            _output.Assumption(Assumption);

            var estimate = _input.GetEstimation();
            switch (estimate)
            {
                case OopEstimation.Equal:
                    guessed = true;
                    break;

                case OopEstimation.Less:
                    Assumption -= Line;
                    break;

                case OopEstimation.More:
                    Assumption += Line;
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
            return guessed;
        }

        public void ShowResult(bool outOfIterations)
        {
            _output.DisplayingResultOfGame(outOfIterations);
        }


        //public void Run()
        //{
        //    var line = 500;
        //    var assumption = line;
        //    var guessed = false;
        //        line = line / 2;
        //        if (line == 0)
        //            line = 1;

        //        _output.Assumption(assumption);

        //        var estimate = _input.GetEstimation();
        //    switch (estimate)
        //    {
        //        case OopEstimation.Equal:
        //            guessed = true;
        //            break;

        //        case OopEstimation.Less:
        //            assumption -= line;
        //            break;

        //        case OopEstimation.More:
        //            assumption += line;
        //            break;

        //        default:
        //            throw new ArgumentOutOfRangeException();
        //    }
        //}
    }
}
