using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BullsAndCows.Oop.OopGameLoader;
using BullsAndCows.Oop.GamerConsol;
using BullsAndCows.Oop.Runner;
using BullsAndCows.Oop.Solwer;
using BullsAndCows.Oop.Thinker;
using Autofac;
using BullsAndCows.Oop.ActiveGame;

namespace BullsAndCows.Oop.Menu
{
    public class OopMenu
    {
        private readonly IGamerConsoleInput _input;
        private readonly IOopRunnerOutput _output;

        private readonly ActiveGameService _activeGame;
        private readonly ILifetimeScope _scope;



        public OopMenu(IGamerConsoleInput input, IOopRunnerOutput output, ILifetimeScope scope)
        {
            _input = input;
            _output = output;
            
            _scope = scope;
        }


        public void RunMainMenu()
        {
            while (true)
                using (var gameScope = _scope.BeginLifetimeScope())
                {

                    var input = _input.SelectGame();
                    IOopGame game = null;
                    // создать LiveTimeScope для игры. Дальше все зависимости будем получать из него
                    //var gameLoader = gameScope.Resolve<GameLoader>();
                    //var temporaryStorage = gameScope.Resolve<TemporaryStorage>();
                    //var oopRunner = gameScope.Resolve<OopRunner>();
                    switch (input.Option)
                    {
                        case GameInputOption.CallGameMenu:
                            
                            var gamesNames = _activeGame.GetLoader().GetGameNames();
                            var savedGameKey = _input.SelectSavedGame(gamesNames);

                            if (savedGameKey.Option != GameInputOption.GameInput)
                                break;

                            var gameHistory = _activeGame.GetLoader().Load(out game, _activeGame.GetRunner(), savedGameKey.Input);
                            _output.ReloadGameHistory(gameHistory);
                            _activeGame.GetStorage().Clear(gameHistory);
                            break;

                        case GameInputOption.Exit:
                            _output.ByeBye();
                            _input.PressAnyKey();
                            return;

                        case GameInputOption.GameInput:
                            if (input.Input == Game.Solver)
                            {
                                input = _input.SelectSolwerGame();
                            }
                            game = gameScope.Resolve<IBuilder>().GetGame(input.Input);
                            _activeGame.GetStorage().Clear();
                            break;

                        default:
                            throw new ArgumentOutOfRangeException();
                    }


                    if (game != null)
                    {
                        while (true)
                        {
                            var runResult = _activeGame.GetRunner().Run(game);
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
                    var history = _activeGame.GetStorage().GetCurrentHistory();
                    _activeGame.GetLoader().Save(game, _activeGame.GetRunner(), history, gameName);
                    return GameMenuResult.Exit;

                case GamerConsoleInput.Save.Exit:
                    return GameMenuResult.Exit;

                case GamerConsoleInput.Save.Continue:
                    _output.ReloadGameHistory(_activeGame.GetStorage().GetCurrentHistory());
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
