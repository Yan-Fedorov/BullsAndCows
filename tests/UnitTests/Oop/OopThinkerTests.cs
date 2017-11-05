using BullsAndCows.Oop.Thinker;
using NSubstitute;
using Xunit;
using BullsAndCows.Oop.Runner;

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
            var number = 100;

            _input.GetNumber().Returns(new GameInput<int> { Option = GameInputOption.GameInput, Input = number });
            _thinker.Number = number;
            


            _thinker.Run();
            _thinker.ShowResult(true);


            _output.DidNotReceiveWithAnyArgs().ShowEstimationThinker(Arg.Any<int>(), Arg.Any<bool>());
            _output.Received(1).ShowResultThinker(number, true);
            
        }
    }
}
