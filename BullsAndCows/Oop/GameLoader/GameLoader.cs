using System;
using System.Collections.Generic;
using System.Linq;
using BullsAndCows.Oop.Runner;
using BullsAndCows.Oop.Thinker;
using BullsAndCows.Oop.Solwer;
using BullsAndCows.Oop.GameData;



namespace BullsAndCows.Oop.GameLoader
{
    public interface IGameLoader
    {
        string Load(out IOopGame game, IOopRunner runner, int gameNumber);
        List<string> GetGameNames();
        void Save(IOopGame game, IOopRunner runner, string gameHistory, string gameName);
    }

    public class GameLoader : IGameLoader
    {
        private readonly IBuilder _builder;
        private readonly IGameDataService _dataService;

        private Lazy<List<OopGameData>> _games;

        // private readonly List<OopGameData> _games = new List<OopGameData>() {  new OopGameData()}; // этот список нужно загружать из файла
        //        {
        //            new OopThinkerData {Iteration = 4, Number = 300, GameScreen = @"
        //Тут данные итерации
        //"},
        //            new OopSolwerData {Iteration = 2, Assumption = 750, Line = 250, GameScreen = @"
        //Загадайте 3-х значное число и нажмите любую клавишу

        //Вы загадали 500 ?

        // 1 - да
        // 2 - моё число меньше
        // 3 - моё число больше
        //Укажите соответствующий вариант: 3
        //"}
        //        };


        public GameLoader(IBuilder builder, IGameDataService dataService)
        {
            _builder = builder;
            _dataService = dataService;
            _games = new Lazy<List<OopGameData>>(_dataService.LoadDatas);
        }


        // GameDataService DATASERVICE = new GameDataService();

        public string Load(out IOopGame game, IOopRunner runner, int gameNumber)
        {
            var gameData = _games.Value[gameNumber - 1]; // загрузка не работает из за нуля + в консоль инпуте метод определения выбранной игры не пашет
            switch (gameData)
            {
                case OopThinkerData thinkerData:
                    var thinker = (game = _builder.GetGame(Game.Thinker)) as OopThinker;
                    thinker.Number = thinkerData.Number;
                    break;

                case OopSolwerData solwerData:
                    var solwer = (game = _builder.GetGame(Game.Solver)) as OopSolwer;
                    solwer.Assumption = solwerData.Assumption;
                    solwer.Line = solwerData.Line;
                    break;

                default:
                    throw new Exception($"Unnoun game data {gameData.GetType().Name}");
            }

            runner.Iteration = gameData.Iteration;
            return gameData.GameScreen;
        }
        // почему при обьявлении списка в конструкторе его не видно

        public List<string> GetGameNames()
        {
            return _games.Value
                .Select(x => x.GetName())
                .ToList();
        }


        public void Save(IOopGame game, IOopRunner runner, string gameHistory, string gameName)
        {
            OopGameData gameData;
            //GameDataService DATASERVICE = new GameDataService();

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
            gameData.Iteration = runner.Iteration;
            gameData.GameScreen = gameHistory;
            gameData.GameName = gameName;
            gameData.GameType = tp;

            _dataService.Save(gameData);
            _games = new Lazy<List<OopGameData>>(_dataService.LoadDatas);
        }
    }
}
