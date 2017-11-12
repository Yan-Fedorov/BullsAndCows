namespace BullsAndCows.Oop.GameLoader
{
    public interface IOopGameData
    {

    }
    public class OopGameData : IOopGameData
    {
        public int Iteration { get; set; }
        public string GameScreen { get; set; }

        public string GameName { get; set; }
        public string GameType { get; set; }

        public string GetName()
        {
            return $"{GameName}: {GetType().Name} - {Iteration}";
        }
        //public OopGameData(int iteration, string gameScreen, string gameName)
        //{
        //    Iteration = iteration;
        //    GameScreen = gameScreen;
        //    GameName = GameName;
        //}

        //public OopGameData()
        //{

        //}
    }
}
