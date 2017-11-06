using System;
using BullsAndCows.Oop.Runner;


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

        public int Assumption { get; set; }
        public int Line { get; set; }
        private bool _locked;


        public OopSolwer(ISolwerInput input, ISolwerOutput output)
        {
            _input = input;
            _output = output;

            Line = 500;
            Assumption = Line;

            _locked = false;
        }


        public void MakeGreating()
        {
            _output.SolwerGreating();
        }

        public bool? Run()
        {
            var guessed = false;
            if (!_locked)
            {
                Line = Line / 2;
                if (Line == 0)
                    Line = 1;
            }


            _output.Assumption(Assumption);
            var estimate = _input.GetEstimation();

            _locked = estimate.Option == GameInputOption.CallGameMenu;
            if (_locked)
                return null;




            //           string stringAssumption = Assumption.ToString();
            //           string variants = @"
            //1 - да
            //2 - моё число меньше
            //3 - моё число больше";
            //           _oopMenu.solwerList.Add(new TemporaryStorageSolwer(stringAssumption, variants, estimate));

            switch (estimate.Input)
            {
                case 1:
                    guessed = true;
                    break;

                case 2:
                    Assumption -= Line;
                    break;

                case 3:
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
    }
}
