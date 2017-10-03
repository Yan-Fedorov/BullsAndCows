namespace BullsAndCows.Oop.Thinker
{
    public interface IThinkerOutput
    {
        void ThinkerGreating();
        void ShowEstimationThinker(int assumption, bool isAssumptionBigger);
        void ShowResultThinker(int number, bool isGuessed);
    }
}
