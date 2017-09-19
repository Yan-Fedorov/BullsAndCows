namespace BullsAndCows.Oop.Puzzle
{
    public interface IPuzzleOutput
    {
        void PuzzleGreating();
        void ShowEstimation(int assumption, bool isAssumptionBigger);
        void ShowResult(int number, bool isGuessed);
    }
}
