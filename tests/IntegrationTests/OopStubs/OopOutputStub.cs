using System;
using System.Threading;
using BullsAndCows.Oop.GamerConsol;

namespace IntegrationTests.OopStubs
{
    public class OopOutputStub : IGamerConsoleOutput, IDisposable
    {
        private const int TimeoutMs = 500;


        public void PuzzleGreating()
        {
            throw new NotImplementedException();
        }

        public void ShowEstimation(int assumption, bool isAssumptionBigger)
        {
            throw new NotImplementedException();
        }

        public void ShowResult(int number, bool isGuessed)
        {
            throw new NotImplementedException();
        }



        private readonly AutoResetEvent _receiveSolwerGreating = new AutoResetEvent(false);

        public void SolwerGreating()
        {
            _receiveSolwerGreating.Set();
        }

        public void WaitSolwerGreating()
        {
            if(!_receiveSolwerGreating.WaitOne(TimeoutMs))
                throw new Exception($"{nameof(WaitSolwerGreating)} timeout");
        }



        private int _assumption;
        private readonly AutoResetEvent _receiveAssumption = new AutoResetEvent(false);

        public void Assumption(int assumption)
        {
            _assumption = assumption;
            _receiveAssumption.Set();
        }

        public int WaitAssumption()
        {
            if (!_receiveAssumption.WaitOne(TimeoutMs))
                throw new Exception($"{nameof(WaitAssumption)} timeout");

            return _assumption;
        }



        private bool _thinkerIsGuessed;
        private readonly AutoResetEvent _receiveGuessed = new AutoResetEvent(false);

        public void DisplayingResultOfGame(bool guessed)
        {
            _thinkerIsGuessed = guessed;
            _receiveGuessed.Set();
        }

        public bool WaitGuessed()
        {
            if (!_receiveGuessed.WaitOne(TimeoutMs))
                throw new Exception($"{nameof(WaitGuessed)} timeout");

            return _thinkerIsGuessed;
        }



        private readonly AutoResetEvent _receiveByeBye = new AutoResetEvent(false);

        public void ByeBye()
        {
            _receiveByeBye.Set();
        }

        public void WaitByeBye()
        {
            if(!_receiveByeBye.WaitOne(TimeoutMs))
                throw new Exception($"{nameof(WaitByeBye)} timeout");
        }



        public void Dispose()
        {
            _receiveSolwerGreating?.Dispose();
            _receiveAssumption?.Dispose();
            _receiveGuessed?.Dispose();
            _receiveByeBye?.Dispose();
        }
    }
}
