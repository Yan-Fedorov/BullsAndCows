using BullsAndCows.Oop.Thinker;
using NSubstitute;
using Xunit;

namespace UnitTests.Oop
{
    public class OopPuzzleTests
    {
        private readonly IThinkerInput _input;
        private readonly IThinkerOutput _output;
        private readonly OopPuzzle _puzzle;

        public OopPuzzleTests()
        {
            _input = Substitute.For<IThinkerInput>();

            _output = Substitute.For<IThinkerOutput>();

            _puzzle = new OopPuzzle(_input, _output);

        }

        [Fact]
        public void ДолжелОповещатьОпроигрышеНа10йПопытке()
        {
            _input.GetNumber().Returns(-1);


            _puzzle.Run();


            _output.Received(10).ShowEstimation(Arg.Any<int>(), false);
            _output.Received(1).ShowResult(Arg.Any<int>(), false);
        }

        //[Fact]
        public void ЯМогуВыигратьСПервойПопытки()
        {
            _input.GetNumber().Returns(100);


            _puzzle.Run();


            _output.DidNotReceiveWithAnyArgs().ShowEstimation(Arg.Any<int>(), Arg.Any<bool>());
            _output.Received(1).ShowResult(Arg.Any<int>(), true);
        }
    }
}
