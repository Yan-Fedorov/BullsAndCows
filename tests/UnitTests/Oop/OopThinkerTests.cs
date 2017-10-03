using BullsAndCows.Oop.Thinker;
using NSubstitute;
using Xunit;

namespace UnitTests.Oop
{
    public class OopPuzzleTests
    {
        private readonly IThinkerInput _input;
        private readonly IThinkerOutput _output;
        private readonly OopThinker _thinker;

        public OopPuzzleTests()
        {
            _input = Substitute.For<IThinkerInput>();

            _output = Substitute.For<IThinkerOutput>();

            _thinker = new OopThinker(_input, _output);

        }

        [Fact]
        public void ДолжелОповещатьОпроигрышеНа10йПопытке()
        {
            _input.GetNumber().Returns(-1);


            _thinker.Run();


            _output.Received(10).ShowEstimationThinker(Arg.Any<int>(), false);
            _output.Received(1).ShowResultThinker(Arg.Any<int>(), false);
        }

        //[Fact]
        public void ЯМогуВыигратьСПервойПопытки()
        {
            _input.GetNumber().Returns(100);


            _thinker.Run();


            _output.DidNotReceiveWithAnyArgs().ShowEstimationThinker(Arg.Any<int>(), Arg.Any<bool>());
            _output.Received(1).ShowResultThinker(Arg.Any<int>(), true);
        }
    }
}
