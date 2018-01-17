using System;
using BullsAndCows.Oop.GamerConsol;
using BullsAndCows.Oop.Runner;
using Autofac;
using BullsAndCows.Oop.GameContext;
using BullsAndCows.Oop.GameData;

namespace BullsAndCows.Oop.Menu
{
    public class OopMenu
    {
        private readonly IGamerConsoleInput _input;
        private readonly IOopRunnerOutput _output;
        private readonly IGameDataCached _gameDataCached;
        private readonly ILifetimeScope _scope;

        public OopMenu(IGamerConsoleInput input, IOopRunnerOutput output, ILifetimeScope scope, IGameDataCached gameDataCached)
        {
            _input = input;
            _output = output;
            _scope = scope;
            _gameDataCached = gameDataCached;
        }


        public void RunMainMenu()
        {
            while (true)
            {
                var input = _input.SelectGame();

                switch (input.Option)
                {
                    case GameInputOption.CallGameMenu:

                        var gamesNames = _gameDataCached.GetGameNames();
                        var savedGameKey = _input.SelectSavedGame(gamesNames);

                        if (savedGameKey.Option != GameInputOption.GameInput)
                            break;

                        RunGame(gameId: savedGameKey.Input);
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
                        RunGame(gameType: input.Input);
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }


        public void RunGame(Game? gameType = null, int? gameId = null)
        {
            using (var gameScope = _scope.BeginLifetimeScope())
            {
                gameScope.Resolve<IGameContext>().Run(gameType, gameId);
            }
        }
    }
}
