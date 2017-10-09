namespace BullsAndCows.Oop.Runner
{
    public enum GameInputOption
    {
        CallGameMenu, Exit, GameInput
    }

    public class GameInput<T>
    {
        public T Input { get; set; }
        public GameInputOption Option { get; set; }
    }
}
