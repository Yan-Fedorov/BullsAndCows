using BullsAndCows.Oop.Runner;
using NSubstitute;
using Xunit;
using BullsAndCows.Oop.GameLoader;
using BullsAndCows.Oop;
using BullsAndCows.Oop.GamerConsol;
using BullsAndCows;
using BullsAndCows.Oop.Thinker;
using System.Linq;

namespace UnitTests.Oop
{
    public class OopRunnerTests
    {
        private readonly IGamerConsoleInput _input;
        private readonly IGamerConsoleOutput _output;
        

        public OopRunnerTests()
        {
            _input = Substitute.For<IGamerConsoleInput>();

            _output = Substitute.For<IGamerConsoleOutput>();
            

            
        }
        [Fact]
        public void CheckIfRunnerRun10Times()
        {
            var input = Substitute.For<IGamerConsoleInput>();
            var game = Substitute.For<IOopGame>();
            var runner = new OopRunner(input);


            runner.Run(game);


            game.Received(10).Run();
            game.Received(1).ShowResult(false);
        }
        [Fact]
        public void CheckIsHasWin()
        {
            var input = Substitute.For<IGamerConsoleInput>();
            var game = Substitute.For<IOopGame>();
            var runner = new OopRunner(input);

            game.Run().Returns(true);
            runner.Run(game);
            game.Received(1).Run();
            game.Received(1).ShowResult(true);
        }

        
        [Theory]
        [InlineData (0)]
        [InlineData(4)]
        [InlineData(9)]
        [InlineData(10)]
        public void CheckIfCanWinLast(int iterations)
        {
            var input = Substitute.For<IGamerConsoleInput>();
            var game = Substitute.For<IOopGame>();
            var runner = new OopRunner(input);

            runner.Iteration = iterations;
            game.Run().Returns(true);
            runner.Run(game);
            

            game.Received(1).Run();
            game.Received(1).ShowResult(true);
        }


        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false, false, true)]
        [InlineData(true, false, false, false, false, false, false, false, false, false, true)]
        [InlineData(false, false, false, false, false, false, false, false, false, false, false)]
        [InlineData(false, false, false, false, false, false, false, false, false, false, false, true)]
        [InlineData(false, false, false, false, false, false, false, false, false, false, false, false)]
        public void CheckIfCanWinLast2(bool isWon, params bool[] returns)
        {
            var input = Substitute.For<IGamerConsoleInput>();
            var game = Substitute.For<IOopGame>();
            var runner = new OopRunner(input);

            game.Run().Returns(returns.First(), returns.Skip(1).ToArray());
            runner.Run(game);


            game.Received(returns.Length < 10 ? returns.Length : 10).Run();
            game.Received(1).ShowResult(isWon);
        }
    }
}
