using System;
using System.Collections.Generic;
using System.Text;
using BullsAndCows.Oop.GameLoader;
using BullsAndCows.Oop.Solwer;


namespace BullsAndCows.Oop
{
    public interface ITemporaryStorage
    {
        void Clear(string oldHistory = null);
        string GetCurrentHistory();
    }

    public class TemporaryStorage : IConsoleHistorySaver, ITemporaryStorage
    {
        private readonly StringBuilder _builder = new StringBuilder();


        public void SaveGameHistory(string message)
        {
            _builder.Append(message);
        }


        public void Clear(string oldHistory = null)
        {
            _builder.Clear();

            if (oldHistory != null)
                _builder.Append(oldHistory);
        }

        public string GetCurrentHistory()
        {
            return _builder.ToString();
        }
    }


    public interface ITemporaryStorageSolwer
    {
        void WriteSolwerConsole(List<TemporaryStorageSolwer> solwerList);
    }



    public class TemporaryStorageSolwer : ITemporaryStorageSolwer
    {
        public string YouGuessed { get; set; }
        public string Varients { get; set; }
        public OopEstimation Answer { get; set; }

        public TemporaryStorageSolwer(string youGuessed, string varients, OopEstimation answer)
        {
            YouGuessed = youGuessed;
            Varients = varients;
            Answer = answer;
        }
        public TemporaryStorageSolwer()
        {

        }

        public void WriteSolwerConsole(List<TemporaryStorageSolwer> solwerList)
        {
            for (int i = 0; i < solwerList.Count; i++)
            {
                Console.WriteLine(solwerList[i].YouGuessed);
                Console.WriteLine(solwerList[i].Varients);
                Console.WriteLine(solwerList[i].Answer);
            }

        }
    }

}
