using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BullsAndCows.Oop.OopGameLoader;
using BullsAndCows.Oop.Runner;

namespace BullsAndCows.Oop.ActiveGame
{
    public interface IActiveGameStore
    {
        void StoreRunner(IOopRunner game);
        void StoreStorage(ITemporaryStorage storage);
        void StoreLoader(IGameLoader loader);
        void StoreGame(IOopGame oopGame);
    }
}
