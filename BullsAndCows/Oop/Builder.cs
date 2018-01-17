using System;
using Autofac;
using BullsAndCows.Oop.Solwer;
using BullsAndCows.Oop.ActiveGame;
using System.Collections.Generic;

namespace BullsAndCows.Oop
{
    public interface IBuilder  
    {
        IOopGame CreateGame(Game gameKey);
    }

    //TODO: Удалить из тестов
    public class Builder: IBuilder
    {       
        private readonly ILifetimeScope _scope;
        private readonly IActiveGameStore _activeGameStore;

        private readonly Dictionary<Game, Type> _gamesDictionary = new Dictionary<Game, Type>
        {
            { Game.Solver, typeof(OopSolwer)}
        };


        public Builder(ILifetimeScope scope, IActiveGameStore activeGameStore)
        {
            _scope = scope;
            _activeGameStore = activeGameStore;
        }


        public IOopGame CreateGame(Game gameKey)
        {

            if(!_gamesDictionary.TryGetValue(gameKey, out var gameType))
                throw new ArgumentOutOfRangeException(nameof(gameKey), gameKey, null);

            var game = _scope.Resolve(gameType) as IOopGame;
            _activeGameStore.StoreGame(game);
            return game;
        }
    }
}
