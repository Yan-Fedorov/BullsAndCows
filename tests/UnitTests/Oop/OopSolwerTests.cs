using BullsAndCows.Oop.Solwer;
using NSubstitute;
using Xunit;

namespace UnitTests.Oop
{
    public class OopSolwerTests
    {
        private readonly ISolwerInput _input;
        private readonly ISolwerOutput _output;
        private readonly OopSolwer _puzzle;


        public OopSolwerTests()
        {
            _input = Substitute.For<ISolwerInput>();

            _output = Substitute.For<ISolwerOutput>();

            _puzzle = new OopSolwer(_input, _output);
        }

        [Fact]
        public void CheckIfItGoTo10()
        {
            
            _input.GetEstimation().Returns(OopEstimation.More);

            _puzzle.Run();

            _output.Received(10).Assumption(Arg.Any<int>());
        }

        [Theory]
        [InlineData(999, false)]
        [InlineData(750, true)]
        public void SolwerУгадаетЧисла(int secret, bool resaultOfSeach)
        {
            int assumption = 0;

            var input = Substitute.For<ISolwerInput>();
            input.GetEstimation().Returns(x => assumption == secret
                ? OopEstimation.Equal
                : (secret > assumption ? OopEstimation.More : OopEstimation.Less));

            var output = Substitute.For<ISolwerOutput>();
            output
                .When(x => x.Assumption(Arg.Any<int>()))
                .Do(x =>
                {
                    assumption = x.Arg<int>();
                });

            var solwer = new OopSolwer(input, output);
            solwer.Run();


            output.Received().DisplayingResultOfGame(guessed: resaultOfSeach);
        }



    }
}
