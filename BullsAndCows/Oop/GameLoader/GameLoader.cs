using System;
using BullsAndCows.Oop.Thinker;
using BullsAndCows.Oop.Solwer;

namespace BullsAndCows.Oop.GameLoader
{
    public interface IGameLoader
    {
        void Load(IOopGame game, object data);
    }

    public class GameLoader : IGameLoader
    {
        public void Load(IOopGame game, object data)
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
                case OopSolwer solwer:
                    var solwerData = data as OopSolwerData;
                    if(solwerData == null)
                        throw new Exception("Bad solwer data");
                    solwer.Iteration = solwerData.Iteration;
                    solwer.Assumption = solwerData.Assumption;
                    solwer.Line = solwerData.Line;
                    break;

                default:
                    throw new Exception($"Unnoun game {game.GetType().Name}");
            }
        }
    }
}
