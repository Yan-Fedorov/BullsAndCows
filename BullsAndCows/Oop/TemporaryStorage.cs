using System;
using System.Collections.Generic;
using BullsAndCows.Oop.Solwer;


namespace BullsAndCows.Oop
{
    public interface ITemporaryStorageSolwer
    {
        void WriteSolwerConsole(List<TemporaryStorageSolwer> solwerList);
    }



    public class TemporaryStorageSolwer: ITemporaryStorageSolwer
    {
        public string YouGuessed{get; set;}
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
            for(int i = 0; i < solwerList.Count; i++)
            {
                Console.WriteLine(solwerList[i].YouGuessed);
                Console.WriteLine(solwerList[i].Varients);
                Console.WriteLine(solwerList[i].Answer);
            }
            
        }
}

}
