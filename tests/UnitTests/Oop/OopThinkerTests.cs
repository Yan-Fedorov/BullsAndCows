using BullsAndCows.Oop.Thinker;
using NSubstitute;
using Xunit;

namespace UnitTests.Oop
{
    public class OopThinkerTests
    {
        private readonly IThinkerInput _input;
        private readonly IThinkerOutput _output;
        private readonly OopThinker _thinker;

        public OopThinkerTests()
        {
            _input = Substitute.For<IThinkerInput>();

            _output = Substitute.For<IThinkerOutput>();

            _thinker = new OopThinker(_input, _output);

        }


        [Fact]
        public void ЯМогуВыигратьСПервойПопытки()
        {
            _input.GetNumber().Returns(100);


            _thinker.Run();


            _output.DidNotReceiveWithAnyArgs().ShowEstimationThinker(Arg.Any<int>(), Arg.Any<bool>());
            _output.Received(1).ShowResultThinker(Arg.Any<int>(), true);
        }
    }
}
