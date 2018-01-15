using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BullsAndCows.Oop.OopGameLoader;
using BullsAndCows.Oop.Runner;
using Autofac;

namespace BullsAndCows.Oop.ActiveGame
{
    public class ActiveGameService : IActiveGameProvider, IActiveGameStore
    {
        private readonly ILifetimeScope _scope;

        private IOopRunner _oopRunner;
        private ITemporaryStorage _temporaryStorage;
        private IGameLoader _gameLoader;
        private IOopGame _oopGame;

        public IOopGame GetGame()
        {
            return _scope.Resolve<IOopGame>();
        }
        public void StoreGame(IOopGame oopGame)
        {
            _oopGame = oopGame;
        }
        public IOopRunner GetRunner()
        {
            return _oopRunner;
        }

        public void StoreRunner(IOopRunner game)
        {
            _oopRunner = game;
        }

        public ITemporaryStorage GetStorage()
        {
            return _scope.Resolve<ITemporaryStorage>();
        }
        public void StoreStorage(ITemporaryStorage storage)
        {
            _temporaryStorage = storage;
        }

        public IGameLoader GetLoader()
        {
            return _gameLoader;
        }

        public void StoreLoader(IGameLoader loader)
        {
            _gameLoader = loader;
        }

        
    }
}
