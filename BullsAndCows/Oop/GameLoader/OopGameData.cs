namespace BullsAndCows.Oop.GameLoader
{
    public class OopGameData
    {
        public int Iteration { get; set; }
        public string GameScreen { get; set; }

        public string GameName { get; set; }

        public string GetName()
        {
            return $"{GameName}: {GetType().Name} - {Iteration}";
        }
    }
}
