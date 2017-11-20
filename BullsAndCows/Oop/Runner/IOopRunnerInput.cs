namespace BullsAndCows.Oop.Runner
{
    public interface IOopRunnerInput
    {
        GameInput<Game> SelectGame();
        GameInput<Game> SelectSolwerGame();
        void PressAnyKey();
    }
}
