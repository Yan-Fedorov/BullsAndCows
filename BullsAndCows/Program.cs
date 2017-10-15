using BullsAndCows.Oop;
using BullsAndCows.Oop.Runner;

namespace BullsAndCows
{

    public class Program
    {
        public static void Main()
        { 
        // new Runner().Run();

            new Builder()
                .GetMenu()
                .RunMainMenu();
        }
    }
}
