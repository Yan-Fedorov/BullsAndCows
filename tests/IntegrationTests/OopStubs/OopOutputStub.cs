using System;
using System.Threading;
using BullsAndCows.Oop.GamerConsol;

namespace IntegrationTests.OopStubs
{
    public class OopOutputStub : IGamerConsoleOutput, IDisposable
    {
        private int TimeoutMs => System.Diagnostics.Debugger.IsAttached ? int.MaxValue : 500;

        private readonly AutoResetEvent _receiveThinkerGreating = new AutoResetEvent(false);

        public void ThinkerGreating()
        {
            _receiveThinkerGreating.Set();
        }

        public void WaitThinkerGreating()
        {
            if (!_receiveThinkerGreating.WaitOne(TimeoutMs))
                throw new Exception($"{nameof(WaitSolwerGreating)} timeout");
        }
        
        private int _assumptionThinker;
        private bool _isAssumptionBiggerThinker;

        private readonly AutoResetEvent _receiveAssumptionThinker = new AutoResetEvent(false);

        public void ShowEstimationThinker(int assumption, bool isAssumptionBigger)
        {
            _assumptionThinker = assumption;
            _isAssumptionBiggerThinker = isAssumptionBigger;
            _receiveAssumptionThinker.Set();
        }

        public bool WaitShowEstimationThinker()
        {
            if (!_receiveAssumptionThinker.WaitOne(TimeoutMs))
                throw new Exception($"{nameof(WaitShowEstimationThinker)} timeout");

            return _isAssumptionBiggerThinker;
        }

        private int _number;
        private bool _isGuessed;

        private readonly AutoResetEvent _receiveShowResultThinker = new AutoResetEvent(false);

        public void ShowResultThinker(int number, bool isGuessed)
        {
            _number = number;
            _isGuessed = isGuessed;
            _receiveShowResultThinker.Set();
           

        }

        public bool? WaitShowResultThinker(int timeout)
        {
            return _receiveShowResultThinker.WaitOne(timeout)
                ? (bool?)_isGuessed : null;
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



        private int _assumptionSolwer;
        private readonly AutoResetEvent _receiveAssumptionSolwer = new AutoResetEvent(false);

        public void Assumption(int assumption)
        {
            _assumptionSolwer = assumption;
            _receiveAssumptionSolwer.Set();
        }

        public int WaitAssumption()
        {
            if (!_receiveAssumptionSolwer.WaitOne(TimeoutMs))
                throw new Exception($"{nameof(WaitAssumption)} timeout");

            return _assumptionSolwer;
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
            _receiveAssumptionSolwer?.Dispose();
            _receiveGuessed?.Dispose();
            _receiveByeBye?.Dispose();

            _receiveThinkerGreating.Dispose();
            _receiveAssumptionThinker.Dispose();
            _receiveShowResultThinker.Dispose();
        }
    }
}
