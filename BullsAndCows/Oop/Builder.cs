﻿using System;
using BullsAndCows.Oop.GameLoader;
using BullsAndCows.Oop.GamerConsol;
using BullsAndCows.Oop.Menu;
using BullsAndCows.Oop.Runner;
using BullsAndCows.Oop.Solwer;
using BullsAndCows.Oop.Thinker;


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
        private readonly IGameLoader _gameLoader;
        private OopMenu _menu;
        private readonly OopRunner _runner;
        private readonly ITemporaryStorageSolwer _temporaryStorageSolwer;

        public Builder(IGamerConsoleInput consoleInput = null, IGamerConsoleOutput consoleOutput = null, IGameLoader gameLoader = null, ITemporaryStorageSolwer temporaryStorageSolwer = null)
        {
            _consoleInput = consoleInput ?? new GamerConsoleInput();
            _consoleOutput = consoleOutput ?? new GamerConsoleOutput();
            _gameLoader = gameLoader ?? new GameLoader.GameLoader(this);

            _runner = new OopRunner(_consoleInput);

            _temporaryStorageSolwer = temporaryStorageSolwer ?? new TemporaryStorageSolwer();
            
        }


        public OopRunner GetRunner()
        {
            return _runner;
        }

        public OopMenu GetMenu()
        {
            return _menu = new OopMenu(_consoleInput, _consoleOutput, _gameLoader, this, _runner, _temporaryStorageSolwer);
        }


        public IOopGame GetGame(Game gameKey)
        {
            switch (gameKey)
            {
                case Game.Solver:
                    return new OopSolwer(_consoleInput, _consoleOutput, _menu);

                case Game.Thinker:
                    return new OopThinker(_consoleInput, _consoleOutput);

                default:
                    throw new ArgumentOutOfRangeException(nameof(gameKey), gameKey, null);
            }
        }
    }
}
