using System;
using BullsAndCows.Oop.GameLoader;
using BullsAndCows.Oop.GamerConsol;
using BullsAndCows.Oop.Menu;
using BullsAndCows.Oop.Runner;
using BullsAndCows.Oop.Solwer;
using BullsAndCows.Oop.Thinker;
using BullsAndCows.Oop.GameData;
using BullsAndCows.Oop.ProSolwer;


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
        private readonly TemporaryStorage _temporaryStorage;
        private readonly IGameDataService _dataService;

        public Builder(IGamerConsoleInput consoleInput = null, IGamerConsoleOutput consoleOutput = null, IGameLoader gameLoader = null, ITemporaryStorageSolwer temporaryStorageSolwer = null, TemporaryStorage temporaryStorage = null, IGameDataService dataSevice = null)
        {
            _dataService = dataSevice ?? new GameDataService();
            _temporaryStorage = temporaryStorage ?? new TemporaryStorage();
            _consoleInput = consoleInput ?? new GamerConsoleInput(_temporaryStorage);
            _consoleOutput = consoleOutput ?? new GamerConsoleOutput(_temporaryStorage);
            _gameLoader = gameLoader ?? new GameLoader.GameLoader(this,_dataService);

            _runner = new OopRunner(_consoleInput);

            _temporaryStorageSolwer = temporaryStorageSolwer ?? new TemporaryStorageSolwer();

            
        }


        public OopRunner GetRunner()
        {
            return _runner;
        }

        public OopMenu GetMenu()
        {
            return _menu = new OopMenu(_consoleInput, _consoleOutput, _gameLoader, this, _runner, _temporaryStorageSolwer, _temporaryStorage);
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

                default:
                    throw new ArgumentOutOfRangeException(nameof(gameKey), gameKey, null);
            }
        }
    }
}
