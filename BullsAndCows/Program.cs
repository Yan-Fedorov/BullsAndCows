using System;
using System.Text;

namespace BullsAndCows
{
    public class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            new Solwer().Run();

            Console.ReadLine();
        }
    }
}
