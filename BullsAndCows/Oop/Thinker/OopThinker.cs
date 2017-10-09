using System;

namespace BullsAndCows.Oop.Thinker
{
    public class OopThinker: IGame
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


        public void Run()
        {
            _output.ThinkerGreating();

            do
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


                if (assumption == Number)
                    break;                

                _output.ShowEstimationThinker(assumption, assumption > Number);

                //TODO: подумать как проверку на количество итераций вынести отсюда (аналогично для OopSolwer)
                Iteration++;
            } while (Iteration < 10);

            _output.ShowResultThinker(Number, Iteration < 10);
        }
    }
}
