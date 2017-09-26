namespace BullsAndCows.Oop.Thinker
{
    public interface IThinkerOutput
    {
        void PuzzleGreating();
        void ShowEstimation(int assumption, bool isAssumptionBigger);
        void ShowResult(int number, bool isGuessed);
    }
}
