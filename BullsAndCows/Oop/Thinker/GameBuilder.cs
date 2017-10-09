using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullsAndCows.Oop.Thinker
{
    class GameBuilder 
    {
        
    
        private readonly IThinkerInput _input;
        private readonly IThinkerOutput _output;

        public GameBuilder(IThinkerInput input, IThinkerOutput output)
        {
            _input = input;
            _output = output;
        }

        public int Number { get; set; }
        public int Iteration { get; set; }


        public int? Run()
        {

            if (Number == null && Iteration == null)
            {
                Number = new Random().Next(100, 999);

                _output.ThinkerGreating();

                Iteration = 0;
            }
            
                var assumption = _input.GetNumber();

            //ToDO: подумать как написанного в комментариях не делать здесь
            /*
             * 
             */


            if (assumption == Number)
                return Number;

                _output.ShowEstimationThinker(assumption, assumption > Number);

                //TODO: подумать как проверку на количество итераций вынести отсюда (аналогично для OopSolwer)
                
            
            return Number;

            //_output.ShowResultThinker(number, iteration < 10);
        }

        public void Additions(int? number)
        {
            var iteration = 0;
            GameBuilder gameBuilder = new GameBuilder(_input, _output);
            do
            {
                //if (assumption is exit command)
                //     {
                //    _saver.Save(number, iteration);
                //    _output.ShowExitMessage();
                //          return;
                //     }
               // else{
                    gameBuilder.Run(/*number, iteration*/);
                    iteration++;
               // }
            } while (iteration < 10);

            _output.ShowResultThinker(number.Value, iteration < 10);

        }


        //TODO: подумать как не повторять несколько раз один и тот-же код
        class Count
        {
            private readonly IThinkerInput _input;
            private readonly IThinkerOutput _output;
            

            public Count(IThinkerInput input, IThinkerOutput output)
            {
                _input = input;
                _output = output;
            }
            

            public delegate void MethodContainer();
            public event MethodContainer eventTry;

            int? number = 0;
            public void CountTry()
            {
                GameBuilder gameBuilder = new GameBuilder(_input, _output);
                for (int i = 0; i<= 10; i++)
                {
                    if(i == 10)
                    {
                        eventTry();
                    }
                    gameBuilder.Additions(number/*number, iteration*/);
                }
            }
        }
       
    }
}

