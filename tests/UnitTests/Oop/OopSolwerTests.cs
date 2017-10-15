using BullsAndCows.Oop.Solwer;
using NSubstitute;
using Xunit;

namespace UnitTests.Oop
{
    public class OopSolwerTests
    {
        private readonly ISolwerInput _input;
        private readonly ISolwerOutput _output;
        private readonly OopSolwer _solwer;


        public OopSolwerTests()
        {
            _input = Substitute.For<ISolwerInput>();

            _output = Substitute.For<ISolwerOutput>();

            _solwer = new OopSolwer(_input, _output);
        }

        [Fact]
        public void CheckIfItGoTo10()
        {

            _input.GetEstimation().Returns(OopEstimation.More);

            _solwer.Run();

            _output.Received(1).Assumption(Arg.Any<int>());
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
            var guessed = false;
            for (int i = 0; i < 10 && !guessed; i++)
            {
                guessed = solwer.Run();
            }

            Assert.Equal(resaultOfSeach, guessed);
        }
    }
}
