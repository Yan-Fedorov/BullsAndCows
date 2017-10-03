using System;

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

                //ToDO: подумать как написанного в комментариях не делать здесь
                /*
                 * if(assumption is exit command)
                 * {
                 *      _saver.Save(number, iteration);
                 *      _output.ShowExitMessage();
                 *      return;
                 * }
                 */


                if (assumption == number)
                    break;                

                _output.ShowEstimationThinker(assumption, assumption > number);

                //TODO: подумать как проверку на количество итераций вынести отсюда (аналогично для OopSolwer)
                iteration++;
            } while (iteration < 10);

            _output.ShowResultThinker(number, iteration < 10);
        }


        //TODO: подумать как не повторять несколько раз один и тот-же код
        public void Run(int number, int iteration)
        {
            _output.ThinkerGreating();

            do
            {
                var assumption = _input.GetNumber();

                if (assumption == number)
                    break;

                _output.ShowEstimationThinker(assumption, assumption > number);

                iteration++;
            } while (iteration < 10);

            _output.ShowResultThinker(number, iteration < 10);
        }
    }
}
