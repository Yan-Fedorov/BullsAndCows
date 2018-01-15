using System;
using Autofac;
using BullsAndCows.Oop.OopGameLoader;
using BullsAndCows.Oop.GamerConsol;
using BullsAndCows.Oop.Menu;
using BullsAndCows.Oop.Runner;
using BullsAndCows.Oop.Solwer;
using BullsAndCows.Oop.Thinker;
using BullsAndCows.Oop.GameData;
using BullsAndCows.Oop.ProSolwer;
using BullsAndCows.Oop.ProfessionalSolwer;
using BullsAndCows.Oop.ActiveGame;
using System.Collections.Generic;

namespace BullsAndCows.Oop
{
    public interface IBuilder  
    {
        IOopGame GetGame(Game gameKey);
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


        public IOopGame GetGame(Game gameKey)
        {

            if(!_gamesDictionary.TryGetValue(gameKey, out var gameType))
                throw new ArgumentOutOfRangeException(nameof(gameKey), gameKey, null);

            var game = _scope.Resolve(gameType) as IOopGame;
            _activeGameStore.StoreGame(game);
            return game;

            switch (gameKey)
            {
                case Game.Solver:
                    return _scope.Resolve<OopSolwer>();

                case Game.Thinker:
                    return _scope.Resolve<OopThinker>();

                case Game.ProSolwer:
                    return _scope.Resolve<OopProSolwer>();
                case Game.SolwerDividesBy3:
                    return _scope.Resolve<SolwerDividesBy3>();

                default:
                    throw new ArgumentOutOfRangeException(nameof(gameKey), gameKey, null);
            }
        }
    }
}
