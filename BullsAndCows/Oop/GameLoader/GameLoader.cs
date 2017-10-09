using System;
using BullsAndCows.Oop.Thinker;

namespace BullsAndCows.Oop.GameLoader
{
    public interface IGameLoader
    {
        void Load(IGame game, object data);
    }

    public class GameLoader : IGameLoader
    {
        public void Load(IGame game, object data)
        {
            switch (game)
            {
                case OopThinker thinker:
                    var thinkerData = data as OopThinkerData;
                    if (thinkerData == null)
                        throw new Exception("Bad thinker data");

                    thinker.Iteration = thinkerData.Iteration;
                    thinker.Number = thinkerData.Number;
                    break;

                default:
                    throw new Exception($"Unnoun game {game.GetType().Name}");
            }
        }
    }
}
