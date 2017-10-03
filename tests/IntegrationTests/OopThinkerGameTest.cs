using System.Threading.Tasks;
using BullsAndCows;
using BullsAndCows.Oop;
using BullsAndCows.Oop.Thinker;
using IntegrationTests.OopStubs;
using Xbehave;
using Xunit;

namespace IntegrationTests
{
    public class OopThinkerGameTest
    {
        private readonly OopInputStub _input;
        private readonly OopOutputStub _output;

        public OopThinkerGameTest()
        {
            _input = new OopInputStub();
            _output = new OopOutputStub();
        }
        [Scenario]
        public void S1()
        {

            "Given game with faked console".x(() =>
            {
                Task.Run(() =>
                {
                    new Builder(_input, _output)
                        .GetRunner()
                        .Run();
                });
            });


            "Select Solwer game".x(() =>
            {
                _input.SendGame(Game.Thinker);
                _output.WaitThinkerGreating();
            });


            "Make game".x(() =>
            {
                var line = 500;
                var assumption = line;
            bool? isGuessed;
                while (true)
                {
                    _input.SendNumber(assumption);

                    isGuessed = _output.WaitShowResultThinker(100);
                    if (isGuessed.HasValue)
                        break;

                    var isAssumptionBigger = _output.WaitShowEstimationThinker();

                    line /= 2;
                    assumption = isAssumptionBigger
                    ? assumption - line
                    : assumption + line;

                }
            });

            "Exit".x(() =>
            {
                _input.SendGame(null);
                _output.WaitByeBye();
            });
        }
    }
}
