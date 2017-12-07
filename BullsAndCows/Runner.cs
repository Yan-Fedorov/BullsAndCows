using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullsAndCows
{
    public enum Game
    {
        Solver = 1, Thinker, ProSolwer, SolwerDividesBy3
    }

    public class Runner
    {
        public void Run()
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

                    case Game.Thinker:
                        new Thinker().Run();
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
3 - выход");

            while (true)
            {
                var key = Console.ReadLine();

                if (int.TryParse(key, out var num) && num > 0 && num < 4)
                    return num == 3 ? (Game?)null : (Game)num;
            }
        }
    }
}
