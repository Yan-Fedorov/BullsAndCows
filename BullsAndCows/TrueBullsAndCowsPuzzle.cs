using System;


namespace BullsAndCows
{
    class TrueBullsAndCowsPuzzle :IGame
    {
        public void Run()
        {
            Console.WriteLine("Я загадал трёх значное число, угадывай");
            int assumption;
            int number = 123; // new Random().Next(100, 104);
            char[] strNumber = number.ToString().ToCharArray();
            int iteration = 0;
            bool stop = false;
            do
            {
                assumption = Puzzle.GetNumber();
                char[] strAssumption = assumption.ToString().ToCharArray();
                int guessedPositions = 0;
                int guessedFigure = 0;
                for (int i = 0; i < strAssumption.Length; i++)
                {
                    for (int k = 0; k < strNumber.Length; k++)
                    {

                        if (strAssumption[k] == strNumber[i] && i == k)
                        {
                            guessedFigure++;
                            guessedPositions++;
                            stop = true;
                        }
                       else if (strAssumption[k] == strNumber[i] && stop == false)
                        {
                            guessedFigure++;
                        }
                        
                    }
                }
                if (guessedPositions == 3)
                {
                    Console.WriteLine("Вы угадали!");
                    break;
                }
                else
                {
                    Console.WriteLine("Вы угадали {0} чисел и {1} из них стоят на своём месте", guessedFigure, guessedPositions);
                }
                iteration++;
            } while (iteration < 10);
            if (iteration >= 10)
            {
                Console.WriteLine("В следующий раз вам повезёт!");
            }
            Console.ReadKey();
        }
    }
}
