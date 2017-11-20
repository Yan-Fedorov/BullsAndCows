using System.Collections.Generic;
using BullsAndCows.Oop.Runner;
using BullsAndCows.Oop.Solwer;
using NSubstitute;
using Xunit;

namespace UnitTests.Oop
{
    public class ProfessionalSolwerTests
    {
        [Fact]
        public void AllDown100()
        {
            var assumptionsList = new[] {
                500, 250, 125,
                32, 17,
                7, 6,
                4, 3,
                1 };

            var input = Substitute.For<ISolwerInput>();
            var output = Substitute.For<ISolwerOutput>();
            var proSolver = new OopSolwer(input, output);

            input.GetEstimation().Returns(x => new GameInput<OopEstimation> {Input = OopEstimation.Less, Option = GameInputOption.GameInput});

            var list = new List<int>(10);
            for (int i = 0; i < 10; i++)
            {
                list.Add(proSolver.Assumption);
                proSolver.Run();
            }

            Assert.Equal(assumptionsList, list);
        }
    }
}
