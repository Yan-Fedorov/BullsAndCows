using System;
using BullsAndCows.Oop.GamerConsol;
using BullsAndCows.Oop.OopGameLoader;
using BullsAndCows.Oop.Runner;

namespace BullsAndCows.Oop.GameContext
{
    public interface IGameContext
    {
        void Run(Game? gameType, int? gameId);
    }

    public class GameContext: IGameContext
    {
        private readonly IBuilder _builder;
        private readonly IGameLoader _gameLoader;
        private readonly ITemporaryStorage _temporaryStorage;
        private readonly IOopRunner _oopRunner;
        private readonly IGameMenuOutput _output;
        private readonly IGameMenuInput _input;

        public GameContext(IBuilder builder, IGameLoader gameLoader, ITemporaryStorage temporaryStorage, IOopRunner oopRunner, IGameMenuOutput output, IGameMenuInput input)
        {
            _builder = builder;
            _gameLoader = gameLoader;
            _temporaryStorage = temporaryStorage;
            _oopRunner = oopRunner;
            _output = output;
            _input = input;
        }


        public void Run(Game? gameType, int? gameId)
        {
            var gameHistory = "";


            if (gameType.HasValue)
            {
                _builder.CreateGame(gameType.Value);
            }
            else if (gameId.HasValue)
            {
                gameHistory = _gameLoader.Load(gameId.Value);
            }
            else
                throw new ArgumentNullException("", "require one of parameters");

            _temporaryStorage.Clear(gameHistory);


            while (true)
            {
                var runResult = _oopRunner.Run();
                if (runResult == GameInputOption.CallGameMenu)
                {

                    var tmp = RunGameMenu();
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
        }


        private GameMenuResult RunGameMenu()
        {
            var tmp = _input.GetGameMenuOption();

            switch (tmp)
            {
                case GamerConsoleInput.Save.SaveAndExit:
                    var gameName = _input.GetSaveGameName();
                    var history = _temporaryStorage.GetCurrentHistory();
                    _gameLoader.Save(history, gameName);
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

        enum GameMenuResult
        {
            Continue, Exit, Save
        }
    }
}
