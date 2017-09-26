using System;
using BullsAndCows.Oop.GamerConsol;
using BullsAndCows.Oop.Runner;
using BullsAndCows.Oop.Solwer;
using BullsAndCows.Oop.Thinker;

namespace BullsAndCows.Oop
{
    public interface IBuilder
    {
        OopRunner GetRunner();
        IGame GetGame(Game gameKey);
    }

    public class Builder: IBuilder
    {
        private readonly GamerConsoleInput _consoleInput = new GamerConsoleInput();
        private readonly GamerConsoleOutput _consoleOutput = new GamerConsoleOutput();


        public OopRunner GetRunner()
        {
            return new OopRunner(this, _consoleInput, _consoleOutput);
        }

        public IGame GetGame(Game gameKey)
        {
            switch (gameKey)
            {
                case Game.Solver:
                    return new OopSolwer(_consoleInput, _consoleOutput);

                case Game.Puzzle:
                    return new OopThinker(_consoleInput, _consoleOutput);

                default:
                    throw new ArgumentOutOfRangeException(nameof(gameKey), gameKey, null);
            }
        }
    }
}
