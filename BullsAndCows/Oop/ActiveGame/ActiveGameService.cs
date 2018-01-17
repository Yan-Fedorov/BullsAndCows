namespace BullsAndCows.Oop.ActiveGame
{
    public class ActiveGameService : IActiveGameProvider, IActiveGameStore
    {
        private IOopGame _game;

        public IOopGame GetGame()
        {
            return _game;
        }

        public void StoreGame(IOopGame oopGame)
        {
            _game = oopGame;
        }
    }
}
