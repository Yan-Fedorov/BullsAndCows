using System;
using BullsAndCows.Oop;


namespace BullsAndCows.Oop.Thinker
{
    public class OopThinker : IOopGame
    {
        private readonly IThinkerInput _input;
        private readonly IThinkerOutput _output;

        public int Number { get; set; }
        public int Iteration { get; set; }


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


        public bool Run()
        {

            var assumption = _input.GetNumber();

            //ToDO: подумать как написанного в комментариях не делать здесь
            /*
             * if(assumption is exit command)
             * {
             *      _saver.Save(number, iteration);
             *      _output.ShowExitMessage();
             *      return;
             * }
             */

            var guessed = assumption == Number;

            if (!guessed)
                _output.ShowEstimationThinker(assumption, assumption > Number);

            return guessed;
        }
        


        public void ShowResult(bool outOfIterations)
        {
            _output.ShowResultThinker(Number, outOfIterations);
        }
    }
}
