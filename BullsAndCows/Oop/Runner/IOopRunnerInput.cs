namespace BullsAndCows.Oop.Runner
{
    public interface IOopRunnerInput
    {
        GameInput<Game> SelectGame();
        void PressAnyKey();
    }
}
