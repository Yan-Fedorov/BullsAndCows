using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullsAndCows.Oop
{
    public interface IOopGame
    {
        void MakeGreating();
        bool Run();
        void ShowResult(bool outOfIterations);
    }
}
