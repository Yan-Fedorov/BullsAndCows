﻿using System;
using System.Threading;
using BullsAndCows;
using BullsAndCows.Oop.GamerConsol;
using BullsAndCows.Oop.Solwer;

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


        private Game? _game;
        private readonly AutoResetEvent _sendGame = new AutoResetEvent(false);

        public Game? SelectGame()
        {
            _sendGame.WaitOne();
            return _game;
        }

        public void SendGame(Game? game)
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
