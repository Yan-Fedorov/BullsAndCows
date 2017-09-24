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
            
            _input.GetEstimation().Returns((OopEstimation)2);

            _puzzle.Run();

            _output.Received(10).Assumption(Arg.Any<int>());
        }

        // public void ItCanFindNumber()
        //{
        //    int checkValue = 300;
        //    _input.GetEstimation().Returns(if(checkValue ==a );
        //    _output.Received(10);
        //}
        public void Demo()
        {
            int assumption = 0;

            var input = Substitute.For<ISolwerInput>();
            input.GetEstimation().Returns(x => assumption == 500
                ? OopEstimation.Equal
                : OopEstimation.Less);

            var output = Substitute.For<ISolwerOutput>();
            output
                .When(x => x.Assumption(Arg.Any<int>()))
                .Do(x =>
                {
                    assumption = x.Arg<int>();
                });
        }


    }
}
