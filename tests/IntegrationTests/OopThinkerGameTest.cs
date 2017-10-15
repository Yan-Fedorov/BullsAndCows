using System.Threading.Tasks;
using BullsAndCows;
using BullsAndCows.Oop;
using BullsAndCows.Oop.Runner;
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
                        .GetMenu()
                        .RunMainMenu();
                });
            });


            "Select Thinker game".x(() =>
            {
                _input.SendGame(new GameInput<Game>{Input =Game.Thinker, Option = GameInputOption.GameInput});
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

                    var isAssumptionBigger = _output.WaitShowEstimationThinker();
                    if(isAssumptionBigger == null)
                        break;

                    line /= 2;
                    assumption = isAssumptionBigger == true
                        ? assumption - line
                        : assumption + line;

                }


                isGuessed = _output.WaitShowResultThinker();
            });

            "Exit".x(() =>
            {
                _input.SendGame(new GameInput<Game> { Option = GameInputOption.Exit });
                _output.WaitByeBye();
            });
        }

        [Scenario]
        public void ContinueLoadedGame()
        {
            "Given game with faked console".x(() =>
            {
                Task.Run(() =>
                {
                    new Builder(_input, _output)
                        .GetMenu()
                        .RunMainMenu();
                });
            });


            "Load thinker game".x(() =>
            {
                _input.SendGame(new GameInput<Game> { Option = GameInputOption.CallGameMenu });
                _output.WaitThinkerGreating();
            });


            "Make game".x(() =>
            {
                _input.SendNumber(100);            
                // ReSharper disable once PossibleInvalidOperationException
                Assert.False(_output.WaitShowEstimationThinker().Value);


                _input.SendNumber(300);
                // ReSharper disable once PossibleInvalidOperationException
                Assert.True(_output.WaitShowEstimationThinker().Value);



                _input.SendNumber(200);
                Assert.Null(_output.WaitShowEstimationThinker());
                Assert.True(_output.WaitShowResultThinker());
            });

            "Exit".x(() =>
            {
                _input.SendGame(new GameInput<Game> { Option = GameInputOption.Exit });
                _output.WaitByeBye();
            });

        }
    }
}
