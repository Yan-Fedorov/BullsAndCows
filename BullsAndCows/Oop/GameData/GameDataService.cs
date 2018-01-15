using System.Collections.Generic;
using System.IO;
using System.Linq;
using BullsAndCows.Oop.OopGameLoader;
using BullsAndCows.Oop.Solwer;
using BullsAndCows.Oop.Thinker;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BullsAndCows.Oop.GameData
{
    public interface IGameDataService
    {
        List<OopGameData> LoadDatas();
        void Save(OopGameData gameData);
    }

    public class GameDataService : IGameDataService
    {
        private readonly string _path;


        public GameDataService()
        {
            var localPath = Path.GetDirectoryName(GetType().Assembly.Location);
            _path = Path.Combine(localPath, @"Oop\GameData.json");
        }

        public List<OopGameData> LoadDatas()
        {
            // проверить существует ли файл
            if (!File.Exists(_path))
                return new List<OopGameData>();


            using (var file = File.OpenText(_path))
            {
                var data = file.ReadToEnd();
                var jObject = JArray.Parse(data);
                return jObject.Select(x => x["GameType"].ToString() == "BullsAndCows.Oop.Thinker.OopThinkerData"
                        ? (OopGameData)x.ToObject<OopThinkerData>()
                        : (OopGameData)x.ToObject<OopSolwerData>())
                    .ToList();
            }

            // файла нет - создать, игр нет - написать что нет
            //var list = new List<OopGameData>();
            //list.Add(new OopGameData() { GameName = "Игр не найдено", GameType = "Что бы загрузить сохраненную игру, нужно сначала её сохранить" });
            //return list;
        }

        public void Save(OopGameData gameData)
        {
            var games = LoadDatas();
            games.Add(gameData);

            //var jq = JObject.FromObject(gameData);
            //jq["tmp"] = "temp";

            using (var file = File.Open(_path, FileMode.Create))
            using (var writer = new StreamWriter(file))
            {
                writer.Write(JsonConvert.SerializeObject(games));
                writer.Flush();
            }
        }
    }
}
