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
        OopRunner GetRunner();
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


        public OopRunner GetRunner()
        {
            return _scope.Resolve<OopRunner>();
        }

        public OopMenu GetMenu()
        {
            return _scope.Resolve<OopMenu>();
        }


        public IOopGame GetGame(Game gameKey)
        {
            switch (gameKey)
            {
                case Game.Solver:
                    return new OopSolwer(_consoleInput, _consoleOutput);

                case Game.Thinker:
                    return new OopThinker(_consoleInput, _consoleOutput);

                case Game.ProSolwer:
                    return new OopProSolwer(_consoleInput, _consoleOutput);
                case Game.SolwerDividesBy3:
                    return new SolwerDividesBy3(_consoleInput, _consoleOutput);

                default:
                    throw new ArgumentOutOfRangeException(nameof(gameKey), gameKey, null);
            }
        }
    }
}
