using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BullsAndCows.Oop.GameLoader;
using BullsAndCows.Oop.GamerConsol;
using BullsAndCows.Oop.Runner;
using BullsAndCows.Oop.Solwer;
using BullsAndCows.Oop.Thinker;
using Autofac;

namespace BullsAndCows.Oop.Menu
{
    public class OopMenu
    {
        private readonly IGamerConsoleInput _input;
        private readonly IOopRunnerOutput _output;
        private readonly IGameLoader _gameLoader;
        private readonly IBuilder _builder;
        private readonly IOopRunner _oopRunner;
        private readonly ITemporaryStorageSolwer _temporaryStorageSolwer;
        private readonly ITemporaryStorage _temporaryStorage;

        private readonly ILifetimeScope _scope;



        public OopMenu(IGamerConsoleInput input, IOopRunnerOutput output, IGameLoader gameLoader, IBuilder builder, IOopRunner oopRunner,
            ITemporaryStorage temporaryStorage, ILifetimeScope scope)
        {
            _input = input;
            _output = output;
            _gameLoader = gameLoader;
            _builder = builder;
            _oopRunner = oopRunner;
            _temporaryStorage = temporaryStorage;
            _scope = scope;
        }
        public List<TemporaryStorageSolwer> solwerList = new List<TemporaryStorageSolwer>();


        public void RunMainMenu()
        {
            while (true)
            {

                var input = _input.SelectGame();
                IOopGame game = null;
                // создать LiveTimeScope для игры. Дальше все зависимости будем получать из него

                switch (input.Option)
                {
                    case GameInputOption.CallGameMenu:

                        var gamesNames = _gameLoader.GetGameNames();
                        var savedGameKey = _input.SelectSavedGame(gamesNames);

                        if (savedGameKey.Option != GameInputOption.GameInput)
                            break;

                        var gameHistory = _gameLoader.Load(out game, _oopRunner, savedGameKey.Input);
                        _output.ReloadGameHistory(gameHistory);
                        _temporaryStorage.Clear(gameHistory);
                        break;

                    case GameInputOption.Exit:
                        _output.ByeBye();
                        _input.PressAnyKey();
                        return;

                    case GameInputOption.GameInput:
                        if (input.Input == Game.Solver)
                        {
                            var inputSolwer = _input.SelectSolwerGame();
                            game = _builder.GetGame(inputSolwer.Input);
                            _temporaryStorage.Clear();
                            break;
                        }
                        game = _builder.GetGame(input.Input);
                        _temporaryStorage.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }


                if (game != null)
                {
                    while (true)
                    {
                        var runResult = _oopRunner.Run(game);
                        if (runResult == GameInputOption.CallGameMenu)
                        {

                            var tmp = RunGameMenu(game);
                            if (tmp == GameMenuResult.Exit)
                            {
                                _output.ByeBye();
                                _input.PressAnyKey();

                                break;
                            }

                        }
                        else
                            break;
                    }
                    // уничтожить liveTimeScope игры
                }

            }
        }

        private GameMenuResult RunGameMenu(IOopGame game)
        {
            var tmp = _input.GetGameMenuOption();

            switch (tmp)
            {
                case GamerConsoleInput.Save.SaveAndExit:
                    var gameName = _input.GetSaveGameName();
                    var history = _temporaryStorage.GetCurrentHistory();
                    _gameLoader.Save(game, _oopRunner, history, gameName);
                    return GameMenuResult.Exit;

                case GamerConsoleInput.Save.Exit:
                    return GameMenuResult.Exit;

                case GamerConsoleInput.Save.Continue:
                    _output.ReloadGameHistory(_temporaryStorage.GetCurrentHistory());
                    return GameMenuResult.Continue;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public enum GameMenuResult
        {
            Continue, Exit, Save
        }
    }
}
