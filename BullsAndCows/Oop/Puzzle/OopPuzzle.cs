using System;
using System.Text;

namespace BullsAndCows.Oop.Puzzle
{
    public class OopPuzzle
    {
        private readonly IPuzzleInput _input;
        private readonly IPuzzleOutput _output;

        public OopPuzzle(IPuzzleInput input, IPuzzleOutput output)
        {
            _input = input;
            _output = output;
        }


        public void Run()
        {
            Console.OutputEncoding = Encoding.UTF8;

            var number = new Random().Next(100, 999);

            _output.PuzzleGreating();

            var iteration = 0;
            do
            {
                var assumption = _input.GetNumber();

                if(assumption == number)
                    break;                

                _output.ShowEstimation(assumption, assumption > number);

                iteration++;
            } while (iteration < 10);

            _output.ShowResult(number, iteration < 10);
        }
    }
}
