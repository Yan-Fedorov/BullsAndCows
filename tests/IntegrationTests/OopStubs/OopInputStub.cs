using System;
using System.Threading;
using BullsAndCows;
using BullsAndCows.Oop.GamerConsol;
using BullsAndCows.Oop.Runner;
using BullsAndCows.Oop.Solwer;
using System.Collections.Generic;
using BullsAndCows.Oop;
using BullsAndCows.Oop.Menu;
using BullsAndCows.Oop.Thinker;

namespace IntegrationTests.OopStubs
{
    public class OopInputStub : IGamerConsoleInput, IDisposable
    {
        private GameInput<int> _number;
        private readonly AutoResetEvent _sendNumber = new AutoResetEvent(false);

        public GameInput<int> GetNumber()
        {
            _sendNumber.WaitOne();
            return _number;
        }

        public void SendNumber(GameInput<int> number)
        {
            _number = number;
            _sendNumber.Set();
        }

        public GameInput<int> SelectSavedGame(List<string> games)
        {
            return new GameInput<int> { Option = GameInputOption.GameInput, Input = 1 };
        }


        private GameInput<OopEstimation> _estimation;
        private readonly AutoResetEvent _sendEstimation = new AutoResetEvent(false);

        public GameInput<OopEstimation> GetEstimation()
        {
            _sendEstimation.WaitOne();
            return _estimation;
        }

        public void SendEstimation(GameInput<OopEstimation> estimation)
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

        public GamerConsoleInput.Save GetGameMenuOption()
        {
            return GamerConsoleInput.Save.Exit;
        }

        string st = "Name";
        public string GetSaveGameName()
        {

            return st;
        }

        public GameInput<Game> SelectSolwerGame()
        {
            throw new NotImplementedException();
        }
    }
}
