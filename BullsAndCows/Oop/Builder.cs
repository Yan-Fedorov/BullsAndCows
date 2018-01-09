using System;
using Autofac;
using BullsAndCows.Oop.GameLoader;
using BullsAndCows.Oop.GamerConsol;
using BullsAndCows.Oop.Menu;
using BullsAndCows.Oop.Runner;
using BullsAndCows.Oop.Solwer;
using BullsAndCows.Oop.Thinker;
using BullsAndCows.Oop.GameData;
using BullsAndCows.Oop.ProSolwer;
using BullsAndCows.Oop.ProfessionalSolwer;


namespace BullsAndCows.Oop
{
    public interface IBuilder  
    {
        IOopGame GetGame(Game gameKey);
    }

    public class Builder: IBuilder
    {       
        private readonly IGamerConsoleInput _consoleInput;
        private readonly IGamerConsoleOutput _consoleOutput;
        private readonly ILifetimeScope _scope;
     

        public Builder(IGamerConsoleInput consoleInput, IGamerConsoleOutput consoleOutput, ILifetimeScope scope)
        {
            _scope = scope;
            _consoleInput = consoleInput;
            _consoleOutput = consoleOutput;
        }


        public IOopGame GetGame(Game gameKey)
        {
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
