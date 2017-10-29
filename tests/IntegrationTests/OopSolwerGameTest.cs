using System.Threading.Tasks;
using BullsAndCows;
using BullsAndCows.Oop;
using BullsAndCows.Oop.Runner;
using BullsAndCows.Oop.Solwer;
using IntegrationTests.OopStubs;
using Xbehave;
using Xunit;
using NSubstitute;

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
        [Example(999, false)]
        [Example(750, true)]
        public void S1(int number, bool isWon)
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


            "Select Solwer game".x(() =>
            {
                _input.SendGame(new GameInput<Game> { Input = Game.Solver, Option = GameInputOption.GameInput });
                _output.WaitSolwerGreating();
            });


            "Make game".x(() =>
            {
                int i = 0;

                while (true)
                {
                    var assumption = 0;
                    i++;
                    if (i > 10)
                        break;

                    assumption = _output.WaitAssumption();

                    var estimation = assumption == number
                        ? OopEstimation.Equal
                        : (assumption < number
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
                Assert.Equal(isWon, isGuessed);
            });

            "Exit".x(() =>
            {
                _input.SendGame(new GameInput<Game> { Option = GameInputOption.Exit });
                _output.WaitByeBye();
            });
        }
    }
}
