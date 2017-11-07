using BullsAndCows.Oop;
using BullsAndCows.Oop.GameData;
using BullsAndCows.Oop.Runner;
using BullsAndCows.Oop.Thinker;

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
