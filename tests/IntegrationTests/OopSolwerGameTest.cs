using System.Threading.Tasks;
using BullsAndCows;
using BullsAndCows.Oop;
using BullsAndCows.Oop.Runner;
using BullsAndCows.Oop.Solwer;
using IntegrationTests.OopStubs;
using Xbehave;
using Xunit;

namespace IntegrationTests
{
    public class OopSolwerGameTest
    {
        private readonly OopInputStub _input;
        private readonly OopOutputStub _output;

        public OopSolwerGameTest()
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
                _input.SendGame(new GameInput<Game>{Input = Game.Solver, Option = GameInputOption.GameInput});
                _output.WaitSolwerGreating();
            });


            "Make game".x(() =>
            {
                while (true)
                {
                    var assumption = _output.WaitAssumption();
                    var estimation = assumption == 320
                        ? OopEstimation.Equal
                        : (assumption < 320
                            ? OopEstimation.More
                            : OopEstimation.Less);

                    _input.SendEstimation(estimation);

                    if (estimation == OopEstimation.Equal)
                        break;
                }
            });


            "Werify result".x(() =>
            {
                var isGuessed = _output.WaitGuessed();
                Assert.Equal(true, isGuessed);
            });

            "Exit".x(() =>
            {
                _input.SendGame(new GameInput<Game>{Option = GameInputOption.Exit});
                _output.WaitByeBye();
            });
        }
    }
}
