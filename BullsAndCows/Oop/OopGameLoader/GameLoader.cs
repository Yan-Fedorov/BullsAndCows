using System;
using System.Collections.Generic;
using System.Linq;
using BullsAndCows.Oop.Runner;
using BullsAndCows.Oop.Thinker;
using BullsAndCows.Oop.Solwer;
using BullsAndCows.Oop.GameData;



namespace BullsAndCows.Oop.OopGameLoader
{
    public interface IGameLoader
    {
        string Load(out IOopGame game, IOopRunner runner, int gameNumber);
        List<string> GetGameNames();
        void Save(IOopGame game, IOopRunner runner, string gameHistory, string gameName);
    }

    public class GameLoader : IGameLoader
    {
        private readonly Lazy<IBuilder> _builder;
        private readonly IGameDataService _dataService;

        private Lazy<List<OopGameData>> _games;

        public GameLoader(Lazy<IBuilder> builder, IGameDataService dataService)
        {
            _builder = builder;
            _dataService = dataService;
            _games = new Lazy<List<OopGameData>>(_dataService.LoadDatas);
        }


   

        public string Load(out IOopGame game, IOopRunner runner, int gameNumber)
        {
            
            var gameData = _games.Value[gameNumber - 1];
            switch (gameData)
            {
                case OopThinkerData thinkerData:
                    var thinker = (game = _builder.Value.GetGame(Game.Thinker)) as OopThinker; // _scope.Resolve<OopThinker>();
                    thinker.Number = thinkerData.Number;
                    break;

                case OopSolwerData solwerData:
                    var solwer = (game = _builder.Value.GetGame(Game.Solver)) as OopSolwer;
                    solwer.Assumption = solwerData.Assumption;
                    solwer.Line = solwerData.Line;
                    break;

                default:
                    throw new Exception($"Unnoun game data {gameData.GetType().Name}");
            }

            runner.Iteration = gameData.Iteration;
            return gameData.GameScreen;
        }
        

        public List<string> GetGameNames()
        {
            return _games.Value
                .Select(x => x.GetName())
                .ToList();
        }


        public void Save(IOopGame game, IOopRunner runner, string gameHistory, string gameName)
        {
            OopGameData gameData;

            switch (game)
            {
                case OopThinker thinker:
                    gameData = new OopThinkerData
                    {
                        Number = thinker.Number


                    };
                    break;

                case OopSolwer solwer:
                    gameData = new OopSolwerData
                    {
                        Assumption = solwer.Assumption,
                        Line = solwer.Line
                    };
                    break;

                default:
                    throw new ArgumentException("unnoun type: " + game.GetType().Name);
            }
            var tp = gameData.GetType().ToString();
            gameData.Iteration = runner.Iteration - 1;
            gameData.GameScreen = gameHistory;
            gameData.GameName = gameName;
            gameData.GameType = tp;

            _dataService.Save(gameData);
            _games = new Lazy<List<OopGameData>>(_dataService.LoadDatas);
        }
    }
}
