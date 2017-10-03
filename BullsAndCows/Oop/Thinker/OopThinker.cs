﻿using System;

namespace BullsAndCows.Oop.Thinker
{
    public class OopThinker: IGame
    {
        private readonly IThinkerInput _input;
        private readonly IThinkerOutput _output;

        public OopThinker(IThinkerInput input, IThinkerOutput output)
        {
            _input = input;
            _output = output;
        }


        public void Run()
        {
            var number = 591;// new Random().Next(100, 999);

            _output.ThinkerGreating();

            var iteration = 0;
            do
            {
                var assumption = _input.GetNumber();

                if(assumption == number)
                    break;                

                _output.ShowEstimationThinker(assumption, assumption > number);

                iteration++;
            } while (iteration < 10);

            _output.ShowResultThinker(number, iteration < 10);
        }
    }
}
