using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BullsAndCows.Oop.OopGameLoader;
using BullsAndCows.Oop.Runner;

namespace BullsAndCows.Oop.ActiveGame
{
    public interface IActiveGameProvider
    {
        IOopRunner GetRunner();
        ITemporaryStorage GetStorage();
        IGameLoader GetLoader();
        IOopGame GetGame();
    }
}
