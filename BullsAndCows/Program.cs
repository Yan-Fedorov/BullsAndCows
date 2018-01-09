using BullsAndCows.Oop;
using Autofac;
using BullsAndCows.Oop.GameLoader;
using BullsAndCows.Oop.Menu;

namespace BullsAndCows
{

    public class Program
    {
        public static void Main()
        {
        
            using (var container = IoCBuilder.Building())
            {
                using (var scope = container.BeginLifetimeScope())
                {
                    //var app = scope.TryResolve<Builder>(out var a);
                    var menu = scope.TryResolve<OopMenu>(out var b);
                    b.RunMainMenu();

                }
               
            }

            //a.GetMenu().RunMainMenu();
            //new Builder()
            //    .GetMenu()
            //    .RunMainMenu();
        }

}
}

