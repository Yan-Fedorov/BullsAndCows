using System;
using System.Text;

namespace BullsAndCows
{
    public enum Game
    {
        Solver = 1, Puzzle = 2, TrueBullsAndCowsPuzzle
    }

    public class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            while (true)
            {
                Console.Clear();
                var game = SelectGame();

                switch (game)
                {
                    case Game.Solver:
                        new Solwer().Run();
                        break;

                    case Game.Puzzle:
                        new Puzzle().Run();
                        break;
                    case Game.TrueBullsAndCowsPuzzle:
                        new TrueBullsAndCowsPuzzle().Run();
                        break;

                    case null:
                        Console.WriteLine("Как жаль что вы уже уходите.");
                        Console.ReadLine();
                        return;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

        }


        private static Game? SelectGame()
        {
            Console.WriteLine(@"Укажите вариант игры:
1 - компьютер отгадывает число
2 - компьютер загадывает число
3 - компьютер загадывает число и играет в быков и коров
4 - выход");

            while (true)
            {
                var key = Console.ReadLine();

                if (int.TryParse(key, out var num) && num > 0 && num < 5)
                    return num == 4 ? (Game?)null : (Game)num;
            }
        }
    }
}
