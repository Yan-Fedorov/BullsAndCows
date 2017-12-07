using BullsAndCows.Oop;
using Autofac;
using BullsAndCows.Oop.GameLoader;

namespace BullsAndCows
{

    public class Program
    {
        public static void Main()
        {
            // new Runner().Run();
            //IContainer container = IoCBuilder.Building();
            using (var container = IoCBuilder.Building())
            {
                using (var scope = container.BeginLifetimeScope())
                {
                    var app = scope.TryResolve<Builder>(out var a);
                    a.GetMenu().RunMainMenu();

                }
               
            }


                //new Builder()
                //    .GetMenu()
                //    .RunMainMenu();
            }

}
}

