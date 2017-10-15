using BullsAndCows.Oop.Runner;
using NSubstitute;
using Xunit;
using BullsAndCows.Oop.GameLoader;
using BullsAndCows.Oop;
using BullsAndCows.Oop.GamerConsol;
using BullsAndCows;
using BullsAndCows.Oop.Thinker;





namespace UnitTests.Oop
{
    public class OopRunnerTests
    {
        private readonly IGamerConsoleInput _input;
        private readonly IGamerConsoleOutput _output;
        private readonly IOopGame _game;

        public OopRunnerTests()
        {
            _input = Substitute.For<IGamerConsoleInput>();

            _output = Substitute.For<IGamerConsoleOutput>();

           // _game = new OopGame(_input, _output);  
           // IOopGame _game = 
        }
        [Fact]
        public void CheckIfRunnerRun10Times()
        {
            var input = Substitute.For<IGamerConsoleInput>();
            var builder = Substitute.For<IBuilder>();
            var game = Substitute.For<IOopGame>();
            var output = Substitute.For<IOopRunnerOutput>();
            var runner = new OopRunner(builder, input, output, null);

            input.SelectGame()
                .ReturnsForAnyArgs(
                new GameInput<Game>() { Option = GameInputOption.GameInput },
                new GameInput<Game>() { Option = GameInputOption.Exit });
            builder.GetGame(Game.Solver).ReturnsForAnyArgs(game);

            runner.Run();

            game.Received(10).Run();
            game.Received(1).ShowResult(false);
        }
        //private readonly IGamerConsoleInput _input;
        //private readonly IGamerConsoleOutput _outputC;
        //private readonly IOopRunnerOutput _output;
        //private readonly OopRunner _runner;
        //private readonly IGameLoader _gameLoader;
        //private readonly IBuilder _builder;
        //private readonly IGamerConsoleInput _consoleInput;
        //private readonly IGamerConsoleOutput _consoleOutput;
        //private readonly OopSolwer _solwer;

        //public OopRunnerTests()
        //{
        //    _input = Substitute.For<IGamerConsoleInput>();
        //    _output = Substitute.For<IOopRunnerOutput>();
        //    _runner = new OopRunner(_builder, _input, _output, _gameLoader);
        //    _solwer = new OopSolwer(_input, _outputC);
        //}

        //[Fact]
        ////[InlineData _solwer]
        ////[InlineData ]

        //public void CheckIterations(/*IOopGame _solwer*/)
        //{

        //    //        _input.SelectGame().Returns(new GameInput<Game> { Input = _solwer, Option = GameInputOption.GameInput });
        //    //    IOopGame game;
        //    //    game = _builder.GetGame(_solwer);
        //    //    game.Run();
        //    //    game.Received().ShowResult(false);
        //    IOopGame game;
        //    game = _solwer;
        //    game.Run();
        //    game.Received().ShowResult(false);

        //}
    }
}
