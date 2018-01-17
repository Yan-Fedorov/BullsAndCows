using System;
using System.Collections.Generic;
using System.Linq;
using BullsAndCows.Oop.OopGameLoader;

namespace BullsAndCows.Oop.GameData
{
    public interface IGameDataCached
    {
        List<string> GetGameNames();
        OopGameData Get(int id);
        void Save(OopGameData gameData);
    }

    public class GameDataCached : IGameDataCached
    {
        private readonly IGameDataService _dataService;
        private Lazy<List<OopGameData>> _games;

        public GameDataCached(IGameDataService dataService)
        {
            _dataService = dataService;
            _games = new Lazy<List<OopGameData>>(_dataService.LoadDatas);
        }

        public List<string> GetGameNames()
        {
            return _games.Value
                .Select(x => x.GetName())
                .ToList();
        }


        public OopGameData Get(int id)
        {
            return _games.Value[id];
        }


        public void Save(OopGameData gameData)
        {
            _dataService.Save(gameData);
            _games = new Lazy<List<OopGameData>>(_dataService.LoadDatas);
        }
    }
}
