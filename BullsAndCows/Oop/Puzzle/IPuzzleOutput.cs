namespace BullsAndCows.Oop.Puzzle
{
    public interface IPuzzleOutput
    {
        void Greating();
        void ShowEstimation(int assumption, bool isAssumptionBigger);
        void ShowResult(int number, bool isGuessed);
    }
}
