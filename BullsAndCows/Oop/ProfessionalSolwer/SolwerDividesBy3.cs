using System;
using BullsAndCows.Oop.Runner;
using BullsAndCows.Oop.Solwer;

namespace BullsAndCows.Oop.ProfessionalSolwer
{
    public class SolwerDividesBy3 : IOopGame
    {
        private readonly ISolwerInput _input;
        private readonly ISolwerOutput _output;

        public int Assumption { get; set; }
        public int Line { get; set; }
        private bool _locked;


        public SolwerDividesBy3(ISolwerInput input, ISolwerOutput output)
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
            if (!_locked && Line == 500)
            {
                Line = Line / 3 *2;
                if (Line == 0)
                    Line = 1;
            }
            else if (!_locked)
            {
                if(Line == 332)
                {
                    Line = 168;
                }
                Line = Line / 2;
                if (Line == 0)
                    Line = 1;
            }


            _output.Assumption(Assumption);
            var estimate = _input.GetEstimation();

            _locked = estimate.Option == GameInputOption.CallGameMenu;
            if (_locked)
                return null;


            switch (estimate.Input)
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
    }
}
