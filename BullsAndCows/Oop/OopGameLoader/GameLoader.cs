using System;
using BullsAndCows.Oop.ActiveGame;
using BullsAndCows.Oop.Runner;
using BullsAndCows.Oop.Thinker;
using BullsAndCows.Oop.Solwer;
using BullsAndCows.Oop.GameData;



namespace BullsAndCows.Oop.OopGameLoader
{
    public interface IGameLoader
    {
        string Load(int gameNumber);
        void Save(string gameHistory, string gameName);
    }

    public class GameLoader : IGameLoader
    {
        private readonly Lazy<IBuilder> _builder;
        private readonly IGameDataCached _dataCached;
        private readonly IActiveGameStore _activeGameStore;        
        private readonly IOopRunner _oopRunner;
        private readonly IActiveGameProvider _activeGameProvider;


        public GameLoader(Lazy<IBuilder> builder, IGameDataCached dataCached, IActiveGameStore activeGameStore, IOopRunner oopRunner, IActiveGameProvider activeGameProvider)
        {
            _builder = builder;
            _dataCached = dataCached;
            _activeGameStore = activeGameStore;
            _oopRunner = oopRunner;
            _activeGameProvider = activeGameProvider;
        }


   

        public string Load(int gameNumber)
        {
            var gameData = _dataCached.Get(gameNumber - 1);
            IOopGame game;
            
            switch (gameData)
            {
                case OopThinkerData thinkerData:
                    var thinker = (game = _builder.Value.CreateGame(Game.Thinker)) as OopThinker; // _scope.Resolve<OopThinker>();
                    thinker.Number = thinkerData.Number;
                    break;

                case OopSolwerData solwerData:
                    var solwer = (game = _builder.Value.CreateGame(Game.Solver)) as OopSolwer;
                    solwer.Assumption = solwerData.Assumption;
                    solwer.Line = solwerData.Line;
                    break;

                default:
                    throw new Exception($"Unnoun game data {gameData.GetType().Name}");
            }

            _oopRunner.Iteration = gameData.Iteration;
            _activeGameStore.StoreGame(game);

            return gameData.GameScreen;
        }
        


        public void Save(string gameHistory, string gameName)
        {
            OopGameData gameData;
            var game = _activeGameProvider.GetGame();

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

            gameData.Iteration = _oopRunner.Iteration - 1;

            gameData.GameScreen = gameHistory;
            gameData.GameName = gameName;
            gameData.GameType = tp;

            _dataCached.Save(gameData);
        }
    }
}
