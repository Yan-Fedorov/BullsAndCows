using System;
using BullsAndCows.Oop;
using BullsAndCows.Oop.Runner;


namespace BullsAndCows.Oop.Thinker
{
    public class OopThinker : IOopGame
    {
        private readonly IThinkerInput _input;
        private readonly IThinkerOutput _output;

        public int Number { get; set; }


        public OopThinker(IThinkerInput input, IThinkerOutput output)
        {
            _input = input;
            _output = output;

            Number = new Random().Next(100, 999);
        }

        public void MakeGreating()
        {
            _output.ThinkerGreating();
        }

        public bool? Run()
        {

            var assumption = _input.GetNumber();
            if (assumption.Option != GameInputOption.GameInput)
                return null;


            var guessed = assumption.Input == Number;

            if (!guessed)
                _output.ShowEstimationThinker(assumption.Input, assumption.Input > Number);

            return guessed;
        }
        


        public void ShowResult(bool outOfIterations)
        {
            _output.ShowResultThinker(Number, outOfIterations);
        }
    }
}
