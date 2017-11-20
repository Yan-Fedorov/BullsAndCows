using System;
using BullsAndCows.Oop.Runner;
using BullsAndCows.Oop.Solwer;
using NLog;

namespace BullsAndCows.Oop.ProSolwer
{
 
    public class OopProSolwer : IOopGame
    {
        private readonly ILogger _logger = LogManager.GetCurrentClassLogger();

        private readonly ISolwerInput _input;
        private readonly ISolwerOutput _output;

        public int Assumption { get; set; }
        public int Line { get; set; }
        private bool _locked;
        private int I ;
        private OopEstimation TMP;


        public OopProSolwer(ISolwerInput input, ISolwerOutput output)
        {
            _input = input;
            _output = output;

            Line = 500;
            Assumption = Line;

            _locked = false;
            I = 0;
            TMP = OopEstimation.Equal;
        }


        public void MakeGreating()
        {
            _output.SolwerGreating();
        }

        public bool? Run()
        {
           
            
            var guessed = false;
            if (I == 1)
            {
                    if (!_locked)
                    {
                        Line = (Line/2) +(Line/4);
                        if (Line == 0)
                            Line = 1;
                    }
                    I = 0;
             
            }
            else
            {
                if (!_locked)
                {
                    Line = Line / 2;
                    if (Line == 0)
                        Line = 1;
                }
            }

            _logger.Info($"line: {Line}, assumption: {Assumption}");

            _output.Assumption(Assumption);
            var estimate = _input.GetEstimation();

            if(estimate.Input == TMP)
            {
                I++;
            }
            TMP = estimate.Input;
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
