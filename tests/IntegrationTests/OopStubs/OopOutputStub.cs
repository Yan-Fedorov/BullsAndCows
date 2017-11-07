using System;
using System.Threading;
using BullsAndCows.Oop.GamerConsol;
using BullsAndCows.Oop.Runner;

namespace IntegrationTests.OopStubs
{
    public class OopOutputStub : IGamerConsoleOutput, IDisposable
    {
        private int TimeoutMs => System.Diagnostics.Debugger.IsAttached ? int.MaxValue : 500;

        private readonly AutoResetEvent _receiveThinkerGreating = new AutoResetEvent(false);

        public void ThinkerGreating()
        {
            _isGuessed = null;
            _receiveThinkerGreating.Set();
        }

        public void WaitThinkerGreating()
        {
            if (!_receiveThinkerGreating.WaitOne(TimeoutMs))
                throw new Exception($"{nameof(WaitThinkerGreating)} timeout");
        }
        


        private bool? _isAssumptionBiggerThinker;
        private bool _isWaitThinkerEstimation;

        private readonly AutoResetEvent _receiveAssumptionThinker = new AutoResetEvent(false);

        public void ShowEstimationThinker(int assumption, bool isAssumptionBigger)
        {
            _isAssumptionBiggerThinker = isAssumptionBigger;
            _receiveAssumptionThinker.Set();
        }

        public bool? WaitShowEstimationThinker()
        {
            lock (_receiveShowResultThinker)
            {
                if (_isGuessed.HasValue)
                    return null;


                _isWaitThinkerEstimation = true;
            }

            if (!_receiveAssumptionThinker.WaitOne(TimeoutMs))
                    throw new Exception($"{nameof(WaitShowEstimationThinker)} timeout");            

            _isWaitThinkerEstimation = false;
            return _isAssumptionBiggerThinker;
        }



        private bool? _isGuessed;

        private readonly AutoResetEvent _receiveShowResultThinker = new AutoResetEvent(false);

        public void ShowResultThinker(int number, bool isGuessed)
        {
            lock (_receiveShowResultThinker)
            {
                _isGuessed = isGuessed;

                if (_isWaitThinkerEstimation)
                {
                    _isAssumptionBiggerThinker = null;
                    _receiveAssumptionThinker.Set();
                }

                _receiveShowResultThinker.Set();
            }
        }

        public bool? WaitShowResultThinker()
        {
            if(!_receiveShowResultThinker.WaitOne(TimeoutMs))
                throw new Exception($"{nameof(WaitShowResultThinker)} timeout");

            return _isGuessed;
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

        private string _history;
        private readonly AutoResetEvent _receiveReload = new AutoResetEvent(false);
        public string WaitReloadGameHistory()
        {
            if (!_receiveReload.WaitOne(TimeoutMs))
                throw new Exception($"{nameof(WaitReloadGameHistory)} timeout");

            return _history;
        }

        public void ReloadGameHistory(string history)
        {
            _history = history;
            _receiveReload.Set();
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
