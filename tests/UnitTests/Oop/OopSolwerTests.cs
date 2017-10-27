using BullsAndCows.Oop.Solwer;
using BullsAndCows.Oop.Menu;
using NSubstitute;
using Xunit;

namespace UnitTests.Oop
{
    public class OopSolwerTests
    {
        private readonly ISolwerInput _input;
        private readonly ISolwerOutput _output;
        private readonly OopSolwer _solwer;
        private readonly OopMenu _menu;


        public OopSolwerTests()
        {
            _input = Substitute.For<ISolwerInput>();

            _output = Substitute.For<ISolwerOutput>();

            _solwer = new OopSolwer(_input, _output, _menu);
        }

        [Fact]
        public void CheckIfItGoTo10()
        {

            _input.GetEstimation().Returns(OopEstimation.More);

            _solwer.Run();

            _output.Received(1).Assumption(Arg.Any<int>());
        }


    }
}
