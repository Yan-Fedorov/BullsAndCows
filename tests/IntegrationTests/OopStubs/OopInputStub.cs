using System;
using System.Threading;
using BullsAndCows;
using BullsAndCows.Oop.GamerConsol;
using BullsAndCows.Oop.Runner;
using BullsAndCows.Oop.Solwer;
using System.Collections.Generic;
using BullsAndCows.Oop;
using BullsAndCows.Oop.Menu;

namespace IntegrationTests.OopStubs
{
    public class OopInputStub : IGamerConsoleInput, IDisposable
    {
        private int _number;
        private readonly AutoResetEvent _sendNumber = new AutoResetEvent(false);

        public int GetNumber()
        {
            _sendNumber.WaitOne();
            return _number;
        }

        public void SendNumber(int number)
        {
            _number = number;
            _sendNumber.Set();
        }

        public GameInput<int> SelectSavedGame(List<string> games)
        {
            return new GameInput<int> { Option = GameInputOption.GameInput, Input = 1 };
        }


        private OopEstimation _estimation;
        private readonly AutoResetEvent _sendEstimation = new AutoResetEvent(false);

        public OopEstimation GetEstimation()
        {
            _sendEstimation.WaitOne();
            return _estimation;
        }

        public void SendEstimation(OopEstimation estimation)
        {
            _estimation = estimation;
            _sendEstimation.Set();
        }


        private GameInput<Game> _game;
        private readonly AutoResetEvent _sendGame = new AutoResetEvent(false);

        public GameInput<Game> SelectGame()
        {
            _sendGame.WaitOne();
            return _game;
        }

        public void SendGame(GameInput<Game> game)
        {
            _game = game;
            _sendGame.Set();
        }


        public void PressAnyKey()
        {
        }


        public void Dispose()
        {
            _sendNumber?.Dispose();
            _sendEstimation?.Dispose();
            _sendGame?.Dispose();
        }
    }
}
