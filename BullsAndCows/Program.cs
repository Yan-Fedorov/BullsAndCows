using BullsAndCows.Oop;

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
