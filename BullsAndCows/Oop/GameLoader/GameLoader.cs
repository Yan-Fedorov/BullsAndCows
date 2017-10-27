using System;
using System.Collections.Generic;
using System.Linq;
using BullsAndCows.Oop.Runner;
using BullsAndCows.Oop.Thinker;
using BullsAndCows.Oop.Solwer;

namespace BullsAndCows.Oop.GameLoader
{
    public interface IGameLoader
    {
        string Load(out IOopGame game, IOopRunner runner, int gameNumber);
        List<string> GetGameNames();
    }

    public class GameLoader : IGameLoader
    {
        private readonly IBuilder _builder;
        private readonly List<OopGameData> _games = new List<OopGameData>
        {
            new OopThinkerData {Iteration = 4, Number = 300, GameScreen = @"
Тут данные итерации
"},
            new OopSolwerData {Iteration = 2, Assumption = 750, Line = 250, GameScreen = @"
Вы загадали 500 ?

 1 - да
 2 - моё число меньше
 3 - моё число больше
Укажите соответствующий вариант: 3
"}
        };


        public GameLoader(IBuilder builder)
        {
            _builder = builder;
        }


        public string Load(out IOopGame game, IOopRunner runner, int gameNumber)
        {
            var gameData = _games[gameNumber - 1];
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

        public List<string> GetGameNames()
        {
            return _games
                .Select(x => x.GetName())
                .ToList();
        }
    }
}
