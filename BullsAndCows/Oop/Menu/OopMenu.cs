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



        public OopMenu(IGamerConsoleInput input, IOopRunnerOutput output, IGameLoader gameLoader, IBuilder builder, IOopRunner oopRunner, ITemporaryStorageSolwer temporaryStorageSolwer, ITemporaryStorage temporaryStorage)
        {
            _input = input;
            _output = output;
            _gameLoader = gameLoader;
            _builder = builder;
            _oopRunner = oopRunner;
            _temporaryStorageSolwer = temporaryStorageSolwer;
            _temporaryStorage = temporaryStorage;
        }
        public List<TemporaryStorageSolwer> solwerList = new List<TemporaryStorageSolwer>();


        public void RunMainMenu()
        {
            while (true)
            {
               
                    var input = _input.SelectGame();
                IOopGame game = null;
                
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
                            game = _builder.GetGame(input.Input);
                            _temporaryStorage.Clear();
                            break;

                        default:
                            throw new ArgumentOutOfRangeException();
                    }


                    if (game != null)
                        while (true)
                        {
                            var runResult = _oopRunner.Run(game);
                            if (runResult == GameInputOption.CallGameMenu)
                            {

                                var tmp = RunGameMenu(game);
                              if(tmp == GameMenuResult.Exit) { 
                                    _output.ByeBye();
                                    _input.PressAnyKey();
                                    
                                    break; 
                                }

                            }
                            else
                                break;
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
