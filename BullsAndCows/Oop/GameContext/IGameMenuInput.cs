using BullsAndCows.Oop.GamerConsol;

namespace BullsAndCows.Oop.GameContext
{
    public interface IGameMenuInput
    {
        void PressAnyKey();
        GamerConsoleInput.Save GetGameMenuOption();
        string GetSaveGameName();
    }
}
