using System.Threading.Tasks;
using BullsAndCows;
using BullsAndCows.Oop;
using BullsAndCows.Oop.Runner;
using BullsAndCows.Oop.GamerConsol;
using IntegrationTests.OopStubs;
using Xbehave;
using Xunit;

namespace IntegrationTests
{
    public class OopThinkerGameTest
    {
        private readonly OopInputStub _input;
        private readonly OopOutputStub _output;

        public OopThinkerGameTest()
        {
            _input = new OopInputStub();
            _output = new OopOutputStub();
        }

        [Scenario]
        public void S1()
        {
            "Given game with faked console".x(() =>
            {
                Task.Run(() =>
                {
                    new Builder(_input, _output)
                        .GetMenu()
                        .RunMainMenu();
                });
            });


            "Select Thinker game".x(() =>
            {
                _input.SendGame(new GameInput<Game> { Input = Game.Thinker, Option = GameInputOption.GameInput });
                _output.WaitThinkerGreating();
            });


            "Make game".x(() =>
            {
                var line = 500;
                var assumption = new GameInput<int> { Input = line, Option = GameInputOption.GameInput };
                ////var assumption = line;
                bool? isGuessed;
                while (true)
                {
                    _input.SendNumber(assumption);

                    var isAssumptionBigger = _output.WaitShowEstimationThinker();
                    if (isAssumptionBigger == null)
                        break;

                    line /= 2;
                    assumption.Input = isAssumptionBigger == true
                        ? assumption.Input - line
                        : assumption.Input + line;

                }


                isGuessed = _output.WaitShowResultThinker();
            });

            "Exit".x(() =>
            {
                _input.SendGame(new GameInput<Game> { Option = GameInputOption.Exit });
                _output.WaitByeBye();
            });
        }


        [Scenario]
        public void ContinueLoadedGame()
        {
            "Given game with faked console".x(() =>
            {
                Task.Run(() =>
                {
                    new Builder(_input, _output)
                        .GetMenu()
                        .RunMainMenu();
                });
            });


            "Load thinker game".x(() =>
            {
                _input.SendGame(new GameInput<Game> { Option = GameInputOption.CallGameMenu });

                var history = _output.WaitReloadGameHistory();
                Assert.Contains("Тут данные итерации", history);
            });


            "Make game".x(() =>
            {
                var n1 = new GameInput<int> { Option = GameInputOption.GameInput, Input = 200 };
                var n2 = new GameInput<int> { Option = GameInputOption.GameInput, Input = 400 };
                var n3 = new GameInput<int> { Option = GameInputOption.GameInput, Input = 300 };
                _input.SendNumber(n1);
                // ReSharper disable once PossibleInvalidOperationException
                Assert.False(_output.WaitShowEstimationThinker().Value);


                _input.SendNumber(n2);
                // ReSharper disable once PossibleInvalidOperationException
                Assert.True(_output.WaitShowEstimationThinker().Value);



                _input.SendNumber(n3);
                Assert.Null(_output.WaitShowEstimationThinker());
                Assert.True(_output.WaitShowResultThinker());
            });

            "Exit".x(() =>
            {
                _input.SendGame(new GameInput<Game> { Option = GameInputOption.Exit });
                _output.WaitByeBye();
            });

        }


        [Scenario]
        public void ExitFromGameWithoutSaving()
        {
            "Given game with faked console".x(() =>
            {
                Task.Run(() =>
                {
                    new Builder(_input, _output)
                        .GetMenu()
                        .RunMainMenu();
                });
            });


            "Select Thinker game".x(() =>
            {
                _input.SendGame(new GameInput<Game> { Input = Game.Thinker, Option = GameInputOption.GameInput });
                _output.WaitThinkerGreating();
            });


            "Make game".x(() =>
            {
                _input.SendNumber(new GameInput<int> { Option = GameInputOption.CallGameMenu });

                //TODO: отсылку в меню в игре 2-ки - выйти в главное меню без сохранения

                //дальше выбрать выход и проверить что получилось выйти
                _output.WaitByeBye();
            });

            "Exit".x(() =>
            {
                _input.SendGame(new GameInput<Game> { Option = GameInputOption.Exit });
                _output.WaitByeBye();
            });
        }
    }
}
