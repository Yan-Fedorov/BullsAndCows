using System.Threading.Tasks;
using BullsAndCows;
using BullsAndCows.Oop;
using BullsAndCows.Oop.Runner;
using BullsAndCows.Oop.Thinker;
using IntegrationTests.OopStubs;
using Xbehave;
using Xunit;
using BullsAndCows.Oop.GameLoader;

namespace IntegrationTests
{
    public class OopGameLoaderTest
    {
        private readonly OopInputStub _input;
        private readonly OopOutputStub _output;
        private readonly IGame _game;


        public OopGameLoaderTest()
        {
            _input = new OopInputStub();
            _output = new OopOutputStub();
        }

        [Scenario]
        public void S1()
        {
            "Loading game".x(() =>
            {
                Task.Run(() =>
                {
                    new GameLoader().Load(_game,_output);
                        
                });
            });
        }

    }
}
