using System;
using BullsAndCows.Oop;
using System.Collections.Generic;
using BullsAndCows.Oop.Menu;


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
        private readonly OopMenu _oopMenu;
        public OopSolwer(ISolwerInput input, ISolwerOutput output, OopMenu menu)
        {
            _input = input;
            _output = output;
            _oopMenu = menu;
            Line = 500;
            Assumption = Line;

        }

        public int Assumption { get; set; }
        public int Line { get; set; }
        


        public void MakeGreating()
        {
            _output.SolwerGreating();
        }

        public bool Run()
        {
            
            
            var guessed = false;
            Line = Line / 2;
            if (Line == 0)
                Line = 1;

            _output.Assumption(Assumption);

            var estimate = _input.GetEstimation();


 //           string stringAssumption = Assumption.ToString();
 //           string variants = @"
 //1 - да
 //2 - моё число меньше
 //3 - моё число больше";
 //           _oopMenu.solwerList.Add(new TemporaryStorageSolwer(stringAssumption, variants, estimate));
            
            
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
    }
}
